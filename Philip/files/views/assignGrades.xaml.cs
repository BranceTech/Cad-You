using System;
using System.Collections.Generic;
using System.Data;
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

namespace chool.views
{
    /// <summary>
    /// Interaction logic for AddToClass.xaml
    /// </summary>
    public partial class AddToClass : UserControl
    {
        DbConnections dbc = new DbConnections();
        public AddToClass()
        {
            InitializeComponent();
            autoPopulateComboBox();
        }
        private void autoPopulateComboBox()
        {
            //selecting data from subject tp populate datagridview
            
            string query4 = "Select * from subject ";
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;
            
           // for (int i = 0; i < dbc.SqlTable(pullClasses).Rows.Count; i++)
               // cmAssignClass.Items.Add(dbc.SqlTable(pullClasses).Rows[i][0].ToString());
        
          }
        private void btnStudAssin_Click(object sender, RoutedEventArgs e)
        {
            //assigning values to student
            //saves data to grades table
            string assessedGrade = assessGrade(Convert.ToInt16(txtStuscore.Text));
            string str= " insert into  grades values('" + txtStudntId.Text + "', '" + subjectId + "', '" + txtStuscore.Text + "','"+ assessedGrade + "' )";
            dbc.sqlOperation(str );
            MessageBox.Show("Success");
            
        }
        /// <summary>
        /// method is used to asses and assign grades to 
        /// the marks entered
        /// </summary>
        /// <param name="marks"></param>
        /// <returns></returns>
        private  string assessGrade(int marks)
        {
            string grade = "";

            if (marks >= 80 && marks <= 100)
                grade = "A";
            if (marks >=75 && marks <= 79)
                grade = "B+";
            if (marks >= 70 && marks <= 74)
                grade = "B";
            if (marks >= 65 && marks <= 69)
                grade = "B-";
            if (marks >= 60 && marks <= 69)
                grade = "C+";
            if (marks >= 55 && marks <= 59)
                grade = "C";
            if (marks >= 50 && marks <= 54)
                grade = "C-";
            if (marks >= 40 && marks <= 59)
                grade = "D";
            else grade = "Fail";

            return grade;
        }
        private void datagridAssinStudent(object sender, SelectedCellsChangedEventArgs e)
        {
        }
        private void data(object sender, SelectedCellsChangedEventArgs e)
        {
            
            
        }

        private void dataGridStud_CurrentCellChanged(object sender, EventArgs e)
        {
           
           
        }
        string subjectId = "";
        private void dataGridStud_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //gets the selected rows id cell value
            //it will be used to populate grades table
           // var i = dataGridStud.Items.IndexOf(dataGridStud.CurrentItem);
            foreach (DataRowView row in dataGridStud.SelectedItems)
            {
                string id = row.Row.ItemArray[0].ToString();
                subjectId = id;
            }
        }
    }
    


}
