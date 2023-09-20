////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyCpu.cs
//
// summary:	Implements the galaxy CPU class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy cpu. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyCpuConnection
    {
        public GalaxyCpuConnection()
        {
            Initialize();
        }

        public GalaxyCpuConnection(GalaxyCpuConnection e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyCpuConnection e)
        {
            Initialize();
            if (e == null)
                return;
            this.CpuUid = e.CpuUid;
            this.IsConnected = e.IsConnected;
            this.ServerAddress = e.ServerAddress;
            this.LastConnectedTime = e.LastConnectedTime;
            this.LastDisconnectedTime = e.LastDisconnectedTime;
        }

        public GalaxyCpuConnection Clone(GalaxyCpuConnection e)
        {
            return new GalaxyCpuConnection(e);
        }

        public bool Equals(GalaxyCpuConnection other)
        {
            if (this.CpuUid != other.CpuUid )
                return false;
            return true;
            //return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuConnection other)
        {
            if (other == null)
                return false;

            if (other.CpuUid != this.CpuUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}