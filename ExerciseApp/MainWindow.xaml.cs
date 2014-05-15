using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLClassLibrary;

namespace ExerciseApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            List<Object> objList = (List<Object>)SQLHelper.ExecuteReader();
            foreach (var item in objList)
            {
                object[] abc = item as object[];
                ComboBoxItem cbbItem = new ComboBoxItem();
                cbbItem.Content = abc[1].ToString();
                cbbItem.Tag = abc[0];
                comboBox1.Items.Add(cbbItem);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SQLHelper.ExecuteNonQuery();
            MessageBox.Show("ok");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SQLHelper.ExecuteScalar().ToString());
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(((ComboBoxItem)comboBox1.SelectedItem).Tag.ToString());
        }


    }
}
