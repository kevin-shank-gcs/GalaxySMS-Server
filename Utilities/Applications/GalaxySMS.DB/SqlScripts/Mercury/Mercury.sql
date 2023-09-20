
if exists (select 1
            from  sysobjects
           where  id = object_id('GCS.RoleMercScpGroupPermission')
            and   type = 'U')
   drop table GCS.RoleMercScpGroupPermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GCS.RoleMercScpGroup')
            and   type = 'U')
   drop table GCS.RoleMercScpGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GCS.MercScpStatus')
            and   type = 'U')
   drop table GCS.MercScpStatus
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GCS.MercScp')
            and   type = 'U')
   drop table GCS.MercScp
go


if exists (select 1
            from  sysobjects
           where  id = object_id('GCS.MercScpGroup')
            and   type = 'U')
   drop table GCS.MercScpGroup
go



if exists (select 1
			from  sysobjects
		   where  id = object_id('GCS.MercScpType')
			and   type = 'U')
   drop table GCS.MercScpType
go


if exists (select 1
			from  sysobjects
		   where  id = object_id('GCS.MercSioType')
			and   type = 'U')
   drop table GCS.MercSioType
go

if exists (select 1
			from  sysobjects
		   where  id = object_id('GCS.MercScpIdReport')
			and   type = 'U')
   drop table GCS.MercScpIdReport
go


CREATE OR ALTER FUNCTION [GCS].[MercScpEntityId] (@mercScpUid uniqueidentifier) 
RETURNS uniqueidentifier
as
begin

declare @uid uniqueidentifier

	SELECT @uid = g.EntityId from GCS.MercScp scp JOIN GCS.MercScpGroup g ON g.MercScpGroupUid = scp.MercScpGroupUid 
	where scp.MercScpUid = @mercScpUid
	
	return @uid
end
go

GRANT EXECUTE ON GCS.[MercScpEntityId] TO public
GO

CREATE OR ALTER FUNCTION [GCS].[MercScpSiteUid] (@mercScpUid uniqueidentifier) 
RETURNS uniqueidentifier
as
begin

declare @uid uniqueidentifier

	SELECT @uid = g.SiteUid from GCS.MercScp scp JOIN GCS.MercScpGroup g ON g.MercScpGroupUid = scp.MercScpGroupUid 
	where scp.MercScpUid = @mercScpUid
	
	return @uid
end
go

GRANT EXECUTE ON GCS.[MercScpSiteUid] TO public
GO

/*==============================================================*/
/* Table: MercScp                                               */
/*==============================================================*/
create table GCS.MercScp (
   MercScpUid           GCS.UniversalUniqueId    RowGuidCol not null,
   MercScpTypeUid       uniqueidentifier    not null,
   MercScpGroupUid      uniqueidentifier    not null,
   ScpName              GCS.Text65               not null,
   Location             GCS.Text65               null,
   Description			GCS.Text1000			 null,
   MacAddress           GCS.Text50               not null,
   Serialnumber         bigint               not null default 0,
   ConnectionType       int                  not null default 4,
   IpAddress            GCS.Text50               null,
   IpPort               int                  not null default 3001,
   AesPassword          GCS.Text50               null,
   ScpReplyTimeout      int                  not null default 3000,
   TcpConnectRetryInterval int                  not null default 10000,
   RetryCountBeforeOffline int                  not null default 0,
   OfflineTime          int                  not null default 15000,
   PollDelay            int                  not null default 5000,
   TimeZoneId           GCS.Text65               not null,
   UseDaylightSavingsTime bit                  not null default 1,
   TransactionCount     int                  not null default 60000,
   TransactionUnreportedLimit int                  not null default 50000,
   DualPortEnabled      bit                  not null,
   ConnectionTypeAlt    int                  not null default 4,
   RetryCountBeforeOfflineAlt int                  not null default 0,
   PollDelayAlt         int                  not null default 5000,
   IpAddressAlt         GCS.Text50               null,
   IpPortAlt            int                  not null default 3001,
   AllowConnection      bit                  not null default 1,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset             not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset             null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1,
   EntityId as ([GCS].[MercScpEntityId](MercScpUid)),
   SiteUid as ([GCS].[MercScpSiteUid](MercScpUid))
)
go


alter table GCS.MercScp
   add constraint CKC_CONNECTIONTYPE_MERCSCP check (ConnectionType in (4,7))
go

alter table GCS.MercScp
   add constraint CKC_IPPORT_MERCSCP check (IpPort is null or (IpPort between 0 and 65535))
go

alter table GCS.MercScp
   add constraint CKC_SCPREPLYTIMEOUT_MERCSCP check (ScpReplyTimeout between 500 and 65535)
go

alter table GCS.MercScp
   add constraint CKC_TCPCONNECTRETRYIN_MERCSCP check (TcpConnectRetryInterval between 2000 and 60000)
go

alter table GCS.MercScp
   add constraint CKC_OFFLINETIME_MERCSCP check (OfflineTime between 2000 and 65000)
go

alter table GCS.MercScp
   add constraint CKC_POLLDELAY_MERCSCP check (PollDelay between 500 and 5000)
go

alter table GCS.MercScp
   add constraint CKC_TRANSACTIONCOUNT_MERCSCP check (TransactionCount >= 10000)
go

alter table GCS.MercScp
   add constraint CKC_TRANSACTIONUNREPO_MERCSCP check (TransactionUnreportedLimit >= 10000)
go

alter table GCS.MercScp
   add constraint CKC_CONNECTIONTYPEALT_MERCSCP check (ConnectionTypeAlt in (0,4,7))
go

alter table GCS.MercScp
   add constraint CKC_POLLDELAYALT_MERCSCP check (PollDelayAlt between 500 and 5000)
go

alter table GCS.MercScp
   add constraint CKC_IPPORTALT_MERCSCP check (IpPortAlt between 0 and 65535)
go

alter table GCS.MercScp
   add constraint PK_MERCSCP primary key (MercScpUid)
go

exec dbo.[gcs_DeleteIndex] 'GCS', 'MercScp', 'idxScpSerialnumber'
go

/*==============================================================*/
/* Index: idxScpSerialnumber                                    */
/*==============================================================*/
create nonclustered index idxScpSerialnumber on GCS.MercScp (Serialnumber ASC)
go

/*==============================================================*/
/* Index: idxScpMacAddress                                      */
/*==============================================================*/
create unique nonclustered index idxScpMacAddress on GCS.MercScp (MacAddress ASC)
go

/*==============================================================*/
/* Table: MercScpStatus                                         */
/*==============================================================*/
create table GCS.MercScpStatus (
   MercScpUid           uniqueidentifier     RowGuidCol not null,
   Online               bit                  null,
   LastConnected        datetimeoffset       null,
   LastDisconnected      datetimeoffset       null
)
go

alter table GCS.MercScpStatus
   add constraint PK_MERCSCPSTATUS primary key (MercScpUid)
go

alter table GCS.MercScpStatus
   add constraint FK_MercScpStatusMercScp foreign key (MercScpUid)
      references GCS.MercScp (MercScpUid)
         on update cascade on delete cascade
go



