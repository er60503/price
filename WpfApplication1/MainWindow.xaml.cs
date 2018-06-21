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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\data.txt");

            foreach (string line in lines)
            {

                string[] parts = line.Split('|');

                price price = new price();

                price.date.Text = parts[0];
                price.TaskName.Text = parts[1];
                price.TaskPrice.Text = parts[2];

                TaskList.Children.Add(price);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            int AddPrice = 0;

            if (e.Key == Key.Return)
            {

                foreach (price item in TaskList.Children)
                {

                    AddPrice += item.itemPriceValue;
                }

                totalPrice.Text = AddPrice.ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            List<string> datas = new List<string>();


            foreach (price price in TaskList.Children)
            {

                string data = "";

                data += price.date.Text + "|" + price.TaskName.Text + "|" + price.TaskPrice.Text;

                datas.Add(data);
            }

            System.IO.File.WriteAllLines(@"c:\data.txt", datas);
        }


        private void addTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            price price = new price();

            TaskList.Children.Add(price);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                int total = 0;



                foreach (price item in TaskList.Children)
                {

                    total += item.itemPriceValue;
                }


                totalPrice.Text = total.ToString();
            }

        }
    }

}