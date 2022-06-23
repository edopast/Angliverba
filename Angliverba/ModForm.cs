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
    public partial class ModForm : Form
    {
        Tester VerbTesterAttribute { get; }
        public ModForm(Tester VerbTester)
        {
            InitializeComponent();
            VerbTesterAttribute = VerbTester;
            refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Verbo nuovo = new Verbo(addtextBox1.Text, addtextBox2.Text.Split(',').ToList(), addtextBox3.Text.Split(',').ToList(), addtextBox4.Text.Split(',').ToList());
            VerbTesterAttribute.Add(nuovo);
            refresh();
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            VerbTesterAttribute.Remove(removetextBox1.Text);
            refresh();
        }
        private void refresh()
        {
            VerbsRichTextBox.Clear();
            ListaVerbi Lista = VerbTesterAttribute.getListaVerbi();
            VerbsRichTextBox.AppendText("INFINITIVE (to...)" + "   |   " + "PAST SIMPLE" + "   |   " + "PAST PARTICIPLE" + "   |   " + "MEANING (ita)" + "\n");
            for (int i = 0; i < VerbTesterAttribute.getNumVerbi(); i++)
            {
                string presente = Lista[i].presente;
                string passati = string.Join(",", Lista[i].passato);
                string participi = string.Join(",", Lista[i].participio);
                string significati = string.Join(",", Lista[i].traduzione);
                VerbsRichTextBox.AppendText(presente + "   |   " + passati + "   |   " + participi + "   |   " + significati + "\n");
            }
            addtextBox1.Clear();
            addtextBox2.Clear();
            addtextBox3.Clear();
            addtextBox4.Clear();
            removetextBox1.Clear();
        }
    }
    
}
