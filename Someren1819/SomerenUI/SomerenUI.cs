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
            drinkTableAdapter.Fill(pdbe37DataSet.Drink);
       
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Lecturers.Hide();

                pnl_Drinks.Hide();
                pnl_UpdateDrinks.Hide();

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
                // Hide other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();

                // Show lecturers panel; clear listView
                pnl_Lecturers.Show();
                listViewLecturers.Clear();

                // Add columns 
                listViewLecturers.Columns.Add("Lecturer ID");
                listViewLecturers.Columns[0].Width = 100;
                listViewLecturers.Columns.Add("First Name");
                listViewLecturers.Columns[1].Width = 100;
                listViewLecturers.Columns.Add("Last Name");
                listViewLecturers.Columns[2].Width = 100;
                listViewLecturers.Columns.Add("Is Supervisor");
                listViewLecturers.Columns[3].Width = 100;

                // Fill the lecturers listview within the lecturers panel with a list of lecturers
                SomerenLogic.Lecturer_Service lecService = new SomerenLogic.Lecturer_Service();
                List<Teacher> lecturerList = lecService.GetTeachers();

                // Iterate over teachers
                foreach (SomerenModel.Teacher t in lecturerList)
                {

                    ListViewItem li = new ListViewItem(t.Number.ToString());
                    li.SubItems.Add(t.FirstName);
                    li.SubItems.Add(t.LastName);

                    // Parse supervisor status which is either 0 or 1.
                    if (t.Supervisor == 1)
                    {
                        li.SubItems.Add("Yes");
                    } else
                    {
                        li.SubItems.Add("No");
                    }
                    listViewLecturers.Items.Add(li);
                }
            }
            else if (panelName == "Drinks Supplies")
            {
                // Hide other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                //pnl_RevenueReport.Hide();
                pnl_Lecturers.Hide();
                pnl_UpdateDrinks.Hide();

                //Show the panel 
                pnl_Drinks.Show();
                listViewDrinks.Clear();

                //Add columns
                listViewDrinks.Columns.Add("Drink");
                listViewDrinks.Columns[0].Width = 100;
                listViewDrinks.Columns.Add("Token");
                listViewDrinks.Columns[1].Width = 100;
                listViewDrinks.Columns.Add("Stock");
                listViewDrinks.Columns[2].Width = 100;
                listViewDrinks.Columns.Add("Amount");
                listViewDrinks.Columns[3].Width = 50;

                // Fill the lecturers listview within the lecturers panel with a list of lecturers
                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
                List<Drink> drinksList = drinkService.GetDrinks();

                foreach (SomerenModel.Drink d in drinksList)
                {

                    ListViewItem li = new ListViewItem(d.Name);
                    li.SubItems.Add(d.Token.ToString());
                    li.SubItems.Add(d.Stock.ToString());
                    d.Amount = d.Stock;

                    //listing the sufficiency
                    if (d.Amount >= 10)
                    {
                        li.SubItems.Add("✔️");
                    }
                    else
                    {
                        li.SubItems.Add("⚠️");

                    }
                    li.SubItems.Add(d.DrinksSold.ToString());


                    listViewDrinks.Items.Add(li);
                }
            }
            else if (panelName == "Edit drinks")
            {
                // Hide other panels
                //pnl_Dashboard.Hide();
                //img_Dashboard.Hide();
                //pnl_Students.Hide();
                //pnl_Lecturers.Hide();
                pnl_Drinks.Hide();

                //show panel
                pnl_UpdateDrinks.Show();

            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void drinksSuppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks Supplies");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //using the adapter to update and save the changes to the database
            this.drinkTableAdapter.Update(pdbe37DataSet);

            //show the panel

            showPanel("Drinks Supplies");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            showPanel("Edit drinks");
        }
        //using the adapter to fill the database into datagridview
        private void DataGridViewDirectDBUpdate_Load(object sender, EventArgs e)
        {
            this.drinkTableAdapter.Fill(this.pdbe37DataSet.Drink);
            MessageBox.Show("TEST");
        }

        private void dataGridViewUpdate_Load(object sender, DataGridViewCellEventArgs e)
        {
            this.drinkTableAdapter.Fill(this.pdbe37DataSet.Drink);

        }


    }
}
