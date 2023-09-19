using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    public enum GalaxyLoadFlashCommandActionCode
    {
        BeginFlashLoad,
        BeginFlashLoadAutoValidateFlashData,
        BeginFlashLoadAutoValidateAndBurnFlashData,
        CancelFlashLoad,
        PauseFlashLoad,
        ResumeFlashLoad,
        ValidateFlashData,
        ValidateAndBurnFlashData
    }
}
