
namespace Genetics
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.makewNewGenerationsAsyncWorker = new System.ComponentModel.BackgroundWorker();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.racialPurityDevalvationTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.raciaPurityImportanceCoefTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groomCountTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.groomSearchRadiusTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.birthRateTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.julianCountTextBox = new System.Windows.Forms.TextBox();
			this.aivianCountTextBox = new System.Windows.Forms.TextBox();
			this.moiranCountTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.fekliteCountTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dynaianCountTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.aidanCountTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.setSeedAndRestButton = new System.Windows.Forms.Button();
			this.cameliteCountTextBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.makeHundredGenButton = new System.Windows.Forms.Button();
			this.makeTenGenButton = new System.Windows.Forms.Button();
			this.makeOneGenButton = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.populationCountLabel = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.progressBar3 = new System.Windows.Forms.ProgressBar();
			this.progressBar4 = new System.Windows.Forms.ProgressBar();
			this.progressBar5 = new System.Windows.Forms.ProgressBar();
			this.progressBar6 = new System.Windows.Forms.ProgressBar();
			this.progressBar7 = new System.Windows.Forms.ProgressBar();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.generationNumberLabel = new System.Windows.Forms.Label();
			this.progressBar8 = new System.Windows.Forms.ProgressBar();
			this.progressBar9 = new System.Windows.Forms.ProgressBar();
			this.progressBar10 = new System.Windows.Forms.ProgressBar();
			this.genProgressBar = new System.Windows.Forms.ProgressBar();
			this.reproductionProgressBar = new System.Windows.Forms.ProgressBar();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// makewNewGenerationsAsyncWorker
			// 
			this.makewNewGenerationsAsyncWorker.WorkerReportsProgress = true;
			this.makewNewGenerationsAsyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TheBackgorundWorker_DoWork);
			this.makewNewGenerationsAsyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.TheBackgorundWorker_ProgressChanged);
			this.makewNewGenerationsAsyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TheBackgorundWorker_RunWorkerCompleted);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.racialPurityDevalvationTextBox);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.raciaPurityImportanceCoefTextBox);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.groomCountTextBox);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.groomSearchRadiusTextBox);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.birthRateTextBox);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(12, 315);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(221, 343);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Прочие параметры";
			// 
			// racialPurityDevalvationTextBox
			// 
			this.racialPurityDevalvationTextBox.Location = new System.Drawing.Point(13, 310);
			this.racialPurityDevalvationTextBox.Name = "racialPurityDevalvationTextBox";
			this.racialPurityDevalvationTextBox.Size = new System.Drawing.Size(190, 27);
			this.racialPurityDevalvationTextBox.TabIndex = 38;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(27, 282);
			this.label12.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(164, 20);
			this.label12.TabIndex = 37;
			this.label12.Text = "Девальвация расизма";
			// 
			// raciaPurityImportanceCoefTextBox
			// 
			this.raciaPurityImportanceCoefTextBox.Location = new System.Drawing.Point(15, 247);
			this.raciaPurityImportanceCoefTextBox.Name = "raciaPurityImportanceCoefTextBox";
			this.raciaPurityImportanceCoefTextBox.Size = new System.Drawing.Size(190, 27);
			this.raciaPurityImportanceCoefTextBox.TabIndex = 36;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(8, 219);
			this.label11.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(199, 20);
			this.label11.TabIndex = 35;
			this.label11.Text = "Важность расовой чистоты";
			// 
			// groomCountTextBox
			// 
			this.groomCountTextBox.Location = new System.Drawing.Point(15, 184);
			this.groomCountTextBox.Name = "groomCountTextBox";
			this.groomCountTextBox.Size = new System.Drawing.Size(190, 27);
			this.groomCountTextBox.TabIndex = 34;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(27, 156);
			this.label10.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(155, 20);
			this.label10.TabIndex = 33;
			this.label10.Text = "Количество женихов";
			// 
			// groomSearchRadiusTextBox
			// 
			this.groomSearchRadiusTextBox.Location = new System.Drawing.Point(15, 121);
			this.groomSearchRadiusTextBox.Name = "groomSearchRadiusTextBox";
			this.groomSearchRadiusTextBox.Size = new System.Drawing.Size(190, 27);
			this.groomSearchRadiusTextBox.TabIndex = 32;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(18, 93);
			this.label9.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(174, 20);
			this.label9.TabIndex = 31;
			this.label9.Text = "Радиус поиска женихов";
			// 
			// birthRateTextBox
			// 
			this.birthRateTextBox.Location = new System.Drawing.Point(13, 55);
			this.birthRateTextBox.Name = "birthRateTextBox";
			this.birthRateTextBox.Size = new System.Drawing.Size(197, 27);
			this.birthRateTextBox.TabIndex = 30;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(57, 28);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(102, 20);
			this.label8.TabIndex = 29;
			this.label8.Text = "Рождаемость";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 226);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 20);
			this.label7.TabIndex = 27;
			this.label7.Text = "Аидяне";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 160);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 20);
			this.label5.TabIndex = 23;
			this.label5.Text = "Камелиты";
			// 
			// julianCountTextBox
			// 
			this.julianCountTextBox.Location = new System.Drawing.Point(129, 60);
			this.julianCountTextBox.Name = "julianCountTextBox";
			this.julianCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.julianCountTextBox.TabIndex = 18;
			// 
			// aivianCountTextBox
			// 
			this.aivianCountTextBox.Location = new System.Drawing.Point(129, 93);
			this.aivianCountTextBox.Name = "aivianCountTextBox";
			this.aivianCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.aivianCountTextBox.TabIndex = 20;
			// 
			// moiranCountTextBox
			// 
			this.moiranCountTextBox.Location = new System.Drawing.Point(129, 27);
			this.moiranCountTextBox.Name = "moiranCountTextBox";
			this.moiranCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.moiranCountTextBox.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 20);
			this.label1.TabIndex = 15;
			this.label1.Text = "Мойриане";
			// 
			// fekliteCountTextBox
			// 
			this.fekliteCountTextBox.Location = new System.Drawing.Point(129, 126);
			this.fekliteCountTextBox.Name = "fekliteCountTextBox";
			this.fekliteCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.fekliteCountTextBox.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 61);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 20);
			this.label2.TabIndex = 17;
			this.label2.Text = "Джулиане";
			// 
			// dynaianCountTextBox
			// 
			this.dynaianCountTextBox.Location = new System.Drawing.Point(129, 192);
			this.dynaianCountTextBox.Name = "dynaianCountTextBox";
			this.dynaianCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.dynaianCountTextBox.TabIndex = 26;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 193);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 20);
			this.label6.TabIndex = 25;
			this.label6.Text = "Динайцы";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 127);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 20);
			this.label4.TabIndex = 21;
			this.label4.Text = "Феклиты";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 94);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 20);
			this.label3.TabIndex = 19;
			this.label3.Text = "Айвинцы";
			// 
			// aidanCountTextBox
			// 
			this.aidanCountTextBox.Location = new System.Drawing.Point(129, 225);
			this.aidanCountTextBox.Name = "aidanCountTextBox";
			this.aidanCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.aidanCountTextBox.TabIndex = 28;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.setSeedAndRestButton);
			this.groupBox1.Controls.Add(this.aidanCountTextBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.dynaianCountTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cameliteCountTextBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.fekliteCountTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.aivianCountTextBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.julianCountTextBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.moiranCountTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(221, 297);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Начальные условия";
			// 
			// setSeedAndRestButton
			// 
			this.setSeedAndRestButton.Location = new System.Drawing.Point(18, 258);
			this.setSeedAndRestButton.Name = "setSeedAndRestButton";
			this.setSeedAndRestButton.Size = new System.Drawing.Size(176, 29);
			this.setSeedAndRestButton.TabIndex = 29;
			this.setSeedAndRestButton.Text = " Сбросить и посеять";
			this.setSeedAndRestButton.UseVisualStyleBackColor = true;
			this.setSeedAndRestButton.Click += new System.EventHandler(this.setSeedAndRestButton_Click);
			// 
			// cameliteCountTextBox
			// 
			this.cameliteCountTextBox.Location = new System.Drawing.Point(129, 159);
			this.cameliteCountTextBox.Name = "cameliteCountTextBox";
			this.cameliteCountTextBox.Size = new System.Drawing.Size(62, 27);
			this.cameliteCountTextBox.TabIndex = 24;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.makeHundredGenButton);
			this.groupBox3.Controls.Add(this.makeTenGenButton);
			this.groupBox3.Controls.Add(this.makeOneGenButton);
			this.groupBox3.Location = new System.Drawing.Point(250, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(172, 133);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Управление";
			// 
			// makeHundredGenButton
			// 
			this.makeHundredGenButton.Enabled = false;
			this.makeHundredGenButton.Location = new System.Drawing.Point(7, 98);
			this.makeHundredGenButton.Name = "makeHundredGenButton";
			this.makeHundredGenButton.Size = new System.Drawing.Size(159, 29);
			this.makeHundredGenButton.TabIndex = 2;
			this.makeHundredGenButton.Text = "+ 100 поколений";
			this.makeHundredGenButton.UseVisualStyleBackColor = true;
			this.makeHundredGenButton.Click += new System.EventHandler(this.makeHundredGenButton_Click);
			// 
			// makeTenGenButton
			// 
			this.makeTenGenButton.Enabled = false;
			this.makeTenGenButton.Location = new System.Drawing.Point(7, 63);
			this.makeTenGenButton.Name = "makeTenGenButton";
			this.makeTenGenButton.Size = new System.Drawing.Size(159, 29);
			this.makeTenGenButton.TabIndex = 1;
			this.makeTenGenButton.Text = "+ 10 поколений";
			this.makeTenGenButton.UseVisualStyleBackColor = true;
			this.makeTenGenButton.Click += new System.EventHandler(this.makeTenGenButton_Click);
			// 
			// makeOneGenButton
			// 
			this.makeOneGenButton.Enabled = false;
			this.makeOneGenButton.Location = new System.Drawing.Point(7, 28);
			this.makeOneGenButton.Name = "makeOneGenButton";
			this.makeOneGenButton.Size = new System.Drawing.Size(159, 29);
			this.makeOneGenButton.TabIndex = 0;
			this.makeOneGenButton.Text = "+ 1 поколение";
			this.makeOneGenButton.UseVisualStyleBackColor = true;
			this.makeOneGenButton.Click += new System.EventHandler(this.makeOnGenButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.populationCountLabel);
			this.groupBox4.Location = new System.Drawing.Point(428, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(542, 125);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Население";
			// 
			// populationCountLabel
			// 
			this.populationCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.populationCountLabel.AutoSize = true;
			this.populationCountLabel.Font = new System.Drawing.Font("Segoe UI", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
			this.populationCountLabel.Location = new System.Drawing.Point(111, 26);
			this.populationCountLabel.Name = "populationCountLabel";
			this.populationCountLabel.Size = new System.Drawing.Size(315, 81);
			this.populationCountLabel.TabIndex = 0;
			this.populationCountLabel.Text = "10000000";
			this.populationCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(250, 270);
			this.progressBar1.MarqueeAnimationSpeed = 0;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(720, 29);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 6;
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point(250, 305);
			this.progressBar2.MarqueeAnimationSpeed = 0;
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(720, 29);
			this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar2.TabIndex = 7;
			// 
			// progressBar3
			// 
			this.progressBar3.Location = new System.Drawing.Point(250, 340);
			this.progressBar3.MarqueeAnimationSpeed = 0;
			this.progressBar3.Name = "progressBar3";
			this.progressBar3.Size = new System.Drawing.Size(720, 29);
			this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar3.TabIndex = 8;
			// 
			// progressBar4
			// 
			this.progressBar4.Location = new System.Drawing.Point(250, 445);
			this.progressBar4.MarqueeAnimationSpeed = 0;
			this.progressBar4.Name = "progressBar4";
			this.progressBar4.Size = new System.Drawing.Size(720, 29);
			this.progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar4.TabIndex = 11;
			// 
			// progressBar5
			// 
			this.progressBar5.Location = new System.Drawing.Point(250, 410);
			this.progressBar5.MarqueeAnimationSpeed = 0;
			this.progressBar5.Name = "progressBar5";
			this.progressBar5.Size = new System.Drawing.Size(720, 29);
			this.progressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar5.TabIndex = 10;
			// 
			// progressBar6
			// 
			this.progressBar6.Location = new System.Drawing.Point(250, 375);
			this.progressBar6.MarqueeAnimationSpeed = 0;
			this.progressBar6.Name = "progressBar6";
			this.progressBar6.Size = new System.Drawing.Size(720, 29);
			this.progressBar6.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar6.TabIndex = 9;
			// 
			// progressBar7
			// 
			this.progressBar7.Location = new System.Drawing.Point(250, 480);
			this.progressBar7.MarqueeAnimationSpeed = 0;
			this.progressBar7.Name = "progressBar7";
			this.progressBar7.Size = new System.Drawing.Size(720, 29);
			this.progressBar7.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar7.TabIndex = 12;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.generationNumberLabel);
			this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox5.Location = new System.Drawing.Point(257, 152);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(268, 79);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Номер поколения";
			// 
			// generationNumberLabel
			// 
			this.generationNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.generationNumberLabel.AutoSize = true;
			this.generationNumberLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
			this.generationNumberLabel.Location = new System.Drawing.Point(77, 26);
			this.generationNumberLabel.Name = "generationNumberLabel";
			this.generationNumberLabel.Size = new System.Drawing.Size(113, 38);
			this.generationNumberLabel.TabIndex = 0;
			this.generationNumberLabel.Text = "100000";
			this.generationNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar8
			// 
			this.progressBar8.Location = new System.Drawing.Point(250, 515);
			this.progressBar8.MarqueeAnimationSpeed = 0;
			this.progressBar8.Name = "progressBar8";
			this.progressBar8.Size = new System.Drawing.Size(720, 29);
			this.progressBar8.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar8.TabIndex = 14;
			// 
			// progressBar9
			// 
			this.progressBar9.Location = new System.Drawing.Point(250, 550);
			this.progressBar9.MarqueeAnimationSpeed = 0;
			this.progressBar9.Name = "progressBar9";
			this.progressBar9.Size = new System.Drawing.Size(720, 29);
			this.progressBar9.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar9.TabIndex = 15;
			// 
			// progressBar10
			// 
			this.progressBar10.Location = new System.Drawing.Point(250, 588);
			this.progressBar10.MarqueeAnimationSpeed = 0;
			this.progressBar10.Name = "progressBar10";
			this.progressBar10.Size = new System.Drawing.Size(720, 29);
			this.progressBar10.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar10.TabIndex = 16;
			// 
			// genProgressBar
			// 
			this.genProgressBar.Location = new System.Drawing.Point(531, 195);
			this.genProgressBar.Name = "genProgressBar";
			this.genProgressBar.Size = new System.Drawing.Size(438, 30);
			this.genProgressBar.TabIndex = 17;
			// 
			// reproductionProgressBar
			// 
			this.reproductionProgressBar.Location = new System.Drawing.Point(531, 162);
			this.reproductionProgressBar.Name = "reproductionProgressBar";
			this.reproductionProgressBar.Size = new System.Drawing.Size(438, 30);
			this.reproductionProgressBar.TabIndex = 18;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.ClientSize = new System.Drawing.Size(982, 666);
			this.Controls.Add(this.reproductionProgressBar);
			this.Controls.Add(this.genProgressBar);
			this.Controls.Add(this.progressBar10);
			this.Controls.Add(this.progressBar9);
			this.Controls.Add(this.progressBar8);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.progressBar7);
			this.Controls.Add(this.progressBar4);
			this.Controls.Add(this.progressBar5);
			this.Controls.Add(this.progressBar6);
			this.Controls.Add(this.progressBar3);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximumSize = new System.Drawing.Size(1000, 713);
			this.MinimumSize = new System.Drawing.Size(1000, 713);
			this.Name = "MainForm";
			this.Text = "Genetcs";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker makewNewGenerationsAsyncWorker;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox racialPurityDevalvationTextBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox raciaPurityImportanceCoefTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox groomCountTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox groomSearchRadiusTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox birthRateTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox julianCountTextBox;
		private System.Windows.Forms.TextBox aivianCountTextBox;
		private System.Windows.Forms.TextBox moiranCountTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox fekliteCountTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox dynaianCountTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox aidanCountTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button setSeedAndRestButton;
		private System.Windows.Forms.TextBox cameliteCountTextBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button makeHundredGenButton;
		private System.Windows.Forms.Button makeTenGenButton;
		private System.Windows.Forms.Button makeOneGenButton;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label populationCountLabel;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.ProgressBar progressBar3;
		private System.Windows.Forms.ProgressBar progressBar4;
		private System.Windows.Forms.ProgressBar progressBar5;
		private System.Windows.Forms.ProgressBar progressBar6;
		private System.Windows.Forms.ProgressBar progressBar7;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label generationNumberLabel;
		private System.Windows.Forms.ProgressBar progressBar8;
		private System.Windows.Forms.ProgressBar progressBar9;
		private System.Windows.Forms.ProgressBar progressBar10;
		private System.Windows.Forms.ProgressBar genProgressBar;
		private System.Windows.Forms.ProgressBar reproductionProgressBar;
	}
}

