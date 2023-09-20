////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\FeatureIds.cs
//
// summary:	Implements the feature identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal feature identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalFeatureIds
    {
        /// <summary>   The has credential reader. </summary>
        public static readonly Guid HasCredentialReader = new Guid("73384773-BAF0-4DA8-BFAB-4437B9EA8E95");
        /// <summary>   The has lock. </summary>
        public static readonly Guid HasLock = new Guid("7688B3A9-E6F6-4393-9D00-53CFCC163CB0");
        /// <summary>   The has request to exit. </summary>
        public static readonly Guid HasRequestToExit = new Guid("364B7C1C-9B13-4669-9C50-1BF5CB7E6E3F");
        /// <summary>   The has door contact. </summary>
        public static readonly Guid HasDoorContact = new Guid("E759AD14-E6A1-4DFC-A4BA-D2BDA87033FC");
    }
}
