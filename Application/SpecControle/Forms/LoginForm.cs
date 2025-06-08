using Application;
using Infrastructure.Context;

namespace SpecControle.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        btnLogin.Click += new System.EventHandler(BtnLogin_Click);
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUser.Text.Trim();
        string password = txtPassword.Text;

        string hashedPassword = PasswordHelper.ComputeSha256Hash(password);

        using var db = new SpecificationsDatabaseModel();
        var user = db.Users.SingleOrDefault(u => u.Name == username && u.PasswordHash == hashedPassword);

        if (user is not null)
        {
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}

