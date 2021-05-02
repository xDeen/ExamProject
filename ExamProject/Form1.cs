using DataLibrary.Data;
using DataLibrary.Models;
using DataLibrary.Models.Initialize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExamProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        List<FGOne> fGOnes = new List<FGOne>();
        List<FGTwo> fGTwos = new List<FGTwo>();
        List<FGThree> fGThrees = new List<FGThree>();

        private void txtTireQty_TextChanged(object sender, EventArgs e)
        {
            if (txtTireQty.Text != "")
            {
                try
                {
                    Compute();
                }
                catch
                { }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Compute()
        {
            dataGridView1.Rows.Clear();

            IRequestMethods requestMethods = new RequestMethods();
            var output1 = requestMethods.GetMatsTwo(decimal.Parse(txtTireQty.Text));
            var output2 = requestMethods.GetMatsThree(decimal.Parse(txtTireQty.Text));
            var t = output2.Where(r => r.hasraw == 1).Select(r => r.qty);
            var output3 = requestMethods.GetMatsRawMats(decimal.Parse(t.FirstOrDefault().ToString()));

            List<Output> finaloutput = new List<Output>();

            finaloutput.AddRange(output1);
            finaloutput.AddRange(output2);
            finaloutput.AddRange(output3);

            foreach (var item in finaloutput)
            {
                AddToDGV(item.description, Math.Round(item.qty, 3).ToString(), item.uom);
            }
        }

        private void AddToDGV(string description, string qty, string uom)
        {
            string[] row = new string[] { description, qty, uom };
            dataGridView1.Rows.Add(row);
        }

        private void txtTireQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbcon dbcon = new dbcon();
            dbcon.ShowDialog();
        }
    }
}