/*==============================================================*/
/* Table: MercScpGroup                                          */
/*==============================================================*/
create table GCS.MercScpGroup (
   MercScpGroupUid      GCS.UniversalUniqueId    RowGuidCol not null,
   EntityId             uniqueidentifier    not null,
   SiteUid              uniqueidentifier    not null,
   Name                 GCS.Text65               not null,
   Description			GCS.Text1000		null,
   IsActive				bit					not null default 1,
   NumberOfTransactions int                  not null,
   NumberOfOperatingModes smallint             not null default 2,
   OperatingModeType    smallint             not null default 0,
   AllowConnection      bit                  not null default 1,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset             not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset             null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.MercScpGroup
   add constraint CKC_NUMBEROFTRANSACTI_MERCSCPG check (NumberOfTransactions >= 60000)
go

alter table GCS.MercScpGroup
   add constraint CKC_NUMBEROFOPERATING_MERCSCPG check (NumberOfOperatingModes between 1 and 8)
go

alter table GCS.MercScpGroup
   add constraint CKC_OPERATINGMODETYPE_MERCSCPG check (OperatingModeType between 0 and 1)
go

alter table GCS.MercScpGroup
   add constraint PK_MERCSCPGROUP primary key (MercScpGroupUid)
go

/*==============================================================*/
/* Index: idxMercScpGroupName                                   */
/*==============================================================*/
create unique nonclustered index idxMercScpGroupName on GCS.MercScpGroup (Name ASC,
  EntityId ASC)
go


alter table GCS.MercScpGroup
   add constraint FK_GcsMercScpGroupEntity foreign key (EntityId)
      references GCS.gcsEntity (EntityId)
         on update cascade on delete cascade
go

alter table GCS.MercScpGroup
   add constraint FK_MercScpGroupSite foreign key (SiteUid)
      references GCS.Site (SiteUid)
         on update cascade on delete cascade
go

-- This must be here because if it is right after the create table GCS.MercScp, it fails because the GCS.MerScpGroup table has not yet been created
alter table GCS.MercScp
   add constraint FK_MercScpMercScpGroup foreign key (MercScpGroupUid)
	  references GCS.MercScpGroup (MercScpGroupUid)
		 on update cascade on delete cascade
go


/*==============================================================*/
/* Table: MercScpType                                           */
/*==============================================================*/
create table GCS.MercScpType (
   MercScpTypeUid       GCS.UniversalUniqueId    RowGuidCol not null,
   Display              GCS.Text65               not null,
   DisplayResourceKey   uniqueidentifier      null,
   Description          GCS.Text1000             not null,
   DescriptionResourceKey uniqueidentifier     null,
   TypeCode             GCS.Text20               not null,
   TypeCodeValue        int                  not null,
   MaxReaders           int                  not null,
   MaxInputs            int                  not null,
   MaxOutputs           int                  not null,
   MaxSio485Ports       smallint             not null,
   OnboardReaders       smallint             not null,
   OnboardInputs        smallint             not null,
   OnboardOutputs       smallint             not null,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset       not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset       null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.MercScpType
   add constraint PK_MERCSCPTYPE primary key (MercScpTypeUid)
go

/*==============================================================*/
/* Index: idxMercScpTypeDisplay                                 */
/*==============================================================*/
create unique nonclustered index idxMercScpTypeDisplay on GCS.MercScpType (Display ASC)
go

/*==============================================================*/
/* Index: idxMercScpTypeCodeValue                               */
/*==============================================================*/
create unique nonclustered index idxMercScpTypeCodeValue on GCS.MercScpType (TypeCodeValue ASC)
go

/*==============================================================*/
/* Index: idxMercScpTypeCode                                    */
/*==============================================================*/
create unique nonclustered index idxMercScpTypeCode on GCS.MercScpType (TypeCode ASC)
go

/*==============================================================*/
/* Table: MercSioType                                           */
/*==============================================================*/
create table GCS.MercSioType (
   MercSioTypeUid       GCS.UniversalUniqueId    RowGuidCol not null,
   Display              GCS.Text65               not null,
   DisplayResourceKey   uniqueidentifier    null,
   Description          GCS.Text1000             not null,
   DescriptionResourceKey uniqueidentifier    null,
   TypeCode             nvarchar(20)         not null,
   TypeCodeValue        int                  not null,
   ModelNumber          int                  not null,
   MaxReaders           int                  not null default 0,
   MaxInputs            int                  not null default 0,
   MaxOutputs           int                  not null default 0,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset       not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset       null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.MercSioType
   add constraint PK_MERCSIOTYPE primary key (MercSioTypeUid)
go

/*==============================================================*/
/* Index: idxMercSioTypeCode                                    */
/*==============================================================*/
create unique nonclustered index idxMercSioTypeCode on GCS.MercSioType (ModelNumber ASC)
go

/*==============================================================*/
/* Index: idxMercSioTypeCodeValue                               */
/*==============================================================*/
create unique nonclustered index idxMercSioTypeCodeValue on GCS.MercSioType (TypeCodeValue ASC)
go


/*==============================================================*/
/* Table: MercScpIdReport                                       */
/*==============================================================*/
create table GCS.MercScpIdReport (
   MercScpIdReportUid   GCS.UniversalUniqueId    RowGuidCol not null,
   MacAddress           GCS.Text50               not null,
   DriverSpcId          int						not null,
   ScpId                int                  not null,
   Serialnumber         bigint               not null,
   DeviceId             GCS.Text50               not null,
   DeviceVersion        GCS.Text50               not null,
   SoftwareRevisionMajor int                  not null,
   SoftwareRevisionMinor int                  not null,
   CumulativeBuildCount int                  not null,
   NeedsConfiguration   bit                  not null,
   TlsStatus            GCS.Text50               not null,
   OemCode              int                  not null,
   CurrentOperatingMode smallint             not null,
   Input1State          smallint             not null,
   Input2State          smallint             not null,
   Input3State          smallint             not null,
   BioDb1Active         int                  not null,
   BioDb1Max            int                  not null,
   BioDb2Active         int                  not null,
   BioDb2Max            int                  not null,
   AssetDbActive        int                  not null,
   AssetDbMax           int                  not null,
   FirmwareAdvisory     GCS.Text50               not null,
   DipSwitchCurrent     smallint             not null,
   DipSwitchPowerUp     smallint             not null,
   DbActiveRecords      int                  not null,
   DbMaxSize            int                  not null,
   CurrentClock         bigint               not null,
   RamFree              int                  not null,
   RamSize              int                  not null,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset             not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset             null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.MercScpIdReport
   add constraint PK_MERCSCPIDREPORT primary key (MercScpIdReportUid)
go


CREATE OR ALTER TRIGGER GCS.td_mercscptype on GCS.MercScpType for delete as
begin
    declare
       @numrows  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Cannot delete parent "GCS.MercScpType" if children still exist in "GCS.MercScp"  */
    if exists (select 1
               from   GCS.MercScp t2, deleted t1
               where  t2.MercScpTypeUid = t1.MercScpTypeUid)
       begin
          select @errno =6,
                 @errmsg = 'Children still exist in "GCS.MercScp". Cannot delete parent "GCS.MercScpType".'
          goto error
       end


    return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.ti_mercscptype on GCS.MercScpType for insert as
begin
    declare
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Parent "GCS.gcsResourceString" must exist when inserting a child in "GCS.MercScpType"  */
    if update(DisplayResourceKey)
    begin
       select @numnull = (select count(*)
                          from   inserted
                          where  DisplayResourceKey is null)
       if @numnull != @numrows
          if (select count(*)
              from   GCS.gcsResourceString t1, inserted t2
              where  t1.ResourceId = t2.DisplayResourceKey) != @numrows - @numnull
          begin
             select @errno =2,
                    @errmsg = 'Parent does not exist in "GCS.gcsResourceString". Cannot create child in "GCS.MercScpType".'
             goto error
          end
    end
    /*  Parent "GCS.gcsResourceString" must exist when inserting a child in "GCS.MercScpType"  */
    if update(DescriptionResourceKey)
    begin
       select @numnull = (select count(*)
                          from   inserted
                          where  DescriptionResourceKey is null)
       if @numnull != @numrows
          if (select count(*)
              from   GCS.gcsResourceString t1, inserted t2
              where  t1.ResourceId = t2.DescriptionResourceKey) != @numrows - @numnull
          begin
             select @errno =2,
                    @errmsg = 'Parent does not exist in "GCS.gcsResourceString". Cannot create child in "GCS.MercScpType".'
             goto error
          end
    end

    return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.tu_mercscptype on GCS.MercScpType for update as
begin
   declare
      @ins_MercScpTypeUid uniqueidentifier,
      @del_MercScpTypeUid uniqueidentifier,
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return

      /*  Parent "GCS.gcsResourceString" must exist when updating a child in "GCS.MercScpType"  */
      if update(DisplayResourceKey)
      begin
         select @numnull = (select count(*)
                            from   inserted
                            where  DisplayResourceKey is null)
         if @numnull != @numrows
            if (select count(*)
                from   GCS.gcsResourceString t1, inserted t2
                where  t1.ResourceId = t2.DisplayResourceKey) != @numrows - @numnull
            begin
               select @errno =3,
                      @errmsg = 'GCS.gcsResourceString" does not exist. Cannot modify child in "GCS.MercScpType".'
               goto error
            end
      end
      /*  Parent "GCS.gcsResourceString" must exist when updating a child in "GCS.MercScpType"  */
      if update(DescriptionResourceKey)
      begin
         select @numnull = (select count(*)
                            from   inserted
                            where  DescriptionResourceKey is null)
         if @numnull != @numrows
            if (select count(*)
                from   GCS.gcsResourceString t1, inserted t2
                where  t1.ResourceId = t2.DescriptionResourceKey) != @numrows - @numnull
            begin
               select @errno =3,
                      @errmsg = 'GCS.gcsResourceString" does not exist. Cannot modify child in "GCS.MercScpType".'
               goto error
            end
      end
      declare cIns cursor local for select 
              MercScpTypeUid
          from inserted
      declare cDel cursor local for select 
              MercScpTypeUid
          from deleted

      /*  Modify parent code of "GCS.MercScpType" for all children in "GCS.MercScp"  */
      if update(MercScpTypeUid)
      begin
         if @@rowcount = 1
            update GCS.MercScp
               set   MercScpTypeUid = i1.MercScpTypeUid
            from   GCS.MercScp t2, inserted i1, deleted d1
               where  t2.MercScpTypeUid = d1.MercScpTypeUid
                and  (i1.MercScpTypeUid != d1.MercScpTypeUid)
         else
         begin
            open cIns
            open cDel
            fetch cIns into @ins_MercScpTypeUid
            fetch cDel into @del_MercScpTypeUid

            while (@@fetch_status = 0)
            begin
               update GCS.MercScp
                  set   MercScpTypeUid = @ins_MercScpTypeUid
               where  MercScpTypeUid = @del_MercScpTypeUid
               fetch cIns into @ins_MercScpTypeUid
               fetch cDel into @del_MercScpTypeUid
            end
            close cIns
            close cDel
         end
      end

      return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.td_mercsiotype on GCS.MercSioType for delete as
begin
    declare
       @numrows  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Cannot delete parent "GCS.MercSioType" if children still exist in "GCS.MercSio"  */
    if exists (select 1
               from   GCS.MercSio t2, deleted t1
               where  t2.MercSioTypeUid = t1.MercSioTypeUid)
       begin
          select @errno =6,
                 @errmsg = 'Children still exist in "GCS.MercSio". Cannot delete parent "GCS.MercSioType".'
          goto error
       end


    return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.ti_mercsiotype on GCS.MercSioType for insert as
begin
    declare
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Parent "GCS.gcsResourceString" must exist when inserting a child in "GCS.MercSioType"  */
    if update(DescriptionResourceKey)
    begin
       select @numnull = (select count(*)
                          from   inserted
                          where  DescriptionResourceKey is null)
       if @numnull != @numrows
          if (select count(*)
              from   GCS.gcsResourceString t1, inserted t2
              where  t1.ResourceId = t2.DescriptionResourceKey) != @numrows - @numnull
          begin
             select @errno =2,
                    @errmsg = 'Parent does not exist in "GCS.gcsResourceString". Cannot create child in "GCS.MercSioType".'
             goto error
          end
    end
    /*  Parent "GCS.gcsResourceString" must exist when inserting a child in "GCS.MercSioType"  */
    if update(DisplayResourceKey)
    begin
       select @numnull = (select count(*)
                          from   inserted
                          where  DisplayResourceKey is null)
       if @numnull != @numrows
          if (select count(*)
              from   GCS.gcsResourceString t1, inserted t2
              where  t1.ResourceId = t2.DisplayResourceKey) != @numrows - @numnull
          begin
             select @errno =2,
                    @errmsg = 'Parent does not exist in "GCS.gcsResourceString". Cannot create child in "GCS.MercSioType".'
             goto error
          end
    end

    return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.tu_mercsiotype on GCS.MercSioType for update as
begin
   declare
      @ins_MercSioTypeUid uniqueidentifier,
      @del_MercSioTypeUid uniqueidentifier,
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return

      /*  Parent "GCS.gcsResourceString" must exist when updating a child in "GCS.MercSioType"  */
      if update(DescriptionResourceKey)
      begin
         select @numnull = (select count(*)
                            from   inserted
                            where  DescriptionResourceKey is null)
         if @numnull != @numrows
            if (select count(*)
                from   GCS.gcsResourceString t1, inserted t2
                where  t1.ResourceId = t2.DescriptionResourceKey) != @numrows - @numnull
            begin
               select @errno =3,
                      @errmsg = 'GCS.gcsResourceString" does not exist. Cannot modify child in "GCS.MercSioType".'
               goto error
            end
      end
      /*  Parent "GCS.gcsResourceString" must exist when updating a child in "GCS.MercSioType"  */
      if update(DisplayResourceKey)
      begin
         select @numnull = (select count(*)
                            from   inserted
                            where  DisplayResourceKey is null)
         if @numnull != @numrows
            if (select count(*)
                from   GCS.gcsResourceString t1, inserted t2
                where  t1.ResourceId = t2.DisplayResourceKey) != @numrows - @numnull
            begin
               select @errno =3,
                      @errmsg = 'GCS.gcsResourceString" does not exist. Cannot modify child in "GCS.MercSioType".'
               goto error
            end
      end
      declare cIns cursor local for select 
              MercSioTypeUid
          from inserted
      declare cDel cursor local for select 
              MercSioTypeUid
          from deleted

      /*  Modify parent code of "GCS.MercSioType" for all children in "GCS.MercSio"  */
      if update(MercSioTypeUid)
      begin
         if @@rowcount = 1
            update GCS.MercSio
               set   MercSioTypeUid = i1.MercSioTypeUid
            from   GCS.MercSio t2, inserted i1, deleted d1
               where  t2.MercSioTypeUid = d1.MercSioTypeUid
                and  (i1.MercSioTypeUid != d1.MercSioTypeUid)
         else
         begin
            open cIns
            open cDel
            fetch cIns into @ins_MercSioTypeUid
            fetch cDel into @del_MercSioTypeUid

            while (@@fetch_status = 0)
            begin
               update GCS.MercSio
                  set   MercSioTypeUid = @ins_MercSioTypeUid
               where  MercSioTypeUid = @del_MercSioTypeUid
               fetch cIns into @ins_MercSioTypeUid
               fetch cDel into @del_MercSioTypeUid
            end
            close cIns
            close cDel
         end
      end

      return

/*  Errors handling  */
error:
    raiserror(@errmsg, @errno, 1)
    rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.ti_mercscp on GCS.MercScp for insert as
begin
	declare
	   @numrows  int,
	   @numnull  int,
	   @errno    int,
	   @errmsg   varchar(255)

	select  @numrows = @@rowcount
	if @numrows = 0
	   return

	/*  Parent "GCS.MercScpType" must exist when inserting a child in "GCS.MercScp"  */
	if update(MercScpTypeUid)
	begin
	   if (select count(*)
		   from   GCS.MercScpType t1, inserted t2
		   where  t1.MercScpTypeUid = t2.MercScpTypeUid) != @numrows
		  begin
			 select @errno =2,
					@errmsg = 'Parent does not exist in "GCS.MercScpType". Cannot create child in "GCS.MercScp".'
			 goto error
		  end
	end

	return

/*  Errors handling  */
error:
	raiserror(@errmsg, @errno, 1)
	rollback  transaction
end
go


CREATE OR ALTER TRIGGER GCS.tu_mercscp on GCS.MercScp for update as
begin
   declare
	  @numrows  int,
	  @numnull  int,
	  @errno    int,
	  @errmsg   varchar(255)

	  select  @numrows = @@rowcount
	  if @numrows = 0
		 return

	  /*  Parent "GCS.MercScpType" must exist when updating a child in "GCS.MercScp"  */
	  if update(MercScpTypeUid)
	  begin
		 if (select count(*)
			 from   GCS.MercScpType t1, inserted t2
			 where  t1.MercScpTypeUid = t2.MercScpTypeUid) != @numrows
			begin
			   select @errno =3,
					  @errmsg = 'GCS.MercScpType" does not exist. Cannot modify child in "GCS.MercScp".'
			   goto error
			end
	  end

	  return

/*  Errors handling  */
error:
	raiserror(@errmsg, @errno, 1)
	rollback  transaction
end
go


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpIdReportUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpIdReportUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].[IsMercScpIdReportUnique]
	@MercScpIdReportUid [uniqueidentifier],
	@MacAddress [nvarchar](50),
	@DeviceVersion [nvarchar](50),
	@Serialnumber bigint,
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScpIdReport where MercScpIdReportUid <> @MercScpIdReportUid and MacAddress = @MacAddress
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercScpIdReport where MercScpIdReportUid <> @MercScpIdReportUid and DeviceVersion = @DeviceVersion and Serialnumber = @Serialnumber 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpIdReportUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpIdReportUnique] TO [public] AS [dbo]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpTypeUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpTypeUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].[IsMercScpTypeUnique]
	@MercScpTypeUid [uniqueidentifier],
	@TypeCode [nvarchar](20),
	@TypeCodeValue int,
	@Display [nvarchar](65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScpType where MercScpTypeUid <> @MercScpTypeUid and TypeCode = @TypeCode 
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercScpType where MercScpTypeUid <> @MercScpTypeUid and TypeCodeValue = @TypeCodeValue 
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercScpType where MercScpTypeUid <> @MercScpTypeUid and Display = @Display 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpTypeUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpTypeUnique] TO [public] AS [dbo]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercSioTypeUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercSioTypeUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].[IsMercSioTypeUnique]
	@MercSioTypeUid [uniqueidentifier],
	@TypeCode [nvarchar](20),
	@TypeCodeValue int,
	@Display [nvarchar](65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercSioType where MercSioTypeUid <> @MercSioTypeUid and TypeCode = @TypeCode 
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercSioType where MercSioTypeUid <> @MercSioTypeUid and TypeCodeValue = @TypeCodeValue
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercSioType where MercSioTypeUid <> @MercSioTypeUid and Display = @Display 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercSioTypeUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercSioTypeUnique] TO [public] AS [dbo]
GO


