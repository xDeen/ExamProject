using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProject
{
    public partial class dbcon : Form
    {
        public dbcon()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Conn.cn", richTextBox1.Text);
            this.Dispose();
        }

        private void dbcon_Load(object sender, EventArgs e)
        {
            string FILE_NAME = "";
            FILE_NAME = "Conn.cn";
            string line;
            System.IO.StreamReader objReader = new System.IO.StreamReader(FILE_NAME);
            string[] readText = File.ReadAllLines(FILE_NAME);
            //line = objReader.ReadLine();
            //openFileDialog1.ShowDialog(); //Shows the dialog   
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt  
            //{
            // string open = File.ReadAllText(line); //Reads the text from file  
            foreach (var item in readText)
            {
                richTextBox1.Text += item.ToString() + Environment.NewLine;
            }
                ; //Shows the reded text in the textbox  
            //}
            //else //If something goes wrong...  
            //{
            //    MessageBox.Show("The file you've chosen is not a text file");
            //}
            objReader.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
