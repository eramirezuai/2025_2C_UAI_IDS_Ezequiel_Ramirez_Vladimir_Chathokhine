using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        private UserBLL userBLL;
        public string userName;
        public FormLogin()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                var user = userBLL.LoginWithCredentials(txt_user.Text, txt_password.Text);
                //MessageBox.Show("User " + user.Name + "logged in");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            //temporal
            txt_user.Text = "admin01";
            txt_password.Text = "admin01";
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
