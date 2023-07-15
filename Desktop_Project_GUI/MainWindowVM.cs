using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Desktop_Project_GUI
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Person> users;
        [ObservableProperty]
        public Person selectedUser = null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD STUDENT";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();
            

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Person before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddStudentVM(selectedUser);
                vm.title = "EDIT A STUDENT";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<Person>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            users.Add(new Person(23, "Lathini", "Navoda", "14/10/1999", image1,3.87));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            users.Add(new Person(24, "Sandaruwan", "Wickramasinghe", "22/09/1998", image2,3.4));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            users.Add(new Person(24, "Naveendi", "Thashara", "10/10/1998", image3,3.2));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            users.Add(new Person(23, "Tharushi", "Pabasara", "12/01/2000", image4,3.67));
            BitmapImage image5 = new BitmapImage(new Uri("/Images/6.png", UriKind.Relative));
            users.Add(new Person(22, "Dahami", "Nethsarani", "1/10/2000", image5,3.5));
            BitmapImage image6 = new BitmapImage(new Uri("/Images/7.png", UriKind.Relative));
            users.Add(new Person(22, "Moshintha", "Isuru", "19/02/2000", image6,3.9));
            BitmapImage image7 = new BitmapImage(new Uri("/Images/8.png", UriKind.Relative));
            users.Add(new Person(25, "Rishitha", "Imesha", "17/07/1997", image7,2.9));
            BitmapImage image8 = new BitmapImage(new Uri("/Images/9.png", UriKind.Relative));
            users.Add(new Person(22, "Rashmi", "Lalithya", "12/03/2000", image8,2.78));

        }
    }
}
