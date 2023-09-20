////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\PDSADataAccess.cs
//
// summary:	Implements the pdsa data access class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSA.DataLayer;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A pdsa data access. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PDSADataAccess
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the provider. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The provider. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected static object GetProvider()
        {
            var mgr = new PDSADataManager();
            return mgr.Provider;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets database connection string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The database connection string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected static string GetDatabaseConnectionString()
        {
            var mgr = new PDSADataManager();
            return mgr.Provider.ConnectString;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data set. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sql">  The SQL. </param>
        ///
        /// <returns>   The data set. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected static DataSet GetDataSet(string sql)
        {
            DataSet ds;
            var mgr = new PDSADataManager();
            ds = mgr.Provider.GetDataSet(sql);
            return ds;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the SQL operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sql">          The SQL. </param>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected static void ExecuteSQL(string sql, IEnumerable<IDataParameter> parameters)
        {
            var mgr = new PDSADataManager();
            var prov = mgr.Provider;
            var cmd = prov.CreateCommand(sql);
            cmd.Connection = prov.CreateConnection(prov.ConnectString);
            foreach (var param in parameters)
                cmd.Parameters.Add(param);

            // Execute the SQL and close the connection
            var rows = prov.ExecuteSQL(cmd, true);
        }
    }
}
