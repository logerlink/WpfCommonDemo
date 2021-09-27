using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf.Demo.Form
{
    /// <summary>
    /// RichTextBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class RichTextBoxDemo : Window
    {
        public RichTextBoxDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rictextbox.Paste();
            FindRtbImagesandsave(rictextbox);
        }

        public void FindRtbImagesandsave(RichTextBox rtb)
        {
            IEnumerable<Image> images = rtb.Document.Blocks.OfType<BlockUIContainer>()
           .Select(c => c.Child).OfType<Image>()
       .Union(rtb.Document.Blocks.OfType<Paragraph>()
           .SelectMany(pg => pg.Inlines.OfType<InlineUIContainer>())
           .Select(inline => inline.Child).OfType<Image>()
       );
            foreach (var image in images)
            {
                // resize
                BitmapImage bim = (BitmapImage)image.Source;
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));
                using (FileStream stream = new FileStream(@"D:\imaghpas.png", FileMode.Create))
                    encoder.Save(stream);
            }
        }


    }
}
