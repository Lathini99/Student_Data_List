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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Desktop_Project_GUI
{
    
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow(AddStudentVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
           
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            fnametxt.Text=string.Empty;
            lnametxt.Text=string.Empty;
            
            dobtxt.Text=string.Empty;
            int intValue;
            if (int.TryParse(agetxt.Text, out intValue))
            {
                agetxt.Text = "0"; 
            }
            else
            {
                agetxt.Text = string.Empty;
            }

            double doubleValue;
            if (double.TryParse(gpatxt.Text, out doubleValue))
            {
                gpatxt.Text = "0.0"; 
            }
            else
            {
                gpatxt.Text = string.Empty;
            }
        
        





        }
}

}
