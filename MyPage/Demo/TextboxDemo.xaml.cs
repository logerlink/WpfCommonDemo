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

namespace Wpf.Demo.MyPage.Demo
{
    /// <summary>
    /// TextboxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class TextboxDemo : Page
    {
        public TextboxDemo()
        {
            InitializeComponent();
        }

        #region 清空文本框
        /// <summary>
        /// 清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Tb_Username.Text = "";
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear2_Click(object sender, RoutedEventArgs e)
        {
            Tb_Username2.Text = "";
        }
        #endregion

        #region  明文和密码切换
        /// <summary>
        /// 明文和密码切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_Eye_Click(object sender, RoutedEventArgs e)
        {
            var tg = sender as ToggleButton;
            if (tg == null) return;
            if (tg?.IsChecked == true)
            {
                tb_password.Text = pw_password.Password;
                tb_password.Visibility = Visibility.Visible;
                pw_password.Visibility = Visibility.Collapsed;
            }
            else
            {
                pw_password.Password = tb_password.Text;
                pw_password.Visibility = Visibility.Visible;
                tb_password.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region 文本选中事件
        /// <summary>
        /// 文本框获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_focus_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_focus.SelectAll();   //全选
            //tb_focus文本框  取消 点击前 事件
            tb_focus.PreviewMouseDown -= new MouseButtonEventHandler(tb_focus_PreviewMouseDown);
        }
        /// <summary>
        /// 文本框被点击前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_focus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tb_focus.Focus();   //触发 tb_focus_GotFocus
            e.Handled = true;   //不继续往下
        }
        /// <summary>
        /// 文本框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_focus_LostFocus(object sender, RoutedEventArgs e)
        {
            //tb_focus文本框  添加 点击前 事件
            tb_focus.PreviewMouseDown += new MouseButtonEventHandler(tb_focus_PreviewMouseDown);
        }
        #endregion
    }
}
