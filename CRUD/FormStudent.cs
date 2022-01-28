using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public string id, name, gender, @class, section;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void Clear()
        {
            txtName.Text = txtGender.Text = txtClass.Text = txtSection.Text = string.Empty;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtGender.Text = gender;
            txtClass.Text = @class;
            txtSection.Text = section;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student is Empty ( > 3 )");
                return;
            }

            if (txtGender.Text.Trim().Length < 3)
            {
                MessageBox.Show("Gender is Empty ( > 3 )");
                return;
            }

            if (txtClass.Text.Trim().Length ==  0)
            {
                MessageBox.Show("Student Class  is Empty ( > 1 )");
                return;
            }

            if (txtSection.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Section  is Empty ( > 1 )");
                return;
            }

            if(btnSave.Text == "Save")
            {
                Student std = new Student(txtName.Text.Trim(), txtGender.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());

                DbStudent.AddStudent(std);

                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtGender.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.UpdateStudent(std, id);
            }
            _parent.Display();
        }
    }
}
