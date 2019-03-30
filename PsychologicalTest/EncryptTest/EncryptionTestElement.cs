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
		public const int WIDTH = 20;
		public const int HEIGHT = 40;

		private static Random random = new Random();
		private static int tabIndex = 0;

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
			textBox.TextChanged += OnTextChanged;
			textBox.Multiline = false;
			textBox.Location = new System.Drawing.Point(x, y + 17);
			textBox.Size = new System.Drawing.Size(WIDTH, HEIGHT / 2);
			textBox.BorderStyle = BorderStyle.FixedSingle;
			textBox.TabIndex = tabIndex;
			textBox.Margin = new Padding(3, 3, 3, 3);
			tabIndex++;
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
			label.Text = (random.Next(9) + 1).ToString();
		}

		private void OnTextChanged(object sender, EventArgs e)
		{
			textBox.Text = "  " + textBox.Text[0].ToString();
		}

		public int GetInfo() => int.Parse(label.Text);

		public char GetValue() => label.Text[label.Text.Length - 1];
	}
}
