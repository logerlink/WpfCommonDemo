using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Wpf.Demo.Helper
{
   public static class DialogHelper
    {
        /// <summary>
        /// 展示模态框
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        private static bool? MyShowDialog(this Window currentWindow, MessageBoxModule mem)
        {
            return currentWindow.Dispatcher.Invoke(() => {
                mem.SetInfo(currentWindow);
                var result = mem.ShowDialog();  // false 取消   true 确定 null 第三个按钮
                return result;
            });
        }
        /// <summary>
        /// 展示加载框
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        private static MessageBoxModule MyShow(this Window currentWindow, MessageBoxModule mem)
        {
            return currentWindow.Dispatcher.Invoke(() => {
                mem.SetInfo(currentWindow);
                mem.Show();
                return mem;
            });
        }
        /// <summary>
        /// 设置弹出框的信息 弹出的位置，宽高，owner
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="currentWindow"></param>
        /// <returns></returns>
        private static MessageBoxModule SetInfo(this MessageBoxModule mem, Window currentWindow)
        {
            var rect = GetAbsolutePlacement(currentWindow, true);
            mem.Width = currentWindow.Width;
            mem.Height = currentWindow.Height;
            mem.WindowStartupLocation = WindowStartupLocation.Manual;
            //设置top、left改变弹出的位置  让他覆盖到我们的主窗体currentWindow
            mem.Top = rect.Top;
            mem.Left = rect.Left;
            if (currentWindow.WindowStyle != WindowStyle.None)
            {
                //如果你的主窗口有自带的标题栏  弹出的位置会有一点偏差   所以要减掉一些距离
                mem.Top -= 30;
                mem.Width -= 15;
                mem.Height -= 9;
            }
            mem.Owner = currentWindow;
            return mem;
        }

        /// <summary>
        /// 没有一个按钮  通常不用
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public static bool? ShowNoCancel(this Window currentWindow, string message, string title)
        {
            var button = new Model.MyMessageBoxButton(false);
            MessageBoxModule mem = new MessageBoxModule(message, title, CancelButton: button, SubmitButton: button);
            return currentWindow.MyShowDialog(mem);
        }

        /// <summary>
        /// 只有一个按钮  默认展示确定按钮 返回true
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public static bool? ShowOneButton(this Window currentWindow, string message, string title = "提示", string buttonText = "确定")
        {
            var buttonSubmit = new Model.MyMessageBoxButton(true, buttonText);
            var button = new Model.MyMessageBoxButton(false);
            MessageBoxModule mem = new MessageBoxModule(message, title, CancelButton: button, SubmitButton: buttonSubmit);
            return currentWindow.MyShowDialog(mem);
        }


        /// <summary>
        /// Loading   不可取消 点击取消不是真正意义的取消
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="buttonText">默认展示确定按钮  按钮的文字  如果提供则默认显示按钮，注意不提供，则一个按钮都不显示</param>
        /// <returns></returns>
        public static MessageBoxModule ShowLoading(this Window currentWindow, string message, string title = "请稍等", string buttonText = null)
        {
            bool IsShowSubmit = !string.IsNullOrWhiteSpace(buttonText);
            var buttonSubmit = new Model.MyMessageBoxButton(IsShowSubmit, buttonText);
            var button = new Model.MyMessageBoxButton(false);
            MessageBoxModule mem = new MessageBoxModule(message, title, isLoading: true, CancelButton: button, SubmitButton: buttonSubmit);
            return currentWindow.MyShow(mem);
        }

        public static void CancelLoading(MessageBoxModule mem)
        {
            throw new Exception("已取消加载");
        }
        /// <summary>
        /// 关闭弹窗 Loading
        /// </summary>
        /// <param name="mem"></param>
        public static void CloseLoading(this MessageBoxModule mem)
        {
            mem?.Close();
        }

        /// <summary>
        /// 有两个按钮 确定返回true，取消返回false
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        public static bool? ShowDefaultButton(this Window currentWindow, string message, string title = "提示")
        {
            MessageBoxModule mem = new MessageBoxModule(message, title);
            return currentWindow.MyShowDialog(mem);
        }

        /// <summary>
        /// 有三个按钮  确定返回true，取消返回false 第三个按钮返回null
        /// </summary>
        /// <param name="currentWindow"></param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="buttonText">第三个按钮的文字</param>
        /// <returns></returns>
        public static bool? ShowThreeButton(this Window currentWindow, string message, string title, string buttonText)
        {
            var button = new Model.MyMessageBoxButton(true, buttonText);
            MessageBoxModule mem = new MessageBoxModule(message, title, OtherButton: button);
            currentWindow.MyShowDialog(mem);
            return mem.Result;
        }


        /// <summary>
        /// 获取窗口左上角的坐标
        /// </summary>
        /// <param name="element"></param>
        /// <param name="relativeToScreen"></param>
        /// <returns></returns>
        public static Rect GetAbsolutePlacement(FrameworkElement element, bool relativeToScreen = false)
        {
            var absolutePos = element.PointToScreen(new System.Windows.Point(0, 0));
            if (relativeToScreen)
            {
                return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
            }
            var posMW = Window.GetWindow(element).PointToScreen(new System.Windows.Point(0, 0));
            absolutePos = new System.Windows.Point(absolutePos.X - posMW.X, absolutePos.Y - posMW.Y);
            return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
        }
    }
}
