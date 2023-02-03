using Bogus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
            viewNotes();
        }
        private void viewNotes()
        {
            
            DbConnections dbc=new DbConnections();
            string query = "select note_id as ID,first_name as 'Noted by', value as 'Note' " +
                "from notes n inner join teacher t on n.teacher_id=t.phone";
            //viewNote.ItemsSource.cle;
             for(int i=0; i<dbc.SqlTable(query).Rows.Count; i++)
              {
                viewNote.Items.Add(dbc.SqlTable(query).Rows[i][1]);
                viewNote.Items.Add(dbc.SqlTable(query).Rows[i][2]);

            }
              

           

        }
    }
}
