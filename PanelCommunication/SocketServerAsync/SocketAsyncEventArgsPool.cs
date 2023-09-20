////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SocketAsyncEventArgsPool.cs
//
// summary:	Implements the socket asynchronous event arguments pool class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Represents a collection of resusable SocketAsyncEventArgs objects.   </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	class SocketAsyncEventArgsPool
	{
        /// <summary>   The pool. </summary>
		Stack<SocketAsyncEventArgs> m_pool;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the object pool to the specified size. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="capacity"> The maximum number of SocketAsyncEventArgs objects the pool can hold. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public SocketAsyncEventArgsPool(int capacity)
		{
			m_pool = new Stack<SocketAsyncEventArgs>(capacity);
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Add a SocketAsyncEventArg instance to the pool. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="item"> The SocketAsyncEventArgs instance to add to the pool. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void Push(SocketAsyncEventArgs item)
		{
			if (item == null) { throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); }
			lock (m_pool)
			{
				m_pool.Push(item);
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes a SocketAsyncEventArgs instance from the pool. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The object removed from the pool. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public SocketAsyncEventArgs Pop()
		{
			lock (m_pool)
			{
				return m_pool.Pop();
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The number of SocketAsyncEventArgs instances in the pool. </summary>
        ///
        /// <value> The count. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public int Count
		{
			get { return m_pool.Count; }
		}

	}
}
