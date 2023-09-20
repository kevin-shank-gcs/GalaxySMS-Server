using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class PanelBoardInformationReq
    {
        public PanelBoardInformationReq()
        {
        }

        public PanelBoardInformationReq(PanelBoardInformationReq p)
        {
            if (p != null)
            {
                BoardNumber = p.BoardNumber;
                BoardType = p.BoardType;
            }
        }

        [Required]
        [Range(1, 32)]
        public short BoardNumber { get; set; }
        public GalaxyInterfaceBoardType BoardType { get; set; }
    }


    public class PanelBoardInformationCollectionReq : List<PanelBoardInformationReq>
    {
        public PanelBoardInformationCollectionReq()
        {
            
        }

        public PanelBoardInformationCollectionReq(List<PanelBoardInformationReq> o):base(o)
        {
            
        }
        
        public PanelBoardInformationCollectionReq(PanelBoardInformationCollectionReq o):base(o)
        {
            
        }

        //public PanelBoardInformationCollectionReq()
        //{
        //    Boards = new List<PanelBoardInformationReq>();
        //}

        //public PanelBoardInformationCollectionReq(PanelBoardInformationCollectionReq o)
        //{
        //    Boards = new List<PanelBoardInformationReq>();
        //    if (o != null)
        //        Boards = o.Boards.ToList();
        //}
        //public List<PanelBoardInformationReq> Boards { get; set; }
    }

}
