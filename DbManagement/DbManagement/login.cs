using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbManagement
{

    public class LoginForm : Form
    {
        private Label lblUsername, lblPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnCancel;

        public string ConnectionString { get; set; } // 可傳入資料庫連線字串

        public LoginForm()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblUsername = new Label() { Text = "Username:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            txtUsername = new TextBox() { Location = new System.Drawing.Point(100, 20), Width = 150 };

            lblPassword = new Label() { Text = "Password:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            txtPassword = new TextBox() { Location = new System.Drawing.Point(100, 60), Width = 150, PasswordChar = '*' };

            btnLogin = new Button() { Text = "Login", Location = new System.Drawing.Point(40, 110), Width = 80 };
            btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(150, 110), Width = 80 };

            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnCancel);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入帳號密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 驗證資料庫
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM LogIn WHERE user_name=@user AND pass_word=@pass";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 1)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("帳號或密碼錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
