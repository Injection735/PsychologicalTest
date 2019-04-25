using PsychologicalTest.EncryptTest;
using PsychologicalTest.MathTest;
using PsychologicalTest.MemTest;
using PsychologicalTest.MissTest;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
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
		
		private bool isLoginStarted = false;
		private bool isKettelStarted = false;
		private bool isMathStarted = false;
		private bool isMemoryStarted = false;
		private bool isEncryptionStarted = false;
		private bool isMissingDetailsStarted = false;
		private bool isEnded = false;
		private bool showDescription = true;

		private TestTimer mathTimer;
		private MemoryTestElement memoryTestElement;

		private EncryptionLegend encryptionLegend;
		private EncryptionTestContainer encryptionContainer;

		private MissingDetailsElement missingDetailsElement;

		private Label loginLabel;
		private TextBox loginTextBox;

		private Timer kettelTimer;
		private Timer missTimer;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			mainTextLabel.Text = "";
			buttonNext.Text = BUTTON_TEXT_CONTINUE;
			answersGroup.Visible = false;
			answersGroup.Text = "";
			errorLabel.Visible = false;
			KettelTest.LoadTest();
			iteration = TestIteration.Mathematical; //Login
			AlignElements();

			NextIteration();
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
			catch (InvalidOperationException) 
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
				//case TestIteration.Memory:
				//	NextIterationMemory();
				//	break;
				//case TestIteration.Encryption:
				//	NextIterationEncryption();
				//	break;
				//case TestIteration.MissingDetails:
				//	NextIterationMissingDetails();
				//	break;
				case TestIteration.Result:
					Result();
					break;
				default:
					IncreaseIterator();
					break;
			}
		}

		private void Result()
		{
			if (isEnded)
			{	
				Close();
				return;
			}

			isEnded = true;

			SQLData.Q1 = KettelTest.GetAnswer(KettelTest.Type.Q1);
			SQLData.B = KettelTest.GetAnswer(KettelTest.Type.B);
			SQLData.Q3 = KettelTest.GetAnswer(KettelTest.Type.Q3);
			SQLData.Q4 = KettelTest.GetAnswer(KettelTest.Type.Q4);
			SQLData.math_result = MathematicalTest.GetAnswer();
			SQLData.math_time = MathematicalTest.GetBonusTime();
			SQLData.memory_count = MemoryTest.GetAnswer();
			SQLData.encryption_count = EncryptionTest.answersCount;
			SQLData.miss_count = MissingDetailsTest.GetAnswer();

			SQLScripts.SetAnswers();
			SQLScripts.RemoveUser();
			this.Size = new Size(900, 700);

			ResultView view = new ResultView();
			view.AddElement();
			view.AlignX();
			missingDetailsElement?.Hide();
			AlignElements();
		}

		private void Login()
		{
			if (!isLoginStarted)
			{
				loginLabel = new Label();
				loginLabel.Text = "Введите номер данный вам преподавателем";
				loginLabel.AutoSize = true;
				Controls.Add(loginLabel);
				loginLabel.Location = new Point((Size.Width - loginLabel.Width) / 2, 40);

				loginTextBox = new TextBox();
				Controls.Add(loginTextBox);
				loginTextBox.Size = new Size(180, 17);
				loginTextBox.Location = new Point((Size.Width - loginTextBox.Width) / 2, 80);
				isLoginStarted = true;
			}
			else
			{
				if (SQLScripts.VerifyUser(loginTextBox.Text.ToLower()))
				{
					errorLabel.Visible = false;

					SQLData.user_name = loginTextBox.Text;
					IncreaseIterator();
				}
				else
				{
					errorLabel.Visible = true;
					errorLabel.Text = "Такого пользователя не существует!";
					errorLabel.Location = new Point((Size.Width - errorLabel.Size.Width) / 2, errorLabel.Location.Y);
				}
			}
		}
		private PictureBox pic;
		private void NextIterationMissingDetails()
		{
			Size = new Size(600, 600);

			if (showDescription)
			{
				mainTextLabel.Visible = true;
				mainTextLabel.Text = "В следующем задании необоходимо найти логическое несоответствие на картинке(Например: отсутствие рукоятки у отвертки).\nПросто нажмите на область картинки, где вы предполагаете есть несостыковка";
				pic = new PictureBox();
				pic.Location = new Point(50, mainTextLabel.Location.Y + 20);
				pic.ImageLocation = @"https://i.ibb.co/48pqN2g/Screenshot-1.png";
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				pic.Size = new System.Drawing.Size(500, 500);
				this.Controls.Add(pic);
				showDescription = false;
				AlignElements();
				return;
			}
			pic.Visible = false;
			mainTextLabel.Visible = false;

			if (!isMissingDetailsStarted)
			{
				missTimer = new Timer();
				missTimer.Tick += onMissTimer;
				missTimer.Enabled = true;
				missTimer.Interval = 1000;
				missTimer.Start();

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
			{
				missTimer.Stop();
				missingDetailsElement.Stop();
				IncreaseIterator();
			}
		}

		private void NextIterationEncryption()
		{
			if (showDescription)
			{
				Size = new Size(600, 500);
				mainTextLabel.Visible = true;
				showDescription = false;
				mainTextLabel.Text = "В следующем задании необходимо сопоставить каждой цифре в таблице, свой символ.\nЗа 1.5 минуты необходимо сопоставить как можно больше символов";
				AlignElements();

				int legendCount = 10;
				int legendWidth = EncryptionLegendElement.WIDTH * legendCount;

				encryptionLegend = new EncryptionLegend(legendWidth, legendCount, (Size.Width - legendWidth) / 2, 80);
				encryptionLegend.AddElement();
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
			encryptionContainer.AcceptAnswers();
			HideEncryption();
			IncreaseIterator();
		}

		private void NextIterationMemory()
		{
			if (showDescription)
			{
				mainTextLabel.Visible = true;
				showDescription = false;
				mainTextLabel.Text = "Следующее задание - проверка на память.\nСначала вам будет дано 3 секунды для того чтобы запомнить ряд цифр. А затем нужно ввести ряд В ОБРАТНОМ ПОРЯДКЕ БЕЗ ПРОБЕЛОВ.\nПример: ряд (8 9 4 3)\nОтвет: (3498)";
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

				mathTimer = new TestTimer(NextIterationMathematical, 120, 200, 0);
				mathTimer.Start();
				mathTimer.AddElement();

				foreach(MathTestQuestion question in MathematicalTest.questions)
				{
					MathControlElement element = new MathControlElement(question.description, question.answer, x, y);
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
				SQLData.math_time = mathTimer.currentSeconds;
				mathTimer.Stop();

				foreach(MathControlElement element in MathematicalTest.visualElements)
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
			loginLabel.Visible = false;
			loginTextBox.Visible = false;

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

			if (!isKettelStarted)
			{ 
				kettelTimer = new Timer();
				kettelTimer.Tick += onKettelTimer;
				kettelTimer.Enabled = true;
				kettelTimer.Interval = 1000;
				kettelTimer.Start();
			}

			isKettelStarted = true;

			if (buttonNext.Text == BUTTON_TEXT_START)
				buttonNext.Text = BUTTON_TEXT_CONTINUE;

			answersGroup.Visible = true;

			KettelTestQuestion question = KettelTest.GetNextQuestion();
			
			if (question == null)
			{
				kettelTimer.Stop();
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

		private void onKettelTimer(object sender, EventArgs e)
		{
			SQLData.kettel_time++;
		}

		private void onMissTimer(object sender, EventArgs e)
		{
			SQLData.miss_time++;
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

			foreach (MathControlElement element in MathematicalTest.visualElements)
				element.Hide();
		}

		private void HideMemory()
		{
			memoryTestElement?.Hide();
		}

		private void HideEncryption()
		{
			encryptionLegend?.Hide();
			encryptionContainer?.Hide();
		}

		private void HideMissingDetails()
		{
			missingDetailsElement?.Hide();
		}

		private void label2_Click(object sender, EventArgs e)
		{ }

		private void progressBar1_Click(object sender, EventArgs e)
		{ }

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{ }
	}
}
