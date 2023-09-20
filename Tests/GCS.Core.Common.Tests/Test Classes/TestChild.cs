using System;
using System.Collections.Generic;
using GCS.Core.Common.Core;

namespace GCS.Core.Common.Tests
{
    internal class TestChild : ObjectBase
    {
        string _ChildName = string.Empty;

        public string ChildName
        {
            get { return _ChildName; }
            set
            {
                if (_ChildName == value)
                    return;

                _ChildName = value;
                OnPropertyChanged(() => ChildName);
            }
        }
    }
}
