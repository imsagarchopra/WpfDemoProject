using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treeview
{
    interface IParent<T>
    {
        IEnumerable<T> GetChildren();
    }
}
