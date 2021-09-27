using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
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
    /// FaviconPage.xaml 的交互逻辑
    /// </summary>
    public partial class FaviconPage : Page
    {
        public FaviconPage()
        {
            InitializeComponent();
        }

        #region Favicon演示
        /// <summary>
        /// 使用百度的Favicon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FavRequest_Click(object sender, RoutedEventArgs e)
        {
            Img_Baidu.Visibility = Visibility.Visible;
            var favPath = "http://www.baidu.com/favicon.ico";
            Img_Baidu.Source = GetBitmapFrame(favPath);
        }
        /// <summary>
        /// 使用本地的Favicon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FavFile_Click(object sender, RoutedEventArgs e)
        {
            Img_File.Visibility = Visibility.Visible;
            var path = AppDomain.CurrentDomain.BaseDirectory + "favicon.ico";
            Img_File.Source = GetBitmapFrame(path);
        }

        /// <summary>
        /// 根据地址获取图片资源  可以是本地资源文件、http网络资源文件
        /// </summary>
        /// <returns></returns>
        public static ImageSource GetBitmapFrame(string httpUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(httpUrl)) return null;
                return new BitmapImage(new Uri(httpUrl, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 清空Favicon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FavClear_Click(object sender, RoutedEventArgs e)
        {
            Img_Baidu.Visibility = Visibility.Hidden;
            Img_File.Visibility = Visibility.Hidden;
            Img_Baidu.Source = null;
            Img_File.Source = null;
        }
        /// <summary>
        /// 保存Favicon到本地并打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FavSave_Click(object sender, RoutedEventArgs e)
        {
            var favPath = "http://www.baidu.com/favicon.ico";
            var fullPath = AppDomain.CurrentDomain.BaseDirectory + Guid.NewGuid() + ".ico";
            SavePhotoFromUrl(fullPath, favPath);
            System.Diagnostics.Process.Start("explorer.exe", fullPath);
        }
        /// <summary>
        /// 从图片地址下载图片到本地磁盘
        /// </summary>
        /// <param name="ToLocalPath">图片本地磁盘地址</param>
        /// <param name="Url">图片网址</param>
        /// <returns></returns>
        public static void SavePhotoFromUrl(string fullName, string url)
        {
            WebResponse response = null;
            Stream stream = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                response = request.GetResponse();
                stream = response.GetResponseStream();
                using (Bitmap image = new Bitmap(stream))
                {
                    image.Save(fullName);
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
