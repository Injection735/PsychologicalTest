using PsychologicalTest.MathTest;
using PsychologicalTest.MemTest;
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
			Kettel,
			Mathematical,
			Memory,
			Encryption,
			MissingDetails
		}

		private TestIteration iteration;

		private bool isKettelStarted = false;
		private bool isMathStarted = false;
		private bool isMemoryStarted = false;
		private bool isEncryptionStarted = false;
		private bool isMissingDetailsStarted = false;

		private TestTimer mathTimer;
		private MemoryTestElement memoryTestElement;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			mainTextLabel.Text = "ppffffppp";
			buttonNext.Text = BUTTON_TEXT_START;
			answersGroup.Visible = false;
			answersGroup.Text = "";
			errorLabel.Visible = false;
			KettelTest.LoadTest();
			iteration = TestIteration.Memory; //Kettel;
			AlignElements();
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
			switch (iteration)
			{
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
				
				break;
				case TestIteration.MissingDetails:
				
				break;
			}
		}

		private void NextIterationMemory()
		{
			if (!isMemoryStarted)
			{
				memoryTestElement = new MemoryTestElement(100, 100);
				memoryTestElement.AddElement();
				isMemoryStarted = true;
				memoryTestElement.NextElementIteration();
				return;
			}

			if (MemoryTest.CanBeContinued(memoryTestElement.GetAnswer()))
				memoryTestElement.NextElementIteration();
			else 
				IncreaseIterator();
		}

		private void NextIterationMathematical()
		{
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
				
				ClearMath();
				IncreaseIterator();
			}
		}

		private void ClearMath()
		{
			mathTimer.Hide();

			foreach (TestControlElement element in MathematicalTest.visualElements)
				element.Hide();
		}

		private void IncreaseIterator() => iteration = (TestIteration) ((int) iteration + 1);

		private void NextIterationKettel()
		{
			if (isKettelStarted)
			{
				bool isSuccess = AddResult();

				if (!isSuccess)
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

		private void label2_Click(object sender, EventArgs e)
		{ }

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
