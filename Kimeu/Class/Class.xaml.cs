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

namespace sgs.Views
{
    /// <summary>
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class : UserControl
    {
		DbQuery db = new DbQuery();
		public Class()
        {
            InitializeComponent();
        }

		private void btnAddClass_Click(object sender, RoutedEventArgs e)
		{
			string HeadTeacher, Gender;
			String date = DateTime.Now.ToString("yyyy-MM-dd");
			HeadTeacher = txtClassHteacher.Text;			
			Gender = cmbClevel.Text;

			if (HeadTeacher == "" || Gender == "")
			{
				MessageBox.Show(" Fill All Empty fields!");
			}
			else
			{


				db.Query("insert into Class (HeadTeacher,ClassLevel) " +
							  "values('" + HeadTeacher + "','" + Gender + "')", 0);


				MessageBox.Show("HeadTeacher/ Class successfully Added!");
				RefreshClasses();


			}
		}

		private void txtSearchClass_TextChanged(object sender, TextChangedEventArgs e)
		{
			db.Query("Select * from Class");
			dgClass.ItemsSource = db.table.DefaultView;
		}
		void RefreshClasses()
		{
			txtClassHteacher.Text = "";
			cmbClevel.Text = "";
		}
	}

}

