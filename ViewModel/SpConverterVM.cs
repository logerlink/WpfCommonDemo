using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Wpf.Demo.ViewModel
{
    public class SpConverterVM: NotifyPropertyBase
    {
        public int _state;
        public int State { get => _state; set { _state = value; this.SetProperty(x => x.State); } }

        public int _count;
        public int Count { get => _count; set { _count = value; this.SetProperty(x => x.Count); } }
        public Article _currentArticle;
        public Article CurrentArticle { get => _currentArticle; set { _currentArticle = value; this.SetProperty(x => x.CurrentArticle); } }
        

        #region 事件绑定
        private ICommand _changeStateCommand;
        public ICommand ChangeStateCommand { get { return _changeStateCommand ?? (_changeStateCommand = new Command(ChangeState)); } }
        private ICommand _changeStateAndCountCommand;
        public ICommand ChangeStateAndCountCommand { get { return _changeStateAndCountCommand ?? (_changeStateAndCountCommand = new Command(ChangeStateAndCount)); } }

        private ICommand _articleClickCommand;
        public ICommand ArticleClickCommand { get { return _articleClickCommand ?? (_articleClickCommand = new Command(ArticleClick)); } }

        private void ArticleClick()
        {
            //选中事件
            CurrentArticle = null;
        }


        #endregion
        private void ChangeStateAndCount()
        {
            if (State == 0) State = 1;
            else State = 0;
            Count++;
        }

        public SpConverterVM()
        {
            State = 0;
            CurrentArticle = new Article() { 
                Author = "小泽",
                Title = "WPFDemo演示",
                Content = "这是内容内容内容内容内容内容"
            };
        }

        private void ChangeState()
        {
            if (State == 0) State = 1;
            else State = 0;
        }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
