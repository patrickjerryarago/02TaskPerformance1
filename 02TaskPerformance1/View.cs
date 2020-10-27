using System;
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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            try
            {
                lblShow.Text = CashierClass.CashierQueue.Peek();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("No Remaining Queue Available.", "Message");
                this.Close();
            }
        }
    }
}
