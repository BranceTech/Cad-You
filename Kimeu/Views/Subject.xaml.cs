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
using System.Data;

namespace sgs.Views
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : UserControl
    {
        DbQuery db = new DbQuery();
        public Subject()
        {

            InitializeComponent();
			feedCombobox();
        }
		void feedCombobox()
		{
			string str = "select SubName from Subjects";
            db.Query( str, 0);
			cmbSubject.Items.Clear();
			int i = 0;
			
			while(i<db.table.Rows.Count)
			{
				cmbSubject.Items.Add(db.table.Rows[i][0].ToString());
				i++;
				
            }
			

        }
        
		string subjectId = "";
		private void dgsubjectTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			foreach (DataRowView row in dgsubjectTeacher.SelectedItems)
			{
				string id = row.Row.ItemArray[0].ToString();
				subjectId = id;
			}
		}

		private void btnSubject_Click(object sender, RoutedEventArgs e)
		{
			string query = "Insert into AssignedSubject(TeacherID,Subid) values('" + txtTeacherId.Text + "','" + cmbSubject.Text + "')";
			string sms = "Subject assigned successifully";
			if (txtTeacherId.Text == "" || cmbSubject.SelectedIndex == 0)
				sms = "Fill required data";
			else
				db.Query(query, 0);

            MessageBox.Show(sms);


        }

        private void txtViewSubject_TextChanged(object sender, TextChangedEventArgs e)
        {

         db.Query("SELECT  Firstname as 'First Name',Lastname as 'Last Name', SubName as 'Subject Name' FROM AssignedSubject A INNER JOIN Subjects S on A.TeacherID = s.Subid INNER JOIN Teachers T on T.TeacherID = A.TeacherID where SubName like '%" + txtViewSubject.Text + "%'");
         dgsubjectTeacher.ItemsSource = db.table.DefaultView;
            
        }

  
    }
}
