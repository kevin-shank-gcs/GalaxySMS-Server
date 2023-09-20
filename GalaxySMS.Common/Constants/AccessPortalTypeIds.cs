////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalTypeIds.cs
//
// summary:	Implements the access portal type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalTypeIds
    {
        /// <summary>   The access portal type standard entry point assa IP enabled lock. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_AssaIpEnabledLock = new Guid("EEA973D8-14E4-4F09-AF7A-8DCD063D85FA");
        /// <summary>   The access portal type standard entry point standard wiegand. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_StandardWiegand = new Guid("8DE76CA9-B459-441A-BB4D-792A9AA30DF9");
        /// <summary>   The access portal type standard entry point standard data clock. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_StandardDataClock = new Guid("B012868C-BFF9-4353-9EA7-4B5D09FFAD7C");
        /// <summary>   The access portal type standard entry point farpointe pyramid. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_FarpointePyramid = new Guid("C96D766D-1FF1-42E1-A28F-BD2F7FDC8E61");
        /// <summary>   The access portal type standard entry point farpointe delta. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_FarpointeDelta = new Guid("A50BB875-4E8B-42E6-A8C5-1F40AC721817");
        /// <summary>   The access portal type standard entry point farpointe ranger. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_FarpointeRanger = new Guid("6C674D89-887C-4D4B-8444-7F4FAB282A48");
        /// <summary>   The access portal type standard entry point HID prox 125 k. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_HIDProx125K = new Guid("F3D594E0-D566-4A9E-A18A-981FAA41E33E");
        /// <summary>   The access portal type standard entry point higher di class se. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_HIDiClassSE = new Guid("5E62DF09-1F39-472D-98A8-E345BBEEEEBB");
        /// <summary>   The access portal type standard entry point higher di class long range. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_HIDiClassLongRange = new Guid("94AE4932-3575-45FA-8C82-D953348C6663");
        /// <summary>   The access portal type standard entry point higher di classi class. </summary>
        public static readonly Guid AccessPortalType_StandardEntryPoint_HIDiClassiClass = new Guid("B35F3FAC-27B7-4A0F-98F9-4306811A3C61");
    }
}
