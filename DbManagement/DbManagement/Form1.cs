using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DbManagement
{
    public class AddStudentForm : Form
    {
        public string StudentId { get; private set; }
        public string StudentName { get; private set; }
        public string StudentGpa { get; private set; }
        public string StudentCredits { get; private set; }
        public string StudentMajor { get; private set; }
        public string StudentYear { get; private set; }
        public string StudentEmail { get; private set; }

        private TextBox txtId = new TextBox();
        private TextBox txtName = new TextBox();
        private TextBox txtGpa = new TextBox();
        private TextBox txtCredits = new TextBox();
        private TextBox txtMajor = new TextBox();
        private TextBox txtYear = new TextBox();
        private TextBox txtEmail = new TextBox();
        private Button btnOK = new Button();
        private Button btnCancel = new Button();

        // 建構子 (新增用)
        public AddStudentForm()
        {
            InitForm();
        }

        // 建構子 (編輯用)
        public AddStudentForm(string id, string name, string gpa, string credits,
                              string major, string year, string email)
        {
            InitForm();

            txtId.Text = id;
            txtId.ReadOnly = true; // 編輯時 ID 不允許修改
            txtName.Text = name;
            txtGpa.Text = gpa;
            txtCredits.Text = credits;
            txtMajor.Text = major;
            txtYear.Text = year;
            txtEmail.Text = email;
        }

        private void InitForm()
        {
            this.Text = "Add / Edit Student";
            this.Size = new Size(400, 400);

            int labelX = 10, textX = 120, y = 20, gap = 40;

            Label lblId = new Label { Text = "Student ID:", Location = new Point(labelX, y) };
            txtId.Location = new Point(textX, y);
            y += gap;

            Label lblName = new Label { Text = "Name:", Location = new Point(labelX, y) };
            txtName.Location = new Point(textX, y);
            y += gap;

            Label lblGpa = new Label { Text = "GPA:", Location = new Point(labelX, y) };
            txtGpa.Location = new Point(textX, y);
            y += gap;

            Label lblCredits = new Label { Text = "Credits:", Location = new Point(labelX, y) };
            txtCredits.Location = new Point(textX, y);
            y += gap;

            Label lblMajor = new Label { Text = "Major:", Location = new Point(labelX, y) };
            txtMajor.Location = new Point(textX, y);
            y += gap;

            Label lblYear = new Label { Text = "School Year:", Location = new Point(labelX, y) };
            txtYear.Location = new Point(textX, y);
            y += gap;

            Label lblEmail = new Label { Text = "Email:", Location = new Point(labelX, y) };
            txtEmail.Location = new Point(textX, y);
            y += gap;

            btnOK.Text = "OK";
            btnOK.Location = new Point(80, y + 20);
            btnOK.Click += BtnOK_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(180, y + 20);
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblGpa);
            this.Controls.Add(txtGpa);
            this.Controls.Add(lblCredits);
            this.Controls.Add(txtCredits);
            this.Controls.Add(lblMajor);
            this.Controls.Add(txtMajor);
            this.Controls.Add(lblYear);
            this.Controls.Add(txtYear);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            StudentId = txtId.Text.Trim();
            StudentName = txtName.Text.Trim();
            StudentGpa = txtGpa.Text.Trim();
            StudentCredits = txtCredits.Text.Trim();
            StudentMajor = txtMajor.Text.Trim();
            StudentYear = txtYear.Text.Trim();
            StudentEmail = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(StudentId) || string.IsNullOrEmpty(StudentName))
            {
                MessageBox.Show("ID 與 Name 為必填！");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class StudentCourseForm : Form
    {
        // 控制項
        private Label lblSCourseId, lblStudentId, lblCourseId, lblCredit, lblMajor;
        private TextBox txtSCourseId, txtStudentId, txtCourseId, txtCredit, txtMajor;
        private Button btnOK, btnCancel;

        // 對外公開屬性
        public string SCourseId => txtSCourseId.Text.Trim();
        public string StudentId => txtStudentId.Text.Trim();
        public string CourseId => txtCourseId.Text.Trim();
        public string Credit => txtCredit.Text.Trim();
        public string Major => txtMajor.Text.Trim();

        // 新增模式建構子
        public StudentCourseForm()
        {
            InitializeComponent();
        }

        // 編輯模式建構子
        public StudentCourseForm(string sCourseId, string studentId, string courseId, string credit, string major)
        {
            InitializeComponent();

            txtSCourseId.Text = sCourseId;
            txtSCourseId.ReadOnly = true; // 主鍵不可編輯
            txtStudentId.Text = studentId;
            txtCourseId.Text = courseId;
            txtCredit.Text = credit;
            txtMajor.Text = major;
        }

        private void InitializeComponent()
        {
            this.Text = "StudentCourse Form";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;

            lblSCourseId = new Label() { Text = "SCourse ID:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            txtSCourseId = new TextBox() { Location = new System.Drawing.Point(120, 20), Width = 200 };

            lblStudentId = new Label() { Text = "Student ID:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            txtStudentId = new TextBox() { Location = new System.Drawing.Point(120, 60), Width = 200 };

            lblCourseId = new Label() { Text = "Course ID:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            txtCourseId = new TextBox() { Location = new System.Drawing.Point(120, 100), Width = 200 };

            lblCredit = new Label() { Text = "Credit:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            txtCredit = new TextBox() { Location = new System.Drawing.Point(120, 140), Width = 200 };

            lblMajor = new Label() { Text = "Major:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            txtMajor = new TextBox() { Location = new System.Drawing.Point(120, 180), Width = 200 };

            btnOK = new Button() { Text = "OK", Location = new System.Drawing.Point(70, 220), Size = new System.Drawing.Size(100, 30) };
            btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(200, 220), Size = new System.Drawing.Size(100, 30) };

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblSCourseId);
            this.Controls.Add(txtSCourseId);
            this.Controls.Add(lblStudentId);
            this.Controls.Add(txtStudentId);
            this.Controls.Add(lblCourseId);
            this.Controls.Add(txtCourseId);
            this.Controls.Add(lblCredit);
            this.Controls.Add(txtCredit);
            this.Controls.Add(lblMajor);
            this.Controls.Add(txtMajor);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SCourseId) ||
                string.IsNullOrWhiteSpace(StudentId) ||
                string.IsNullOrWhiteSpace(CourseId))
            {
                MessageBox.Show("SCourse ID, Student ID, and Course ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }


    public class CourseForm : Form
    {
        // 控制項
        private Label lblCourseId, lblCourseName, lblCredit, lblClassroom, lblSchedule, lblEnrollment, lblFacultyId;
        private TextBox txtCourseId, txtCourseName, txtCredit, txtClassroom, txtSchedule, txtEnrollment, txtFacultyId;
        private Button btnOK, btnCancel;

        // 對外公開屬性
        public string CourseId => txtCourseId.Text.Trim();
        public string CourseName => txtCourseName.Text.Trim();
        public string Credit => txtCredit.Text.Trim();
        public string Classroom => txtClassroom.Text.Trim();
        public string Schedule => txtSchedule.Text.Trim();
        public string Enrollment => txtEnrollment.Text.Trim();
        public string FacultyId => txtFacultyId.Text.Trim();

        // 新增模式建構子
        public CourseForm()
        {
            InitializeComponent();
        }

        // 編輯模式建構子
        public CourseForm(string courseId, string courseName, string credit, string classroom, string schedule, string enrollment, string facultyId)
        {
            InitializeComponent();

            txtCourseId.Text = courseId;
            txtCourseId.ReadOnly = true; // 主鍵不可編輯
            txtCourseName.Text = courseName;
            txtCredit.Text = credit;
            txtClassroom.Text = classroom;
            txtSchedule.Text = schedule;
            txtEnrollment.Text = enrollment;
            txtFacultyId.Text = facultyId;
        }

        private void InitializeComponent()
        {
            this.Text = "Course Form";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            lblCourseId = new Label() { Text = "Course ID:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            txtCourseId = new TextBox() { Location = new System.Drawing.Point(120, 20), Width = 200 };

            lblCourseName = new Label() { Text = "Course Name:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            txtCourseName = new TextBox() { Location = new System.Drawing.Point(120, 60), Width = 200 };

            lblCredit = new Label() { Text = "Credit:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            txtCredit = new TextBox() { Location = new System.Drawing.Point(120, 100), Width = 200 };

            lblClassroom = new Label() { Text = "Classroom:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            txtClassroom = new TextBox() { Location = new System.Drawing.Point(120, 140), Width = 200 };

            lblSchedule = new Label() { Text = "Schedule:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            txtSchedule = new TextBox() { Location = new System.Drawing.Point(120, 180), Width = 200 };

            lblEnrollment = new Label() { Text = "Enrollment:", Location = new System.Drawing.Point(20, 220), AutoSize = true };
            txtEnrollment = new TextBox() { Location = new System.Drawing.Point(120, 220), Width = 200 };

            lblFacultyId = new Label() { Text = "Faculty ID:", Location = new System.Drawing.Point(20, 260), AutoSize = true };
            txtFacultyId = new TextBox() { Location = new System.Drawing.Point(120, 260), Width = 200 };

            btnOK = new Button() { Text = "OK", Location = new System.Drawing.Point(70, 310), Size = new System.Drawing.Size(100, 30) };
            btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(200, 310), Size = new System.Drawing.Size(100, 30) };

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(lblCourseId);
            this.Controls.Add(txtCourseId);
            this.Controls.Add(lblCourseName);
            this.Controls.Add(txtCourseName);
            this.Controls.Add(lblCredit);
            this.Controls.Add(txtCredit);
            this.Controls.Add(lblClassroom);
            this.Controls.Add(txtClassroom);
            this.Controls.Add(lblSchedule);
            this.Controls.Add(txtSchedule);
            this.Controls.Add(lblEnrollment);
            this.Controls.Add(txtEnrollment);
            this.Controls.Add(lblFacultyId);
            this.Controls.Add(txtFacultyId);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // 基本驗證
            if (string.IsNullOrWhiteSpace(CourseId) || string.IsNullOrWhiteSpace(CourseName))
            {
                MessageBox.Show("Course ID and Course Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

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
        public string connectionString = "Data Source=Ping;Initial Catalog=CSIE_Db;Integrated Security=True;Trust Server Certificate=True";
        public Form1()
        {
            InitializeComponent();
            InitializeFacultyData();
            InitializeStudentTab();
            InitializeCourseAndStudentCourseTabs(); // <-- 這行必須加

            LoadFacultyFromDatabase();
            LoadStudentFromDatabase();
            LoadCourseFromDatabase();
            LoadStudentCourseFromDatabase();
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
        // ===== Student Tab =====
        private TabPage tabStudent;
        private DataGridView dgvStudent;
        private Button btnAddStudent;
        private Button btnEditStudent;
        private Button btnDeleteStudent;
        private PictureBox pbStudent;
        private Button btnUploadStudentPic;

        private void InitializeStudentTab()
        {
            this.tabStudent = new TabPage();
            this.dgvStudent = new DataGridView();
            this.btnAddStudent = new Button();
            this.btnEditStudent = new Button();
            this.btnDeleteStudent = new Button();
            this.pbStudent = new PictureBox();
            this.btnUploadStudentPic = new Button();

            this.tabStudent.Text = "Student";
            this.tabStudent.Controls.Add(this.dgvStudent);
            this.tabStudent.Controls.Add(this.btnAddStudent);
            this.tabStudent.Controls.Add(this.btnEditStudent);
            this.tabStudent.Controls.Add(this.btnDeleteStudent);
            this.tabStudent.Controls.Add(this.pbStudent);
            this.tabStudent.Controls.Add(this.btnUploadStudentPic);

            // DataGridView
            this.dgvStudent.Location = new Point(10, 10);
            this.dgvStudent.Size = new Size(750, 400);
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.RowTemplate.Height = 30;
            this.dgvStudent.SelectionChanged += DgvStudent_SelectionChanged;

            // PictureBox
            this.pbStudent.Location = new Point(770, 10);
            this.pbStudent.Size = new Size(180, 180);
            this.pbStudent.BorderStyle = BorderStyle.FixedSingle;
            this.pbStudent.SizeMode = PictureBoxSizeMode.Zoom;

            // Upload Photo Button
            this.btnUploadStudentPic.Location = new Point(770, 200);
            this.btnUploadStudentPic.Size = new Size(180, 40);
            this.btnUploadStudentPic.Text = "Upload Photo";
            this.btnUploadStudentPic.Click += BtnUploadStudentPic_Click;

            // Add Button
            this.btnAddStudent.Location = new Point(10, 420);
            this.btnAddStudent.Size = new Size(100, 40);
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.Click += BtnAddStudent_Click;

            // Edit Button
            this.btnEditStudent.Location = new Point(120, 420);
            this.btnEditStudent.Size = new Size(100, 40);
            this.btnEditStudent.Text = "Edit";
            this.btnEditStudent.Click += BtnEditStudent_Click;

            // Delete Button
            this.btnDeleteStudent.Location = new Point(230, 420);
            this.btnDeleteStudent.Size = new Size(100, 40);
            this.btnDeleteStudent.Text = "Delete";
            this.btnDeleteStudent.Click += BtnDeleteStudent_Click;

            // 加入到 TabControl
            this.tabControl1.Controls.Add(this.tabStudent);
        }

        // 載入 Student 資料
        private void LoadStudentFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Student";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            dgvStudent.DataSource = dt;
        }

        // DataGridView 選擇改變 → 顯示照片
        private void DgvStudent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
            {
                pbStudent.Image = null;
                return;
            }

            string studentId = dgvStudent.SelectedRows[0].Cells["student_id"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT simage FROM Student WHERE student_id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        byte[] imgBytes = (byte[])result;
                        using (var ms = new System.IO.MemoryStream(imgBytes))
                        {
                            pbStudent.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbStudent.Image = null;
                    }
                }
            }
        }

        // 新增 Student
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            using (AddStudentForm addForm = new AddStudentForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO Student 
                               (student_id, student_name, gpa, credits, major, schoolYear, email) 
                               VALUES (@Id, @Name, @Gpa, @Credits, @Major, @Year, @Email)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", addForm.StudentId);
                            cmd.Parameters.AddWithValue("@Name", addForm.StudentName);
                            cmd.Parameters.AddWithValue("@Gpa", addForm.StudentGpa);
                            cmd.Parameters.AddWithValue("@Credits", addForm.StudentCredits);
                            cmd.Parameters.AddWithValue("@Major", addForm.StudentMajor);
                            cmd.Parameters.AddWithValue("@Year", addForm.StudentYear);
                            cmd.Parameters.AddWithValue("@Email", addForm.StudentEmail);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadStudentFromDatabase();
                }
            }
        }

        // 編輯 Student
        private void BtnEditStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆 Student 資料");
                return;
            }

            DataGridViewRow row = dgvStudent.SelectedRows[0];

            string id = row.Cells["student_id"].Value.ToString();
            string name = row.Cells["student_name"].Value?.ToString();
            string gpa = row.Cells["gpa"].Value?.ToString();
            string credits = row.Cells["credits"].Value?.ToString();
            string major = row.Cells["major"].Value?.ToString();
            string year = row.Cells["schoolYear"].Value?.ToString();
            string email = row.Cells["email"].Value?.ToString();

            using (AddStudentForm editForm = new AddStudentForm(id, name, gpa, credits, major, year, email))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"UPDATE Student 
                               SET student_name = @Name, gpa = @Gpa, credits = @Credits, 
                                   major = @Major, schoolYear = @Year, email = @Email
                               WHERE student_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", editForm.StudentId);
                            cmd.Parameters.AddWithValue("@Name", editForm.StudentName);
                            cmd.Parameters.AddWithValue("@Gpa", editForm.StudentGpa);
                            cmd.Parameters.AddWithValue("@Credits", editForm.StudentCredits);
                            cmd.Parameters.AddWithValue("@Major", editForm.StudentMajor);
                            cmd.Parameters.AddWithValue("@Year", editForm.StudentYear);
                            cmd.Parameters.AddWithValue("@Email", editForm.StudentEmail);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadStudentFromDatabase();
                    MessageBox.Show("資料已更新！");
                }
            }
        }

        // 刪除 Student
        private void BtnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆資料");
                return;
            }

            string studentId = dgvStudent.SelectedRows[0].Cells["student_id"].Value.ToString();

            DialogResult dr = MessageBox.Show($"確定要刪除 Student ID {studentId} 嗎？",
                                              "刪除確認",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Student WHERE student_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", studentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadStudentFromDatabase();
                MessageBox.Show("刪除成功！");
            }
        }

        // 上傳照片
        private void BtnUploadStudentPic_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇一筆 Student 資料");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    byte[] imgBytes = System.IO.File.ReadAllBytes(filePath);

                    pbStudent.Image = Image.FromFile(filePath);

                    string studentId = dgvStudent.SelectedRows[0].Cells["student_id"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE Student SET simage = @simage WHERE student_id = @Id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@simage", SqlDbType.VarBinary).Value = imgBytes;
                            cmd.Parameters.AddWithValue("@Id", studentId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadStudentFromDatabase();
                    MessageBox.Show("圖片已成功上傳到資料庫！");
                }
            }
        }

        // --- 在 Form1 class 內往下加 ---

        // 宣告控制項
        private TabPage tabCourse, tabStudentCourse;
        private DataGridView dgvCourse, dgvStudentCourse;
        private Button btnAddCourse, btnEditCourse, btnDeleteCourse;
        private Button btnAddStudentCourse, btnEditStudentCourse, btnDeleteStudentCourse;

        // 載入 Course
        private void LoadCourseFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * from Course";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            dgvCourse.DataSource = dt;
        }

        // 載入 StudentCourse
        private void LoadStudentCourseFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * from StudentCourse";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            dgvStudentCourse.DataSource = dt;
        }

        // 初始化 Tab
        private void InitializeCourseAndStudentCourseTabs()
        {
            // ===== Course Tab =====
            tabCourse = new TabPage("Course");
            dgvCourse = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(750, 400),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            btnAddCourse = new Button { Text = "Add", Location = new Point(10, 420), Size = new Size(100, 40) };
            btnEditCourse = new Button { Text = "Edit", Location = new Point(120, 420), Size = new Size(100, 40) };
            btnDeleteCourse = new Button { Text = "Delete", Location = new Point(230, 420), Size = new Size(100, 40) };

            btnAddCourse.Click += BtnAddCourse_Click;
            btnEditCourse.Click += BtnEditCourse_Click;
            btnDeleteCourse.Click += BtnDeleteCourse_Click;

            tabCourse.Controls.Add(dgvCourse);
            tabCourse.Controls.Add(btnAddCourse);
            tabCourse.Controls.Add(btnEditCourse);
            tabCourse.Controls.Add(btnDeleteCourse);

            // ===== StudentCourse Tab =====
            tabStudentCourse = new TabPage("StudentCourse");
            dgvStudentCourse = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(750, 400),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            btnAddStudentCourse = new Button { Text = "Add", Location = new Point(10, 420), Size = new Size(100, 40) };
            btnEditStudentCourse = new Button { Text = "Edit", Location = new Point(120, 420), Size = new Size(100, 40) };
            btnDeleteStudentCourse = new Button { Text = "Delete", Location = new Point(230, 420), Size = new Size(100, 40) };

            btnAddStudentCourse.Click += BtnAddStudentCourse_Click;
            btnEditStudentCourse.Click += BtnEditStudentCourse_Click;
            btnDeleteStudentCourse.Click += BtnDeleteStudentCourse_Click;

            tabStudentCourse.Controls.Add(dgvStudentCourse);
            tabStudentCourse.Controls.Add(btnAddStudentCourse);
            tabStudentCourse.Controls.Add(btnEditStudentCourse);
            tabStudentCourse.Controls.Add(btnDeleteStudentCourse);

            tabControl1.Controls.Add(tabCourse);
            tabControl1.Controls.Add(tabStudentCourse);
        }

        // === Course CRUD ===
        private void BtnAddCourse_Click(object sender, EventArgs e)
        {
            using (CourseForm f = new CourseForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO Course(course_id, course, credit, classroom, schedule, enrollment, faculty_id) 
                               VALUES(@id,@course,@credit,@classroom,@schedule,@enrollment,@faculty_id)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", f.CourseId);
                            cmd.Parameters.AddWithValue("@course", f.CourseName);
                            cmd.Parameters.AddWithValue("@credit", f.Credit);
                            cmd.Parameters.AddWithValue("@classroom", f.Classroom);
                            cmd.Parameters.AddWithValue("@schedule", f.Schedule);
                            cmd.Parameters.AddWithValue("@enrollment", f.Enrollment);
                            cmd.Parameters.AddWithValue("@faculty_id", f.FacultyId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCourseFromDatabase();
                }
            }
        }

        private void BtnEditCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvCourse.SelectedRows[0];
            using (CourseForm f = new CourseForm(
                row.Cells["course_id"].Value.ToString(),
                row.Cells["course"].Value?.ToString(),
                row.Cells["credit"].Value?.ToString(),
                row.Cells["classroom"].Value?.ToString(),
                row.Cells["schedule"].Value?.ToString(),
                row.Cells["enrollment"].Value?.ToString(),
                row.Cells["faculty_id"].Value?.ToString()
            ))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"UPDATE Course SET course=@course, credit=@credit, classroom=@classroom, 
                               schedule=@schedule, enrollment=@enrollment, faculty_id=@faculty_id
                               WHERE course_id=@id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", f.CourseId);
                            cmd.Parameters.AddWithValue("@course", f.CourseName);
                            cmd.Parameters.AddWithValue("@credit", f.Credit);
                            cmd.Parameters.AddWithValue("@classroom", f.Classroom);
                            cmd.Parameters.AddWithValue("@schedule", f.Schedule);
                            cmd.Parameters.AddWithValue("@enrollment", f.Enrollment);
                            cmd.Parameters.AddWithValue("@faculty_id", f.FacultyId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCourseFromDatabase();
                }
            }
        }

        private void BtnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.SelectedRows.Count == 0) return;
            string id = dgvCourse.SelectedRows[0].Cells["course_id"].Value.ToString();
            if (MessageBox.Show($"Delete Course {id}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Course WHERE course_id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCourseFromDatabase();
            }
        }

        // === StudentCourse CRUD ===
        private void BtnAddStudentCourse_Click(object sender, EventArgs e)
        {
            using (StudentCourseForm f = new StudentCourseForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO StudentCourse(s_course_id, student_id, course_id, credit, major) 
                               VALUES(@sid,@stuid,@cid,@credit,@major)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", f.SCourseId);
                            cmd.Parameters.AddWithValue("@stuid", f.StudentId);
                            cmd.Parameters.AddWithValue("@cid", f.CourseId);
                            cmd.Parameters.AddWithValue("@credit", f.Credit);
                            cmd.Parameters.AddWithValue("@major", f.Major);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadStudentCourseFromDatabase();
                }
            }
        }

        private void BtnEditStudentCourse_Click(object sender, EventArgs e)
        {
            if (dgvStudentCourse.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvStudentCourse.SelectedRows[0];

            using (StudentCourseForm f = new StudentCourseForm(
                row.Cells["s_course_id"].Value.ToString(),
                row.Cells["student_id"].Value?.ToString(),
                row.Cells["course_id"].Value?.ToString(),
                row.Cells["credit"].Value?.ToString(),
                row.Cells["major"].Value?.ToString()
            ))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"UPDATE StudentCourse SET student_id=@stuid, course_id=@cid, credit=@credit, major=@major
                               WHERE s_course_id=@sid";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", f.SCourseId);
                            cmd.Parameters.AddWithValue("@stuid", f.StudentId);
                            cmd.Parameters.AddWithValue("@cid", f.CourseId);
                            cmd.Parameters.AddWithValue("@credit", f.Credit);
                            cmd.Parameters.AddWithValue("@major", f.Major);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadStudentCourseFromDatabase();
                }
            }
        }

        private void BtnDeleteStudentCourse_Click(object sender, EventArgs e)
        {
            if (dgvStudentCourse.SelectedRows.Count == 0) return;
            string sid = dgvStudentCourse.SelectedRows[0].Cells["s_course_id"].Value.ToString();
            if (MessageBox.Show($"Delete StudentCourse {sid}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM StudentCourse WHERE s_course_id=@sid";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", sid);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadStudentCourseFromDatabase();
            }
        }

    }
}
