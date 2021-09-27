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

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// TitlePage.xaml 的交互逻辑
    /// </summary>
    public partial class TitlePage : Page
    {
        public TitlePage()
        {
            InitializeComponent();
        }

        private void Btn_ShowCustomTitleBar_Click(object sender, RoutedEventArgs e)
        {
            CustomBar customBar = new CustomBar();
            customBar.Owner = Window.GetWindow(this);
            customBar.Show();
        }
    }
}
