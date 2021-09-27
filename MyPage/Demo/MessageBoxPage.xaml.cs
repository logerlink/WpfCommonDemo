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
using Wpf.Demo.Helper;

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// MessageBoxPage.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxPage : Page
    {
        public MessageBoxPage()
        {
            InitializeComponent();
        }

        private void Btn_Mb_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as Button)?.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(tag)) return;

            var currentWindow = Window.GetWindow(this); //获取当前窗口
            switch (tag)
            {
                case "loading":
                    {
                        var result = currentWindow.ShowLoading("正在加载数据", buttonText: "取消");
                        //MessageBox.Show(result?.ToString());
                    }
                    break;
                case "one":
                    {
                        var result = currentWindow.ShowOneButton("提交成功！");
                        MessageBox.Show(result?.ToString());
                    }
                    break;
                case "two":
                    {
                        var result = currentWindow.ShowDefaultButton("是否提交以下信息？");
                        MessageBox.Show(result?.ToString());
                        if (result == true)
                        {
                            //Todo：提交操作
                        }
                    }
                    break;
                case "three":
                    {
                        var result = currentWindow.ShowThreeButton("那边有xxx，是否前往？", "提示", "忽略此信息");
                        MessageBox.Show(result?.ToString());
                        if (result == true)
                        {
                            //Todo：前往操作
                        }
                        else if (result == false)
                        {
                            //不前往
                        }
                        else
                        {
                            // TODO：忽略该信息推送
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
