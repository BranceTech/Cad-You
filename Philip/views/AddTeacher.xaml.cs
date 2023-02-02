using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : UserControl
    {
        DbConnections dbc = new DbConnections();
        public AddTeacher()
        {
            InitializeComponent();
        }


        private void saveStudentData_Clicked(object sender, RoutedEventArgs e)
        {
            //adding student to teacher table
            string queryTeacher = "select * from teacher where  phone='" + txtTeacherTel.Text + "'";
            if (txtTeacherName.Text.Length < 1 || txtTeacherLname.Text.Length < 1 || txtTeacherTel.Text.Length < 1)
                MessageBox.Show("Fields cant be null");
            else if (dbc.SqlTable(queryTeacher).Rows.Count > 0)
                MessageBox.Show("Teacher already exists");
            else populateTable();


        }
        private void populateTable()
        {
            int levelId = cmbTeacherLevel.SelectedIndex + 1;
            string query1 = "insert into teacher(first_name,last_name,phone,gender,level_id) " +
               "values('" + txtTeacherName.Text + "','" + txtTeacherLname.Text + "','" + txtTeacherTel.Text + "'," +
               "'" + cmbStudGender.Text + "','" + levelId + "')";
            dbc.sqlOperation(query1);
            MessageBox.Show("Data saved successifully");
            clearInterface();

        }
        private void clearInterface()
        {
            txtTeacherName.Text = string.Empty; 
            txtTeacherLname.Text=string.Empty;
            txtTeacherTel.Text=string.Empty;
            cmbStudGender.Text = string.Empty;  
            cmbTeacherLevel.Text= string.Empty; 
            

        }
    }
}
