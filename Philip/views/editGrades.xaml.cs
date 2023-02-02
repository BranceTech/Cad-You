using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using Prism.Services.Dialogs;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for editGrades.xaml
    /// </summary>
    public partial class editGrades : UserControl
    {
        DbConnections dbc=new DbConnections();
        public editGrades()
        {
            InitializeComponent();
            autoPopulateGrid();
        }
        private void autoPopulateGrid()
        {
            string query = "select s.student_id as 'Student ID',fname as 'First name', lname as 'Last name', level as 'Class'" +
                ",subject_name as 'Subject name', marks as Marks, grades as Grades " +
                "from grades g inner join student s on g.stud_id=s.student_id " +
                "inner join subject sb on g.subject_id = sb.id";
            dataGridGrades.ItemsSource = dbc.SqlTable(query).DefaultView;
        }
        private bool constraints()
        {
            if (txtTeacherName.Text.Length < 1)
            {
                MessageBox.Show("Field cant be null");
                return false;
            }else if(studentId == string.Empty)
            {
                MessageBox.Show("select the row to update");
                return false;

            }else 
            return true;
        }
        private void updateGrade_Clicked(object sender, RoutedEventArgs e)
        {
          
            bool passed =constraints();
            if (passed){

                string grade = assessGrade(int.Parse(txtTeacherName.Text));
                string query = "update grades set marks='" + txtTeacherName.Text + "', grades='" + grade + "' where " +
                    " stud_id='" + studentId + "'";
                dbc.sqlOperation(query);
                MessageBox.Show("Data successifully updated");
                //refresh datagrid view
                autoPopulateGrid();
            }
        }

        private void deleteData_Clicked(object sender, RoutedEventArgs e)
        {
            string query = "delete from grades where stud_id='" + studentId + "'";
            dbc.sqlOperation(query);
            MessageBox.Show("Data cleared successifully");
            //refresh datagrid view
            autoPopulateGrid();
        }
        private string assessGrade(int marks)
        {
            string grade = "";

            if (marks >= 80 && marks <= 100)
                grade = "A";
            else if (marks >= 75 && marks <= 79)
                grade = "B+";
            else if (marks >= 70 && marks <= 74)
                grade = "B";
            else if (marks >= 65 && marks <= 69)
                grade = "B-";
            else if (marks >= 60 && marks <= 69)
                grade = "C+";
            else if (marks >= 55 && marks <= 59)
                grade = "C";
            else if (marks >= 50 && marks <= 54)
                grade = "C-";
            else if (marks >= 40 && marks <= 59)
                grade = "D";
            else if(marks <= 39)  grade = "Fail";

            return grade;
        }

        string studentId=string.Empty;  
        private void dataGridGrades_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView row in dataGridGrades.SelectedItems)
            {
                string id = row.Row.ItemArray[0].ToString();
                studentId = id;
            }
        }
    }
}
