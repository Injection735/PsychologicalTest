using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychologicalTest
{
	class TestTimer : IGraphicElement
	{
		private Action callback;
		private Timer timer;
		private int totalSeconds;
		private int currentSeconds = 0;
		private Label timerLabel;
		private static int timerCounter = 0;

		public TestTimer(Action callback, int seconds, int x, int y)
		{
			this.callback = callback;

			timer = new Timer();
			timer.Tick += Update;
			timer.Enabled = true;
			timer.Interval = 1000;

			timerLabel = new Label();
			timerLabel.AutoSize = true;
			timerLabel.Location = new System.Drawing.Point(x, y);
			timerLabel.Size = new System.Drawing.Size(46, 17);
			timerLabel.TabIndex = 0;

			totalSeconds = seconds;
			timerCounter++;

			Update(null, null);
		}

		public int x
		{
			get => timerLabel.Location.X;
			set => timerLabel.Location = new System.Drawing.Point(value, timerLabel.Location.Y);
		}

		public int width
		{
			get => timerLabel.Size.Width;
		}

		public void Start()
		{
			currentSeconds = 0;
			timer.Stop();
			timer.Start();
		}

		public void Stop()
		{
			timer.Stop();
		}

		public void Hide()
		{
			timerLabel.Visible = false;
			timer.Stop();
			timer.Dispose();
		}

		private void Update(object sender, EventArgs e)
		{
			if (currentSeconds >= totalSeconds)
			{
				timer.Stop();
				callback.Invoke();
			}

			timerLabel.Text = GetCurrentTime();
			currentSeconds++;
		}

		private string GetCurrentTime()
		{ 
			string result = "";
			int minutes = (totalSeconds - currentSeconds) / 60;

			if (minutes < 10)
				result += "0";
			
			result += minutes.ToString();
			result += ":";
			int seconds = (totalSeconds - currentSeconds) % 60;

			if (seconds < 10)
				result += "0";

			result += seconds;

			return result;
		}

		public void AddElement()
		{
			Program.mainForm.Controls.Add(timerLabel);	
		}

		public void Remove()
		{
			throw new NotImplementedException();
		}

		public bool Visible
		{
			get => timerLabel.Visible;
			set => timerLabel.Visible = value;
		}
	}
}
