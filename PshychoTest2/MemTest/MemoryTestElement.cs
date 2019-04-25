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
		private Label label;
		private TestTimer timer;
		private RichTextBox textBox;

		public bool isAnswering = true;

		public MemoryTestElement(int x, int y)
		{
			label = new Label();
			label.AutoSize = true;
			label.Location = new System.Drawing.Point(x, y);
			label.TabIndex = 0;
			label.Text = "";

			timer = new TestTimer(NextElementIteration, 3, label.Location.X + label.Width / 2, y + 30);

			textBox = new RichTextBox();
			textBox.Multiline = false;
			textBox.Size = new System.Drawing.Size(90, 17);
			textBox.Visible = false;
		}

		public void AlignByX(int parentWidth)
		{
			label.Location = new System.Drawing.Point((parentWidth - label.Size.Width) / 2, label.Location.Y);
			textBox.Location = new System.Drawing.Point((parentWidth - textBox.Size.Width) / 2, label.Location.Y);
			timer.x = (parentWidth - timer.width) / 2;
		}

		public void NextElementIteration()
		{
			isAnswering = !isAnswering;

			timer.Stop();
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

		public string GetAnswer() => textBox.Text.Replace(" ", "");

		public void Remove()
		{
			throw new NotImplementedException();
		}
	}
}