/*==============================================================*/
/* Table: RoleMercScpGroup                                      */
/*==============================================================*/
create table GCS.RoleMercScpGroup (
   RoleMercScpGroupUid  GCS.UniversalUniqueId    RowGuidCol not null,
   MercScpGroupUid      uniqueidentifier	not null,
   RoleId               uniqueidentifier	not null,
	IncludeAllAccessPortals bit NOT NULL,
	IncludeAllInputOutputGroups bit NOT NULL,
	IncludeAllInputDevices bit NOT NULL,
	IncludeAllOutputDevices bit NOT NULL,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset       not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset       null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.RoleMercScpGroup
   add constraint PK_ROLEMERCSCPGROUP primary key (RoleMercScpGroupUid)
go

/*==============================================================*/
/* Index: idxRoleMercScpGroup                                   */
/*==============================================================*/
create unique nonclustered index idxRoleMercScpGroup on GCS.RoleMercScpGroup (MercScpGroupUid ASC,
  RoleId ASC)
go

alter table GCS.RoleMercScpGroup
   add constraint FK_RoleMercScpGroupMercScpGroup foreign key (MercScpGroupUid)
      references GCS.MercScpGroup (MercScpGroupUid)
         on update cascade on delete cascade
go

alter table GCS.RoleMercScpGroup
   add constraint FK_RoleMercScpGroupRole foreign key (RoleId)
      references GCS.gcsRole (RoleId)
         on update cascade on delete cascade
go


/*==============================================================*/
/* Table: RoleMercScpGroupPermission                            */
/*==============================================================*/
create table GCS.RoleMercScpGroupPermission (
   RoleMercScpGroupPermissionUid GCS.UniversalUniqueId    RowGuidCol not null,
   RoleMercScpGroupUid  uniqueidentifier     not null,
   PermissionId         uniqueidentifier     not null,
   InsertName           nvarchar(50)         not null default user_name(),
   InsertDate           datetimeoffset       not null default SYSDATETIMEOFFSET(),
   UpdateName           nvarchar(50)         null default user_name(),
   UpdateDate           datetimeoffset       null default SYSDATETIMEOFFSET(),
   ConcurrencyValue     smallint             null default 1
)
go

alter table GCS.RoleMercScpGroupPermission
   add constraint PK_ROLEMERCSCPGROUPPERMISSION primary key (RoleMercScpGroupPermissionUid)
go

/*==============================================================*/
/* Index: idxRoleMercScpGroupPermission                         */
/*==============================================================*/
create unique nonclustered index idxRoleMercScpGroupPermission on GCS.RoleMercScpGroupPermission (RoleMercScpGroupUid ASC,
  PermissionId ASC)
go

alter table GCS.RoleMercScpGroupPermission
   add constraint FK_RoleMercScpGroupPermissionPermission foreign key (PermissionId)
      references GCS.gcsPermission (PermissionId)
         on update cascade on delete cascade
go

alter table GCS.RoleMercScpGroupPermission
   add constraint FK_RoleMercScpGroupPermissionRoleMercScpGroup foreign key (RoleMercScpGroupUid)
      references GCS.RoleMercScpGroup (RoleMercScpGroupUid)
         on update cascade on delete cascade
go



/* All Stored Procedures for table: MercScpType */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.MercScpType table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_SelectAll]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpTypeUid
,Display
,DisplayResourceKey
,Description
,DescriptionResourceKey
,TypeCode
,TypeCodeValue
,MaxReaders
,MaxInputs
,MaxOutputs
,MaxSio485Ports
,OnboardReaders
,OnboardInputs
,OnboardOutputs
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpType

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.MercScpType table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpTypeUid
,Display
FROM GCS.MercScpType

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpType table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_SelectByPK]
@MercScpTypeUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpTypeUid
,Display
,DisplayResourceKey
,Description
,DescriptionResourceKey
,TypeCode
,TypeCodeValue
,MaxReaders
,MaxInputs
,MaxOutputs
,MaxSio485Ports
,OnboardReaders
,OnboardInputs
,OnboardOutputs
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpType
WHERE 
MercScpTypeUid = @MercScpTypeUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.MercScpType table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_SelectSearch]
@Display nvarchar(65) 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpTypeUid
,Display
,DisplayResourceKey
,Description
,DescriptionResourceKey
,TypeCode
,TypeCodeValue
,MaxReaders
,MaxInputs
,MaxOutputs
,MaxSio485Ports
,OnboardReaders
,OnboardInputs
,OnboardOutputs
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpType
WHERE 
(@Display IS NULL OR Display LIKE @Display + '%')

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_SelectSearch] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.MercScpType table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_Insert]
@MercScpTypeUid uniqueidentifier 
,@Display nvarchar(65) 
,@DisplayResourceKey uniqueidentifier  = null
,@Description nvarchar(1000) 
,@DescriptionResourceKey uniqueidentifier  = null
,@TypeCode nvarchar(20) 
,@TypeCodeValue int 
,@MaxReaders int 
,@MaxInputs int 
,@MaxOutputs int 
,@MaxSio485Ports smallint 
,@OnboardReaders smallint 
,@OnboardInputs smallint 
,@OnboardOutputs smallint 
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;


if @MercScpTypeUid = '00000000-0000-0000-0000-000000000000'
	SET @MercScpTypeUid = NULL

if @MercScpTypeUid = '00000000-0000-0000-0000-000000000000' OR @MercScpTypeUid IS NULL
	SET @MercScpTypeUid = NewID()

