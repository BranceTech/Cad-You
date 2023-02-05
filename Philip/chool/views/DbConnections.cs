using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace chool.views
{
    internal class DbConnections
    {
        static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory()+@"\db.mdf;Integrated Security=True;Connect Timeout=30";
    
        SqlConnection con = new SqlConnection(path);
        SqlDataAdapter adapter;
        DataTable table ;
        /// <summary>
        /// This method is used to do sql operation (insert, update and delet)
        /// </summary>
        /// <param name="query"></param>
        public void sqlOperation(string query)
        {  
            con.Open();
            adapter = new SqlDataAdapter(query, con);
            table = new DataTable();
            adapter.Fill(table);
            con.Close();
        }
        /// <summary>
        /// this method is used to return table data 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable SqlTable(string query)
        {
            con.Open();
            adapter = new SqlDataAdapter(query, con);
            table = new DataTable();
            adapter.Fill(table);
            con.Close();

            return table;
        }
       /// <summary>
       /// Method called to return number of rows in a table
       /// </summary>
       /// <param name="query"></param>
       /// <returns></returns>
        public int getRows(string query)
        {
            return SqlTable(query).Rows.Count;
        }
       /// <summary>
       /// returns the specified row value
       /// </summary>
       /// <param name="query"></param>
       /// <param name="row"></param>
       /// <param name="col"></param>
       /// <returns></returns>
        public string getRowData(string query,int row, int col) {            
            return SqlTable(query).Rows[row][col].ToString();
        }

    }
}
