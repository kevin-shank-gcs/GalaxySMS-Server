    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class AccessProfileInputOutputGroup
        {
        	public AccessProfileInputOutputGroup() : base()
        	{
        		Initialize();
        	}
        
        	public AccessProfileInputOutputGroup(AccessProfileInputOutputGroup e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessProfileInputOutputGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessProfileInputOutputGroupUid = e.AccessProfileInputOutputGroupUid;
        		this.AccessProfileClusterUid = e.AccessProfileClusterUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.OrderNumber = e.OrderNumber;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.InputOutputGroupNumber = e.InputOutputGroupNumber;
                this.InputOutputGroupName = e.InputOutputGroupName;
        	}
        
        	public AccessProfileInputOutputGroup Clone(AccessProfileInputOutputGroup e)
        	{
        		return new AccessProfileInputOutputGroup(e);
        	}
        
        	public bool Equals(AccessProfileInputOutputGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessProfileInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessProfileInputOutputGroupUid != this.AccessProfileInputOutputGroupUid )
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
        
            private int _inputOutputGroupNumber;

            [DataMember]
            public int InputOutputGroupNumber
            {
                get { return _inputOutputGroupNumber; }
                set
                {
                    if (_inputOutputGroupNumber != value)
                    {
                        _inputOutputGroupNumber = value;
                        OnPropertyChanged(() => InputOutputGroupNumber, true);
                    }
                }
            }


            private string _inputOutputGroupName;

            [DataMember]
            public string InputOutputGroupName
            {
                get { return _inputOutputGroupName; }
                set
                {
                    if (_inputOutputGroupName != value)
                    {
                        _inputOutputGroupName = value;
                        OnPropertyChanged(() => InputOutputGroupName, true);
                    }
                }
            }
        }
    }
