using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02TaskPerformance1
{
    public partial class Form2 : Form
    {

        private int _tick;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void listCashierQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblWaitingTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _tick++;
                label1.Text = _tick.ToString();
                if (_tick == 10)
                {
                    timer1.Stop();
                    _tick = 0;
                    View show = new View();
                    show.ShowDialog();
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                }
            }
            catch (System.InvalidOperationException ex)
            {
                timer1.Stop();
                _tick = 0;
                this.Close();
            }
        }
    }
}
