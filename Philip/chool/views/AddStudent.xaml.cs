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
using static chool.views.AddStudent;
using static Bogus.DataSets.Name;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
   
    public partial class AddStudent : UserControl
    {
        dataControl dc = new dataControl();
        DbConnections dbc = new DbConnections();
        string query4 = "Select student_id as SN,fname as 'First Name', Lname as 'Last Name'," +
                " gender as Gender, level_name as Level from student s inner join classes c on s.level=c.level_id";



        public AddStudent()
        {
            InitializeComponent();
            
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;
            comboLevel = populateCombo("select level_name from classes", comboLevel);
        }
     
      
        private void saveStudentData_Clicked(object sender, RoutedEventArgs e)
        {
            if (dc.isNull(txtStudFirstName.Text, txtStudLastName.Text, comboGender.SelectedIndex,comboLevel.SelectedIndex))
                MessageBox.Show(dc.nullField());
            else saveStudent();
        }
        void saveStudent()
        {
            int classID = getClassID(comboLevel.Text);
            //adding data to database
            string query1 = "insert into student(fname,lname,gender,level) " +
                "values('"+txtStudFirstName.Text+"','"+txtStudLastName.Text+"'," +
                "'"+comboGender.Text+ "'," + classID + ")";
            dbc.sqlOperation(query1);
           
            //retrieving data from database to data gridview
            string query4 = "Select * from student ";
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;

            MessageBox.Show(dc.success());
        }
        int getClassID(string className)
        { 
            return  int.Parse(dbc.SqlTable("select level_id from classes where level_name='" + className + "' ").Rows[0][0].ToString());  
        }
        //method to populate and return a combobox
        private ComboBox populateCombo(string query,ComboBox cmb)
        {
            for (int i = 0; i < dbc.getRows(query); i++)
                cmb.Items.Add(dbc.getRowData(query,i,0).ToString());
            return cmb;
        }
        private void txtStudSearch_Clicked(object sender, TextChangedEventArgs e)
        {
            //searching student by use of first name or last name
            string query = "Select student_id as SN,fname as 'First Name', Lname as 'Last Name'," +
                " gender as Gender, level_name as Level from student s inner join classes c on s.level=c.level_id" +
                " where fname like'%"+txtStudSearch.Text+ "%' or lname like'%"+txtStudSearch.Text+"%' ";
            dataGridStud.ItemsSource = dbc.SqlTable(query).DefaultView;
        }

    }
}
