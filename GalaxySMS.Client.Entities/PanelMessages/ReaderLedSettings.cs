////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ReaderLedSettings.cs
//
// summary:	Implements the reader LED settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A reader LED settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class ReaderLedSettings : ObjectBase
	{
        /// <summary>   The no leds. </summary>
	    private LedMode _noLeds;
        /// <summary>   The green solid. </summary>
	    private LedMode _greenSolid;
        /// <summary>   The red solid. </summary>
	    private LedMode _redSolid;
        /// <summary>   The both solid. </summary>
	    private LedMode _bothSolid;
        /// <summary>   The green blink 6 times per second. </summary>
	    private LedMode _greenBlink6TimesPerSecond;
        /// <summary>   The green blink 12 times per second. </summary>
	    private LedMode _greenBlink12TimesPerSecond;
        /// <summary>   The both blink 12 times per second. </summary>
	    private LedMode _bothBlink12TimesPerSecond;
        /// <summary>   The red blink 2 times per second. </summary>
	    private LedMode _redBlink2TimesPerSecond;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public ReaderLedSettings()
		{
			NoLeds = LedMode.AllOff;
			GreenSolid = LedMode.GreenOnlySolid;
			RedSolid = LedMode.RedOnlySolid;
			BothSolid = LedMode.BothSolid;
			GreenBlink6TimesPerSecond = LedMode.GreenBlink6TimesPerSecond;
			GreenBlink12TimesPerSecond = LedMode.GreenBlink12TimesPerSecond;
			BothBlink12TimesPerSecond = LedMode.BothBlink12TimesPerSecond;
			RedBlink2TimesPerSecond = LedMode.RedBlink2TimesPerSecond;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the no leds. </summary>
        ///
        /// <value> The no leds. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode NoLeds
	    {
	        get { return _noLeds; }
            set
            {
                if (_noLeds != value)
                {
                    _noLeds = value;
                    OnPropertyChanged(() => NoLeds);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the green solid. </summary>
        ///
        /// <value> The green solid. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode GreenSolid
	    {
	        get { return _greenSolid; }
            set
            {
                if (_greenSolid != value)
                {
                    _greenSolid = value;
                    OnPropertyChanged(() => GreenSolid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the red solid. </summary>
        ///
        /// <value> The red solid. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode RedSolid
	    {
	        get { return _redSolid; }
            set
            {
                if (_redSolid != value)
                {
                    _redSolid = value;
                    OnPropertyChanged(() => RedSolid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the both solid. </summary>
        ///
        /// <value> The both solid. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode BothSolid
	    {
	        get { return _bothSolid; }
            set
            {
                if (_bothSolid != value)
                {
                    _bothSolid = value;
                    OnPropertyChanged(() => BothSolid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the green blink 6 times per second. </summary>
        ///
        /// <value> The green blink 6 times per second. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode GreenBlink6TimesPerSecond
	    {
            get { return _greenBlink6TimesPerSecond; }
            set
            {
                if (_greenBlink6TimesPerSecond != value)
                {
                    _greenBlink6TimesPerSecond = value;
                    OnPropertyChanged(() => GreenBlink6TimesPerSecond);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the green blink 12 times per second. </summary>
        ///
        /// <value> The green blink 12 times per second. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode GreenBlink12TimesPerSecond
	    {
	        get { return _greenBlink12TimesPerSecond; }
            set
            {
                if (_greenBlink12TimesPerSecond != value)
                {
                    _greenBlink12TimesPerSecond = value;
                    OnPropertyChanged(() => GreenBlink12TimesPerSecond);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the both blink 12 times per second. </summary>
        ///
        /// <value> The both blink 12 times per second. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode BothBlink12TimesPerSecond
	    {
	        get { return _bothBlink12TimesPerSecond; }
            set
            {
                if (_bothBlink12TimesPerSecond != value)
                {
                    _bothBlink12TimesPerSecond = value;
                    OnPropertyChanged(() => BothBlink12TimesPerSecond);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the red blink 2 times per second. </summary>
        ///
        /// <value> The red blink 2 times per second. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public LedMode RedBlink2TimesPerSecond
	    {
	        get { return _redBlink2TimesPerSecond; }
            set
            {
                if (_redBlink2TimesPerSecond != value)
                {
                    _redBlink2TimesPerSecond = value;
                    OnPropertyChanged(() => RedBlink2TimesPerSecond);
                }
            }
        }
	}
}
