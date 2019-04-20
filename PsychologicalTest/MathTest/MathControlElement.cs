using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.MathTest
{
	class MathControlElement : IGraphicElement
	{
		private static Random random = new Random();

		private Label label;
		private RichTextBox textBox;

		public MathControlElement(string text, double answer, int x, int y)
		{
			label = new Label();
			label.AutoSize = true;
			label.Location = new System.Drawing.Point(x, y);
			label.TabIndex = 0;
			label.Text = text;

			textBox = new RichTextBox();
			textBox.Multiline = false;
			textBox.Size = new System.Drawing.Size(46, 17);
			textBox.Location = new System.Drawing.Point(label.Location.X + label.Size.Width, y);
		}

		public void Hide()
		{
			textBox.Visible = false;
			label.Visible = false;
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(label);
			Program.mainForm.Controls.Add(textBox);
			textBox.Location = new System.Drawing.Point(label.Location.X + label.Size.Width, label.Location.Y);
		}

		public double GetCurrentAnswer()
		{
			if (textBox.Text == "")
				return -1;
			
			string text = textBox.Text.Replace('.', ',');
			double result = Convert.ToDouble(text);
			
			return result;
		}

		public void Remove()
		{
			throw new NotImplementedException();
		}

		public int height => label.Height;
	}
}
