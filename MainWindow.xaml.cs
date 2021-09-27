using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
using Wpf.Demo.Helper;
using Wpf.Demo.Model;
using Wpf.Demo.ViewModel;

namespace Wpf.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var menu = new List<MenuItemModel>() {
             new MenuItemModel("弹框展示","MessageBoxPage"),
             new MenuItemModel("自定义标题栏","TitlePage"),
             new MenuItemModel("Icon+Svg","IconPage"),
             new MenuItemModel("样式展示","StyleDemo"),
             new MenuItemModel("TextBox展示","TextboxDemo"),
             new MenuItemModel("Popup展示","PopupPage"),
             new MenuItemModel("异常捕获","ExceptionPage"),
             new MenuItemModel("查找父子元素","FindPage"),
             new MenuItemModel("打开资源文件","ProcessPage"),
             new MenuItemModel("Favicon演示","FaviconPage"),
             new MenuItemModel("Converter演示","ConverterPage"),
             new MenuItemModel("FrameDemo演示","FramePage"),
             new MenuItemModel("(Begin)Invoke","InvokePage"),
            };
            LV_Menu.ItemsSource = menu;
            LV_Menu.SelectedItem = menu[0];
        }

        
        #region 关闭前事件
        /// <summary>
        /// 关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var hasOtherWindow = CheckHasOtherWindow();
            if (hasOtherWindow)
            {
                MessageBox.Show("请先关闭其他窗口！");
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 判断是否有其他窗口
        /// </summary>
        /// <returns></returns>
        private bool CheckHasOtherWindow()
        {
            var hasOtherWindow = false;
            foreach (Window item in Application.Current.Windows)
            {
                if (item.ToString() == "Wpf.Demo.CustomBar")     //通过窗口标题来判断子窗口是否存在
                {
                    hasOtherWindow = true;
                    break;
                }
            }
            return hasOtherWindow;
        }
        #endregion

        #region 菜单事件
        Dictionary<string, Page> PageDic = new Dictionary<string, Page>();
        

        /// <summary>
        /// 菜单切换时  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectItem = LV_Menu.SelectedItem as MenuItemModel;
            var name = selectItem?.Source?.ToString();
            if (name == null) return;
            DrawFrame(name);
        }

        /// <summary>
        /// 加载完成事件   加载完成时间 比LV_Menu_SelectionChanged晚
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Menu_Loaded(object sender, RoutedEventArgs e)
        {
            var selectItem = LV_Menu.SelectedItem as MenuItemModel;
            var name = selectItem?.Source?.ToString();
            if (name == null) return;
            DrawFrame(name);
        }

        /// <summary>
        /// 渲染Frame
        /// </summary>
        /// <param name="content"></param>
        private void DrawFrame(string name)
        {
            Page pageContent = null;

            if (PageDic.ContainsKey(name))
            {
                pageContent = PageDic[name];
            }
            else
            {
                var type = Type.GetType("Wpf.Demo.MyPage.Demo." + name);
                pageContent = (Page)Activator.CreateInstance(type);
                PageDic.Add(name, pageContent);
            }
            if (Frame_Page != null) Frame_Page.Content = pageContent;
        }

        #endregion
    }
}
