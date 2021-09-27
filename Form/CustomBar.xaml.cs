using System;
using System.Windows;
using System.Windows.Input;

namespace Wpf.Demo
{
    /// <summary>
    /// CustomBar.xaml 的交互逻辑
    /// </summary>
    public partial class CustomBar : Window
    {
        public CustomBar()
        {
            InitializeComponent();
            this.Title = Tb_Title.Text;
        }

        #region 标题栏事件
        /*
         已知问题：
            1.窗口最大化时无法通过拖拽标题栏实现窗口最小化操作
            2. 必须要设置 ResizeMode="CanResizeWithGrip"   才能改变窗口大小   而且只能在右下角触发（右下角会有一个图标）
            3.默认窗体没有边框也没有边框阴影
         */
        /// <summary>
        /// 窗口移动事件
        /// </summary>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        int i = 0;
        /// <summary>
        /// 标题栏双击事件
        /// </summary>        
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;
            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                this.WindowState = this.WindowState == WindowState.Maximized ?
                              WindowState.Normal : WindowState.Maximized;
            }
        }
        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        /// 窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>        
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("确定关闭程序？","提示",MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }

        }
        private void MI_SwitchAccount_Click(object sender, RoutedEventArgs e)
        {
            //第三个按钮
        }

        #endregion 标题栏事件

    }
}
