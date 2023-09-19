////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\DisposableProxyExecutioner.cs
//
// summary:	Implements the disposable proxy executioner class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Logger;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A disposable proxy executioner. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class DisposableProxyExecutioner
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WithClient<T>(T proxy, Action<T> codeToExecute)
        {
            codeToExecute.Invoke(proxy);

            try
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("WithClient exception: {0}", ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static async void WithClientAsync<T>(T proxy, Action<T> codeToExecute)
        {
            await Task.Run(() =>
            {
                codeToExecute.Invoke(proxy);
            });

            try
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("WithClientAsync exception: {0}", ex.Message);
            }
        }
    }
}
