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
    /// InvokePage.xaml 的交互逻辑
    /// </summary>
    public partial class InvokePage : Page
    {
        public InvokePage()
        {
            InitializeComponent();
        }

        #region Invoke和BeginInvoke演示
        private void Btn_Normal_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Lb_Invoke.Content = i;
            }
        }

        private void Btn_Except_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        Lb_Invoke.Content = i;
                    }
                }
                catch (Exception ex)
                {
                    //调用线程无法访问此对象，因为另一个线程拥有该对象。
                    MessageBox.Show(ex.Message);
                }
            });
        }
        private void Btn_Invoke_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                try
                {
                    // 要用for包Invoke  不能用Invoke包for
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        this.Dispatcher.Invoke(() => {
                            Lb_Invoke.Content = i;
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }

        private void Btn_BeginInvoke_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                try
                {
                    // 要用for包BeginInvoke  不能用BeginInvoke包for
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        MessageBox.Show("当前的i值" + i);
                        //BeginInvoke是异步的   调用BeginInvoke是会继续往下执行代码，即先执行i++再到BeginInvoke里面的代码
                        this.Dispatcher.BeginInvoke(new Action(() => {
                            Lb_Invoke.Content = i;
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private void Btn_InvokeDiff_Click(object sender, RoutedEventArgs e)
        {
            Lb_Invoke.Content = "";
            var message = "";
            message += "Invoke执行前——";
            this.Dispatcher.Invoke(() => {
                message += "Invoke执行中——";
            });
            message += "Invoke执行结束——";

            message += "BeginInvoke执行前——";
            this.Dispatcher.BeginInvoke(new Action(() => {
                message += "BeginInvoke执行中——";      //在最后面
                Lb_Invoke.Content = message;
            }));
            message += "BeginInvoke执行结束——";

            //Lb_Invoke.Content = message; 不能放这里  要放在BeginInvoke里面才算完整
        }

        #endregion
    }
}
