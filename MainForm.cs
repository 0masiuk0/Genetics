using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genetics
{
	public partial class MainForm : Form
	{
		Population population;
		Timer ProgressUpdateTimer = new Timer();
				
		public MainForm()
		{
			InitializeComponent();
			decilesProgressBars = new ProgressBar[10] {
				progressBar1, progressBar2, progressBar3, progressBar4, progressBar5, 
				progressBar6, progressBar7,	 progressBar8, progressBar9, progressBar10 
			};

			decileTextBoxes = new TextBox[10] {
				decileTextBox1, decileTextBox2, decileTextBox3, decileTextBox4, decileTextBox5,
				decileTextBox6, decileTextBox7, decileTextBox8, decileTextBox9, decileTextBox10
			};

			foreach(ProgressBar pb in decilesProgressBars)
			{
				pb.Maximum = 100;
				pb.Minimum = 0;
			}

			birthRateTextBox.Leave +=  new System.EventHandler(UpdateParameters);
			groomSearchRadiusTextBox.Leave += new System.EventHandler(UpdateParameters);
			groomCountTextBox.Leave += new System.EventHandler(UpdateParameters);
			raciaPurityImportanceCoefTextBox.Leave += new System.EventHandler(UpdateParameters);
			racialPurityDevalvationTextBox.Leave += new System.EventHandler(UpdateParameters);

			birthRateTextBox.KeyDown += new KeyEventHandler(paramterTextBoxKeyPressed);
			groomSearchRadiusTextBox.KeyDown += new KeyEventHandler(paramterTextBoxKeyPressed);
			groomCountTextBox.KeyDown += new KeyEventHandler(paramterTextBoxKeyPressed);
			raciaPurityImportanceCoefTextBox.KeyDown += new KeyEventHandler(paramterTextBoxKeyPressed);
			racialPurityDevalvationTextBox.KeyDown += new KeyEventHandler(paramterTextBoxKeyPressed);

			ProgressUpdateTimer.Interval = 300;
			ProgressUpdateTimer.Tick += new EventHandler(TimerTick);

			moiranCountTextBox.Text = aidanCountTextBox.Text = aivianCountTextBox.Text =
				julianCountTextBox.Text = cameliteCountTextBox.Text = fekliteCountTextBox.Text =
				dynaianCountTextBox.Text = "5";

			birthRateTextBox.Text = Population.BirthRate.ToString();
			groomCountTextBox.Text = Population.GroomCount.ToString();
			groomSearchRadiusTextBox.Text = Population.GroomSearchRadius.ToString();
			racialPurityDevalvationTextBox.Text = Population.racialPurityImportanceDepretiationCoef.ToString();
			raciaPurityImportanceCoefTextBox.Text = Person.RacialPurityImportnace.ToString();

			generationNumberLabel.Text = "0";
			populationCountLabel.Text = "0";
		}
				
		readonly ProgressBar[] decilesProgressBars;
		readonly TextBox[] decileTextBoxes;
				
		private void setSeedAndRestButton_Click(object sender, EventArgs e)
		{
			int[] seedPopulation = new int[7];
			bool parseSuccess = true;
			parseSuccess &= Int32.TryParse(moiranCountTextBox.Text, out seedPopulation[0]);
			parseSuccess &= Int32.TryParse(julianCountTextBox.Text, out seedPopulation[1]);
			parseSuccess &= Int32.TryParse(aivianCountTextBox.Text, out seedPopulation[2]);
			parseSuccess &= Int32.TryParse(fekliteCountTextBox.Text, out seedPopulation[3]);
			parseSuccess &= Int32.TryParse(cameliteCountTextBox.Text, out seedPopulation[4]);
			parseSuccess &= Int32.TryParse(dynaianCountTextBox.Text, out seedPopulation[5]);
			parseSuccess &= Int32.TryParse(aidanCountTextBox.Text, out seedPopulation[6]);
			parseSuccess &= seedPopulation.All(s => s >= 0);
			
			if (!parseSuccess)
			{
				MessageBox.Show("Неверные входные данные.", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			population = new Population(seedPopulation);
			UpdateStats();
			LockSeedParametersButtons(true);
			EnableGenerationButtons(true);
		}

		private async void UpdateStats()
		{
			int[] racialPurityDeciles = await Task<int[]>.Run(() => population.GetRacialPurityDeciles());

			populationCountLabel.Text = population.PeopleCount.ToString();
			generationNumberLabel.Text = population.GenerationNumber.ToString();
			genProgressBar.Value = reproductionProgressBar.Value = 100;					

			for (int i = 0; i < 10; i++)
			{
				decilesProgressBars[i].Value = racialPurityDeciles[i];
				decileTextBoxes[i].Text = $"{racialPurityDeciles[i]}%";
			}

			raciaPurityImportanceCoefTextBox.Text = Person.RacialPurityImportnace.ToString();
		}
				
		private void UpdateParameters(object sender, EventArgs e)
		{
			bool validParameters = true;			
			validParameters &= double.TryParse(birthRateTextBox.Text, out double birthRate);
			validParameters &= int.TryParse(groomCountTextBox.Text, out int groomsCount);
			validParameters &= int.TryParse(groomSearchRadiusTextBox.Text, out int groomsSearchRadius);
			validParameters &= double.TryParse(racialPurityDevalvationTextBox.Text, out double racialPurityDepreciationCoef);
			validParameters &= double.TryParse(raciaPurityImportanceCoefTextBox.Text, out double racialPurityImportanceCoef);

			validParameters &= birthRate > 0;
			validParameters &= groomsCount > 0;
			validParameters &= groomsSearchRadius > 0;
			validParameters &= racialPurityImportanceCoef > 0 && racialPurityImportanceCoef <= 1;
			validParameters &= racialPurityDepreciationCoef >= 0 && racialPurityDepreciationCoef <= 1;

			if (validParameters)
			{
				Population.BirthRate = birthRate;
				Population.GroomCount = groomsCount;
				Population.GroomSearchRadius = groomsSearchRadius;
				Population.racialPurityImportanceDepretiationCoef = racialPurityDepreciationCoef;
				Person.RacialPurityImportnace = racialPurityImportanceCoef;
			}

			EnableGenerationButtons(validParameters);
		}

		private void makeOnGenButton_Click(object sender, EventArgs e)
		{
			MakeNewGenerations(1);
		}

		private void makeTenGenButton_Click(object sender, EventArgs e)
		{
			MakeNewGenerations(10);
		}

		private void makeHundredGenButton_Click(object sender, EventArgs e)
		{
			MakeNewGenerations(100);
		}

		void MakeNewGenerations(int N)
		{
			if (!makewNewGenerationsAsyncWorker.IsBusy)
			{
				ProgressUpdateTimer.Start();
				EnableGenerationButtons(false);
				makewNewGenerationsAsyncWorker.RunWorkerAsync(N);
			}
		}

		private void paramterTextBoxKeyPressed(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) UpdateParameters(sender, e);
		}

		private void EnableGenerationButtons(bool generationAdvancemntAllowed)
		{
			makeOneGenButton.Enabled = makeTenGenButton.Enabled = makeHundredGenButton.Enabled = generationAdvancemntAllowed;
		}

		private void LockSeedParametersButtons(bool changingSeedParamtersAllowed)
		{
			moiranCountTextBox.Enabled = aidanCountTextBox.Enabled = aivianCountTextBox.Enabled =
				julianCountTextBox.Enabled = cameliteCountTextBox.Enabled = fekliteCountTextBox.Enabled =
				dynaianCountTextBox.Enabled = changingSeedParamtersAllowed;
		}

		private void TheBackgorundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int genNuber = (int)e.Argument;			
			population.MakeNewGenerations(genNuber, sender as BackgroundWorker);
		}

		private void TheBackgorundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (progressUpdateAllowed)
			{
				Population.GenerationsGenerationProgressReport report = (Population.GenerationsGenerationProgressReport)e.UserState;
				genProgressBar.Value = report.generationProgress;
				reproductionProgressBar.Value = report.reproductionProgress;
				populationCountLabel.Text = report.peopleCount.ToString();
				generationNumberLabel.Text = report.generationNumber.ToString();
				progressUpdateAllowed = false;
			}
		}

		bool progressUpdateAllowed = true;
		private void TimerTick(object sender, EventArgs e)
		{
			progressUpdateAllowed = true;
		}

		private void TheBackgorundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ProgressUpdateTimer.Stop();
			foreach(ProgressBar pbn in decilesProgressBars)
			{
				pbn.Value = 100;
				pbn.MarqueeAnimationSpeed = 800;
				pbn.Style = ProgressBarStyle.Marquee;
			}
			
			this.UpdateStats();

			foreach (ProgressBar pbn in decilesProgressBars)
			{				
				pbn.MarqueeAnimationSpeed = 0;
				pbn.Style = ProgressBarStyle.Continuous;
			}

			LockSeedParametersButtons(false);
			EnableGenerationButtons(true);
		}

		
	}
}
