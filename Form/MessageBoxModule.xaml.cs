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
using System.Windows.Shapes;
using Wpf.Demo.Model;

namespace Wpf.Demo
{
    /// <summary>
    /// MessageDemo.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxModule : Window
    {
        public bool? Result { get; set; }

        public MessageBoxModule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造初始化页面
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="title">提示标题</param>
        /// <param name="isLoading">是否是加载loading状态 默认为false</param>
        /// <param name="CancelButton">自定义取消按钮</param>
        /// <param name="SubmitButton">自定义确定按钮</param>
        /// <param name="OtherButton">自定义第三个按钮</param>
        public MessageBoxModule(string message, string title, bool isLoading = false, MyMessageBoxButton CancelButton = null, MyMessageBoxButton SubmitButton = null, MyMessageBoxButton OtherButton = null)
        {
            var messageBoxModel = InitMessageModel(message, title, CancelButton, SubmitButton, OtherButton, isLoading);
            InitializeComponent();
            DrawPage(messageBoxModel);
        }
        /// <summary>
        /// 初始化自定义提示框
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="title">提示标题</param>
        /// <param name="cancelButton">自定义取消按钮</param>
        /// <param name="submitButton">自定义确定按钮</param>
        /// <param name="otherButton">自定义第三个按钮</param>
        /// <param name="isLoading">是否是加载loading状态 默认为false</param>
        /// <returns></returns>
        private MessageBoxModel InitMessageModel(string message, string title, MyMessageBoxButton cancelButton, MyMessageBoxButton submitButton, MyMessageBoxButton otherButton, bool isLoading = false)
        {
            var messageBoxModel = new MessageBoxModel();
            messageBoxModel.Message = message;
            messageBoxModel.Title = title;
            messageBoxModel.CancelButton = cancelButton ?? new MyMessageBoxButton(true, "取消");
            messageBoxModel.SubmitButton = submitButton ?? new MyMessageBoxButton(true, "确定");
            messageBoxModel.OtherButton = otherButton ?? new MyMessageBoxButton(false, "");
            messageBoxModel.IsLoading = isLoading;
            return messageBoxModel;
        }

        /// <summary>
        /// 绘制画面  建议用mvvm数据绑定会好一点
        /// </summary>
        /// <param name="messageBoxModel"></param>
        private void DrawPage(MessageBoxModel messageBoxModel)
        {
            Tb_Title.Text = messageBoxModel.Title;
            Tb_Message.Text = messageBoxModel.Message;

            Btn_Cancel.Content = messageBoxModel.CancelButton.Text;
            Btn_Cancel.Visibility = messageBoxModel.CancelButton.IsShow ? Visibility.Visible : Visibility.Collapsed;

            Btn_Submit.Content = messageBoxModel.SubmitButton.Text;
            Btn_Submit.Visibility = messageBoxModel.SubmitButton.IsShow ? Visibility.Visible : Visibility.Collapsed;

            Btn_Other.Content = messageBoxModel.OtherButton.Text;
            Btn_Other.Visibility = messageBoxModel.OtherButton.IsShow ? Visibility.Visible : Visibility.Collapsed;

            Pb_Loading.Visibility = messageBoxModel.IsLoading ? Visibility.Visible : Visibility.Collapsed;
        }

        #region 按钮事件
        /// <summary>
        /// 点击第三个按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Other_Click(object sender, RoutedEventArgs e)
        {
            Result = null;
            this.DialogResult = false;
        }
        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
            Result = false;
            this.DialogResult = false;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //判断showDialog还是show   //判断数loading还是普通弹出框
            if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
            {
                //普通弹出框
                Result = true;
                this.DialogResult = true;
            }
            else
            {
                //loading的话把他变成取消操作
                this.Close();
                //this.IsCancel = true;
            }
        }
        #endregion

        /// <summary>
        /// 加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pb_Loading.Width = this.Width;
        }
    }
}
