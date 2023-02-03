using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sgs.Views
{
	/// <summary>
	/// Interaction logic for Grades.xaml
	/// </summary>
	public partial class Grades : UserControl
	{
		DbQuery db=new DbQuery();
		string dbQuery = "";
		public Grades()
		{
			InitializeComponent();
		}
		String grade = "";
         void giveGrades(int i)
        {
			if (i < 40)
				grade = "Fail";
			else if (i >= 40 && i <= 50)
				grade = "D";
			else if (i >=50 && i <= 60)
				grade = "C";
			else if (i >= 60 && i <= 70)
				grade = "B";
			else if (i >=70 && i <= 100)
				grade = "A";
			else MessageBox.Show("Invalid entry!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			giveGrades(int.Parse(txtMarks.Text));

            int i=db.Query("insert into Grade(StudentId,Marks,Grade,Subid) values('"+txtStudentId.Text+"','"+txtMarks.Text+"','"+grade+ "','"+txtSubjectId.Text+"')", 0);

			
			MessageBox.Show( (i <1) ? "Grade added successifully" : "Oops error occured");
        }

        private void txtSearchGrade_TextChanged(object sender, TextChangedEventArgs e)
        {
			dgViewGrade.ItemsSource = null;
			db.Query("SELECT Firstname as 'First Name', Lastname as 'Last Name', SubName as 'Subject Name' FROM AssignedSubject A INNER JOIN Subjects S on A.TeacherID = s.Subid INNER JOIN Teachers T on T.TeacherID = A.TeacherID");        
            dgViewGrade.ItemsSource = db.table.DefaultView;
        }
    }

	
}
