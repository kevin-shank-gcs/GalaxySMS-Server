////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PersonExpirationModeIds.cs
//
// summary:	Implements the person expiration mode identifiers class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    public class PersonActivationModeIds
    {
        public static readonly Guid ImmediatelyActive = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid ActivateByDate = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid ActivateByDateAndTime = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
