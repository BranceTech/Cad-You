using Bogus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
using static Azure.Core.HttpHeader;

namespace chool.views
{
    /// <summary>
    /// Interaction logic for findData.xaml
    /// </summary>
    public partial class findData : UserControl
    {
        //calling DbConnection classe that handles our queries
        DbConnections dbc = new DbConnections();
        public findData()
        {
            InitializeComponent();
            hideControls("All");
        }
        private void hideControls(string hideControl)
        {
            if (hideControl == "Search")
            {
                txtSearchBySubject.Visibility = Visibility.Hidden;
                searchClassCombo.Visibility = Visibility.Visible;

            }
                
            else if (hideControl == "Combo")
            {
                txtSearchBySubject.Visibility = Visibility.Visible;
                searchClassCombo.Visibility = Visibility.Hidden;

            }
            else if (hideControl == "All")
            {
                txtSearchBySubject.Visibility = Visibility.Hidden;
                searchClassCombo.Visibility = Visibility.Hidden;
            }
        }

        private void searchCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ///retrieving data from database to fill datagrid
            //----Querying data for teachers and there associate classes------//
            string str1 = "select c.level_id as id, first_name as 'First name',last_name as 'Last name', phone as Phone,gender as Gender," +
                "level_name as class from classes c inner join teacher t on c.level_id=t.level_id";

            ///retrieving data from database to fill datagrid
            //----Querying data for teachers and their subjects------//
            string str2 = "select first_name as 'First name', last_name as 'Last name', phone as Phone,gender as Sex," +
                "subject_name as Subject from teacher t inner join subject s on t.phone=s.teacher";


            //1.if commbobox index 1 is selected use string1 (str1) as our query
            //perse the query to dbc class and retern DataTable
            //.2 if commbobox index 3 is selected use string2 (str2) as our query
            //perse the query to dbc class and retern DataTable
            //3. else perse the selected index to displayComboBox method
            //for mor operations
            dataGridStud.ItemsSource = null;
            if (searchCombo.SelectedIndex == 0 || searchCombo.SelectedIndex == 3)
            {
                hideControls("All");
                dataGridStud.ItemsSource = (searchCombo.SelectedIndex == 0) ? dbc.SqlTable(str1).DefaultView : dbc.SqlTable(str2).DefaultView;
            }
               
            else 
                displayComboBox(searchCombo.SelectedIndex);
        }
        /// <summary>
        /// isplayComboBox method populate class/level names from database
        /// to a searchClassComboBox to help for searching by class function
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void displayComboBox(int selectedIndex)
        {
            searchClassCombo.Items.Clear();

            if (selectedIndex == 1)
            {
                hideControls("Search");
                ///retrieving data from database to fill datagrid
                //----populating class/level name to a combobox------//
                string classes = "select level_name from classes";

                for (int i = 0; i < dbc.SqlTable(classes).Rows.Count; i++)
                    searchClassCombo.Items.Add(dbc.SqlTable(classes).Rows[i][0].ToString());
            }
            else
            {
                string str = "select CONCAT( fname, ' ',  lname) as Names , subject_name as Subject,marks as Marks, grades as Grades " +
                    "from grades g inner join subject sb on g.subject_id=sb.id inner join student st on g.stud_id=st.student_id";

                dataGridStud.ItemsSource = dbc.SqlTable(str).DefaultView;
                                                                                                                      
                hideControls("Combo");
            }

        }

        private void searchClassCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ///retrieving data from database to fill datagrid
            //----searching student by class------//
            dataGridStud.ItemsSource = null;
            string str = "select fname as 'First name',lname as 'Last name', gender as Sex , level_name as Class  from classes c " +
                "inner join student s on c.level_id=s.level where level_name='" + searchClassCombo.Text + "'";

            dataGridStud.ItemsSource = dbc.SqlTable(str).DefaultView;
        }

        private void txtSearchBySubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            ///retrieving data from database to fill datagrid
            //----serching grade by subject------//
            dataGridStud.ItemsSource = null;
            string str = "select CONCAT( fname, ' ',  lname) as Names , subject_name as Subject,marks as Marks, grades as Grades " +
                   "from grades g inner join subject sb on g.subject_id=sb.id " +
                   "inner join student st on g.stud_id=st.student_id " +
                   "where subject_name like '%" + txtSearchBySubject.Text + "%'";

            dataGridStud.ItemsSource = dbc.SqlTable(str).DefaultView;
        }

       
    }
}
