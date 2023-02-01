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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void saveStudentData_Clicked(object sender, RoutedEventArgs e)
        {
            //adding student to teacher table
            string query1 = "insert into teacher(first_name,last_name,phone,gender,level_id) " +
                "values('" + txtTeacherName.Text+ "','" + txtTeacherLname.Text+ "','" + txtTeacherTel.Text + "'," +
                "'" + cmbStudGender.Text+ "','" + cmbTeacherLevel.Text+"')";
            dbc.sqlOperation(query1);
            MessageBox.Show("Data successifully saved");

        }
    }
}
