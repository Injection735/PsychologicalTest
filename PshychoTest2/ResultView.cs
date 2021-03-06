﻿using PsychologicalTest.EncryptTest;
using PsychologicalTest.MemTest;
using PsychologicalTest.MissTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest
{
	class ResultView : IGraphicElement
	{
		private const int LABEL_COUNT = 6;
		private List<Label> labelList = new List<Label>();

		private Label userNameLabel;
		private Label kettelLabel;
		private Label mathLabel;
		private Label memoryLabel;
		private Label encryptionLabel;
		private Label missLabel;

		public ResultView()
		{
			userNameLabel = new Label();
			userNameLabel.AutoSize = true;
			userNameLabel.Text = "Спасибо за уделенное время!";
			userNameLabel.TabIndex = 0;
			Program.mainForm.Controls.Add(userNameLabel);
			userNameLabel.Location = new System.Drawing.Point((Program.mainForm.Size.Width - userNameLabel.Size.Width) / 2, 50);

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

			int x = 0, y = 70;

			userNameLabel.Text = SQLData.user_name;
			kettelLabel.MaximumSize = new System.Drawing.Size(650, 1000);
			kettelLabel.Text = 
			"Результат по фактору " + KettelTest.Type.B.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.B) + "\n" + BriefDescription.GetDescription(KettelTest.Type.B) + "\n" +
			"Результат по фактору " + KettelTest.Type.Q1.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q1) + "\n" + BriefDescription.GetDescription(KettelTest.Type.Q1) + "\n" +
			"Результат по фактору " + KettelTest.Type.Q3.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q3) + "\n" + BriefDescription.GetDescription(KettelTest.Type.Q2) + "\n" +
			"Результат по фактору " + KettelTest.Type.Q4.ToString() + " " + KettelTest.GetAnswer(KettelTest.Type.Q4) + "\n" + BriefDescription.GetDescription(KettelTest.Type.Q4) + "\n";

			mathLabel.Text = "Результат по арифметической части " + MathematicalTest.GetAnswer() + "/" + MathematicalTest.questions.Count; //+ " бонусное время : " + MathematicalTest.GetBonusTime();
			memoryLabel.Text = "Результат по тесту \"Ряды\"" + MemoryTest.GetAnswer().ToString() + " запомненых цифр";
			encryptionLabel.Text = "Результат по тесту \"Шифрование\"" + EncryptionTest.answersCount.ToString() + " правильных расшифровок";
			missLabel.Text = "Результат по тесту \"Недостащие детали\"" + MissingDetailsTest.GetAnswer().ToString() + "/" + MissingDetailsTest.GetInfo().Count;

			for (int i = 0; i < LABEL_COUNT; i++)
			{
				labelList[i].AutoSize = true;
				labelList[i].Location = new Point(x, y);
				labelList[i].TabIndex = 0;
				y += 40;

				if (i == 1)
					y += 200;
			}

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

		public void Remove()
		{
			throw new NotImplementedException();
		}
	}
}
