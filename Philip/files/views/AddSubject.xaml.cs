using Bogus;
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
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : UserControl
    {
        DbConnections dbc=new  DbConnections();
        public AddSubject()
        {
            InitializeComponent();
        }

        private void saveSubject_Clicked(object sender, RoutedEventArgs e)
        {
            //querrying th db to confirm teachr's number

            string queryTeachers = "Select * from teacher where phone='"+txtTeacherNumber.Text+"' ";

            string querySubject = "Select * from subject where teacher='" + txtTeacherNumber.Text + "' and subject_name='"+txtSubjectName.Text+"' ";

            if (txtSubjectName.Text.Length<1 || txtTeacherNumber.Text.Length < 1)
               MessageBox.Show("Please fill all the fields");//ensure no blank field
            else if (dbc.SqlTable(queryTeachers).Rows.Count > 0)
            {
                //check if data exist in the subject table before adding
                if(dbc.SqlTable(querySubject).Rows.Count <1) 
                {
                    popupateTable();
                    MessageBox.Show("Data saved successifully");
                }
                else MessageBox.Show("Data already exists!");


                //clearing the interface
                clearInterface();
            }
            else MessageBox.Show("Teacher's number not found!");
           
        }
        //saving to database
        private void popupateTable()
        {
            string query1 = "insert into subject(subject_name,teacher) " +
                    "values('" + txtSubjectName.Text + "','" + txtTeacherNumber.Text + "')";
            dbc.sqlOperation(query1);
            
        }
        //clearing interface
        private void clearInterface()
        {
            txtSubjectName.Clear();
            txtTeacherNumber.Clear();
        }
    }
}
