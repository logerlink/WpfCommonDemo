using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// ExceptionPage.xaml 的交互逻辑
    /// </summary>
    public partial class ExceptionPage : Page
    {
        public ExceptionPage()
        {
            InitializeComponent();
        }

        #region 异常演示
        /// <summary>
        /// UI主线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_UIEx_Click(object sender, RoutedEventArgs e)
        {
            string str = null;
            str.ToString();     //报错  空指针异常
        }
        /// <summary>
        /// 非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_NotUIEx_Click(object sender, RoutedEventArgs e)
        {
            var t1 = new Thread(() => {
                string str = null;
                str.ToString();     //报错  空指针异常
            });
            t1.Start();
            Thread.Sleep(2000);     //保证t1执行完成
        }
        /// <summary>
        /// UI子线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ThreadEx_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                string str = null;
                str.ToString();     //报错  空指针异常
            });
        }
        #endregion
    }
}
