namespace PsychologicalTest
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainTextLabel = new System.Windows.Forms.Label();
			this.answersGroup = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.buttonNext = new System.Windows.Forms.Button();
			this.errorLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.answersGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// mainTextLabel
			// 
			this.mainTextLabel.AutoSize = true;
			this.mainTextLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.mainTextLabel.Location = new System.Drawing.Point(346, 50);
			this.mainTextLabel.Name = "mainTextLabel";
			this.mainTextLabel.Size = new System.Drawing.Size(46, 17);
			this.mainTextLabel.TabIndex = 0;
			this.mainTextLabel.Text = "label1";
			this.mainTextLabel.Click += new System.EventHandler(this.label1_Click);
			// 
			// answersGroup
			// 
			this.answersGroup.Controls.Add(this.radioButton3);
			this.answersGroup.Controls.Add(this.radioButton2);
			this.answersGroup.Controls.Add(this.radioButton1);
			this.answersGroup.Location = new System.Drawing.Point(279, 173);
			this.answersGroup.Name = "answersGroup";
			this.answersGroup.Size = new System.Drawing.Size(200, 100);
			this.answersGroup.TabIndex = 3;
			this.answersGroup.TabStop = false;
			this.answersGroup.Text = "groupBox1";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(20, 73);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(110, 21);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "radioButton3";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(19, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(110, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "radioButton2";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(19, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(110, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "radioButton1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// buttonNext
			// 
			this.buttonNext.Location = new System.Drawing.Point(334, 337);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(132, 23);
			this.buttonNext.TabIndex = 4;
			this.buttonNext.Text = "button1";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.button1_Click);
			// 
			// errorLabel
			// 
			this.errorLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader;
			this.errorLabel.AutoSize = true;
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(317, 293);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(123, 17);
			this.errorLabel.TabIndex = 5;
			this.errorLabel.Text = "Не выбран ответ!";
			this.errorLabel.Click += new System.EventHandler(this.label2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.ImageLocation = "http://psylab.info/images/c/cc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_" +
    "8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_1.png";
			this.pictureBox1.Location = new System.Drawing.Point(144, 83);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 50);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.answersGroup);
			this.Controls.Add(this.mainTextLabel);
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.answersGroup.ResumeLayout(false);
			this.answersGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mainTextLabel;
		private System.Windows.Forms.GroupBox answersGroup;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Label errorLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}