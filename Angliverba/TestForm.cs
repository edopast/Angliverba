using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angliverba
{
    public partial class TestForm : Form
    {
        public Tester VerbTesterAttribute { get; }
        
        ListaVerbi randomList = null;
        Random randomTenseSelector = new Random();
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
            currentTense = randomTenseSelector.Next(4);
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
            pastTextBox.Clear();
            pastTextBox.Enabled = true;
            partTextBox.Clear();
            partTextBox.Enabled = true;
            tradTextBox.Clear();
            tradTextBox.Enabled = true;
        }

        private void VerificaButton_Click(object sender, EventArgs e)
        {
            refreshPoints();

            Nextbutton.Enabled = true;
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
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
