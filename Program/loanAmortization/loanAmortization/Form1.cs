using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Windows form class used for interface.
namespace loanAmortization
{
    public partial class Form1 : Form
    {
        
        bool f1, f2, f3;
        float r,p,m;
        
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e) //event for change of text in TextBox1 i.e. Rate of Interest
        {
            
            float n;
            if (textBox1.Text == "" || float.TryParse(textBox1.Text, out n))
            {
                if (textBox1.Text == "" || float.Parse(textBox1.Text) > 100 || float.Parse(textBox1.Text) < 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    f1 = false;
                }
                else
                {
                    f1 = true;
                    r = float.Parse(textBox1.Text);
                    if (f3 && f2)
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                }
            }
            else if (textBox1.Text != "")
            {
                
                textBox1.Clear();
                textBox1.Text = r.ToString();
                MessageBox.Show("Only numeric value is acceptable for rate of interest");
                
            }
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e) // event for change of text in TextBox2 i.e. Number of Months
        {
            int n;
            if (textBox2.Text == "" || int.TryParse(textBox2.Text, out n))
            {
                if (textBox2.Text == "" || int.Parse(textBox2.Text) < 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    f2 = false;
                }
                else
                {
                    f2 = true;
                    m = int.Parse(textBox2.Text);
                    if (f3 && f1)
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                }
            }
            else if (textBox2.Text != "")
            {

                textBox2.Clear();
                textBox2.Text = m.ToString();
                MessageBox.Show("Only integer value is acceptable for number of months");

                
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // event for change of text in TextBox3 i.e. Principle Amount
        {
            float n;
            if (textBox3.Text == "" || float.TryParse(textBox3.Text, out n))
            {
                if (textBox3.Text == "" || float.Parse(textBox3.Text) < 0)
                {
                    button2.Enabled = false;
                    button1.Enabled = false;
                    button3.Enabled = false;
                    f3 = false;
                }
                else
                {
                    f3 = true;
                    p = float.Parse(textBox3.Text);
                    if (f1 && f2)
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                }
            }
            else if (textBox3.Text != "")
            {
                textBox3.Clear();
                textBox3.Text = p.ToString();
                MessageBox.Show("Only numeric value is acceptable for principle amount");
            }
        }


        private void button1_Click(object sender, EventArgs e) // Botton "Calculate EMI". 
        {
            LoanValueTable vTab = new LoanValueTable(float.Parse(textBox3.Text), int.Parse(textBox2.Text), float.Parse(textBox1.Text));
            // defined an object of class vTab. Class vTab is responsible for storing the generated EMI table in arrayLiat for a given input.
            ArrayDataView a;

            label7.Text = (vTab.amt).ToString(); // to display the EMI
            label10.Text = (vTab.total).ToString(); // to display the Total amount.

            dataGridView1.Rows.Clear();
            
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("chart1");
            // create chart.

            chart1.Series.Clear();
            chart1.Series.Add("A");
            chart1.Series.Add("B");
            chart1.Series.Add("C");
            

            for (int i = 0; i < m; i++)
            {
                a = vTab.loanTable[i]; // a is used to store the specific entry of a month got from the arrayList of class vTab. Class vTab stores generated EMI table.
                dataGridView1.Rows.Add((a.PayNumber), Math.Round(a.PrincipleFrac, 2), Math.Round(a.InterestFrac, 2), Math.Round(a.RemainingAmt, 2), Math.Round(a.RemainingP, 2));

                chart1.Series[0].Points.AddXY(a.PayNumber, (Math.Round(a.RemainingAmt, 2)));
                chart1.Series[1].Points.AddXY(a.PayNumber, (Math.Round(a.RemainingP, 2)));
                chart1.Series[2].Points.AddXY(a.PayNumber, (Math.Round(a.PrincipleFrac, 2)));

                // disable the series Remaining Principle and Principle fraction to get only Remaining Balance as default graph.
                chart1.Series[2].Enabled = false; 
                chart1.Series[1].Enabled = false;

                
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                checkBox4.Checked = false;

                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
            }

            // display EMI table and Chart.
            chart1.Visible = true;
            dataGridView1.Visible = true;
            chart1.Height = 350;
            chart1.Width = 350;
            chart1.Location = new Point(360, 220);

            dataGridView1.Height = 350;
            dataGridView1.Width = 300;
            dataGridView1.Location = new Point(50, 220);

        }

        private void button2_Click(object sender, EventArgs e) // Button "EMI table"
        {
            button1_Click(null, null);
            chart1.Visible = false;
            dataGridView1.Visible = true;

            dataGridView1.Location = new Point(100, 220);
            dataGridView1.Height = 350;
            dataGridView1.Width = 600;

            checkBox2.Enabled = false;
            checkBox1.Enabled = false;
            checkBox4.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e) // Button "EMI chart"
        {
            button1_Click(null,null);
            dataGridView1.Visible = false;
            chart1.Visible = true;

            chart1.Location = new Point(100, 220);
            chart1.Height = 350;
            chart1.Width = 600;
            
        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart1.Series[2].Enabled = true;
            }
            else
            {
                chart1.Series[2].Enabled = false;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Series[0].Enabled = true;
            }
            else
            {
                chart1.Series[0].Enabled = false;
            }
       }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                chart1.Series[1].Enabled = true;
            }
            else
            {
                chart1.Series[1].Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
