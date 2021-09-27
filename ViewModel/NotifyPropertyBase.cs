using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Wpf.Demo.ViewModel
{
    public class NotifyPropertyBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
    public static class NotifyPropertyBaseEx
    {
        //扩展方法
        public static void SetProperty<T, U>(this T tvm, Expression<Func<T, U>> expre) where T : NotifyPropertyBase, new()
        {
            string _pro = GetPropertyName(expre);
            tvm.OnPropertyChanged(_pro);
        }

        public static string GetPropertyName<T, U>(Expression<Func<T, U>> expr)
        {
            string _propertyName = "";
            if (expr.Body is MemberExpression)
            {
                _propertyName = (expr.Body as MemberExpression).Member.Name;
            }
            else if (expr.Body is UnaryExpression)
            {
                _propertyName = ((expr.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            }
            return _propertyName;
        }
    }
}
