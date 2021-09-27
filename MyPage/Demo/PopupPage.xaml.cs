using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Demo.Form;

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// PopupPage.xaml 的交互逻辑
    /// </summary>
    public partial class PopupPage : Page
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        private void Btn_ShowPup_Click(object sender, RoutedEventArgs e)
        {
            var window = new PopupDemo();
            window.Owner = Window.GetWindow(this);
            window.Show();
        }
    }
}
