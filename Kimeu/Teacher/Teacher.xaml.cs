using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace sgs.Views
{
    /// <summary>
    /// Interaction logic for Teacher.xaml
    /// </summary>
    public partial class Teacher : UserControl
    {
		DbQuery db = new DbQuery();
		public Teacher()
        {
            InitializeComponent();
        }
		
		private void btnSTeachers_Click(object sender, RoutedEventArgs e)
		{
			string Fname, Lname, gender;
			String date = DateTime.Now.ToString("yyyy-MM-dd");
			Fname = txtFTeachers.Text;
			Lname = txtLTeachers.Text;
			gender = cmbGTeachers.Text;
			
			if (Fname == "" || Lname == "" || gender == ""  )
			{
				MessageBox.Show(" Fill All Empty fields!");
			}
			else
			{


				db.Query("insert into Teachers (FIrstname,Lastname,Gender) " +
							  "values('" + Fname + "','" + Lname + "','" + gender + "')", 0);


				MessageBox.Show("Teacher Saved successfully!");
				RefreshTeachers();


			}
		}

		private void txtSearchTeacher_TextChanged(object sender, TextChangedEventArgs e)
		{
			db.Query("select * from Teachers ", 0);
			dgTeachers.ItemsSource = db.table.DefaultView;
		}
		void RefreshTeachers()
		{
			txtFTeachers.Text = "";
			txtLTeachers.Text = "";
			cmbGTeachers.Text = "";
		}
	}
    
}
