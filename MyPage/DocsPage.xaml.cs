using System;
using System.Collections.Generic;
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

namespace Wpf.Demo
{
    /// <summary>
    /// Docs.xaml 的交互逻辑
    /// </summary>
    public partial class DocsPage : Page
    {
        public DocsPage()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            LB_Docs.Content = "新增的文本，试试切换菜单，看看我还在不在";
        }
    }
}
