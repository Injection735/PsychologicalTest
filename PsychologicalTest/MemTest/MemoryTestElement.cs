using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.MemTest
{
	class MemoryTestElement : IGraphicElement
	{
		private static int labelCounter = 1;

		private Label label;
		private TestTimer timer;
		private RichTextBox textBox;

		private bool isAnswering = false;

		public MemoryTestElement(int x, int y)
		{
			label = new Label();
			label.AutoSize = true;
			label.Location = new System.Drawing.Point(x, y);
			label.Name = "MemoryTestElementLabel" + labelCounter;
			label.TabIndex = 0;
			label.Text = "";

			timer = new TestTimer(NextElementIteration, 3, label.Location.X + label.Width / 2, y + 30);

			textBox = new RichTextBox();
			textBox.Multiline = false;
			textBox.Size = new System.Drawing.Size(46, 17);
			textBox.Name = "MemoryTestElementTextBox" + labelCounter;
			textBox.Location = new System.Drawing.Point(label.Location.X + label.Size.Width, y);
			textBox.Visible = false;
		}

		public void NextElementIteration()
		{
			if (!isAnswering)
			{
				label.Text = MemoryTest.GetRow();
				timer.Start();
			}

			if (isAnswering)
				textBox.Text = "";

			textBox.Visible = isAnswering;
			label.Visible = !isAnswering;
			timer.Visible = !isAnswering;
			isAnswering = !isAnswering;
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(label);
			Program.mainForm.Controls.Add(textBox);
			timer.AddElement();
		}

		public void Hide()
		{
			textBox.Visible = false;
			label.Visible = false;
			timer.Visible = false;
		}

		public string GetAnswer() => textBox.Text;
	}
}
