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
    /// Interaction logic for AddClasses.xaml
    /// </summary>
    public partial class AddClasses : UserControl
    {
        DbConnections dbc=new DbConnections();
        public AddClasses()
        {
            InitializeComponent();
        }

        private void saveClass_Clicked(object sender, RoutedEventArgs e)
        {
            string queryClass = "Select * from classes where level_name='" + txtClass.Text + "'  ";

            if (txtClass.Text.Length < 1)
                MessageBox.Show("The field cant be null");//ensure the field is not black

            else if (dbc.SqlTable(queryClass).Rows.Count <1 )
            {
                dbc.SqlTable("insert into classes(level_name) values('"+txtClass.Text+"')");
                MessageBox.Show("Class successifully saved");
            }
            else MessageBox.Show("Class already exists");
        }
        private void clearInterface()
        {
            txtClass.Text="";
        }
    }
}
