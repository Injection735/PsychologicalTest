using PsychologicalTest.EncryptTest;
using PsychologicalTest.MemTest;
using PsychologicalTest.MissTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest
{
	class ResultView : IGraphicElement
	{
		private const int LABEL_COUNT = 6;
		private List<Label> labelList;

		private Label userNameLabel;
		private Label kettelLabel;
		private Label mathLabel;
		private Label memoryLabel;
		private Label encryptionLabel;
		private Label missLabel;

		public ResultView()
		{
			userNameLabel = new Label();
			kettelLabel = new Label();
			mathLabel = new Label();
			memoryLabel = new Label();
			encryptionLabel = new Label();
			missLabel = new Label();

			labelList = new List<Label>()
			{
				userNameLabel,
				kettelLabel,
				mathLabel,
				memoryLabel,
				encryptionLabel,
				missLabel
			};

			int x = 0, y = 0;

			for (int i = 0; i < LABEL_COUNT; i++)
			{
				labelList[i].AutoSize = true;
				labelList[i].Location = new System.Drawing.Point(x, y);
				labelList[i].TabIndex = 0;
				y += 30;
			}

			userNameLabel.Text = "ff";
			kettelLabel.Text = 
			KettelTest.Type.B.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.B) + "\n" +
			KettelTest.Type.Q1.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q1) + "\n" +
			KettelTest.Type.Q3.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q3) + "\n" +
			KettelTest.Type.Q4.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q4);

			mathLabel.Text = MathematicalTest.GetAnswer() + " : " + MathematicalTest.GetBonusTime();
			memoryLabel.Text = MemoryTest.GetAnswer();
			encryptionLabel.Text = EncryptionTest.answersCount.ToString();
			missLabel.Text = MissingDetailsTest.GetAnswer();
			AlignX();
		}

		public void AlignX()
		{
			foreach (Label label in labelList)
				label.Location = new System.Drawing.Point((Program.mainForm.Size.Width - label.Size.Width) / 2, label.Location.Y);
		}

		public void AddElement()
		{
			foreach (Label label in labelList)
				Program.mainForm.Controls.Add(label);
		}

		public void Hide()
		{
			foreach (Label label in labelList)
				label.Visible = false;
		}
	}
}
