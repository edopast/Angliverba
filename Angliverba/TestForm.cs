using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angliverba
{
    public partial class TestForm : Form
    {
        public Tester VerbTesterAttribute { get; }
        
        ListaVerbi randomList = null;
        int verbIdx = 0;
        Verbo currentVerb = null;
        int currentTense = 0;

        public TestForm(Tester VerbTester)
        {
            InitializeComponent();
            VerbTesterAttribute = VerbTester;
            randomList = VerbTester.StartTest();
            Nextbutton.Enabled = false;
            VerificaButton.Enabled = true;
        }

        public void goTest()
        {
            currentVerb = randomList[verbIdx];
            VerbTesterAttribute.Done[verbIdx] = true;
            refreshTextBoxes();
            currentTense = SeriouslyRandom.Next(0,4);
            switch (currentTense)
            {
                case 0:
                    infTextBox.Text = currentVerb.presente;
                    infTextBox.Enabled = false;
                    break;
                case 1:
                    pastTextBox.Text = string.Join(",", currentVerb.passato);
                    pastTextBox.Enabled = false;
                    break;
                case 2:
                    partTextBox.Text = string.Join(",", currentVerb.participio);
                    partTextBox.Enabled = false;
                    break;
                case 3:
                    tradTextBox.Text = string.Join(",", currentVerb.traduzione);
                    tradTextBox.Enabled = false;
                    break;
            }
        }
        public void refreshPoints()
        {
            Scorelabel.Text = VerbTesterAttribute.returnPoints()[0].ToString() + "/" + (VerbTesterAttribute.returnPoints()[1]*10).ToString();
        }
        public void refreshTextBoxes()
        {
            infTextBox.Clear();
            infTextBox.Enabled = true;
            infTextBox.ForeColor = Color.Black;
            infTextBox.Font = new Font(this.Font, FontStyle.Regular);

            pastTextBox.Clear();
            pastTextBox.Enabled = true;
            pastTextBox.ForeColor = Color.Black;
            pastTextBox.Font = new Font(this.Font, FontStyle.Regular);
            
            partTextBox.Clear();
            partTextBox.Enabled = true;
            partTextBox.ForeColor = Color.Black;
            partTextBox.Font = new Font(this.Font, FontStyle.Regular);

            tradTextBox.Clear();
            tradTextBox.Enabled = true;
            tradTextBox.ForeColor = Color.Black;
            tradTextBox.Font = new Font(this.Font, FontStyle.Regular);
        }

        private void VerificaButton_Click(object sender, EventArgs e)
        {
            int currentPoints = 0;
            for (int textBoxIdx = 1; textBoxIdx <= 4; textBoxIdx++)
            {
                if (textBoxIdx == currentTense + 1)
                    continue;
                switch (textBoxIdx)
                {
                    case 1:
                        if (infTextBox.Text == currentVerb.presente)
                        {
                            currentPoints += 3;
                        }
                        else
                        {
                            infTextBox.ForeColor = Color.Red;
                            infTextBox.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        infTextBox.Text = currentVerb.presente;
                        //infTextBox.Enabled = false;
                        break;
                    case 2:
                        if (currentVerb.passato.Contains(pastTextBox.Text))
                        {
                            currentPoints += 3;
                        }
                        else
                        {
                            pastTextBox.ForeColor = Color.Red;
                            pastTextBox.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        pastTextBox.Text = string.Join(",", currentVerb.passato);
                        //pastTextBox.Enabled = false;
                        break;
                    case 3:
                        if (currentVerb.participio.Contains(partTextBox.Text))
                        {
                            currentPoints += 3;
                        }
                        else
                        {
                            partTextBox.ForeColor = Color.Red;
                            partTextBox.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        partTextBox.Text = string.Join(",", currentVerb.participio);
                        //partTextBox.Enabled = false;
                        break;
                    case 4:
                        if (currentVerb.traduzione.Contains(tradTextBox.Text))
                        {
                            currentPoints += 3;
                        }
                        else
                        {
                            tradTextBox.ForeColor = Color.Red;
                            tradTextBox.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        tradTextBox.Text = string.Join(",", currentVerb.traduzione);
                        //tradTextBox.Enabled = false;
                        break;
                }
            }
            if (currentPoints >= 6)
            {
                currentPoints++;
            }
            VerbTesterAttribute.addPoints(currentPoints);
            refreshPoints();
            Nextbutton.Enabled = true;
            VerificaButton.Enabled = false;
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            VerificaButton.Enabled = true;
            Nextbutton.Enabled = false;
            if (verbIdx< randomList.Count()-1)
            {
                verbIdx++;
                goTest();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Test completo!\n" + "Punti:" +
                    VerbTesterAttribute.returnPoints()[0].ToString() + "/" + (VerbTesterAttribute.returnPoints()[1]*10).ToString());
                this.Close();
            }
                
        }
    }

}
