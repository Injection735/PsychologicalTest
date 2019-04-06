using PsychologicalTest.EncryptTest;
using PsychologicalTest.MathTest;
using PsychologicalTest.MemTest;
using PsychologicalTest.MissTest;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PsychologicalTest
{
	public partial class MainWindow : Form
	{
		private const string BUTTON_TEXT_START = "Начать";
		private const string BUTTON_TEXT_CONTINUE = "Продолжить";
		private const string BUTTON_TEXT_END = "Закончить";

		private enum TestIteration
		{
			Login,
			Kettel,
			Mathematical,
			Memory,
			Encryption,
			MissingDetails,
			Result
		}

		private TestIteration iteration;

		private bool isKettelStarted = false;
		private bool isMathStarted = false;
		private bool isMemoryStarted = false;
		private bool isEncryptionStarted = false;
		private bool isMissingDetailsStarted = false;
		private bool showDescription = true;

		private TestTimer mathTimer;
		private MemoryTestElement memoryTestElement;

		private EncryptionLegend encryptionLegend;
		private EncryptionTestContainer encryptionContainer;

		private MissingDetailsElement missingDetailsElement;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			mainTextLabel.Text = "";
			buttonNext.Text = BUTTON_TEXT_START;
			answersGroup.Visible = false;
			answersGroup.Text = "";
			errorLabel.Visible = false;
			KettelTest.LoadTest();
			iteration = TestIteration.MissingDetails;//Kettel;
			AlignElements();
			var a = new SQLData();

			//NextIterationKettel();
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{ }

		private void label1_Click(object sender, EventArgs e)
		{ }

		private bool AddResult()
		{
			int index = 0;
			try
			{ 
				index = answersGroup.Controls.IndexOf(answersGroup.Controls.OfType<RadioButton>().First(n => n.Checked));
			}
			catch (InvalidOperationException e) 
			{
				errorLabel.Visible = true;
				return false;
			}

			KettelTest.Type type = KettelTest.questions[KettelTest.currentIterator].type;

			int points = KettelTest.questions[KettelTest.currentIterator].answers[index].points;

			KettelTest.result.AddValue(type, points);

			return true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NextIteration();
		}

		private void NextIteration()
		{
			switch (iteration)
			{
				case TestIteration.Login:
					Login();
					break;
				case TestIteration.Kettel:
					NextIterationKettel();
					break;
				case TestIteration.Mathematical:
					NextIterationMathematical();
					break;
				case TestIteration.Memory:
					NextIterationMemory();
					break;
				case TestIteration.Encryption:
					NextIterationEncryption();
					break;
				case TestIteration.MissingDetails:
					NextIterationMissingDetails();
					break;
				case TestIteration.Result:
					Result();
					break;
			}
		}

		private void Result()
		{
			ResultView view = new ResultView();
			view.AddElement();
			missingDetailsElement.Hide();
		}

		private void Login()
		{
			
		}

		private void NextIterationMissingDetails()
		{
			if (showDescription)
			{
				mainTextLabel.Visible = true;
				mainTextLabel.Text = "В следующем задании необоходимо найти логическое несоответствие на картинке(Например: отсутствие рукоятки у отвертки).\nПросто нажмите на область картинки, где вы предполагаете есть несостыковка";
				showDescription = false;
				return;
			}

			mainTextLabel.Visible = false;

			if (!isMissingDetailsStarted)
			{
				missingDetailsElement = new MissingDetailsElement(NextIterationMissingDetails, 50, 50);
				missingDetailsElement.AddElement();
				isMissingDetailsStarted = true;
				Size = new Size(600, 600);
				AlignElements();
			}

			var info = MissingDetailsTest.GetNextInfo();
			
			if (info != null)
				missingDetailsElement.Load(info);
			else
				IncreaseIterator();
		}

		private void NextIterationEncryption()
		{
			if (showDescription)
			{
				mainTextLabel.Visible = true;
				showDescription = false;
				mainTextLabel.Text = "В следующем задании необходимо сопоставить каждой цифре в таблице, свой символ.\nЗа 1.5 минуты необходимо сопоставить как можно больше символов";
				AlignElements();

				int legendCount = 10;
				int legendWidth = EncryptionLegendElement.WIDTH * legendCount;

				encryptionLegend = new EncryptionLegend(legendWidth, legendCount, (Size.Width - legendWidth) / 2, 80);
				encryptionLegend.AddElement();
				Size = new Size(600, 500);
				AlignElements();
				return;
			}
			
			if (!isEncryptionStarted)
			{
				int encryptionCount = 100;
				int encryptionWidth = 500;

				encryptionContainer = new EncryptionTestContainer(OnEncryptionOver, encryptionWidth, encryptionCount, (Size.Width - encryptionWidth) / 2, 160);
				encryptionContainer.AddElement();

				isEncryptionStarted = true;
			}
		}

		private void OnEncryptionOver()
		{
			HideEncryption();
			IncreaseIterator();
		}

		private void NextIterationMemory()
		{
			if (showDescription)
			{
				mainTextLabel.Visible = true;
				showDescription = false;
				mainTextLabel.Text = "Следующее задание - проверка на память.\nСначала вам будет дано 3 секунды для того чтобы запомнить ряд цифр. А затем нужно ввести ряд обратный изначальному(цифры пишутся через пробел).\nПример: ряд (8 9 4 3)\nОтвет: (3 4 9 8)";
				AlignElements();	
				return;
			}

			mainTextLabel.Visible = false;

			if (!isMemoryStarted)
			{
				memoryTestElement = new MemoryTestElement(100, 100);
				memoryTestElement.AddElement();
				isMemoryStarted = true;
				memoryTestElement.NextElementIteration();
				memoryTestElement.AlignByX(Size.Width);
				return;
			}

			if (!memoryTestElement.isAnswering)
				return;

			if (MemoryTest.CanBeContinued(memoryTestElement.GetAnswer()))
				memoryTestElement.NextElementIteration();
			else 
			{
				mainTextLabel.Visible = false;
				IncreaseIterator();
			}
		}

		private void NextIterationMathematical()
		{
			if (showDescription)
			{
				mainTextLabel.Visible = true;
				mainTextLabel.Text = "Следующие вопросы являются математическими задачами\nЗа отведенное время вам нужно решить как можно больше задач\nПо истечении времени программа перейдет к следующему тесту\nПример:\nСначала Васе дали 3 копейки, а потом 1 рубль. Сколько у Васи осталось денег?(в рублях)\nОтвет: 1.03 или 1,03";

				showDescription = false;
				AlignElements();
				return;
			}

			mainTextLabel.Visible = false;

			if (!isMathStarted)
			{
				int x = 20;
				int y = 20;

				mathTimer = new TestTimer(IncreaseIterator, 120, 200, 0);
				mathTimer.Start();
				mathTimer.AddElement();

				foreach(MathTestQuestion question in MathematicalTest.questions)
				{
					TestControlElement element = new TestControlElement(question.description, question.answer, x, y);
					MathematicalTest.visualElements.Add(element);
					element.AddElement();
					y += element.height + 20;
				}

				Size = new Size(900, 600); 
				AlignElements();
				isMathStarted = true;
			}
			else
			{
				foreach(TestControlElement element in MathematicalTest.visualElements)
					MathematicalTest.answers.Add(element.GetCurrentAnswer());
				
				IncreaseIterator();
			}
		}

		private void IncreaseIterator()
		{
			showDescription = true;
			HideCurrent();
			iteration = (TestIteration) ((int) iteration + 1);
			NextIteration();
		}

		private void NextIterationKettel()
		{
			if (isKettelStarted)
			{
				bool isSuccess = AddResult();

				if (!isSuccess)
					return;
			}

			if (showDescription)
			{
				mainTextLabel.Text = "Вам предлагается ответить на ряд вопросов, цель которых – выяснить ваши когнитивные навыки" + 
				"\n\n	1. Не нужно тратить много времени на обдумывание ответов.\nДавайте тот ответ, который первым придет Вам в голову.\nКонечно, вопросы часто будут сформулированы не так подробно, как Вам хотелось бы.\nВ таком случае старайтесь представить себе «среднюю»,\nнаиболее частую ситуацию, которая соответствует смыслу вопроса и, исходя из этого, выбирайте ответ.\nОтвечать надо как можно точнее, но не слишком медленно." + 
				"\n\n	2. Старайтесь не прибегать к промежуточным, неопределенным ответам\n(типа «не знаю», «нечто среднее» и т.п.) слишком часто." + 
				"\n\n	3. Некоторые вопросы могут показаться Вам личными,\nно Вы можете быть уверены в том, что ответы не будут разглашены.\nПричем ответы на каждый отдельный вопрос вообще не будут рассматриваться:\nнас интересуют только обобщенные показатели." + 
				"\n\n	4. Не старайтесь произвести хорошее впечатление своими ответами, они должны соответствовать действительности.\nЗаранее благодарим Вас за помощь в отработке методики.";
				showDescription = false;
				AlignElements();
				return;
			}

			isKettelStarted = true;

			if (buttonNext.Text == BUTTON_TEXT_START)
				buttonNext.Text = BUTTON_TEXT_CONTINUE;

			answersGroup.Visible = true;

			KettelTestQuestion question = KettelTest.GetNextQuestion();
			
			if (question == null)
			{
				IncreaseIterator();
				return;
			}

			mainTextLabel.Text = question.text;
			int questionIndex = question.answers.Count - 1;

			foreach (RadioButton button in answersGroup.Controls.OfType<RadioButton>())
			{
				if (questionIndex == 0)
				{	
					button.Checked = true;
					button.Checked = false;
				}

				button.Text = question.answers[questionIndex].name;
				questionIndex--;
			}

			errorLabel.Visible = false;
			AlignElements();
		}

		private void AlignElements()
		{
			mainTextLabel.Location = new Point((Size.Width - mainTextLabel.Width) / 2, 50);
			answersGroup.Location = new Point((Size.Width - answersGroup.Width) / 2, 173);
			buttonNext.Location = new Point((Size.Width - buttonNext.Width) / 2, Size.Height - 70);
		}

		private void HideCurrent()
		{
			switch (iteration)
			{
				case TestIteration.Kettel:
					HideKettel();
					break;
				case TestIteration.Mathematical:
					HideMathematical();
					break;
				case TestIteration.Memory:
					HideMemory();
					break;
				case TestIteration.Encryption:
					HideEncryption();
					break;
				case TestIteration.MissingDetails:
					HideMissingDetails();
					break;
			}
		}

		private void HideKettel()
		{
			answersGroup.Visible = false;
		}

		private void HideMathematical()
		{
			mathTimer.Hide();

			foreach (TestControlElement element in MathematicalTest.visualElements)
				element.Hide();
		}

		private void HideMemory()
		{
			memoryTestElement.Hide();
		}

		private void HideEncryption()
		{
			encryptionLegend.Hide();
			encryptionContainer.Hide();
		}

		private void HideMissingDetails()
		{
			missingDetailsElement.Hide();
		}

		private void label2_Click(object sender, EventArgs e)
		{ }

		private void progressBar1_Click(object sender, EventArgs e)
		{ }

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{ }
	}
}
