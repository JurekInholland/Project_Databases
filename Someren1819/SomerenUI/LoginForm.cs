using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class LoginForm : Form
    {
        // Username and password are currently hardcoded inside the loginform.
        // This should definitely be changed but for clarity ill leave it for now.
        const string USERNAME = "root";
        const string PASSWORD = "admin";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // If username and password match, return the correct DialogResult.
            // Else, display an error message to the user.
            if (txtUsername.Text == USERNAME && txtPassword.Text == PASSWORD)
            {
                DialogResult = DialogResult.OK;
            } else
            {
                lblLoginError.Visible = true;
            }
        }
    }
}
