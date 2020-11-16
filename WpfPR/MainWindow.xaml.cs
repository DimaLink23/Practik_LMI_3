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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MyClass:INotifyPropertyChanged 
    {
        private string Obj1;
        private string Color;
        private string Masa;
        public string obj1 { get { return Obj1; } set { Obj1 = value; OnPropertyChanged("obj1"); } }
        public string color { get { return Color; } set { Color = value; OnPropertyChanged("color"); } }
        public string masa { get { return Masa; } set { Masa = value; OnPropertyChanged("masa"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    
    public partial class MainWindow : Window
    {
        ObservableCollection<MyClass> MyCollections;
        public MainWindow()
        {
            InitializeComponent();
            MyCollections = new ObservableCollection<MyClass>
            {
              new MyClass{obj1 = "Яблуко", color = "червоний",masa = "1"},
              new MyClass{obj1 = "Праска", color = "білий", masa = "2"},
              new MyClass{obj1 = "мопед", color = "зелений", masa = "170"}
            };
            Data.ItemsSource = MyCollections;

        }

     
        
        
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd add = new WindowAdd(MyCollections);
            add.Show();
        }

 private void Data_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (Data.SelectedItem != null)
            {
                Delete.IsEnabled = true;
               
            }
            else
            {
                Delete.IsEnabled = false;
               
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MyCollections.Remove(Data.SelectedItem as MyClass);
        }

       

    }
}
