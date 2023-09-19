using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.PDSA.BusinessClasses
{
    public class PDSAStoredProcExecuteManager : PDSAStoredProcExecuteManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcs_IsEntityUniquePDSAManager class
        /// </summary>
        public PDSAStoredProcExecuteManager()
            : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcs_IsEntityUniquePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PDSAStoredProcExecuteManager(PDSADataProvider dataProvider)
            : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created

            ClassName = "PDSAStoredProcExecuteManager";
        }
        #endregion
    }
}
