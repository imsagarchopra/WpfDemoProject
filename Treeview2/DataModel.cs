using System;
using System.Collections.Generic;
using System.Windows;
using Treeview2;

namespace WpfApplication102
{
    public class Family : DependencyObject, IParent<object>
    {
        public string Name { get; set; }
        public List<Person> Members { get; set; }

        IEnumerable<object> IParent<object>.GetChildren()
        {
            if (Members == null)
            {
                Members = new List<Person>();
            }
            return Members;
        }
    }

    public class Person : DependencyObject, IParent<object>
    {
        public string Name { get; set; }
        public List<Children> Members { get; set; }
        IEnumerable<object> IParent<object>.GetChildren()
        {
            if (Members == null)
            {
                Members = new List<Children>();
            }
            return Members;
        }
    }

    public class Children : DependencyObject
    {
        public string Name { get; set; }
    }
}