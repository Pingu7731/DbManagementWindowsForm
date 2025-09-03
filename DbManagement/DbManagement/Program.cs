using System;
using System.Windows.Forms;

namespace DbManagement
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = "Data Source=Ping;Initial Catalog=CSIE_Db;Integrated Security=True;Trust Server Certificate=True";

            using (LoginForm login = new LoginForm() { ConnectionString = connectionString })
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // 登入成功 → 開啟主程式
                    Application.Run(new Form1());
                }
                else
                {
                    // 登入失敗或取消 → 程式結束
                    Application.Exit();
                }
            }
        }
	}
}