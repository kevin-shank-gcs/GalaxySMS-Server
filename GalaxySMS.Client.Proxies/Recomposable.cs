using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Proxies
{
    [Export]
    public class Recomposable<T>
    {
        [Import(AllowRecomposition=true)]
        public T Value { get; private set; }
    }
}
