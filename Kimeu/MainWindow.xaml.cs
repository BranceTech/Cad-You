using sgs.Views;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace sgs
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			//DataContext = new Home();
			InitializeComponent();
		}
		private SQLiteDataAdapter sda;
		public DataTable table;
		private SQLiteCommand cmd;
		private SQLiteDataReader read;
		SQLiteConnection connection = new SQLiteConnection("DataSource=SGS.db");


		private void Home_Clicked(object sender, RoutedEventArgs e)
		{
			//DataContext = new Home();
		}

		private void Student_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new student();
		}

		private void Teacher_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new Teacher();
		}

		private void Subject_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new Subject();
		}

		private void Class_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new Class();
		}

		private void Note_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new Note();
		}

		private void View_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new View();
		}
		private void Grade_Clicked(object sender, RoutedEventArgs e)
		{
			DataContext = new Grades();
		}

		

		private void btnEditGrade_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new EditGrades();
		}
	}
}
