using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace talktomeadmin
{
    public partial class AdminLogin : Form
    {
        private readonly UserService _userService;
        public AdminLogin(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string email = txtEmail.Text;
            //string password = txtPassword.Text;
            string email = "nbaburov@abv.bg";
            string password = "7712niko";

            var loginSuccess = _userService.LoginAdmin(email, password);

            if (loginSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblError.Text = "Invalid credentials. Please try again. This login works only for admins.";
            }

        }
    }
}
