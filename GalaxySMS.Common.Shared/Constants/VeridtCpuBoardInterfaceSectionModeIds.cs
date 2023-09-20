////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\VeridtCpuBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the veridt CPU board interface section mode identifiers class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    public class VeridtCpuBoardInterfaceSectionModeIds
    {
        public static readonly Guid VeridtCpuBoardInterfaceSectionMode_Cpu = new Guid("a2d8e561-5d0c-4915-a850-65346ddbf8ae");

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(VeridtCpuBoardInterfaceSectionMode_Cpu);
                return r;
            }
        }
    }

}
