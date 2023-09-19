////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\DataAccess.cs
//
// summary:	Implements the data access class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data access. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DataAccess
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data set. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="svr">  The server. </param>
        /// <param name="sql">  The SQL. </param>
        ///
        /// <returns>   The data set. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DataSet GetDataSet(Server svr, string sql)
        {
            var ds = svr.ConnectionContext.ExecuteWithResults(sql);
            return ds;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data sets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="svr">          The server. </param>
        /// <param name="sqlCommands">  The SQL commands. </param>
        ///
        /// <returns>   An array of data set. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DataSet[] GetDataSets(Server svr, StringCollection sqlCommands)
        {
            var ds = svr.ConnectionContext.ExecuteWithResults(sqlCommands);
            return ds;
        }
    }
}
