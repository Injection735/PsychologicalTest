using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest.MissTest
{
	class MissingDetailsElement : IGraphicElement
	{
		private PictureBox picture;
		private Label labelButton;
		private TestTimer timer;

		private Action next;

		public MissingDetailsElement(Action next, int x, int y)
		{
			this.next = next;
			picture = new PictureBox();
			labelButton = new Label();
			timer = new TestTimer(OnTimer, 15, 240, y);

			picture.ImageLocation = MissingDetailsTest.GetInfo()[0].url;//"http://psylab.info/images/c/cc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_" + "8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_1.png";
			picture.SizeMode = PictureBoxSizeMode.StretchImage;
			picture.Location = new System.Drawing.Point(x, y);
			picture.Size = new System.Drawing.Size(500, 500);
			picture.TabIndex = 6;
			picture.TabStop = false;
			picture.Click += new System.EventHandler(OnDenied);
			picture.LoadCompleted += LoadComplete; 

			labelButton.Location = new System.Drawing.Point(334 - x, 337 + y);
			labelButton.Size = new System.Drawing.Size(30, 30);
			labelButton.TabIndex = 4;
			labelButton.Text = "";
			labelButton.TabStop = false;
			labelButton.FlatStyle = FlatStyle.Flat;
			labelButton.BackColor = Color.Red;

			labelButton.Click += new System.EventHandler(OnAccept);
		}

		private void LoadComplete(Object sender, AsyncCompletedEventArgs e) => timer.Start();

		public void AddElement()
		{
			timer.AddElement();

			Program.mainForm.Controls.Add(labelButton);
			Program.mainForm.Controls.Add(picture);
		}

		public void Hide()
		{
			labelButton.Visible = false;
			picture.Visible = false;
			timer.Visible = false;
		}

		public void Load(MissingDetailsElementInfo info)
		{
			picture.ImageLocation = info.url;
			labelButton.Location = new Point(info.point.X - 50, info.point.Y - 50);
			labelButton.Size = info.size;
			labelButton.Parent = picture;
			labelButton.BackColor = Color.Transparent;
		}
		public void Stop()
		{
			this.timer.Stop();
		}

		public void Remove()
		{
			throw new NotImplementedException();
		}

		private void OnAccept(object sender, EventArgs e)
		{
			next.Invoke();
			MissingDetailsTest.rightAnswersCount++;
		}

		private void OnDenied(object sender = null, EventArgs e = null)
		{
			next.Invoke();
		}

		private void OnTimer()
		{
			next.Invoke();
		}
	}
}
