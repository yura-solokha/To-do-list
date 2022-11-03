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

namespace tasks_window
{
    /// <summary>
    /// Логика взаимодействия для Categories_list.xaml
    /// </summary>
    public partial class Categories_list : Window
    {
        public Categories_list()
        {
            InitializeComponent();
        }

        private void Cansel_button_Click(object sender, RoutedEventArgs e)
        {
            penis.Text = "101";
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            penis.Text = "102";
        }
    }
}
