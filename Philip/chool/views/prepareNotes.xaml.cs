using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for prepareNotes.xaml
    /// </summary>
    public partial class prepareNotes : UserControl
    {
        //initialiing database connection class
        DbConnections db = new DbConnections();
        public prepareNotes()
        {
            InitializeComponent();
        }
        //inserting data to database
        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            string notify="Note successifully save";
            string query = "insert into notes(teacher_id,value) values('"+txtTeacherId.Text+"','"+ txtNotes.Text + "')";
            try
            {
                if (isText(txtNotes.Text,txtTeacherId.Text))
                    db.SqlTable(query);
            } catch (Exception ex) {
                        notify = "Err: " + ex;
            }

            MessageBox.Show(notify);    
        }
        //clearing text from textboxes
        private void clearInterface()
        {
            txtNotes.Clear();
            txtTeacherId.Clear();
        }
        /// <summary>
        ///boolean functon to check whether our note is not null
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private bool isText(string note,string teacherId)
        {
            return (!string.IsNullOrEmpty(note) && !string.IsNullOrEmpty(teacherId)) ? true : false;
        }
    }
}
