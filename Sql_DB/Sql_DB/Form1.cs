using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Sql_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string cname = tbcName.Text;
            string ccode = tbcCode.Text;

            var conn = Database.ConnectDatabase();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = string.Format("insert into sql_DB values ('{0}','{1}')", cname, ccode);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show(" Course Inserted ");
                }
                else
                {
                    MessageBox.Show(" insert Failed ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            RefreshControls();

            var courses = GetAllCourses();
            dtView.DataSource = courses;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            var courses = GetAllCourses();
            dtView.DataSource = courses;
        }

        List<Course> GetAllCourses()
        {
            var conn = Database.ConnectDatabase();
            List<Course> courses = new List<Course>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = "select * from sql_DB";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course c = new Course();
                    c.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    c.CourseName = reader.GetString(reader.GetOrdinal("CourseName"));
                    c.CourseCode = reader.GetString(reader.GetOrdinal("CourseCode"));
                    courses.Add(c);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return courses;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var courses = GetAllCourses();
            dtView.DataSource = courses;
        }

        void RefreshControls()
        {
            tbcCode.Text = "";
            tbcName.Text = "";
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            var conn = Database.ConnectDatabase();
            conn.Open();
            int id = Int32.Parse(tbcId.Text);
            string query = "select * from sql_DB where id = " + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Course c = new Course();

            while (reader.Read())
            {
                c.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                c.CourseCode = reader.GetString(reader.GetOrdinal("CourseCode"));
                c.CourseName = reader.GetString(reader.GetOrdinal("CourseName"));

            }
            conn.Close();
            tbcCodeUpdate.Text = c.CourseCode;
            tbcNameUpdate.Text = c.CourseName;
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(tbcId.Text); ;
            string cCode = tbcCodeUpdate.Text.Trim();
            string cName = tbcNameUpdate.Text;

            var conn = Database.ConnectDatabase();
            conn.Open();
            string query = string.Format("update sql_DB set CourseName='{0}',CourseCode='{1}' where id={2}", cName, cCode, id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            var courses = GetAllCourses();
            dtView.DataSource = courses;
        }

        
    }
}
