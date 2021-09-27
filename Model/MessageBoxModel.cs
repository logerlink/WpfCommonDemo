using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.Demo.Model
{
    public class MessageBoxModel
    {
        //标题
        public string Title { get; set; }
        //提示信息
        public string Message { get; set; }
        public bool IsLoading { get; set; }
        //取消按钮
        public MyMessageBoxButton CancelButton { get; set; }
        //确定按钮
        public MyMessageBoxButton SubmitButton { get; set; }
        //第三个按钮
        public MyMessageBoxButton OtherButton { get; set; }
    }

    public class MyMessageBoxButton
    {
        public MyMessageBoxButton(bool isShow, string text = null)
        {
            IsShow = isShow;
            Text = text;
        }
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 按钮文字
        /// </summary>
        public string Text { get; set; }
    }
}
