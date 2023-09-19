////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BufferManager.cs
//
// summary:	Implements the buffer manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Net.Sockets;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class creates a single large buffer which can be divided up and assigned to
    /// SocketAsyncEventArgs objects for use with each socket I/O operation.  This enables bufffers
    /// to be easily reused and gaurds against fragmenting heap memory.
    /// 
    /// The operations exposed on the BufferManager class are not thread safe.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	class BufferManager
	{
        /// <summary>   the total number of bytes controlled by the buffer pool. </summary>
		int m_numBytes;
        /// <summary>   the underlying byte array maintained by the Buffer Manager. </summary>
		byte[] m_buffer;
        /// <summary>   The free index pool. </summary>
		Stack<int> m_freeIndexPool;     // 
        /// <summary>   The current index. </summary>
		int m_currentIndex;
        /// <summary>   Size of the buffer. </summary>
		int m_bufferSize;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="totalBytes">   The total in bytes. </param>
        /// <param name="bufferSize">   Size of the buffer. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public BufferManager(int totalBytes, int bufferSize)
		{
			m_numBytes = totalBytes;
			m_currentIndex = 0;
			m_bufferSize = bufferSize;
			m_freeIndexPool = new Stack<int>();
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Allocates buffer space used by the buffer pool. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void InitBuffer()
		{
			// create one big large buffer and divide that out to each SocketAsyncEventArg object
			m_buffer = new byte[m_numBytes];
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Assigns a buffer from the buffer pool to the specified SocketAsyncEventArgs object.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="args"> Socket asynchronous event information. </param>
        ///
        /// <returns>   true if the buffer was successfully set, else false. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public bool SetBuffer(SocketAsyncEventArgs args)
		{

			if (m_freeIndexPool.Count > 0)
			{
				args.SetBuffer(m_buffer, m_freeIndexPool.Pop(), m_bufferSize);
			}
			else
			{
				if ((m_numBytes - m_bufferSize) < m_currentIndex)
				{
					return false;
				}
				args.SetBuffer(m_buffer, m_currentIndex, m_bufferSize);
				m_currentIndex += m_bufferSize;
			}
			return true;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Removes the buffer from a SocketAsyncEventArg object.  This frees the buffer back to the
        /// buffer pool.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="args"> Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void FreeBuffer(SocketAsyncEventArgs args)
		{
			m_freeIndexPool.Push(args.Offset);
			args.SetBuffer(null, 0, 0);
		}


	}
}