INSERT INTO GCS.MercScpType
(
MercScpTypeUid
,Display
,DisplayResourceKey
,Description
,DescriptionResourceKey
,TypeCode
,TypeCodeValue
,MaxReaders
,MaxInputs
,MaxOutputs
,MaxSio485Ports
,OnboardReaders
,OnboardInputs
,OnboardOutputs
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@MercScpTypeUid
,@Display
,@DisplayResourceKey
,@Description
,@DescriptionResourceKey
,@TypeCode
,@TypeCodeValue
,@MaxReaders
,@MaxInputs
,@MaxOutputs
,@MaxSio485Ports
,@OnboardReaders
,@OnboardInputs
,@OnboardOutputs
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.MercScpType table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_Update]
@MercScpTypeUid uniqueidentifier 
,@Display nvarchar(65)
,@DisplayResourceKey uniqueidentifier
,@Description nvarchar(1000)
,@DescriptionResourceKey uniqueidentifier
,@TypeCode nvarchar(20)
,@TypeCodeValue int
,@MaxReaders int
,@MaxInputs int
,@MaxOutputs int
,@MaxSio485Ports smallint
,@OnboardReaders smallint
,@OnboardInputs smallint
,@OnboardOutputs smallint
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpType
SET 
MercScpTypeUid = @MercScpTypeUid
,Display = @Display
,DisplayResourceKey = @DisplayResourceKey
,Description = @Description
,DescriptionResourceKey = @DescriptionResourceKey
,TypeCode = @TypeCode
,TypeCodeValue = @TypeCodeValue
,MaxReaders = @MaxReaders
,MaxInputs = @MaxInputs
,MaxOutputs = @MaxOutputs
,MaxSio485Ports = @MaxSio485Ports
,OnboardReaders = @OnboardReaders
,OnboardInputs = @OnboardInputs
,OnboardOutputs = @OnboardOutputs
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
MercScpTypeUid = @MercScpTypeUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.MercScpType table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_UpdateConcurrency]
@MercScpTypeUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpType
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
MercScpTypeUid = @MercScpTypeUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.MercScpType table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_DeleteByPK]
@MercScpTypeUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.MercScpType
WHERE
MercScpTypeUid = @MercScpTypeUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.MercScpType table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpTypePDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpTypePDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpTypePDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.MercScpType

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpTypePDSA_RowCount] TO public
GO


/* All Stored Procedures for table: MercScpGroup */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.MercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_SelectAll]
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScpGroup

if @PageSize = 0
	set @PageSize = 1

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScpGroup t
ORDER BY (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 0 THEN Name end) asc,
         (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 1 THEN Name end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_ByAllowConnection]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_ByAllowConnection]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_ByAllowConnection]
@AllowConnection bit,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScpGroup

if @PageSize = 0
	set @PageSize = 1

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScpGroup t
WHERE 
AllowConnection= @AllowConnection
ORDER BY (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 0 THEN Name end) asc,
         (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 1 THEN Name end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_ByAllowConnection] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_ByEntityId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_ByEntityId]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_ByEntityId]
@EntityId uniqueidentifier,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScpGroup

if @PageSize = 0
	set @PageSize = 1

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScpGroup t
WHERE 
EntityId = @EntityId
ORDER BY (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 0 THEN Name end) asc,
         (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 1 THEN Name end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_ByEntityId] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_BySiteUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_BySiteUid]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_BySiteUid]
@SiteUid uniqueidentifier,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScpGroup

if @PageSize = 0
	set @PageSize = 1

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScpGroup t
WHERE 
SiteUid = @SiteUid
ORDER BY (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 0 THEN Name end) asc,
         (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 1 THEN Name end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_BySiteUid] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.MercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpGroupUid
,Name
FROM GCS.MercScpGroup

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpGroup table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_SelectByPK]
@MercScpGroupUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpGroup
WHERE 
MercScpGroupUid = @MercScpGroupUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.MercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_SelectSearch]
GO
CREATE  PROCEDURE GCS.[MercScpGroupPDSA_SelectSearch]
@Name nvarchar(65),
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScpGroup

if @PageSize = 0
	set @PageSize = 1

SELECT 
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScpGroup t
WHERE 
(@Name IS NULL OR Name LIKE @Name + '%')
ORDER BY (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 0 THEN Name end) asc,
         (CASE WHEN @SortColumn = 'Name' AND @DescendingOrder = 1 THEN Name end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_SelectSearch] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.MercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_Insert]
@MercScpGroupUid uniqueidentifier 
,@EntityId uniqueidentifier 
,@SiteUid uniqueidentifier 
,@Name nvarchar(65) 
,@Description nvarchar(1000)
,@IsActive bit
,@NumberOfTransactions int 
,@NumberOfOperatingModes smallint 
,@OperatingModeType smallint 
,@AllowConnection bit 
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;


if @MercScpGroupUid = '00000000-0000-0000-0000-000000000000'
	SET @MercScpGroupUid = NULL

if @MercScpGroupUid = '00000000-0000-0000-0000-000000000000' OR @MercScpGroupUid IS NULL
	SET @MercScpGroupUid = NewID()

INSERT INTO GCS.MercScpGroup
(
MercScpGroupUid
,EntityId
,SiteUid
,Name
,Description
,IsActive
,NumberOfTransactions
,NumberOfOperatingModes
,OperatingModeType
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@MercScpGroupUid
,@EntityId
,@SiteUid
,@Name
,@Description
,@IsActive
,@NumberOfTransactions
,@NumberOfOperatingModes
,@OperatingModeType
,@AllowConnection
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.MercScpGroup table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_Update]
@MercScpGroupUid uniqueidentifier 
,@EntityId uniqueidentifier
,@SiteUid uniqueidentifier
,@Name nvarchar(65)
,@Description nvarchar(1000)
,@IsActive bit
,@NumberOfTransactions int
,@NumberOfOperatingModes smallint
,@OperatingModeType smallint
,@AllowConnection bit
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpGroup
SET 
MercScpGroupUid = @MercScpGroupUid
,EntityId = @EntityId
,SiteUid = @SiteUid
,Name = @Name
,Description = @Description
,IsActive = @IsActive
,NumberOfTransactions = @NumberOfTransactions
,NumberOfOperatingModes = @NumberOfOperatingModes
,OperatingModeType = @OperatingModeType
,AllowConnection = @AllowConnection
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
MercScpGroupUid = @MercScpGroupUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.MercScpGroup table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_UpdateConcurrency]
@MercScpGroupUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpGroup
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
MercScpGroupUid = @MercScpGroupUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.MercScpGroup table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_DeleteByPK]
@MercScpGroupUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.MercScpGroup
WHERE
MercScpGroupUid = @MercScpGroupUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.MercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.MercScpGroup

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpGroupPDSA_RowCount] TO public
GO

/* All Stored Procedures for table: RoleMercScpGroup */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.RoleMercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectAll]
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroup

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.RoleMercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,InsertName
FROM GCS.RoleMercScpGroup

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroup table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectByPK]
@RoleMercScpGroupUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroup
WHERE 
RoleMercScpGroupUid = @RoleMercScpGroupUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.RoleMercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_SelectSearch]
@InsertName nvarchar(50) 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroup
WHERE 
(@InsertName IS NULL OR InsertName LIKE @InsertName + '%')

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_SelectSearch] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_ByMercScpGroupUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_ByMercScpGroupUid]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_ByMercScpGroupUid]
@MercScpGroupUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroup
WHERE 
MercScpGroupUid = @MercScpGroupUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_ByMercScpGroupUid] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_ByRoleId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_ByRoleId]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_ByRoleId]
@RoleId uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroup
WHERE 
RoleId = @RoleId

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_ByRoleId] TO public
GO

/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroup table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_ByRoleIdAndSiteUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_ByRoleIdAndSiteUid]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_ByRoleIdAndSiteUid]
@RoleId uniqueidentifier,
@SiteUid uniqueidentifier
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupUid
,t.MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,t.InsertName
,t.InsertDate
,t.UpdateName
,t.UpdateDate
,t.ConcurrencyValue
FROM GCS.RoleMercScpGroup t
JOIN GCS.MercScpGroup g on g.MercScpGroupUid = t.MercScpGroupUid
WHERE 
RoleId = @RoleId and g.SiteUid = @SiteUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_ByRoleIdAndSiteUid] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.RoleMercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_Insert]
@RoleMercScpGroupUid uniqueidentifier 
,@MercScpGroupUid uniqueidentifier 
,@RoleId uniqueidentifier
,@IncludeAllAccessPortals bit
,@IncludeAllInputOutputGroups bit
,@IncludeAllInputDevices bit
,@IncludeAllOutputDevices bit
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;


if @RoleMercScpGroupUid = '00000000-0000-0000-0000-000000000000'
	SET @RoleMercScpGroupUid = NULL

if @RoleMercScpGroupUid = '00000000-0000-0000-0000-000000000000' OR @RoleMercScpGroupUid IS NULL
	SET @RoleMercScpGroupUid = NewID()

INSERT INTO GCS.RoleMercScpGroup
(
RoleMercScpGroupUid
,MercScpGroupUid
,RoleId
,IncludeAllAccessPortals
,IncludeAllInputOutputGroups
,IncludeAllInputDevices
,IncludeAllOutputDevices
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@RoleMercScpGroupUid
,@MercScpGroupUid
,@RoleId
,@IncludeAllAccessPortals
,@IncludeAllInputOutputGroups
,@IncludeAllInputDevices
,@IncludeAllOutputDevices
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.RoleMercScpGroup table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_Update]
@RoleMercScpGroupUid uniqueidentifier 
,@MercScpGroupUid uniqueidentifier
,@RoleId uniqueidentifier
,@IncludeAllAccessPortals bit
,@IncludeAllInputOutputGroups bit
,@IncludeAllInputDevices bit
,@IncludeAllOutputDevices bit
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.RoleMercScpGroup
SET 
RoleMercScpGroupUid = @RoleMercScpGroupUid
,MercScpGroupUid = @MercScpGroupUid
,RoleId = @RoleId
,IncludeAllAccessPortals = @IncludeAllAccessPortals
,IncludeAllInputOutputGroups = @IncludeAllInputOutputGroups
,IncludeAllInputDevices = @IncludeAllInputDevices
,IncludeAllOutputDevices = @IncludeAllOutputDevices
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
RoleMercScpGroupUid = @RoleMercScpGroupUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.RoleMercScpGroup table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_UpdateConcurrency]
@RoleMercScpGroupUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.RoleMercScpGroup
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
RoleMercScpGroupUid = @RoleMercScpGroupUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.RoleMercScpGroup table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_DeleteByPK]
@RoleMercScpGroupUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.RoleMercScpGroup
WHERE
RoleMercScpGroupUid = @RoleMercScpGroupUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.RoleMercScpGroup table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.RoleMercScpGroup

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPDSA_RowCount] TO public
GO

CREATE OR ALTER PROCEDURE [GCS].[IsRoleMercScpGroupUnique]
	@RoleMercScpGroupUid [uniqueidentifier],
	@RoleId [uniqueidentifier],
	@MercScpGroupUid [uniqueidentifier],
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.RoleMercScpGroup where RoleMercScpGroupUid <> @RoleMercScpGroupUid AND RoleId = @RoleId AND MercScpGroupUid = @MercScpGroupUid
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsRoleMercScpGroupUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsRoleMercScpGroupUnique] TO [public] AS [dbo]
GO

