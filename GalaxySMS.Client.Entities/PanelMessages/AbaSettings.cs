////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\AbaSettings.cs
//
// summary:	Implements the aba settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An aba settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class AbaSettings : ObjectBase
	{
        /// <summary>   The start. </summary>
	    private byte _start;
        /// <summary>   The end. </summary>
	    private byte _end;
        /// <summary>   The folding. </summary>
	    private AbaFold _folding;
        /// <summary>   The clipping. </summary>
	    private AbaClip _clipping;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public AbaSettings()
		{
			Start = 1;
			End = 60;
			Folding = AbaFold.Off;
			Clipping = AbaClip.None;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the start. </summary>
        ///
        /// <value> The start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte Start
	    {
	        get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    OnPropertyChanged(() => Start);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the end. </summary>
        ///
        /// <value> The end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte End
	    {
	        get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    OnPropertyChanged(() => End);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the folding. </summary>
        ///
        /// <value> The folding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AbaFold Folding
	    {
	        get { return _folding; }
            set
            {
                if (_folding != value)
                {
                    _folding = value;
                    OnPropertyChanged(() => Folding);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the clipping. </summary>
        ///
        /// <value> The clipping. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AbaClip Clipping
	    {
	        get { return _clipping; }
            set
            {
                if (_clipping != value)
                {
                    _clipping = value;
                    OnPropertyChanged(() => Clipping);
                }
            }
	    }
	}
}
