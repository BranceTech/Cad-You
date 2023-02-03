using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
	/// Interaction logic for EditGrades.xaml
	/// </summary>
	public partial class EditGrades : UserControl
	{
		DbQuery db = new DbQuery();
		public EditGrades()
		{
			InitializeComponent();
			AutofillGrid();
		}
		void AutofillGrid()
		{
			string query= "SELECT s.studentId as 'Student ID',Firstname as 'First Name', Lastname as 'Last Name', Level as 'Class'" +
				"SubName as 'Subject', Marks, Grade" +
				"FROM Grade g INNER JOIN Students s on g.studentId = s.studentId" +
				"INNER JOIN Subjects sg on g.Subid = sg.Subid";
			    // dgEditGrades.ItemsSource = db.table.DefaultView;
				
		}
		private bool constraints()
		{
			if (txtTeacherName.Text.Length < 1)
			{
				MessageBox.Show("Field cant be null");
				return false;
			}
			else if (studentId == string.Empty)
			{
				MessageBox.Show("select the row to update");
				return false;

			}
			else
				return true;
		}
		string studentId = string.Empty;
		private void btnUpdateGrade_Click(object sender, RoutedEventArgs e)
		{
			bool passed = constraints();
			if (passed)
			{

				//string grade = giveGrades(int.Parse(txtTeacherName.Text));
				//string query = "update Grade set Marks='" + txtTeacherName.Text + "', Grade='" + grade + "' where " +
				//" Studentid='" + studentId + "'";
				//dgEditGrades.ItemsSource = db.table.DefaultView;
				//MessageBox.Show("Data successifully updated");
				//refresh datagrid view
				//AutofillGrid();
			}
		}
		
		void giveGrades(int i)
		{
			String grade = "";
			if (i < 40)
				grade = "Fail";
			else if (i >= 40 && i <= 50)
				grade = "D";
			else if (i >= 50 && i <= 60)
				grade = "C";
			else if (i >= 60 && i <= 70)
				grade = "B";
			else if (i >= 70 && i <= 100)
				grade = "A";
			else MessageBox.Show("Invalid entry!");
		}

		private void btnDeleteGrade_Click(object sender, RoutedEventArgs e)
		{
			string query = "delete from Grade where Studentid='" + studentId + "'";
			dgEditGrades.ItemsSource = db.table.DefaultView;
			MessageBox.Show("Data cleared successifully");
			//refresh datagrid view
			AutofillGrid();
		}

		private void txtTeacherName_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