/* All Stored Procedures for table: RoleMercScpGroupPermission */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.RoleMercScpGroupPermission table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectAll]
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroupPermission

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.RoleMercScpGroupPermission table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,InsertName
FROM GCS.RoleMercScpGroupPermission

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroupPermission table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectByPK]
@RoleMercScpGroupPermissionUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroupPermission
WHERE 
RoleMercScpGroupPermissionUid = @RoleMercScpGroupPermissionUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.RoleMercScpGroupPermission table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_SelectSearch]
@InsertName nvarchar(50) 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroupPermission
WHERE 
(@InsertName IS NULL OR InsertName LIKE @InsertName + '%')

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_SelectSearch] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroupPermission table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_ByPermissionId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_ByPermissionId]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_ByPermissionId]
@PermissionId uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroupPermission
WHERE 
PermissionId = @PermissionId

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_ByPermissionId] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.RoleMercScpGroupPermission table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_ByRoleMercScpGroupUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_ByRoleMercScpGroupUid]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_ByRoleMercScpGroupUid]
@RoleMercScpGroupUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.RoleMercScpGroupPermission
WHERE 
RoleMercScpGroupUid = @RoleMercScpGroupUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_ByRoleMercScpGroupUid] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.RoleMercScpGroupPermission table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_Insert]
@RoleMercScpGroupPermissionUid uniqueidentifier 
,@RoleMercScpGroupUid uniqueidentifier 
,@PermissionId uniqueidentifier 
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;


if @RoleMercScpGroupPermissionUid = '00000000-0000-0000-0000-000000000000'
	SET @RoleMercScpGroupPermissionUid = NULL

if @RoleMercScpGroupPermissionUid = '00000000-0000-0000-0000-000000000000' OR @RoleMercScpGroupPermissionUid IS NULL
	SET @RoleMercScpGroupPermissionUid = NewID()

INSERT INTO GCS.RoleMercScpGroupPermission
(
RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid
,PermissionId
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@RoleMercScpGroupPermissionUid
,@RoleMercScpGroupUid
,@PermissionId
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.RoleMercScpGroupPermission table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_Update]
@RoleMercScpGroupPermissionUid uniqueidentifier 
,@RoleMercScpGroupUid uniqueidentifier
,@PermissionId uniqueidentifier
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.RoleMercScpGroupPermission
SET 
RoleMercScpGroupPermissionUid = @RoleMercScpGroupPermissionUid
,RoleMercScpGroupUid = @RoleMercScpGroupUid
,PermissionId = @PermissionId
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
RoleMercScpGroupPermissionUid = @RoleMercScpGroupPermissionUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.RoleMercScpGroupPermission table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_UpdateConcurrency]
@RoleMercScpGroupPermissionUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.RoleMercScpGroupPermission
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
RoleMercScpGroupPermissionUid = @RoleMercScpGroupPermissionUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.RoleMercScpGroupPermission table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_DeleteByPK]
@RoleMercScpGroupPermissionUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.RoleMercScpGroupPermission
WHERE
RoleMercScpGroupPermissionUid = @RoleMercScpGroupPermissionUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.RoleMercScpGroupPermission table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[RoleMercScpGroupPermissionPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[RoleMercScpGroupPermissionPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.RoleMercScpGroupPermission

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[RoleMercScpGroupPermissionPDSA_RowCount] TO public
GO

CREATE OR ALTER PROCEDURE [GCS].[IsRoleMercScpGroupPermissionUnique]
	@RoleMercScpGroupPermissionUid [uniqueidentifier],
	@RoleMercScpGroupUid [uniqueidentifier],
	@PermissionId [uniqueidentifier],
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.RoleMercScpGroupPermission where RoleMercScpGroupPermissionUid <> @RoleMercScpGroupPermissionUid AND RoleMercScpGroupUid = @RoleMercScpGroupUid AND PermissionId = @PermissionId
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsRoleMercScpGroupPermissionUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsRoleMercScpGroupPermissionUnique] TO [public] AS [dbo]
GO


CREATE OR ALTER FUNCTION [GCS].[fn_GCSDoesUserHaveMercScpGroupFilters] (	
	@UserId [uniqueidentifier],
	@EntityId [uniqueidentifier])
	returns int
AS
BEGIN
declare @Result int
declare @entId uniqueidentifier
declare @parentEntityId uniqueidentifier
declare @isAdministrator bit
declare @isAdministratorRole bit
declare @inheritParentRoles bit
declare @includeAllMercScpGroups bit

	select @entId = EntityId, @parentEntityId = ParentEntityId, @isAdministrator = IsAdministrator, @isAdministratorRole = IsAdministratorRole, @inheritParentRoles = InheritParentRoles, @includeAllMercScpGroups = IncludeAllClusters from GCS.UserEntityRoleView where UserId = @UserId AND EntityId = @entityId
	
	if @isAdministrator = 1 OR @isAdministratorRole = 1 OR @includeAllMercScpGroups = 1
	BEGIN
		return 0
	END

	while @inheritParentRoles = 1 AND @parentEntityId IS NOT NULL
	begin
		if [GCS].[fn_GCSDoesUserHaveMercScpGroupFilters](@UserId, @parentEntityId) = 0
		BEGIN
			return 0
		END
	end
	return 1
END
GO
ALTER AUTHORIZATION ON [GCS].[fn_GCSDoesUserHaveMercScpGroupFilters] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[fn_GCSDoesUserHaveMercScpGroupFilters] TO [public] AS [dbo]
GO



IF EXISTS ( SELECT  1
            FROM    Information_schema.Routines
            WHERE   Specific_schema = 'GCS'
                    AND specific_name = 'fnMercScpGroupUids_SelectForUserId'
                    AND Routine_Type = 'FUNCTION' ) 
DROP FUNCTION [GCS].[fnMercScpGroupUids_SelectForUserId]
go

CREATE OR ALTER FUNCTION [GCS].[fnMercScpGroupUids_SelectForUserId] (@UserId uniqueidentifier) 
RETURNS @MercScpGroupUids TABLE (MercScpGroupUid uniqueidentifier not null)
as
BEGIN
declare @entityId uniqueidentifier
	-- Start by getting all userentities for the user
	declare ueCursor CURSOR LOCAL FOR
		select EntityId from GCS.gcsUserEntity WHERE UserId = @UserId
    OPEN ueCursor
    FETCH NEXT FROM ueCursor INTO @entityId
    WHILE @@FETCH_STATUS = 0
    BEGIN
		
		IF [GCS].[fn_GCSDoesUserHaveMercScpGroupFilters] (@UserId, @entityId) = 1
		BEGIN -- IF THE USER HAS FILTERS FOR THE ENTITY, THEN USE THIS SQL
			insert into @MercScpGroupUids select distinct(MercScpGroup.MercScpGroupUid) 
			from GCS.gcsUser u
			join gcs.gcsUserEntity ue on ue.UserId = u.UserId
			join gcs.gcsEntity entity on entity.EntityId = ue.EntityId
			join gcs.gcsUserEntityRole uer on uer.UserEntityId = ue.UserEntityId
			join gcs.gcsRole r on r.roleid = uer.RoleId
			join gcs.gcsRolePermission rolePerm on rolePerm.RoleId = r.RoleId
			join gcs.gcsPermission perm on perm.PermissionId = rolePerm.PermissionId
			--left outer 
			join GCS.RoleMercScpGroup roleMercScpGroup on roleMercScpGroup.RoleId = r.RoleId
			--left outer 
			join GCS.MercScpGroup MercScpGroup on MercScpGroup.MercScpGroupUid = roleMercScpGroup.MercScpGroupUid
			where u.UserId = @UserId
		END
		ELSE
		BEGIN
			-- IF THE USER DOES NOT HAVE FILTERS FOR THE ENTITY, THEN USE THIS SQL TO SELECT ALL MercScpGroupUids for the entity
			INSERT INTO @MercScpGroupUids SELECT DISTINCT(MercScpGroupUid) from GCS.MercScpGroup where EntityId = @entityId
		END
	FETCH NEXT FROM ueCursor INTO @entityId
    END
    CLOSE ueCursor;
    DEALLOCATE ueCursor;

	return
END
GO

GRANT SELECT ON GCS.[fnMercScpGroupUids_SelectForUserId] TO public
GO


CREATE OR ALTER PROCEDURE GCS.[MercScpGroupUids_SelectForUserId]
@UserId uniqueidentifier
AS
BEGIN
	select * from GCS.fnMercScpGroupUids_SelectForUserId(@UserId)
END
GO

GRANT EXECUTE ON GCS.[MercScpGroupUids_SelectForUserId] TO public
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroupFilters_SelectForUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroupFilters_SelectForUserId]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroupFilters_SelectForUserId]
@UserId uniqueidentifier,
@MercScpGroupUid uniqueidentifier
AS
BEGIN
	
	if @MercScpGroupUid is null or @MercScpGroupUid = '00000000-0000-0000-0000-000000000000'
	BEGIN
		select u.DisplayName, entity.EntityName, r.RoleName, perm.PermissionName, MercScpGroup.MercScpGroupUid, MercScpGroup.Name, perm.PermissionId
		from GCS.gcsUser u
		join gcs.gcsUserEntity ue on ue.UserId = u.UserId
		join gcs.gcsEntity entity on entity.EntityId = ue.EntityId
	    join gcs.gcsUserEntityRole uer on uer.UserEntityId = ue.UserEntityId
	    join gcs.gcsRole r on r.roleid = uer.RoleId
		join gcs.gcsRolePermission rolePerm on rolePerm.RoleId = r.RoleId
		join gcs.gcsPermission perm on perm.PermissionId = rolePerm.PermissionId
		--left outer 
		join GCS.RoleMercScpGroup roleMercScpGroup on roleMercScpGroup.RoleId = r.RoleId
		--left outer 
		join GCS.MercScpGroup MercScpGroup on MercScpGroup.MercScpGroupUid = roleMercScpGroup.MercScpGroupUid
		where u.UserId = @UserId
		ORDER BY MercScpGroupUid, PermissionId
	END
	ELSE
	BEGIN
		select u.DisplayName, entity.EntityName, r.RoleName, perm.PermissionName, MercScpGroup.MercScpGroupUid, MercScpGroup.Name, perm.PermissionId
		from GCS.gcsUser u
		join gcs.gcsUserEntity ue on ue.UserId = u.UserId
		join gcs.gcsEntity entity on entity.EntityId = ue.EntityId
	    join gcs.gcsUserEntityRole uer on uer.UserEntityId = ue.UserEntityId
	    join gcs.gcsRole r on r.roleid = uer.RoleId
		join gcs.gcsRolePermission rolePerm on rolePerm.RoleId = r.RoleId
		join gcs.gcsPermission perm on perm.PermissionId = rolePerm.PermissionId
		--left outer 
		join GCS.RoleMercScpGroup roleMercScpGroup on roleMercScpGroup.RoleId = r.RoleId
		--left outer 
		join GCS.MercScpGroup MercScpGroup on MercScpGroup.MercScpGroupUid = roleMercScpGroup.MercScpGroupUid
		where u.UserId = @UserId AND MercScpGroup.MercScpGroupUid = @MercScpGroupUid
		ORDER BY PermissionId
	END
