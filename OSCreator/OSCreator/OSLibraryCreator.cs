using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSCreator
{
    public partial class OSLibraryCreator : Form
    {
        private Generator generator = null;

        internal Generator Generator { get => generator; set => generator = value; }

        public OSLibraryCreator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openCSVFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(this.openCSVFileDialog.FileName);
                MessageBox.Show(sr.ReadToEnd(), Generator.APPNAME);
                generator = new Generator(libraryType_cbb.Text, this.openCSVFileDialog.FileName);
                generator.generate();
                sr.Close();
                this.save_btn.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                generator.writeOutput(saveFileDialog.FileName);
                MessageBox.Show("Save " + System.IO.Path.GetFileName(saveFileDialog.FileName) + " completely",  Generator.APPNAME);
            }

        }
    }
}
