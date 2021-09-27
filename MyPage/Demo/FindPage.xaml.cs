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
    /// FindPage.xaml 的交互逻辑
    /// </summary>
    public partial class FindPage : Page
    {
        public FindPage()
        {
            InitializeComponent();
        }

        #region 查找父子元素
        /// <summary>
        /// 查找父元素 通过当前按钮获取StackPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FindParent_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;
            var parentEL = FindVisualParent<StackPanel>(btn);
            MessageBox.Show("找到元素名为" + parentEL?.Name);
        }

        /// <summary>
        /// 查找子元素  通过StackPanel获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FindChild_Click(object sender, RoutedEventArgs e)
        {
            var btnName = (sender as Button)?.Name;
            if (btnName == null) return;
            var childEL = FindVisualChild<Button>(SP_Find);
            MessageBox.Show("找到元素名为" + childEL?.Name);
            var childEL2 = FindVisualChild<Button>(SP_Find, "Btn_FindChild");
            MessageBox.Show("找到元素名为" + childEL2?.Name);
        }

        /// <summary>
        /// 查找父元素
        /// </summary>
        /// <typeparam name="T">要查找的父元素</typeparam>
        /// <param name="childVisual">当前元素</param>
        /// <returns></returns>
        public T FindVisualParent<T>(DependencyObject childVisual)
            where T : DependencyObject
        {
            if (childVisual == null) return null;
            try
            {
                while (childVisual != null)
                {
                    childVisual = VisualTreeHelper.GetParent(childVisual);
                    if (childVisual is T visual) return visual;
                }
            }
            catch (System.Exception)
            {
            }
            return null;
        }


        /// <summary>
        /// 查找子元素 默认查找第一个符合的元素
        /// </summary>
        /// <typeparam name="T">要查找的子元素</typeparam>
        /// <param name="parentVisual">当前元素</param>
        /// <returns></returns>
        public T FindVisualChild<T>(DependencyObject parentVisual)
            where T : DependencyObject
        {
            if (parentVisual == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parentVisual); i++)
            {
                var child = VisualTreeHelper.GetChild(parentVisual, i);
                if (child is T dependencyObject)
                {
                    return dependencyObject;
                }

                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null) return childOfChild;
            }
            return null;
        }

        /// <summary>
        /// 查找子元素  根据Name来查找元素
        /// </summary>
        /// <typeparam name="T">要查找的子元素</typeparam>
        /// <param name="parentVisual">当前元素</param>
        /// <param name="controlName">元素名称</param>
        /// <returns></returns>
        public T FindVisualChild<T>(DependencyObject parentVisual, string controlName)
            where T : DependencyObject
        {
            if (parentVisual == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parentVisual); i++)
            {
                var child = VisualTreeHelper.GetChild(parentVisual, i);
                if (child is T childVisual && child is Control control && control.Name == controlName)
                {
                    return childVisual;
                }

                var childOfChild = FindVisualChild<T>(child, controlName);
                if (childOfChild != null) return childOfChild;
            }
            return null;
        }
        #endregion
    }
}
