using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] mass = new int[10];
        Random rand = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 4;
            dataGridView1.Rows[0].HeaderCell.Value = "x";
            dataGridView1.Rows[1].HeaderCell.Value = "y";
            dataGridView1.Rows[2].HeaderCell.Value = "xy";
            dataGridView1.Rows[3].HeaderCell.Value = "xx";

            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Columns[i].Width = 25;
                dataGridView1.Rows[0].Cells[i].Value = 0;
                
                dataGridView1.Rows[1].Cells[i].Value = 0;
                
                dataGridView1.Rows[2].Cells[i].Value = 0;
                
                dataGridView1.Rows[3].Cells[i].Value = 0;
            }
            chart1.Series.Add("pmiseries");
            chart1.Series.Add("линия");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                mass[i] = rand.Next(-20, 80);

            }
            
            
            chart1.Series["pmiseries"].Points.Clear();
            chart1.Series["линия"].Points.Clear();

            int sumx = 0;
            int sumy = 0;
            int sumxy = 0;
            int sumxx = 0;
            chart1.Series["pmiseries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["линия"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i+1);
                sumx += i;
                dataGridView1.Rows[0].Cells[i].Value = i ;
                sumy += mass[i];
                dataGridView1.Rows[1].Cells[i].Value = mass[i] ;
                sumxy += i * mass[i];
                dataGridView1.Rows[2].Cells[i].Value = i*mass[i];
                sumxx += i * i;
                dataGridView1.Rows[3].Cells[i].Value = i*i;
                
            }
            double a = (10 * sumxy - sumx * sumy) / (10 * sumxx - sumx * sumx);
            double b = (sumy - sumx * a) / 10;

            for (int i = 0; i < 10; i++)
            {

                
                chart1.Series["pmiseries"].Points.Add(mass[i]);
                double  fx = a * i + b;
                chart1.Series["линия"].Points.Add(fx);
            }

        }
        
    


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
