using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.EncryptTest
{
	class EncryptionTestElement : IGraphicElement
	{
		public const int WIDTH = 15;
		public const int HEIGHT = 34;

		private static Random random = new Random();

		private Label label;
		private RichTextBox textBox;

		public EncryptionTestElement(int x, int y)
		{
			label = new Label();
			label.Location = new System.Drawing.Point(x, y);
			label.BorderStyle = BorderStyle.FixedSingle;
			label.Size = new System.Drawing.Size(WIDTH, HEIGHT / 2);
			label.TabIndex = 0;
			label.Text = "";

			textBox = new RichTextBox();
			textBox.Multiline = false;
			textBox.Location = new System.Drawing.Point(x, y + 17);
			textBox.Size = new System.Drawing.Size(WIDTH, HEIGHT / 2);
			textBox.Location = new System.Drawing.Point(label.Location.X + label.Size.Width, y);
			textBox.BorderStyle = BorderStyle.FixedSingle;
			textBox.Visible = false;
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(label);
			Program.mainForm.Controls.Add(textBox);
			SetRandomValue();
		}

		public void Hide()
		{
			textBox.Visible = false;
			label.Visible = false;
		}

		public void SetRandomValue()
		{
			label.Text = random.Next(10).ToString();
		}
	}
}
