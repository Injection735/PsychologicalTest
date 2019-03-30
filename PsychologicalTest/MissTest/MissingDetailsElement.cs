using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.MissTest
{
	class MissingDetailsElement : IGraphicElement
	{
		private PictureBox picture;
		private Button acceptButton;

		public MissingDetailsElement()
		{
			picture = new PictureBox();
			acceptButton = new Button();

			picture.ImageLocation = MissingDetailsTest.GetUrls()[0];//"http://psylab.info/images/c/cc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_" + "8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_1.png";
			picture.Location = new System.Drawing.Point(144, 83);
			picture.Name = "pictureBox1";
			picture.Size = new System.Drawing.Size(100, 50);
			picture.TabIndex = 6;
			picture.TabStop = false;
			picture.Click += new System.EventHandler(OnDenied);

			acceptButton.Location = new System.Drawing.Point(334, 337);
			acceptButton.Name = "buttonNext";
			acceptButton.Size = new System.Drawing.Size(132, 23);
			acceptButton.TabIndex = 4;
			acceptButton.Text = "button1";
			acceptButton.UseVisualStyleBackColor = true;
			acceptButton.Click += new System.EventHandler(OnAccept);
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(picture);
			Program.mainForm.Controls.Add(acceptButton);
		}

		public void Hide()
		{
			acceptButton.Visible = false;
			picture.Visible = false;
		}

		public void Load()
		{
			
		}

		private void OnAccept(object sender, EventArgs e)
		{
			
		}

		private void OnDenied(object sender, EventArgs e)
		{
			
		}
	}
}
