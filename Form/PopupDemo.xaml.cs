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
using System.Windows.Shapes;

namespace Wpf.Demo.Form
{
    /// <summary>
    /// Popup.xaml 的交互逻辑
    /// </summary>
    public partial class PopupDemo : Window
    {
        public PopupDemo()
        {
            InitializeComponent();
        }
        #region popup操作
        /// <summary>
        /// 打开Pup_Message 信息窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ShowPup_Click(object sender, RoutedEventArgs e)
        {
            Pup_Message.IsOpen = true;
        }
        private void Btn_ShowPupAuto_Click(object sender, RoutedEventArgs e)
        {
            Pup_Message_Auto.IsOpen = true;
        }
        /// <summary>
        /// 关闭Pup_Message 、Pup_Message_Auto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ClosePup_Click(object sender, RoutedEventArgs e)
        {
            if (Pup_Message.IsOpen) Pup_Message.IsOpen = false;
            if (Pup_Message_Auto.IsOpen) Pup_Message_Auto.IsOpen = false;
        }

        /// <summary>
        /// 窗口大小变更事件  窗口位置移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, EventArgs e)
        {
            if (!Pup_Message_Auto.IsOpen) return;
            var mi = typeof(Popup).GetMethod("UpdatePosition", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            mi.Invoke(Pup_Message_Auto, null);
        }



        #endregion
    }
}
