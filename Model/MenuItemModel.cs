using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.Demo.Model
{
    public class MenuItemModel
    {
        public MenuItemModel(string name,string source)
        {
            Name = name;
            Source = source;
        }
        public string Name { get; set; }
        public string Source { get; set; }
    }
}
