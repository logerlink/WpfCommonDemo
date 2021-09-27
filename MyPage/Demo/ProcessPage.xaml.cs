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
    /// ProcessPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessPage : Page
    {
        public ProcessPage()
        {
            InitializeComponent();
        }

        #region 打开本地资源文件
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OpenDir_Click(object sender, RoutedEventArgs e)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        /// <summary>
        /// 打开test.txt  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OpenTxt_Click(object sender, RoutedEventArgs e)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "test.txt";
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        #endregion
    }
}
