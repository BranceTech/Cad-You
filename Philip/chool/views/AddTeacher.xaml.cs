using System;
using System.Collections;
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
using static Bogus.DataSets.Name;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : UserControl
    {
        dataControl dc = new dataControl();
        DbConnections dbc = new DbConnections();
        public AddTeacher()
        {
            InitializeComponent();
            cmbTeacherLevel = populateCombo("select level_name from classes",cmbTeacherLevel);
        }

        //method to populate and return a combobox
        private ComboBox populateCombo(string query,ComboBox cmb)
        {
            for (int i = 0; i < dbc.getRows(query); i++)
                cmb.Items.Add(dbc.SqlTable(query).Rows[i][0].ToString());
            return cmb;
        }
        private void saveStudentData_Clicked(object sender, RoutedEventArgs e)
        {
            //adding student to teacher table
            string queryTeacher = "select * from teacher where  phone='" + txtTeacherTel.Text + "'";
            bool isPhoneNull = (txtTeacherTel.Text.Length < 1) ? true : false;//checks if teacher's phone ia null

            if (dc.isNull(txtTeacherName.Text, txtTeacherLname.Text,cmbStudGender.SelectedIndex,cmbTeacherLevel.SelectedIndex) || isPhoneNull)
                MessageBox.Show(dc.nullField());//checks if fields null
            else if (dbc.SqlTable(queryTeacher).Rows.Count > 0)
                MessageBox.Show(dc.dataExists());//checks if data exists 
            else populateTable();

        }
        /// <summary>
        /// Adds data into database
        /// </summary>
        private void populateTable()
        {
            
            int levelId = cmbTeacherLevel.SelectedIndex + 1;
            string query1 = "insert into teacher(first_name,last_name,phone,gender,level_id) " +
               "values('" + txtTeacherName.Text + "','" + txtTeacherLname.Text + "','" + txtTeacherTel.Text + "'," +
               "'" + cmbStudGender.Text + "','" + levelId + "')";
            dbc.sqlOperation(query1);
            MessageBox.Show(dc.success());

            clearInterface();

        }
        /// <summary>
        /// clearing the text fields and combobox
        /// </summary>
        private void clearInterface()
        {
            txtTeacherName.Text = string.Empty; 
            txtTeacherLname.Text=string.Empty;
            txtTeacherTel.Text=string.Empty;
            cmbStudGender.Text = "Select gender";  
            cmbTeacherLevel.Text= "Select level"; 
            

        }
    }
}
