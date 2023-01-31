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
using System.Data.SQLite;
using System.Data;
using System.Security.RightsManagement;

namespace sgs
{
	internal class DbQuery
	{
		private SQLiteDataAdapter sda;
		public DataTable table;
		private SQLiteCommand cmd;
		private SQLiteDataReader read;
		SQLiteConnection connection = new SQLiteConnection("DataSource=SGS.db");
		public void Co()
		{
			if (connection.State == System.Data.ConnectionState.Closed)
			{
				connection.Open();
			}
		}
		public void Disco()
		{
			if (connection.State == System.Data.ConnectionState.Open)
			{
				connection.Close();
			}
		}
		
		public int Query(string query, int i)
		{
			//try
			{

				Co();
				sda = new SQLiteDataAdapter(query, connection);
				DataTable dt = new DataTable();
				table = new DataTable();
				sda.Fill(table);
				Disco();
				if (table.Rows.Count > 0)
					i = 1;

			}//catch(Exception ex)
			 //{
			 //MessageBox.Show("Error "+ex);
			 //}
			return i;
		}

		internal void Query(string query2)
		{
			Co();
			sda = new SQLiteDataAdapter(query2, connection);
			DataTable dt = new DataTable();
			table = new DataTable();
			sda.Fill(table);
			Disco();

		}
	}
}
