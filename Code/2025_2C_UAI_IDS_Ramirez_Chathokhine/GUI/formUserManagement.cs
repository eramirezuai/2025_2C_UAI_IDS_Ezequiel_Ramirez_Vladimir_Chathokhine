using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class formUserManagement : Form
    {
        private UserBLL userBLL;
        public formUserManagement()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formUserManagement_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length>0&&txtPassword.Text.Length>0)
            {
                userBLL.CreateUser(txtUser.Text, txtPassword.Text);
            }
            else
            {
                MessageBox.Show("Username or password is not complete");
            }

            
        }
    }
}
