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
using Prism.Services.Dialogs;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for editGrades.xaml
    /// </summary>
    public partial class editGrades : UserControl
    {
        DbConnections dbc=new DbConnections();
        dataControl dc=new dataControl();
        public editGrades()
        {
            InitializeComponent();
            autoPopulateGrid();
        }
        /// <summary>
        /// populates gridview on page load
        /// </summary>
        private void autoPopulateGrid()
        {
            string query = "select s.student_id as 'Student ID',updateId as 'Exam ID',fname as 'First name', lname as 'Last name', level as 'Class'" +
                ",subject_name as 'Subject name', marks as Marks, grades as Grades " +
                "from grades g inner join student s on g.stud_id=s.student_id " +
                "inner join subject sb on g.subject_id = sb.id";
            dataGridGrades.ItemsSource = dbc.SqlTable(query).DefaultView;
        }
        /// <summary>
        /// checks if the field and id of a given row are all set
        /// </summary>
        /// <returns></returns>
        private bool constraints()
        {
           
            if (txtTeacherName.Text.Length < 1)
            {
                MessageBox.Show(dc.nullField());
                return false;
            }else if(updateId == string.Empty)
            {
                MessageBox.Show(dc.sectionError());
                return false;

            }else 
                 return true;
        }
        /// <summary>
        /// updates data of a selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateGrade_Clicked(object sender, RoutedEventArgs e)
        {
            
            bool passed =constraints();
            if (passed){
                string error = string.Empty;
                string grade =(dc.assessGrade(int.Parse(txtTeacherName.Text)));               

                //if grade returns null / emply string 
                //inform user to try again
                error=(grade==string.Empty)? dc.invalidData(): updateGrades(grade);

               MessageBox.Show(error);  
                //refresh datagrid view
                autoPopulateGrid();
            }
        }
        /// <summary>
        /// updates the grade for specified student 
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        string  updateGrades(string grade)
        {
            string query = "update grades set marks='" + txtTeacherName.Text + "', grades='" + grade+"' where " +
                   " updateId='" + updateId + "'";
            dbc.sqlOperation(query);
            return dc.success();
        }
        /// <summary>
        /// delete data of a selecte row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteData_Clicked(object sender, RoutedEventArgs e)
        {
            string query = "delete from grades where updateID='" +updateId + "'";
            dbc.sqlOperation(query);
            MessageBox.Show("Data cleared successifully");
            //refresh datagrid view
            autoPopulateGrid();
        }
     
        /// <summary>
        /// gets the student id by selecting a row
        /// </summary>
        string updateId = string.Empty;  

        private void dataGridGrades_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView row in dataGridGrades.SelectedItems)
            {
                string id = row.Row.ItemArray[1].ToString();
                updateId = id;
            }
        }
    }
}
