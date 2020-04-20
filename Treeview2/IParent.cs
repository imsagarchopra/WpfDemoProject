using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treeview2
{
    interface IParent<T>
    {
        IEnumerable<T> GetChildren();
    }
}