END
GO

GRANT EXECUTE ON GCS.[MercScpGroupFilters_SelectForUserId] TO public
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroup_GetUserPermission]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroup_GetUserPermission]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpGroup_GetUserPermission]
@UserId uniqueidentifier,
@MercScpGroupUid uniqueidentifier,
@PermissionId uniqueidentifier,
@EntityId uniqueidentifier
AS
BEGIN

	
	if GCS.fn_GCSDoesUserHavePermission(@UserId, @EntityId, @PermissionId) > 0
	BEGIN
		select u.DisplayName, entity.EntityName, null as RoleName, null as PermissionName, @MercScpGroupUid as MercScpGroupUid, null as MercScpGroupName, null as PermissionId
		from GCS.gcsUser u
		join gcs.gcsUserEntity ue on ue.UserId = u.UserId
		join gcs.gcsEntity entity on entity.EntityId = ue.EntityId
		where u.UserId = @UserId 
	END
	ELSE
	BEGIN
		select u.DisplayName, entity.EntityName, r.RoleName, perm.PermissionName, MercScpGroup.MercScpGroupUid, MercScpGroup.Name, perm.PermissionId
		from GCS.gcsUser u
		join gcs.gcsUserEntity ue on ue.UserId = u.UserId
		join gcs.gcsEntity entity on entity.EntityId = ue.EntityId
		join gcs.gcsUserEntityRole uer on uer.UserEntityId = ue.UserEntityId
		join gcs.gcsRole r on r.roleid = uer.RoleId
		join gcs.gcsRolePermission rolePerm on rolePerm.RoleId = r.RoleId
		join gcs.gcsPermission perm on perm.PermissionId = rolePerm.PermissionId
		left outer 
		join GCS.RoleMercScpGroup roleMercScpGroup on roleMercScpGroup.RoleId = r.RoleId
		left outer 
		join GCS.MercScpGroup MercScpGroup on MercScpGroup.MercScpGroupUid = roleMercScpGroup.MercScpGroupUid
		where u.UserId = @UserId AND MercScpGroup.MercScpGroupUid = @MercScpGroupUid AND perm.PermissionId = @PermissionId
	END
END
go


GRANT EXECUTE ON GCS.[MercScpGroup_GetUserPermission] TO public
GO




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[GetEntityIdForMercScpGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.GetEntityIdForMercScpGroup
GO

CREATE OR ALTER PROCEDURE GCS.GetEntityIdForMercScpGroup 
@uid uniqueidentifier
AS

	select EntityId from GCS.MercScpGroup where MercScpGroupUid = @uid
GO

GRANT EXECUTE ON GCS.GetEntityIdForMercScpGroup TO public
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpGroupUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpGroupUnique]
GO

CREATE OR ALTER PROCEDURE [GCS].[IsMercScpGroupUnique]
	@MercScpGroupUid [uniqueidentifier],
	@EntityId [uniqueidentifier],
	@Name [nvarchar](65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
select @Result = count(*) from GCS.MercScpGroup where MercScpGroupUid <> @MercScpGroupUid AND ( EntityId = @EntityId AND Name = @Name )
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpGroupUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpGroupUnique] TO [public] AS [dbo]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[gcsEntityCountPDSA_InsertMercScpGroupCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[gcsEntityCountPDSA_InsertMercScpGroupCount]
GO
CREATE OR ALTER PROCEDURE GCS.[gcsEntityCountPDSA_InsertMercScpGroupCount]
@EntityId uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

declare @cnt int
select @cnt = count(*) from GCS.MercScpGroup where EntityId = @EntityId

INSERT INTO GCS.gcsEntityCount
(
EntityCountUid
,EntityId
,CountType
,CountValue
) 
VALUES 
(
NewID()
,@EntityId
,N'MercScpGroup'
,@cnt)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[gcsEntityCountPDSA_InsertMercScpGroupCount] TO public
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroup_GetAllUidsFromRoleId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroup_GetAllUidsFromRoleId]
GO

CREATE OR ALTER PROCEDURE [GCS].[MercScpGroup_GetAllUidsFromRoleId]
	@RoleId [uniqueidentifier]
AS
	select MercScpGroupUid from GCS.MercScpGroup where EntityId = (Select EntityId from GCS.gcsRole where RoleId = @RoleId)
GO
ALTER AUTHORIZATION ON [GCS].[MercScpGroup_GetAllUidsFromRoleId] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[MercScpGroup_GetAllUidsFromRoleId] TO [public] AS [dbo]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpGroup_GetAllUidsFromRoleIdAndSiteUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpGroup_GetAllUidsFromRoleIdAndSiteUid]
GO

CREATE OR ALTER PROCEDURE [GCS].[MercScpGroup_GetAllUidsFromRoleIdAndSiteUid]
	@RoleId [uniqueidentifier],
	@SiteUid [uniqueidentifier]

AS
	select MercScpGroupUid from GCS.MercScpGroup where EntityId = (Select EntityId from GCS.gcsRole where RoleId = @RoleId) and SiteUid = @SiteUid
GO
ALTER AUTHORIZATION ON [GCS].[MercScpGroup_GetAllUidsFromRoleIdAndSiteUid] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[MercScpGroup_GetAllUidsFromRoleIdAndSiteUid] TO [public] AS [dbo]
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpGroupNameUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpGroupNameUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].[IsMercScpGroupNameUnique]
	@MercScpGroupUid [uniqueidentifier],
	@EntityId [uniqueidentifier],
	@Name [nvarchar](65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScpGroup where MercScpGroupUid <> @MercScpGroupUid AND ( EntityId = @EntityId AND Name = @Name )
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpGroupNameUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpGroupNameUnique] TO [public] AS [dbo]
GO


/* All Stored Procedures for table: MercScp */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.MercScp table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_SelectAll]
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1
SELECT 
t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_ByAllowConnection]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_ByAllowConnection]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_ByAllowConnection]
@AllowConnection bit,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
AllowConnection = @AllowConnection
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.MercScpPDSA_ByAllowConnection TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_ByEntityId]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_ByEntityId]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_ByEntityId]
@EntityId uniqueidentifier,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT 
t.MercScpUid
,MercScpTypeUid
,t.MercScpGroupUid
,ScpName
,t.Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,t.AllowConnection
,t.InsertName
,t.InsertDate
,t.UpdateName
,t.UpdateDate
,t.ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
t.EntityId = @EntityId
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_ByEntityId] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_ByMacAddress]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_ByMacAddress]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_ByMacAddress]
@MacAddress nvarchar(50),
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
MacAddress = @MacAddress 
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.MercScpPDSA_ByMacAddress TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_ByMercScpGroupUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_ByMercScpGroupUid]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_ByMercScpGroupUid]
@MercScpGroupUid uniqueidentifier, 
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT 
t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
MercScpGroupUid = @MercScpGroupUid
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_ByMercScpGroupUid] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_BySerialnumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_BySerialnumber]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_BySerialnumber]
@Serialnumber bigint,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT 
t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
Serialnumber = @Serialnumber
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.MercScpPDSA_BySerialnumber TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.MercScp table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,ScpName
FROM GCS.MercScp

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_SelectByPK]
@MercScpUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,1 as TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
t.MercScpUid = @MercScpUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.MercScp table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_SelectSearch]
@ScpName nvarchar(65),
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1

AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT 
t.MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
,EntityId
,SiteUid
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
(@ScpName IS NULL OR ScpName LIKE @ScpName + '%')
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_SelectSearch] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScp table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_BySiteUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_BySiteUid]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_BySiteUid]
@SiteUid uniqueidentifier,
@PageNumber int,
@PageSize int,
@SortColumn nvarchar(255) = 'InsertDate',
@DescendingOrder bit = 1
AS

declare @ret int;
select @ret = 0;

if @PageNumber = 0
	set @PageNumber = 1

if @PageSize = 0
	select @PageSize = count(*) from GCS.MercScp

if @PageSize = 0
	set @PageSize = 1

SELECT 
t.MercScpUid
,MercScpTypeUid
,t.MercScpGroupUid
,ScpName
,t.Description
,Location
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,t.InsertName
,t.InsertDate
,t.UpdateName
,t.UpdateDate
,t.ConcurrencyValue
,s.Online
,s.LastConnected
,s.LastDisconnected
,COUNT(*) OVER() TotalRowCount
FROM GCS.MercScp t
LEFT OUTER JOIN GCS.MercScpStatus s on s.MercScpUid = t.MercScpUid
WHERE 
t.SiteUid = @SiteUid
ORDER BY (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 0 THEN ScpName end) asc,
         (CASE WHEN @SortColumn = 'ScpName' AND @DescendingOrder = 1 THEN ScpName end) desc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 0 THEN t.InsertDate end) asc,
         (CASE WHEN @SortColumn = 'InsertDate' AND @DescendingOrder = 1 THEN t.InsertDate end) desc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 0 THEN t.UpdateDate end) asc,
         (CASE WHEN @SortColumn = 'UpdateDate' AND @DescendingOrder = 1 THEN t.UpdateDate end) desc
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_BySiteUid] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.MercScp table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_Insert]
@MercScpUid uniqueidentifier 
,@MercScpTypeUid uniqueidentifier 
,@MercScpGroupUid uniqueidentifier 
,@ScpName nvarchar(65) 
,@Location nvarchar(65) 
,@Description nvarchar(1000)
,@MacAddress nvarchar(50) 
,@Serialnumber bigint 
,@ConnectionType int 
,@IpAddress nvarchar(50)  = null
,@IpPort int  = null
,@AesPassword nvarchar(50) 
,@ScpReplyTimeout int 
,@TcpConnectRetryInterval int 
,@RetryCountBeforeOffline int 
,@OfflineTime int 
,@PollDelay int 
,@TimeZoneId nvarchar(65) 
,@UseDaylightSavingsTime bit 
,@TransactionCount int 
,@TransactionUnreportedLimit int 
,@DualPortEnabled bit 
,@ConnectionTypeAlt int 
,@RetryCountBeforeOfflineAlt int 
,@PollDelayAlt int 
,@IpAddressAlt nvarchar(50) 
,@IpPortAlt int 
,@AllowConnection bit
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint
,@Online bit
,@LastConnected datetimeoffset
AS

