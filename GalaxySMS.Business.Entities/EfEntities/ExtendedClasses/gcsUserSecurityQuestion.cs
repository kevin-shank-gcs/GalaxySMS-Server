    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class gcsUserSecurityQuestion
        {
        	public gcsUserSecurityQuestion()
        	{
        		Initialize();
        	}
        
        	public gcsUserSecurityQuestion(gcsUserSecurityQuestion e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsUserSecurityQuestion e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.UserSecurityQuestionId = e.UserSecurityQuestionId;
        		this.UserId = e.UserId;
        		this.QuestionNumber = e.QuestionNumber;
        		this.SecurityQuestion = e.SecurityQuestion;
        		this.SecurityAnswer = e.SecurityAnswer;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsUserSecurityQuestion Clone(gcsUserSecurityQuestion e)
        	{
        		return new gcsUserSecurityQuestion(e);
        	}
        
        	public bool Equals(gcsUserSecurityQuestion other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsUserSecurityQuestion other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserSecurityQuestionId != this.UserSecurityQuestionId )
        			return false;
        		return true;
        	}
        
        	public override int GetHashCode()
        	{
        		return base.GetHashCode();
        	}
        }
    }
