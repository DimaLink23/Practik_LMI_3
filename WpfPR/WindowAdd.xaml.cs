using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfPR
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        ObservableCollection<MyClass> MyCollections;
        MyClass Obj;
        public WindowAdd(ObservableCollection<MyClass> myCollections = null, MyClass obj = null)
        {
            InitializeComponent();
            if(obj != null)
            {
                obj1.Text = obj.obj1;
                color.Text = obj.color;
                masa.Text = obj.masa;
                Obj = obj;
            }
            MyCollections = myCollections;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Obj == null)
            {
                MyClass temp = new MyClass { obj1 = obj1.Text, color = color.Text, masa = masa.Text };
                MyCollections.Add(temp);
            }
            else
            {
                var item = MyCollections.FirstOrDefault(x => x.obj1 == Obj.obj1 && x.color == Obj.color && x.masa == Obj.masa);
                int i = MyCollections.IndexOf(item);
                MyCollections[i] = new MyClass { obj1 = obj1.Text, color = color.Text, masa = masa.Text };

            }
            Close();
        }
    }
}
