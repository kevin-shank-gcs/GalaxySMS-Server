using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Framework.DataAccess.DataClasses;

namespace GCS.Framework.DataAccess
{

        public class SqlServerSelectedEventArgs : EventArgs
        {
            public SqlServerSelectedEventArgs(SqlServer server) : base()
            {
                ConnectionString = string.Empty;
                SelectedSqlServer = server;
                if (server != null)
                    ConnectionString = server.ConnectionString;
            }

            public string ConnectionString { get; internal set; }

            public SqlServer SelectedSqlServer { get; internal set; }
        }
}
