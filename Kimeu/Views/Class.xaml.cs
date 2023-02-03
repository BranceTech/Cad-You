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
        string class_name;
        string dbquery;
        String date = DateTime.Now.ToString("yyyy-MM-dd");
        string getError = string.Empty;
        bool isSaved = true;
        public Class()
        {
            InitializeComponent();
        }

		private void btnAddClass_Click(object sender, RoutedEventArgs e)
		{
            if (isDataExists())
                addNewClass();
            else
            {
                getError = "Class exists";
                MessageBox.Show(getError);
            }
        }
        private bool isDataExists()
        {
            dbquery = "select * from Class where Classlevel like '%" + txtClassName.Text + "%'";            
            return (db.Query(dbquery, 0) < 1) ? true : false;
        }
        private void addNewClass()
        {

            class_name = txtClassName.Text;

            dbquery = "insert into Class (ClassLevel,dateCreated) values('" + class_name + "','" + date + "')";

            if (string.IsNullOrEmpty(class_name))
                getError = " Fill All Empty fields!";
            else _ = db.Query(dbquery, 0) > 0 ? isSaved : false;
            if (isSaved)
                getError = "Class added successifully!";

            RefreshClasses();
            MessageBox.Show(getError);
        }
      

		private void txtSearchClass_TextChanged(object sender, TextChangedEventArgs e)
		{
			db.Query("Select * from Class");
			dgClass.ItemsSource = db.table.DefaultView;
		}
		void RefreshClasses()
		{
            txtClassName.Text="";
        }
	}

}

