////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PersonExpirationModeIds.cs
//
// summary:	Implements the person expiration mode identifiers class
///=================================================================================================

using System;

namespace GalaxySMS.Common.Constants
{
    public class PersonExpirationModeIds
    {
        public static readonly Guid NeverExpires = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid ExpireByDate = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid ExpireByUsageCount = new Guid("00000000-0000-0000-0000-000000000003");
        public static readonly Guid ExpireByDateAndTime = new Guid("00000000-0000-0000-0000-000000000004");
        public static readonly Guid ExpireByDateAndTimeAndUsageCount = new Guid("00000000-0000-0000-0000-000000000005");
    }
}
