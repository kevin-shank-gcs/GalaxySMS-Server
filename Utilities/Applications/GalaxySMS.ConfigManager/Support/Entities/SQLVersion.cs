using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support.Entities
{
    public class SqlFeature : ObjectBase
    {
        private bool _isSelected;
        private string _title;
        private string _code;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(() => Title, true);
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(() => Code, true);
                }
            }
        }


        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(() => IsSelected, true);
                }
            }
        }

    }

    public class SQLVersion : ObjectBase
    {
        private string _name;

        public enum SQL_TYPE : int
        {
            SQL2014_EXPRESS_32BIT,
            SQL2014_EXPRESS_64BIT,
            SQL2016_SP1_EXPRESS_64_BIT,
            SQL2017_EXPRESS_64_BIT,
            SQL2019_EXPRESS_64_BIT,
        };

        public SQLVersion()
        {
            Features = new List<SqlFeature>();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(() => Name, true);
                }
            }
        }

        public SQL_TYPE SqlType { get; set; }
        public List<SqlFeature> Features { get; set; }
        public string SetupPath { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }

}
