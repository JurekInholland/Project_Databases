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

        /// <summary>
        /// Hide every panel
        /// </summary>
        private void HideAllPanels()
        {
            pnl_Students.Hide();
            pnl_Lecturers.Hide();

            pnl_Dashboard.Hide();

            pnl_Drinks.Hide();
            pnl_UpdateDrinks.Hide();

            pnl_Report.Hide();
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

                pnl_Report.Hide();
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

            else if (panelName == "Revenue Report")
            {

                HideAllPanels();

                SomerenLogic.Report_Service reportService = new SomerenLogic.Report_Service();
                List<Report> reportsList = reportService.GetReports();

                pnl_Report.Show();
            }
            else if (panelName == "Activities")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Lecturers.Hide();
                //pnl_RevenueReport.Hide();
                pnl_Students.Hide();

                // show students
                pnl_Activities.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
                List<Activity> studentList = actService.GetActivities();

                // clear the listview before filling it again
                listViewActivities.Clear();

                //add columns 
                listViewActivities.Columns.Add("activity_id");
                listViewActivities.Columns[0].Width = 100;
                listViewActivities.Columns.Add("name");
                listViewActivities.Columns[1].Width = 100;
                listViewActivities.Columns.Add("number of students");
                listViewActivities.Columns[2].Width = 100;
                listViewActivities.Columns.Add("number of supervisors");
                listViewActivities.Columns[2].Width = 100;

                foreach (SomerenModel.Activity s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.activity_id.ToString());
                    li.SubItems.Add(s.name);
                    li.SubItems.Add(s.numberofstudents.ToString());
                    li.SubItems.Add(s.numberofsupervisors.ToString());

                    listViewActivities.Items.Add(li);
                }
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

        /// <summary>
        /// Gets called when the user selects a range of dates with the revenue calendar.
        /// </summary>
        private void cal_Report_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime startDate = e.Start;
            DateTime endDate = e.End;

            DateTime currentDate = DateTime.Now;

            
            int compareStart = DateTime.Compare(startDate, currentDate);
            int compareEnd = DateTime.Compare(endDate, currentDate);

            if (compareStart == -1 && compareEnd == -1)
            {
                lbl_RevTimeframe.Text = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();


                // Fills the model with purchases within the indicated range.
                purchaseTableAdapter.FillWithinRange(pdbe37DataSet.Purchase, endDate, startDate);

                int countWithinRange = 0;
                int turnover = 0;
                int studentCount = 0;

                if (purchaseTableAdapter.TotalDrinksWithinRange(endDate, startDate) > 0)
                {
                    countWithinRange = (int)purchaseTableAdapter.TotalDrinksWithinRange(endDate, startDate);

                }
                else
                {
                    countWithinRange = 0;
                }

                if (purchaseTableAdapter.TurnoverWithinRange(endDate, startDate) > 0)
                {
                    turnover = (int)purchaseTableAdapter.TurnoverWithinRange(endDate, startDate);

                }
                else
                {
                    turnover = 0;
                }

                if (purchaseTableAdapter.StudentCountWithinRange(endDate, startDate) > 0)
                {
                    studentCount = (int)purchaseTableAdapter.StudentCountWithinRange(endDate, startDate);
                }
                else
                {
                    studentCount = 0;
                }

                lblCount.Text = countWithinRange.ToString();
                lblTurnover.Text = turnover.ToString();
                lblCustomers.Text = studentCount.ToString();
            }
            else
            {
                lbl_RevTimeframe.Text = "Please select a past date!";
            }
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Revenue Report");
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            Activity activity = new Activity()
            {
                name = txtname.Text,
                numberofstudents = int.Parse(txtnrstud.Text),
                numberofsupervisors = int.Parse(txtnrsup.Text)

            };


            activity_Service.AddActivity(activity);

            showPanel("Activities");

            txtname.Clear();
            txtnrstud.Clear();
            txtnrsup.Clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            Activity activity = new Activity()
            {
                activity_id = int.Parse(txt_activity_id.Text),
                name = txtname.Text,
                numberofstudents = int.Parse(txtnrstud.Text),
                numberofsupervisors = int.Parse(txtnrsup.Text)

            };


            activity_Service.EditActivity(activity);

            showPanel("Activities");

            txtname.Clear();
            txtnrstud.Clear();
            txtnrsup.Clear();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            Activity activity = new Activity()
            {
                activity_id = int.Parse(txt_activity_id.Text),
                name = txtname.Text,
                numberofstudents = int.Parse(txtnrstud.Text),
                numberofsupervisors = int.Parse(txtnrsup.Text)

            };


            activity_Service.RemoveActivity(activity);

            showPanel("Activities");

            txtname.Clear();
            txtnrstud.Clear();
            txtnrsup.Clear();
        }
    }
}
