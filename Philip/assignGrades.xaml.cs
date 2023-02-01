using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddToClass.xaml
    /// </summary>
    public partial class AddToClass : UserControl
    {
        DbConnections dbc = new DbConnections();
        public AddToClass()
        {
            InitializeComponent();
            autoPopulateComboBox();
        }
        private void autoPopulateComboBox()
        {
            //selecting data from subject tp populate datagridview
            
            string query4 = "Select * from subject ";
            dataGridStud.ItemsSource = dbc.SqlTable(query4).DefaultView;
            
           // for (int i = 0; i < dbc.SqlTable(pullClasses).Rows.Count; i++)
               // cmAssignClass.Items.Add(dbc.SqlTable(pullClasses).Rows[i][0].ToString());
        
          }
        private void btnStudAssin_Click(object sender, RoutedEventArgs e)
        {
            //assigning values to student
            //saves data to grades table
            string str= " insert into  grades values('" + txtStudntId.Text + "', '" + subjectId + "', '" + txtStuscore.Text + "')";
            dbc.sqlOperation(str );
            MessageBox.Show("Success");
            
        }

        private void datagridAssinStudent(object sender, SelectedCellsChangedEventArgs e)
        {
        }
        private void data(object sender, SelectedCellsChangedEventArgs e)
        {
            
            
        }

        private void dataGridStud_CurrentCellChanged(object sender, EventArgs e)
        {
           
           
        }
        string subjectId = "";
        private void dataGridStud_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //gets the selected rows id cell value
            //it will be used to populate grades table
            var i = dataGridStud.Items.IndexOf(dataGridStud.CurrentItem);
            foreach (DataRowView row in dataGridStud.SelectedItems)
            {
                string text = row.Row.ItemArray[0].ToString();
                subjectId = text;
            }
        }
    }
    


}
