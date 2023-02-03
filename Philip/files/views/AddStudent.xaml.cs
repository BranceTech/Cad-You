using Bogus;
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
using System.Data.SqlClient;
using DataSet = Bogus.DataSet;
using System.Collections;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : UserControl
    {

        DbConnections dbc = new DbConnections();
        string query4 = "Select student_id as SN,fname as 'First Name', Lname as 'Last Name', gender as Gender, level as Level from student ";



        public AddStudent()
        {
            InitializeComponent();
            
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;
        }

        private void saveStudentData_Clicked(object sender, RoutedEventArgs e)
        {
            //adding data to database
            string query1 = "insert into student(fname,lname,gender,level) " +
                "values('"+txtStudFirstName.Text+"','"+txtStudLastName.Text+"'," +
                "'"+cmbStudGender.Text+"','"+ cmbStudLevel.Text + "')";
            dbc.sqlOperation(query1);

            //retrieving data from database to data gridview
            string query4 = "Select * from student ";
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;

            MessageBox.Show("Data saved successifully");
        }

        private void txtStudSearch_Clicked(object sender, TextChangedEventArgs e)
        {
            //searching student by use of first name or last name
            string query4 = "Select student_id as SN,fname as 'First Name', Lname as 'Last Name'," +
                " gender as Gender, level as Level from student where fname like'%"+txtStudSearch.Text+ "%' or lname like'%"+txtStudSearch.Text+"%' ";
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;
        }
    }
}
