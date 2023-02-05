using Bogus.DataSets;
using chool.views;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chool
{
    public class dataControl
    {
        DbConnections dbc = new DbConnections();
        Random rng = new Random();
      
       public string invalidData()
        {
            return notify("bad");
        }
        public string success()
        {
            return notify("success");
        }
        public string nullField()
        {
            return notify("nullfield");
        }
        public string userNotFound()
        {
            return notify("user");
        }
        public string studNotFound()
        {
            return notify("student");
        }
        public string dataExists()
        {
           return notify("exists");
        }
        public string sectionError()
        {
            return notify("selectUpdate");
        }

        #region Checks whether user input is null
        public bool isNull(string fname, string lname, int gender, int level)
        {
            Dictionary<string, string> userInfor = new Dictionary<string, string>();
            userInfor.Add("fname", fname);
            userInfor.Add("lname", lname);

            return (userInfor.ContainsValue("") || comboNoSelection(gender, level)) ? true : false;
        }
        private bool comboNoSelection(int gender, int level)
        {
            Dictionary<int, int> userInfo = new Dictionary<int, int>();
            userInfo.Add(1, gender);
            userInfo.Add(2, level);
            return (userInfo.ContainsValue(-1)) ? true : false;
        }
        #endregion ./isNull

        #region generation of random
        public int  getRand()
        {           
           
            int randInt = rng.Next(1000, 10000);
            string findMatch = "select * from grades where updateId="+ randInt + "";
            while (dbc.getRows(findMatch) > 0)
            {
                randInt = rng.Next(1000, 10000);
            }
             
            return randInt;
        }
        #endregion ./getRand

        #region Getting specific errors 
        private string notify(string notify)
        {
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            userInfo.Add("success","Data saved successifully");
            userInfo.Add("nullfield", "Fill all the empty fields");
            userInfo.Add("user","Teacher not found" );
            userInfo.Add("student","Student not found" );
            userInfo.Add("exists","Data already eists" );
            userInfo.Add("selectUpdate", "Select row to be updated");
            userInfo.Add("bad", "Invalid entry, try again");

            return userInfo[notify];
        }
        #endregion ./notify

        #region Assigning of grades to specific marks
        public string assessGrade(int marks)
        {
            string grade = "";

            if (marks >= 80 && marks <= 100)
                grade = "A";
            else if (marks >= 75 && marks <= 79)
                grade = "B+";
            else if (marks >= 70 && marks <= 74)
                grade = "B";
            else if (marks >= 65 && marks <= 69)
                grade = "B-";
            else if (marks >= 60 && marks <= 69)
                grade = "C+";
            else if (marks >= 55 && marks <= 59)
                grade = "C";
            else if (marks >= 50 && marks <= 54)
                grade = "C-";
            else if (marks >= 40 && marks <= 59)
                grade = "D";
            else if (marks <= 39) grade = "Fail";           
            

            return grade;
        }
        #endregion ./assessGrade

    }

}
