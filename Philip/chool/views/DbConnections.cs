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
        DataSet dataset = new DataSet("schooldb"); //C:\Users\philoo\source\repos\myApp\myApp\db.mdf
        // MessageBox.Show(path);
        SqlConnection con = new SqlConnection(path);
        SqlDataAdapter adapter;
        DataTable table ;
       
        
        private void addStudent()
        {

        }
        private void addTeacher()
        {

        }
        private void addClass(string classNAme)
        {
            
        }
        
        public void sqlOperation(string query)
        {  
            con.Open();
            adapter = new SqlDataAdapter(query, con);
            table = new DataTable();
            adapter.Fill(table);
            con.Close();
        }
        public DataTable SqlTable(string query)
        {
            con.Open();
            adapter = new SqlDataAdapter(query, con);
            table = new DataTable();
            adapter.Fill(table);
            con.Close();

            return table;
        }
       
    }
}
