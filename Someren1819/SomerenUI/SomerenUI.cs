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
            pnl_Timetable.Hide();
            pnl_Supervisor.Hide();
            pnl_Activities.Hide();

        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            // Display a login form before main ui is loaded
            // credit: https://stackoverflow.com/a/3507941
            DialogResult result;
            using (var loginForm = new LoginForm())
                result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // login was successful, proceed with setup
                drinkTableAdapter.Fill(pdbe37DataSet.Drink);
                HideAllPanels();
                showPanel("Dashboard");
            } else
            {
                // If so login window is closed without providing correct credentials,
                // close the application.
                Application.Exit();
            }
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                HideAllPanels();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();

            }
            else if (panelName == "Students")
            {
                // hide all other panels
                HideAllPanels();

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
                HideAllPanels();

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
                HideAllPanels();
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
                HideAllPanels();
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
            else if (panelName == "Supervisors")
            {
                HideAllPanels();

                //show panel
                pnl_Supervisor.Show();
                listViewSupervisors.Clear();

                DisplayAddCB();
                DisplayRemoveCB();

                SomerenLogic.Supervisor_Service supservice = new SomerenLogic.Supervisor_Service();
                List<Supervisor> supList = supservice.GetSupervisors();

                //Add columns
                listViewSupervisors.View = View.Details;
                listViewSupervisors.Columns.Add("Lecturer ID");
                listViewSupervisors.Columns[0].Width = 80;
                listViewSupervisors.Columns.Add("Name");
                listViewSupervisors.Columns[1].Width = 120;

                foreach (SomerenModel.Supervisor s in supList)
                {
                    ListViewItem li = new ListViewItem(s.SupervisorID.ToString());
                    li.SubItems.Add(s.Name);
                    listViewSupervisors.Items.Add(li);
                }

            }

            else if (panelName == "Time Table")
            {

                HideAllPanels();
                clearTimetable();
                SomerenLogic.Timetable_Service ttService = new SomerenLogic.Timetable_Service();
                List<Activity> activities = ttService.GetTimetableData();

                Dictionary<int, string> teacherNames = ttService.GetTeacherNames();

                // Sort activities by day
                DateTime actdate = activities[0].date;
                foreach (Activity act in activities)
                {
                    //int teacher1Id = (int)act.supervisor1;
                    string t1name = TeacherLookup(teacherNames, act.supervisor1);
                    string t2name = TeacherLookup(teacherNames, act.supervisor2);

                    // Check if no supervisor is assigned
                    if (t1name == "" && t2name == "")
                    {
                        t1name = "UNSUPERVISED!";
                    }

                    string day = act.date.DayOfWeek.ToString();
                    int month = act.date.Month;
                    int year = act.date.Year;

                    // Only check activities that are within the correct year and month.
                    if ( year == 2016 && month == 4)
                    {
                        // Create a list view item
                        string time = act.date.ToString("H:mm");
                        ListViewItem item = new ListViewItem(time);
                        item.SubItems.Add(act.name);
                        item.SubItems.Add(t1name);
                        item.SubItems.Add(t2name);

                        // Switch case that filters activities by weekday. Since only monday and tuesday are relevant,
                        // those values are hardcoded as well.
                        switch (day)
                        {
                            case "Monday":
                                lv_mon.Items.Add(item);
                                break;

                            case "Tuesday":
                                lv_tue.Items.Add(item);
                                break;
                        }
                    } 
                }
                SetColumnSizes();
                pnl_Timetable.Show();
            }

        }

        private void clearTimetable()
        {
            lv_mon.Items.Clear();
            lv_tue.Items.Clear();
        }

        private void SetDayDates()
        {

        }

        private void SetColumnSizes()
        {
            lv_mon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_mon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lv_tue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_tue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lv_wed.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_wed.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lv_thur.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_thur.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lv_fri.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv_fri.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private string TeacherLookup(Dictionary<int, string> teachers, int teacherId)
        {

            if (teachers.TryGetValue(teacherId, out string teacherName))
            {
                return teacherName;
            }
            return "";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SomerenDAL.Supervisor_DAO superv = new SomerenDAL.Supervisor_DAO();

            //to compare values in the lists to prevent from adding already existing supervisor
            var listItems = listViewSupervisors.Items.Cast<ListViewItem>();
            foreach (ListViewItem lview in listItems)
            {
                if (cbAdd.Text == lview.Text)
                {
                    MessageBox.Show("This teacher is already a supervisor.", "Warning", MessageBoxButtons.OK);
                    return;
                }
            }
            superv.AddSup(cbAdd.Text);
            cbAdd.ResetText();

            //to reniew the page
            showPanel("Supervisors");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove this supervisor?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SomerenDAL.Supervisor_DAO supervisor = new SomerenDAL.Supervisor_DAO();
                supervisor.RemoveSup(cbRemove.Text);
                showPanel("Supervisors");
                cbRemove.ResetText();
            }
        }
        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        //dispaly the content in CB
        void DisplayAddCB()
        {
            SomerenLogic.Lecturer_Service lecturer = new Lecturer_Service();
            //getting the teachers and put them in this list
            List<Teacher> listLecturers = lecturer.GetTeachers();

            cbAdd.Items.Clear();

            //adding them into the CB 
            foreach (SomerenModel.Teacher teacher in listLecturers)
            {

                if (teacher != null)
                {
                    cbAdd.Items.Add(teacher.Number);
                }
            }
        }
        //same but for the other CB
        void DisplayRemoveCB()
        {
            SomerenLogic.Supervisor_Service sup = new Supervisor_Service();
            //getting the teachers and put them in this list
            List<Supervisor> listSupervisors = sup.GetSupervisors();

            cbRemove.Items.Clear();

            //adding them into the CB 
            foreach (SomerenModel.Supervisor teacher in listSupervisors)
            {
                if (teacher != null)
                {
                    cbRemove.Items.Add(teacher.SupervisorID);
                }
            }
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Time Table");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
    }
}
