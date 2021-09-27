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
using Wpf.Demo.ViewModel;

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// ConverterPage.xaml 的交互逻辑
    /// </summary>
    public partial class ConverterPage : Page
    {
        public ConverterPage()
        {
            InitializeComponent();
            Grid_Converter.DataContext = new SpConverterVM();
        }
    }
}
