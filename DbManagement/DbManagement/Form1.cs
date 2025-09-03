using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DbManagement
{
    public class AddFacultyForm : Form
    {
        public string FacultyId { get; private set; }
        public string FacultyName { get; private set; }
        public string FacultyTitle { get; private set; }
        public string FacultyOffice { get; private set; }
        public string FacultyPhone { get; private set; }
        public string FacultyCollege { get; private set; }
        public string FacultyEmail { get; private set; }

        private TextBox txtId = new TextBox();
        private TextBox txtName = new TextBox();
        private TextBox txtTitle = new TextBox();
        private TextBox txtOffice = new TextBox();
        private TextBox txtPhone = new TextBox();
        private TextBox txtCollege = new TextBox();
        private TextBox txtEmail = new TextBox();

        private Button btnOK = new Button();
        private Button btnCancel = new Button();

        public AddFacultyForm()
        {
            this.Text = "Add Faculty";
            this.Size = new Size(400, 400);

            int y = 20;
            int step = 40;

            Label lblId = new Label { Text = "ID:", Location = new Point(10, y) };
            txtId.Location = new Point(120, y);
            y += step;

            Label lblName = new Label { Text = "Name:", Location = new Point(10, y) };
            txtName.Location = new Point(120, y);
            y += step;

            Label lblTitle = new Label { Text = "Title:", Location = new Point(10, y) };
            txtTitle.Location = new Point(120, y);
            y += step;

            Label lblOffice = new Label { Text = "Office:", Location = new Point(10, y) };
            txtOffice.Location = new Point(120, y);
            y += step;

            Label lblPhone = new Label { Text = "Phone:", Location = new Point(10, y) };
            txtPhone.Location = new Point(120, y);
            y += step;

            Label lblCollege = new Label { Text = "College:", Location = new Point(10, y) };
            txtCollege.Location = new Point(120, y);
            y += step;

            Label lblEmail = new Label { Text = "Email:", Location = new Point(10, y) };
            txtEmail.Location = new Point(120, y);
            y += step;

            btnOK.Text = "OK";
            btnOK.Location = new Point(120, y);
            btnOK.Click += BtnOK_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(220, y);
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblOffice);
            this.Controls.Add(txtOffice);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblCollege);
            this.Controls.Add(txtCollege);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }
        public AddFacultyForm(string id, string name, string title, string office, string phone, string college, string email)
        : this()
        {
            txtId.Text = id;
            txtId.ReadOnly = true; // ID 不允許修改
            txtName.Text = name;
            txtTitle.Text = title;
            txtOffice.Text = office;
            txtPhone.Text = phone;
            txtCollege.Text = college;
            txtEmail.Text = email;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            FacultyId = txtId.Text.Trim();
            FacultyName = txtName.Text.Trim();
            FacultyTitle = txtTitle.Text.Trim();
            FacultyOffice = txtOffice.Text.Trim();
            FacultyPhone = txtPhone.Text.Trim();
            FacultyCollege = txtCollege.Text.Trim();
            FacultyEmail = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(FacultyId) || string.IsNullOrEmpty(FacultyName))
            {
                MessageBox.Show("ID and Name are required.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    public partial class Form1 : Form
	{
		private TabControl tabControl1;
		private TabPage tabFaculty;
		private DataGridView dgvFaculty;
		private Button btnAddFaculty;
		private Button btnEditFaculty;
		private Button btnDeleteFaculty;
		private PictureBox pbFaculty;
		private Button btnUploadFacultyPic;
		private DataTable facultyTable;
		private string connectionString = "Data Source=Ping;Initial Catalog=CSIE_Db;Integrated Security=True;Trust Server Certificate=True";
        public Form1()
		{
			InitializeComponent();
			InitializeFacultyData();
            LoadFacultyFromDatabase();
        }
        
        private void LoadFacultyFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * from Faculty";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            dgvFaculty.DataSource = dt;
        }
        private void InitializeComponent()
		{
			this.tabControl1 = new TabControl();
			this.tabFaculty = new TabPage();
			this.dgvFaculty = new DataGridView();
			this.btnAddFaculty = new Button();
			this.btnEditFaculty = new Button();
			this.btnDeleteFaculty = new Button();
			this.pbFaculty = new PictureBox();
			this.btnUploadFacultyPic = new Button();

			// TabControl
			this.tabControl1.Controls.Add(this.tabFaculty);
			this.tabControl1.Dock = DockStyle.Fill;
			this.tabControl1.SelectedIndex = 0;

			// Faculty Tab
			this.tabFaculty.Text = "Faculty";
			this.tabFaculty.Controls.Add(this.dgvFaculty);
			this.tabFaculty.Controls.Add(this.btnAddFaculty);
			this.tabFaculty.Controls.Add(this.btnEditFaculty);
			this.tabFaculty.Controls.Add(this.btnDeleteFaculty);
			this.tabFaculty.Controls.Add(this.pbFaculty);
			this.tabFaculty.Controls.Add(this.btnUploadFacultyPic);

            this.dgvFaculty.Location = new Point(10, 10);
            this.dgvFaculty.Size = new Size(750, 400); // 加大
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 自動撐滿
            this.dgvFaculty.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgvFaculty.RowTemplate.Height = 30;  // 高度自動

            // PictureBox
            this.pbFaculty.Location = new Point(770, 10);
            this.pbFaculty.Size = new Size(180, 180); // 加大照片區
            this.pbFaculty.BorderStyle = BorderStyle.FixedSingle;
            this.pbFaculty.SizeMode = PictureBoxSizeMode.Zoom;
            this.dgvFaculty.SelectionChanged += DgvFaculty_SelectionChanged;

            // Upload Photo Button
            this.btnUploadFacultyPic.Location = new Point(770, 200);
            this.btnUploadFacultyPic.Size = new Size(180, 40);
            this.btnUploadFacultyPic.Text = "Upload Photo";
            this.btnUploadFacultyPic.Click += BtnUploadFacultyPic_Click;

            // Add Button
            this.btnAddFaculty.Location = new Point(10, 420);
            this.btnAddFaculty.Size = new Size(100, 40);
            this.btnAddFaculty.Text = "Add";
            this.btnAddFaculty.Click += BtnAddFaculty_Click;

            // Edit Button
            this.btnEditFaculty.Location = new Point(120, 420);
            this.btnEditFaculty.Size = new Size(100, 40);
            this.btnEditFaculty.Text = "Edit";
            this.btnEditFaculty.Click += BtnEditFaculty_Click;

            // Delete Button
            this.btnDeleteFaculty.Location = new Point(230, 420);
            this.btnDeleteFaculty.Size = new Size(100, 40);
            this.btnDeleteFaculty.Text = "Delete";
            this.btnDeleteFaculty.Click += BtnDeleteFaculty_Click;

            // Form1
            this.ClientSize = new Size(980, 500); // 視窗加大
            this.Controls.Add(this.tabControl1);
            this.Text = "Department Management System";
        }

		private void InitializeFacultyData()
		{
			facultyTable = new DataTable();
			facultyTable.Columns.Add("ID", typeof(int));
			facultyTable.Columns.Add("Name", typeof(string));
			facultyTable.Columns.Add("Title", typeof(string));
			facultyTable.Rows.Add(1, "Alice", "Professor");
			facultyTable.Rows.Add(2, "Bob", "Associate Professor");
			dgvFaculty.DataSource = facultyTable;
		}
        private void DgvFaculty_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count == 0)
            {
                pbFaculty.Image = null;
                return;
            }

            string facultyId = dgvFaculty.SelectedRows[0].Cells["faculty_id"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT fimage FROM Faculty WHERE faculty_id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", facultyId);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        byte[] imgBytes = (byte[])result;
                        using (var ms = new System.IO.MemoryStream(imgBytes))
                        {
                            pbFaculty.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbFaculty.Image = null; // 如果沒圖，清空顯示
                    }
                }
            }
        }

        private void BtnAddFaculty_Click(object sender, EventArgs e)
        {
            using (AddFacultyForm addForm = new AddFacultyForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO Faculty 
                               (faculty_id, faculty_name, title, office, phone, college, email) 
                               VALUES (@Id, @Name, @Title, @Office, @Phone, @College, @Email)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", addForm.FacultyId);
                            cmd.Parameters.AddWithValue("@Name", addForm.FacultyName);
                            cmd.Parameters.AddWithValue("@Title", addForm.FacultyTitle);
                            cmd.Parameters.AddWithValue("@Office", addForm.FacultyOffice);
                            cmd.Parameters.AddWithValue("@Phone", addForm.FacultyPhone);
                            cmd.Parameters.AddWithValue("@College", addForm.FacultyCollege);
                            cmd.Parameters.AddWithValue("@Email", addForm.FacultyEmail);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadFacultyFromDatabase(); // 重新載入 DataGridView
                }
            }
        }

        private void BtnEditFaculty_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆 Faculty 資料");
                return;
            }

            DataGridViewRow row = dgvFaculty.SelectedRows[0];

            string id = row.Cells["faculty_id"].Value.ToString();
            string name = row.Cells["faculty_name"].Value?.ToString();
            string title = row.Cells["title"].Value?.ToString();
            string office = row.Cells["office"].Value?.ToString();
            string phone = row.Cells["phone"].Value?.ToString();
            string college = row.Cells["college"].Value?.ToString();
            string email = row.Cells["email"].Value?.ToString();

            using (AddFacultyForm editForm = new AddFacultyForm(id, name, title, office, phone, college, email))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"UPDATE Faculty 
                               SET 
                                   faculty_id = @id,
                                   faculty_name = @Name, 
                                   title = @Title, 
                                   office = @Office, 
                                   phone = @Phone, 
                                   college = @College, 
                                   email = @Email
                               WHERE faculty_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", editForm.FacultyId);
                            cmd.Parameters.AddWithValue("@Name", editForm.FacultyName);
                            cmd.Parameters.AddWithValue("@Title", editForm.FacultyTitle);
                            cmd.Parameters.AddWithValue("@Office", editForm.FacultyOffice);
                            cmd.Parameters.AddWithValue("@Phone", editForm.FacultyPhone);
                            cmd.Parameters.AddWithValue("@College", editForm.FacultyCollege);
                            cmd.Parameters.AddWithValue("@Email", editForm.FacultyEmail);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadFacultyFromDatabase();
                    MessageBox.Show("資料已更新！");
                }
            }
        }

        private void BtnDeleteFaculty_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆資料");
                return;
            }

            // 取得 faculty_id
            string facultyId = dgvFaculty.SelectedRows[0].Cells["faculty_id"].Value.ToString();

            // 確認刪除
            DialogResult dr = MessageBox.Show($"確定要刪除 Faculty ID {facultyId} 嗎？",
                                              "刪除確認",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Faculty WHERE faculty_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", facultyId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // 重新載入 DataGridView
                LoadFacultyFromDatabase();
                MessageBox.Show("刪除成功！");
            }
        }

        private void BtnUploadFacultyPic_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆 Faculty 資料");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    byte[] imgBytes = System.IO.File.ReadAllBytes(filePath);

                    // 預覽圖片
                    pbFaculty.Image = Image.FromFile(filePath);

                    // 找 faculty_id
                    string facultyId = dgvFaculty.SelectedRows[0].Cells["faculty_id"].Value.ToString();

                    // 更新到資料庫
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE Faculty SET fimage = @fimage WHERE faculty_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@fimage", SqlDbType.VarBinary).Value = imgBytes;
                            cmd.Parameters.AddWithValue("@Id", facultyId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadFacultyFromDatabase();
                    MessageBox.Show("圖片已成功上傳到資料庫！");
                }
            }
        }

    }
}
