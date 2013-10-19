using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public FileLoader fileloader;
        public string cmb1;
        public string cmb2;
        public string cmb3;
        public Form1()
        {
            fileloader = new FileLoader();
            InitializeComponent();
            foreach (string s in fileloader.returnJerseyList())
            {
                this.comboBox1.Items.Add(s);
                this.comboBox2.Items.Add(s);
            }

            foreach (string s in fileloader.returnIceList())
            {
                this.comboBox3.Items.Add(s);
            }

        }
        
        public void Commit(){
            fileloader.set_ice(cmb3);
            fileloader.set_red(cmb1);
            fileloader.set_blue(cmb2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Red team
            cmb1 = this.comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Blue team
            cmb2 = this.comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ice
            cmb3 = this.comboBox3.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save changes
            Commit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Save and open hockey?
            Commit();
            fileloader.launch();
            this.Close();
        }
    }
}
