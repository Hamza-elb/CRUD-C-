using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    class DbStudent
    {
        public static MySqlConnection GetConnection()
        {
            string sql = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

                
               // "datasource=localhost;port=3306;username=root;password=;database=studentsharp";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return con;
        }

        // Insert Students
        public static void AddStudent(Student std)
        {
            string sql = "INSERT INTO student_table VALUES (NULL, @StudentName, @StudentGender, @StudentClass, @StudentSection, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentGender", MySqlDbType.VarChar).Value = std.Gender;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        // Update Students

        public static void UpdateStudent(Student std, string id )
        {
            string sql = "UPDATE student_table SET Name = @StudentName, Gender = @StudentGender, Class = @StudentClass, Section = @StudentSection WHERE ID = @StudentID ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentGender", MySqlDbType.VarChar).Value = std.Gender;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        // Delete Students

        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM  student_table WHERE ID = @StudentID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        // Search

        public static void DisplayAndSearch(string query,DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }
    }
}
