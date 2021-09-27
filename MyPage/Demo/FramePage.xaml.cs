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
    /// FramePage.xaml 的交互逻辑
    /// </summary>
    public partial class FramePage : Page
    {
        public FramePage()
        {
            InitializeComponent();
        }

        #region 切换页面
        /// <summary>
        /// 页面存储区
        /// </summary>
        Dictionary<string, Page> PageDic = new Dictionary<string, Page>();
        /// <summary>
        /// 点击菜单切换时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectItem = LV_Menu.SelectedItem as ListViewItem;
            var name = selectItem?.Name?.ToString();
            DrawFrame(name);
        }
        /// <summary>
        /// 加载完成时间 比LV_Menu_SelectionChanged晚
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Menu_Loaded(object sender, RoutedEventArgs e)
        {
            var selectItem = LV_Menu.SelectedItem as ListViewItem;
            var name = selectItem?.Name?.ToString();
            DrawFrame(name);
        }
        /// <summary>
        /// 渲染Frame
        /// </summary>
        /// <param name="name"></param>
        private void DrawFrame(string name)
        {
            Page pageContent = null;
            switch (name)
            {
                case "LVI_Message":
                    {
                        if (PageDic.ContainsKey(name))
                        {
                            pageContent = PageDic[name];
                        }
                        else
                        {
                            pageContent = new MessagePage();
                            PageDic.Add(name, pageContent);
                        }
                        break;
                    }
                case "LVI_Docs":
                    {
                        pageContent = new DocsPage();
                        break;
                    }
                default:
                    break;
            }
            if (Frame_Page != null) Frame_Page.Content = pageContent;
        }

        #endregion
    }
}
