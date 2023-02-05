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
        dataControl dc =new dataControl();  
        public AddToClass()
        {
            InitializeComponent();
            autoPopulateComboBox();
        }
        private void autoPopulateComboBox()
        {
            //selecting data from subject tp populate datagridview
            
            string query = "Select * from subject ";
            dataGridStud.ItemsSource = dbc.SqlTable(query).DefaultView;
        }
        private void btnStudAssin_Click(object sender, RoutedEventArgs e)
        {
            //assigning values to student
            //saves data to grades table

            if (txtStudntId.Text.Length < 1 || txtStuscore.Text.Length < 1)
                MessageBox.Show(dc.nullField());
            else saveData();
            
        }
        private void saveData()
        {
            string assessedGrade = dc.assessGrade(Convert.ToInt16(txtStuscore.Text));
            string getStud = "select * from student where student_id='" + txtStudntId.Text + "' ";
            string str = " insert into  grades values('" + txtStudntId.Text + "', '" + subjectId + "', '" + txtStuscore.Text + "','" + assessedGrade + "',"+ dc.getRand() + " )";
            string sms = string.Empty;  
            if (subjectId == "")
            {
                sms = "Select subjects below to assign grades";
            }else
            {
                if (dbc.getRows(getStud) > 0)//find if students exists
                {
                    dbc.sqlOperation(str);//save student record if found
                   sms= dc.success();
                }
                else sms=dc.studNotFound();
                clearInterce();
            }

            MessageBox.Show(sms);
           


        }
        private  void clearInterce()
        {
            txtStudntId.Clear();
            txtStuscore.Clear();
            subjectId=string.Empty;    

        }
        private void datagridAssinStudent(object sender, SelectedCellsChangedEventArgs e)
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
           // var i = dataGridStud.Items.IndexOf(dataGridStud.CurrentItem);
            foreach (DataRowView row in dataGridStud.SelectedItems)
            {
                string id = row.Row.ItemArray[0].ToString();
                subjectId = id;
            }
        }
    }
    


}
