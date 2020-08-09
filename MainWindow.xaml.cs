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

namespace ConverterANSII
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MyConverterANSII MyConverter = new MyConverterANSII();

        private void Numbers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Numbers.Text == "" || Numbers.Text == null)
                CodeANSII.Text = "";
            else
            {
                var Li = MyConverter.SetNumberString(Numbers.Text);  // Задать строку (числовую)

                CodeANSII.Text = "";
                foreach (var item in Li)
                {
                    CodeANSII.Text += item.ToString() + " ";
                }
            }
        }
    }
}