declare @ret int;
select @ret = 0;


if @MercScpUid = '00000000-0000-0000-0000-000000000000'
	SET @MercScpUid = NULL

if @MercScpUid = '00000000-0000-0000-0000-000000000000' OR @MercScpUid IS NULL
	SET @MercScpUid = NewID()

INSERT INTO GCS.MercScp
(
MercScpUid
,MercScpTypeUid
,MercScpGroupUid
,ScpName
,Location
,Description
,MacAddress
,Serialnumber
,ConnectionType
,IpAddress
,IpPort
,AesPassword
,ScpReplyTimeout
,TcpConnectRetryInterval
,RetryCountBeforeOffline
,OfflineTime
,PollDelay
,TimeZoneId
,UseDaylightSavingsTime
,TransactionCount
,TransactionUnreportedLimit
,DualPortEnabled
,ConnectionTypeAlt
,RetryCountBeforeOfflineAlt
,PollDelayAlt
,IpAddressAlt
,IpPortAlt
,AllowConnection
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@MercScpUid
,@MercScpTypeUid
,@MercScpGroupUid
,@ScpName
,@Location
,@Description
,@MacAddress
,@Serialnumber
,@ConnectionType
,@IpAddress
,@IpPort
,@AesPassword
,@ScpReplyTimeout
,@TcpConnectRetryInterval
,@RetryCountBeforeOffline
,@OfflineTime
,@PollDelay
,@TimeZoneId
,@UseDaylightSavingsTime
,@TransactionCount
,@TransactionUnreportedLimit
,@DualPortEnabled
,@ConnectionTypeAlt
,@RetryCountBeforeOfflineAlt
,@PollDelayAlt
,@IpAddressAlt
,@IpPortAlt
,@AllowConnection
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)


if @@ROWCOUNT = 0
  SELECT @ret = -1;
ELSE
	INSERT INTO GCS.MercScpStatus (MercScpUid, Online, LastConnected)
	VALUES (@MercScpUid, @Online, @LastConnected)

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.MercScp table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_Update]
@MercScpUid uniqueidentifier 
,@MercScpTypeUid uniqueidentifier
,@MercScpGroupUid uniqueidentifier
,@ScpName nvarchar(65)
,@Location nvarchar(65)
,@Description nvarchar(1000)
,@MacAddress nvarchar(50)
,@Serialnumber bigint
,@ConnectionType int
,@IpAddress nvarchar(50)
,@IpPort int
,@AesPassword nvarchar(50)
,@ScpReplyTimeout int
,@TcpConnectRetryInterval int
,@RetryCountBeforeOffline int
,@OfflineTime int
,@PollDelay int
,@TimeZoneId nvarchar(65)
,@UseDaylightSavingsTime bit
,@TransactionCount int
,@TransactionUnreportedLimit int
,@DualPortEnabled bit
,@ConnectionTypeAlt int
,@RetryCountBeforeOfflineAlt int
,@PollDelayAlt int
,@IpAddressAlt nvarchar(50)
,@IpPortAlt int
,@AllowConnection bit
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
,@Online bit
,@LastConnected datetimeoffset
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScp
SET 
MercScpUid = @MercScpUid
,MercScpTypeUid = @MercScpTypeUid
,MercScpGroupUid = @MercScpGroupUid
,ScpName = @ScpName
,Location = @Location
,Description = @Description
,MacAddress = @MacAddress
,Serialnumber = @Serialnumber
,ConnectionType = @ConnectionType
,IpAddress = @IpAddress
,IpPort = @IpPort
,AesPassword = @AesPassword
,ScpReplyTimeout = @ScpReplyTimeout
,TcpConnectRetryInterval = @TcpConnectRetryInterval
,RetryCountBeforeOffline = @RetryCountBeforeOffline
,OfflineTime = @OfflineTime
,PollDelay = @PollDelay
,TimeZoneId = @TimeZoneId
,UseDaylightSavingsTime = @UseDaylightSavingsTime
,TransactionCount = @TransactionCount
,TransactionUnreportedLimit = @TransactionUnreportedLimit
,DualPortEnabled = @DualPortEnabled
,ConnectionTypeAlt = @ConnectionTypeAlt
,RetryCountBeforeOfflineAlt = @RetryCountBeforeOfflineAlt
,PollDelayAlt = @PollDelayAlt
,IpAddressAlt = @IpAddressAlt
,IpPortAlt = @IpPortAlt
,AllowConnection = @AllowConnection
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
MercScpUid = @MercScpUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
	SELECT @ret = -1;
ELSE
	UPDATE GCS.MercScpStatus set Online = @Online, LastConnected = @LastConnected WHERE MercScpUid = @MercScpUid

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.MercScp table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_UpdateConcurrency]
@MercScpUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScp
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
MercScpUid = @MercScpUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.MercScp table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_DeleteByPK]
@MercScpUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.MercScp
WHERE
MercScpUid = @MercScpUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.MercScp table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.MercScp

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpPDSA_RowCount] TO public
GO


CREATE OR ALTER PROCEDURE GCS.[GetEntityIdForMercScp]
@uid uniqueidentifier
AS

declare @ret int;
select @ret = 0;

SELECT EntityId FROM GCS.MercScp WHERE MercScpUid = @uid

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[GetEntityIdForMercScp] TO public
GO



CREATE OR ALTER PROCEDURE [GCS].[MercScp_GetAllUidsForEntityId]
	@EntityId [uniqueidentifier]
AS
	select MercScpUid as Uid from GCS.MercScp where EntityId = @EntityId
GO
ALTER AUTHORIZATION ON [GCS].[MercScp_GetAllUidsForEntityId] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[MercScp_GetAllUidsForEntityId] TO [public] AS [dbo]
GO


CREATE OR ALTER PROCEDURE [GCS].[MercScp_GetAllUidsForMercScpGroupUid]
	@MercScpGroupUid [uniqueidentifier]
AS
	select MercScpUid as Uid from GCS.MercScp 
	where MercScpGroupUid = @MercScpGroupUid
GO
ALTER AUTHORIZATION ON [GCS].[MercScp_GetAllUidsForMercScpGroupUid] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[MercScp_GetAllUidsForMercScpGroupUid] TO [public] AS [dbo]
GO

CREATE OR ALTER PROCEDURE [GCS].[IsMercScpUnique]
	@MercScpUid [uniqueidentifier],
	@MercScpGroupUid [uniqueidentifier],
	@MacAddress nvarchar(50),
	@ScpName [nvarchar](65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
select @Result = count(*) from GCS.MercScp where MercScpUid <> @MercScpUid AND MacAddress = @MacAddress 
	
	if( @Result <> 0 )
	BEGIN
		select @Result as Result
		return
	END	

	select @Result = count(*) from GCS.MercScp where MercScpUid <> @MercScpUid AND MercScpGroupUid = @MercScpGroupUid AND ScpName = @ScpName 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpUnique] TO [public] AS [dbo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpMacAddressUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpMacAddressUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].IsMercScpMacAddressUnique
	@MercScpUid [uniqueidentifier],
	@MacAddress nvarchar(50),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScp where MercScpUid <> @MercScpUid AND MacAddress = @MacAddress 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpMacAddressUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpMacAddressUnique] TO [public] AS [dbo]
GO

CREATE OR ALTER PROCEDURE [GCS].[DoesMercScpMacAddressExist]
	@MacAddress nvarchar(50),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScp where MacAddress = @MacAddress 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[DoesMercScpMacAddressExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[DoesMercScpMacAddressExist] TO [public] AS [dbo]
GO




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[IsMercScpNameUnique]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[IsMercScpNameUnique]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [GCS].[IsMercScpNameUnique]
	@MercScpUid [uniqueidentifier],
	@MercScpGroupUid [uniqueidentifier],
	@ScpName nvarchar(65),
	@Result [int] OUTPUT
WITH EXECUTE AS CALLER
AS
	select @Result = count(*) from GCS.MercScp where MercScpUid <> @MercScpUid AND MercScpGroupUid = @MercScpGroupUid AND ScpName = @ScpName 
	select @Result as Result
GO
ALTER AUTHORIZATION ON [GCS].[IsMercScpNameUnique] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [GCS].[IsMercScpNameUnique] TO [public] AS [dbo]
GO


















/* All Stored Procedures for table: MercScpIdReport */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.MercScpIdReport table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectAll]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpIdReport

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.MercScpIdReport table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
FROM GCS.MercScpIdReport

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpIdReport table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectByPK]
@MercScpIdReportUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpIdReport
WHERE 
MercScpIdReportUid = @MercScpIdReportUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.MercScpIdReport table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectSearch]
@MacAddress nvarchar(50) 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpIdReport
WHERE 
(@MacAddress IS NULL OR MacAddress LIKE @MacAddress + '%')

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectSearch] TO public
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectByMacAddress]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectByMacAddress]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectByMacAddress]
@MacAddress nvarchar(50) 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpIdReport
WHERE 
MacAddress = @MacAddress

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectByMacAddress] TO public
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_SelectByModelAndSerialnumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_SelectByModelAndSerialnumber]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_SelectByModelAndSerialnumber]
@DeviceVersion nvarchar(50),
@Serialnumber bigint
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
FROM GCS.MercScpIdReport
WHERE 
DeviceVersion = @DeviceVersion and Serialnumber = @Serialnumber

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_SelectByModelAndSerialnumber] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.MercScpIdReport table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_Insert]
@MercScpIdReportUid uniqueidentifier 
,@MacAddress nvarchar(50) 
,@DriverSpcId int 
,@ScpId int 
,@Serialnumber bigint
,@DeviceId nvarchar(50) 
,@DeviceVersion nvarchar(50) 
,@SoftwareRevisionMajor int 
,@SoftwareRevisionMinor int 
,@CumulativeBuildCount int 
,@NeedsConfiguration bit 
,@TlsStatus nvarchar(50) 
,@OemCode int 
,@CurrentOperatingMode smallint 
,@Input1State smallint 
,@Input2State smallint 
,@Input3State smallint 
,@BioDb1Active int 
,@BioDb1Max int 
,@BioDb2Active int 
,@BioDb2Max int 
,@AssetDbActive int 
,@AssetDbMax int 
,@FirmwareAdvisory nvarchar(50) 
,@DipSwitchCurrent smallint 
,@DipSwitchPowerUp smallint 
,@DbActiveRecords int 
,@DbMaxSize int 
,@CurrentClock bigint 
,@RamFree int 
,@RamSize int 
,@InsertName nvarchar(50) 
,@InsertDate datetimeoffset 
,@UpdateName nvarchar(50) 
,@UpdateDate datetimeoffset 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;


