using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class SaveParams
    {
        public SaveParams()
        {
            Options = new List<KeyValuePair<string, string>>();
            IgnoreProperties = new List<string>();
        }

        public SaveParams(SaveParams o)
        {
            Options = new List<KeyValuePair<string, string>>();
            IgnoreProperties = new List<string>();
            if( o != null)
            {
                OperationUid = o.OperationUid;
                SavePhoto = o.SavePhoto;
                Options = o.Options;
                IgnoreProperties = o.IgnoreProperties;
            }
        }
        public bool SavePhoto { get; set; }
        public ICollection<KeyValuePair<string, string>> Options { get; set; }
        public ICollection<string> IgnoreProperties { get; set; }
        public Guid OperationUid { get; set; }

    }

    public class SaveParams<T> : SaveParams where T : class, new()
    {
        public SaveParams() : base()
        {
            Data = new T();
        }

        public SaveParams(SaveParams<T> p) : base(p)
        {
            Data = p.Data;
        }

        
        [Required]
        public T Data { get; set; }

    }

}
