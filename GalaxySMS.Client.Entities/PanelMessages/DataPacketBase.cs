////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\DataPacketBase.cs
//
// summary:	Implements the data packet base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data packet base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DataPacketBase : ObjectBase
    {
        /// <summary>   The date time created Date/Time. </summary>
        private DateTimeOffset _dateTimeCreated;
        /// <summary>   The which direction. </summary>
        private Direction _whichDirection;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataPacketBase()
            : base()
        {
            DateTimeCreated = DateTimeOffset.Now;
            WhichDirection = Direction.Unknown;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The DataPacketBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataPacketBase(DataPacketBase p)
            : base()
        {
            if (p != null)
            {
                DateTimeCreated = p.DateTimeCreated;
                WhichDirection = p.WhichDirection;
            }
            else
            {
                DateTimeCreated = DateTimeOffset.Now;
                WhichDirection = Direction.Unknown;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent directions. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum Direction { Unknown, ReceivedFromPanel, TransmittedToPanel }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the date time created. </summary>
        ///
        /// <value> The date time created. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset DateTimeCreated
        {
            get { return _dateTimeCreated; }
            set
            {
                if (_dateTimeCreated != value)
                {
                    _dateTimeCreated = value;
                    OnPropertyChanged(() => DateTimeCreated);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the which direction. </summary>
        ///
        /// <value> The which direction. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Direction WhichDirection
        {
            get { return _whichDirection; }
            set
            {
                if (_whichDirection != value)
                {
                    _whichDirection = value;
                    OnPropertyChanged(() => WhichDirection);
                }
            }
        }
    }
}
