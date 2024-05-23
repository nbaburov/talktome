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
        private readonly AuthService _authService;
        public AdminLogin(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            // string email = "admin@email.com";
            // string password = "123";

            try
            {
                var loginSuccess = _authService.LoginAdmin(email, password);

                if (loginSuccess)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lblError.Text = "Invalid credentials. Please try again. This login works only for admins.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error" + ex.Message;
            }



        }
    }
}
