using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.EncryptTest
{
	class EncryptionLegendElement : IGraphicElement
	{
		public const int WIDTH = 20;
		public const int HEIGHT = 40;

		private Label labelInfo;
		private Label labelAnswer;
		public EncryptionLegendElement(string info, string answer, int x, int y)
		{
			labelInfo = new Label();
			labelInfo.Location = new System.Drawing.Point(x, y);
			labelInfo.BorderStyle = BorderStyle.FixedSingle;
			labelInfo.Size = new System.Drawing.Size(WIDTH, HEIGHT / 2);
			labelInfo.TabIndex = 0;
			labelInfo.Text = info;

			labelAnswer = new Label();
			labelAnswer.Location = new System.Drawing.Point(x, y + HEIGHT / 2);
			labelAnswer.BorderStyle = BorderStyle.FixedSingle;
			labelAnswer.Size = new System.Drawing.Size(WIDTH, HEIGHT / 2);
			labelAnswer.TabIndex = 0;
			labelAnswer.Text = answer;
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(labelInfo);
			Program.mainForm.Controls.Add(labelAnswer);
		}

		public void Hide()
		{
			labelInfo.Visible= false;
			labelAnswer.Visible= false;
		}

		public void Remove()
		{
			throw new NotImplementedException();
		}
	}
}
