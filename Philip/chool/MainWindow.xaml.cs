using System;
using System.CodeDom;
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

using chool.views;

namespace chool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new home();
        }

        private void home_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new home();

        }
        private void addStudent_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddStudent();
        }
        private void addTeacher_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddTeacher();
        }
        private void addClass_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddClasses();
        }
        private void addNote_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddStudent();
        }
        private void addSubject_clicked(object sender, RoutedEventArgs e)
        {
          
        }
        private void removeStudent_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddSubject();
        }

        private void viewStudents_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddToClass();
        }

        private void viewData_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new findData();
        }

        private void addSubjects_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddSubject();
        }

        private void edditGrades_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new editGrades();
        }

        private void prepareNotes_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new prepareNotes();
        }
    }
}