if @MercScpIdReportUid = '00000000-0000-0000-0000-000000000000'
	SET @MercScpIdReportUid = NULL

if @MercScpIdReportUid = '00000000-0000-0000-0000-000000000000' OR @MercScpIdReportUid IS NULL
	SET @MercScpIdReportUid = NewID()

INSERT INTO GCS.MercScpIdReport
(
MercScpIdReportUid
,MacAddress
,DriverSpcId
,ScpId
,Serialnumber
,DeviceId
,DeviceVersion
,SoftwareRevisionMajor
,SoftwareRevisionMinor
,CumulativeBuildCount
,NeedsConfiguration
,TlsStatus
,OemCode
,CurrentOperatingMode
,Input1State
,Input2State
,Input3State
,BioDb1Active
,BioDb1Max
,BioDb2Active
,BioDb2Max
,AssetDbActive
,AssetDbMax
,FirmwareAdvisory
,DipSwitchCurrent
,DipSwitchPowerUp
,DbActiveRecords
,DbMaxSize
,CurrentClock
,RamFree
,RamSize
,InsertName
,InsertDate
,UpdateName
,UpdateDate
,ConcurrencyValue
) 
VALUES 
(
@MercScpIdReportUid
,@MacAddress
,@DriverSpcId
,@ScpId
,@Serialnumber
,@DeviceId
,@DeviceVersion
,@SoftwareRevisionMajor
,@SoftwareRevisionMinor
,@CumulativeBuildCount
,@NeedsConfiguration
,@TlsStatus
,@OemCode
,@CurrentOperatingMode
,@Input1State
,@Input2State
,@Input3State
,@BioDb1Active
,@BioDb1Max
,@BioDb2Active
,@BioDb2Max
,@AssetDbActive
,@AssetDbMax
,@FirmwareAdvisory
,@DipSwitchCurrent
,@DipSwitchPowerUp
,@DbActiveRecords
,@DbMaxSize
,@CurrentClock
,@RamFree
,@RamSize
,@InsertName
,@InsertDate
,@UpdateName
,@UpdateDate
,@ConcurrencyValue
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.MercScpIdReport table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_Update]
@MercScpIdReportUid uniqueidentifier 
,@MacAddress nvarchar(50)
,@DriverSpcId int
,@ScpId int
,@Serialnumber bigint
,@DeviceId nvarchar(50)
,@DeviceVersion nvarchar(50)
,@SoftwareRevisionMajor int
,@SoftwareRevisionMinor int
,@CumulativeBuildCount int
,@NeedsConfiguration bit
,@TlsStatus nvarchar(50)
,@OemCode int
,@CurrentOperatingMode smallint
,@Input1State smallint
,@Input2State smallint
,@Input3State smallint
,@BioDb1Active int
,@BioDb1Max int
,@BioDb2Active int
,@BioDb2Max int
,@AssetDbActive int
,@AssetDbMax int
,@FirmwareAdvisory nvarchar(50)
,@DipSwitchCurrent smallint
,@DipSwitchPowerUp smallint
,@DbActiveRecords int
,@DbMaxSize int
,@CurrentClock bigint
,@RamFree int
,@RamSize int
,@UpdateName nvarchar(50)
,@UpdateDate datetimeoffset
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpIdReport
SET 
MercScpIdReportUid = @MercScpIdReportUid
,MacAddress = @MacAddress
,DriverSpcId = @DriverSpcId
,ScpId = @ScpId
,Serialnumber = @Serialnumber
,DeviceId = @DeviceId
,DeviceVersion = @DeviceVersion
,SoftwareRevisionMajor = @SoftwareRevisionMajor
,SoftwareRevisionMinor = @SoftwareRevisionMinor
,CumulativeBuildCount = @CumulativeBuildCount
,NeedsConfiguration = @NeedsConfiguration
,TlsStatus = @TlsStatus
,OemCode = @OemCode
,CurrentOperatingMode = @CurrentOperatingMode
,Input1State = @Input1State
,Input2State = @Input2State
,Input3State = @Input3State
,BioDb1Active = @BioDb1Active
,BioDb1Max = @BioDb1Max
,BioDb2Active = @BioDb2Active
,BioDb2Max = @BioDb2Max
,AssetDbActive = @AssetDbActive
,AssetDbMax = @AssetDbMax
,FirmwareAdvisory = @FirmwareAdvisory
,DipSwitchCurrent = @DipSwitchCurrent
,DipSwitchPowerUp = @DipSwitchPowerUp
,DbActiveRecords = @DbActiveRecords
,DbMaxSize = @DbMaxSize
,CurrentClock = @CurrentClock
,RamFree = @RamFree
,RamSize = @RamSize
,UpdateName = @UpdateName
,UpdateDate = @UpdateDate
,ConcurrencyValue = ConcurrencyValue + 1
WHERE
MercScpIdReportUid = @MercScpIdReportUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_Update] TO public
GO
/************************************************************
'* This stored procedure is used to UPDATE the Concurrency Column in
'* GCS.MercScpIdReport table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_UpdateConcurrency]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_UpdateConcurrency]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_UpdateConcurrency]
@MercScpIdReportUid uniqueidentifier 
,@ConcurrencyValue smallint 
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpIdReport
SET 
ConcurrencyValue = @ConcurrencyValue
WHERE
MercScpIdReportUid = @MercScpIdReportUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_UpdateConcurrency] TO public
GO

/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.MercScpIdReport table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_DeleteByPK]
@MercScpIdReportUid uniqueidentifier
,@ConcurrencyValue smallint
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.MercScpIdReport
WHERE
MercScpIdReportUid = @MercScpIdReportUid
 And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.MercScpIdReport table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpIdReportPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpIdReportPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpIdReportPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.MercScpIdReport

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpIdReportPDSA_RowCount] TO public
GO


/* All Stored Procedures for table: MercScpStatus */

/************************************************************
'* This stored procedure is used to retrieve all rows & columns from the
'* GCS.MercScpStatus table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_SelectAll]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_SelectAll]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,Online
,LastConnected
,LastDisconnected
FROM GCS.MercScpStatus

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_SelectAll] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all rows and the primary key column and the 'description' column
'* in the GCS.MercScpStatus table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_SelectListBox]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_SelectListBox]
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_SelectListBox]
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,LastConnected
FROM GCS.MercScpStatus

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_SelectListBox] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpStatus table 
'* for a single row of data based on the primary key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_SelectByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_SelectByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_SelectByPK]
@MercScpUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,Online
,LastConnected
,LastDisconnected
FROM GCS.MercScpStatus
WHERE 
MercScpUid = @MercScpUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_SelectByPK] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns and
'* the rows that match the search fields passed in
'* for the GCS.MercScpStatus table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_SelectSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_SelectSearch]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_SelectSearch]
@LastConnected datetimeoffset 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,Online
,LastConnected
,LastDisconnected
FROM GCS.MercScpStatus
WHERE 
(@LastConnected IS NULL OR LastConnected = @LastConnected )

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_SelectSearch] TO public
GO
/************************************************************
'* This stored procedure is used to retrieve all columns from
'* the GCS.MercScpStatus table 
'* for a single row of data based on a foreign key passed in
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_ByMercScpUid]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_ByMercScpUid]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_ByMercScpUid]
@MercScpUid uniqueidentifier 
AS

declare @ret int;
select @ret = 0;

SELECT 
MercScpUid
,Online
,LastConnected
,LastDisconnected
FROM GCS.MercScpStatus
WHERE 
MercScpUid = @MercScpUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_ByMercScpUid] TO public
GO

/************************************************************
'* This stored procedure is used to INSERT all columns into the 
'* GCS.MercScpStatus table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_Insert]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_Insert]
@MercScpUid uniqueidentifier 
,@Online bit  = null
,@LastConnected datetimeoffset  = null
,@LastDisconnected datetimeoffset  = null
AS

declare @ret int;
select @ret = 0;

INSERT INTO GCS.MercScpStatus
(
MercScpUid
,Online
,LastConnected
,LastDisconnected
) 
VALUES 
(
@MercScpUid
,@Online
,@LastConnected
,@LastDisconnected
)

if @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_Insert] TO public
GO

/************************************************************
'* This stored procedure is used to UPDATE all columns in the
'* GCS.MercScpStatus table for a single row of data based on a primary key.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_Update]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_Update]
@MercScpUid uniqueidentifier 
,@Online bit
,@LastConnected datetimeoffset
,@LastDisconnected datetimeoffset
AS

declare @ret int;
select @ret = 0;

UPDATE GCS.MercScpStatus
SET 
MercScpUid = @MercScpUid
,Online = @Online
,LastConnected = @LastConnected
,LastDisconnected = @LastDisconnected
WHERE
MercScpUid = @MercScpUid

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_Update] TO public
GO

CREATE OR ALTER PROCEDURE GCS.[MercScpStatus_Save]
@MercScpUid uniqueidentifier 
,@Online bit
,@LastConnected datetimeoffset
,@LastDisconnected datetimeoffset
AS

declare @ret int;
select @ret = 0;

if exists( select MercScpUid from GCS.MercScpStatus where MercScpUid = @MercScpUid)
BEGIN
	EXEC GCS.MercScpStatusPDSA_Update @MercScpUid, @Online, @LastConnected, @LastDisconnected
END
ELSE
BEGIN
	EXEC GCS.MercScpStatusPDSA_Insert @MercScpUid, @Online, @LastConnected, @LastDisconnected
END

IF @@ROWCOUNT = 0
  SELECT @ret = -1;

RETURN @@ERROR;
GO

GRANT EXECUTE ON GCS.[MercScpStatus_Save] TO public
GO



/***************************************************************
'* This stored procedure is used to DELETE a single row from the 
'* GCS.MercScpStatus table based on the primary key value passed in.
'***************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_DeleteByPK]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_DeleteByPK]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_DeleteByPK]
@MercScpUid uniqueidentifier
AS

declare @ret int;
select @ret = 0;

DELETE FROM GCS.MercScpStatus
WHERE
MercScpUid = @MercScpUid

if @@ROWCOUNT = 0
  SELECT @ret = -1;
  
RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_DeleteByPK] TO public
GO

/************************************************************
'* This stored procedure is used to count all rows in the 
'* GCS.MercScpStatus table.
'************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GCS.[MercScpStatusPDSA_RowCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE GCS.[MercScpStatusPDSA_RowCount]
GO
CREATE OR ALTER PROCEDURE GCS.[MercScpStatusPDSA_RowCount]
AS

declare @ret int;
select @ret = 0;

SELECT Count(*) As NumRecs FROM GCS.MercScpStatus

RETURN @ret;
GO

GRANT EXECUTE ON GCS.[MercScpStatusPDSA_RowCount] TO public
GO



