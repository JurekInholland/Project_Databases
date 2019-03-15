using SomerenLogic;
using SomerenModel;
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
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Lecturers.Hide();


                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Lecturers.Hide();

                // show students
                pnl_Students.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                //add columns 
                listViewStudents.Columns.Add("Student number");
                listViewStudents.Columns[0].Width = 100;
                listViewStudents.Columns.Add("First name");
                listViewStudents.Columns[1].Width = 100;
                listViewStudents.Columns.Add("Last name");
                listViewStudents.Columns[2].Width = 100;

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Number.ToString());
                    li.SubItems.Add(s.FirstName);
                    li.SubItems.Add(s.LastName);
                    listViewStudents.Items.Add(li);
                }
            }

            else if (panelName == "Lecturers")
            {
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();

                pnl_Lecturers.Show();
                listViewLecturers.Clear();

                //add columns 
                listViewLecturers.Columns.Add("Lecturer ID");
                listViewLecturers.Columns[0].Width = 100;
                listViewLecturers.Columns.Add("Name");
                listViewLecturers.Columns[1].Width = 100;
                listViewLecturers.Columns.Add("Speciality");
                listViewLecturers.Columns[2].Width = 100;

                // fill the lecturers listview within the lecturers panel with a list of lecturers
                SomerenLogic.Lecturer_Service lecService = new SomerenLogic.Lecturer_Service();
                List<Teacher> lecturerList = lecService.GetTeachers();

                foreach (SomerenModel.Teacher t in lecturerList)
                {

                    ListViewItem li = new ListViewItem(t.Number.ToString());
                    li.SubItems.Add(t.Name);
                    li.SubItems.Add(t.Speciality);
                    listViewLecturers.Items.Add(li);
                }
            }

         }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

    }
}
