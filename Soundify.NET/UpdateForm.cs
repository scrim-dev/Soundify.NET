using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundify.NET
{
    public partial class UpdateForm : Form
    {
        //Will work on this later
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Size = new(700, 450);
            UpdateLabel.Text = "To start updates click the 'Update' button.";
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateLabel.Text = "Starting...";
        }

        private void CancelUpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateLabel.Text = "Quitting...";
            Application.Exit();
        }
    }
}
