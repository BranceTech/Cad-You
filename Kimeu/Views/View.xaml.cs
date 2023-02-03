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

namespace sgs.Views
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : UserControl
    {
        public View()
        {
            InitializeComponent();
        }

		private void btnSlevel_Click(object sender, RoutedEventArgs e)
		{
			//db.Query("select FIrstname as 'First Name' ,Lastname as 'Last Name', Gender, Level from Students where  Level like '%" + cmbSearchlevel.Text + "%'", 0);
			//dgStudent.ItemsSource = db.table.DefaultView;
		}
    }
}
