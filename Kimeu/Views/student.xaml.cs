using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
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
using System.Data.SQLite;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;

namespace sgs.Views
{
    /// <summary>
    /// Interaction logic for student.xaml
    /// </summary>
    public partial class student : UserControl
    {
		DbQuery db = new DbQuery();

		public student()
        {
			

			InitializeComponent();
        }	

		private void txtSearchStudent_TextChanged(object sender, TextChangedEventArgs e)
		{
			dgStudent.ItemsSource = null;
            db.Query("select FIrstname as 'First Name' ,Lastname as 'Last Name', Gender, Level from Students where  Level like '%" + txtSearchStudent.Text + "%' ", 0);
			dgStudent.ItemsSource = db.table.DefaultView;
		}
			

		private void SaveStudent_Clicked(object sender, RoutedEventArgs e)		{
			
			String date = DateTime.Now.ToString("yyyy-MM-dd");//grabbing date 
			
			if (txtFnameStu.Text == "" || txtLnameStu.Text == "" || cmbGederStu.Text == "" || cmbLevelStu.Text == "" )
			{
				MessageBox.Show(" Fill All Empty fields!");
			}
			else
			{			
				
			 db.Query("insert into Students (FIrstname,Lastname,Gender,Level) " +
						   "values('" + txtLnameStu.Text + "','" + txtLnameStu.Text + "','" + cmbGederStu.Text + "','" + cmbLevelStu.Text + "')", 0);				
				MessageBox.Show("Student Saved successfully!");
				RefreshStudent();
			}
		}		
		//clearing textboxes
	void RefreshStudent()
		{
			txtFnameStu.Text = "";
			txtLnameStu.Text = "";
			cmbGederStu.Text = "";
			cmbLevelStu.Text = "";
		}

		
	}
	

}
