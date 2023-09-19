////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\VeridtReaderModuleBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the veridt reader module board interface section mode identifiers class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{

    public class VeridtReaderModuleBoardInterfaceSectionModeIds
    {
        public static readonly Guid VeridtReaderModuleBoardInterfaceSectionMode_Reader = new Guid("444a5034-9ee2-42ce-ab28-7558446b70dc");

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(VeridtReaderModuleBoardInterfaceSectionMode_Reader);
                return r;
            }
        }
    }

}
