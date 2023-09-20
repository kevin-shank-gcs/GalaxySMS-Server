use [GalaxySMS-AuditActivity]
go


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[fn_GCSDoesColumnExist]') AND type = 'FN')
DROP FUNCTION [dbo].[fn_GCSDoesColumnExist]
go

/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesColumnExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesColumnExist](@table_name [nvarchar](65), @COLUMN_NAME [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from syscolumns where syscolumns.name = @COLUMN_NAME AND
	syscolumns.id = (SELECT sysobjects.id from sysobjects where sysobjects.name = @table_name AND
	sysobjects.xtype = 'U')
  
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesColumnExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesColumnExist] TO [public] AS [dbo]
GO


CREATE OR ALTER FUNCTION dbo.[gcs_GetColumnDataType] (@schemaName nvarchar(65), @tableName nvarchar(65), @columnName nvarchar(65) )
RETURNS nvarchar(65)
as
begin
declare @dataType nvarchar(100)

	SELECT @dataType = DATA_TYPE
	FROM INFORMATION_SCHEMA.COLUMNS 
	WHERE TABLE_SCHEMA = @schemaName
	AND TABLE_NAME = @tableName 
	AND COLUMN_NAME = @columnName;

	return @dataType
end
go

GRANT EXECUTE ON dbo.[gcs_GetColumnDataType] TO public
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.[gcs_DeleteDefaultConstraint]') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.[gcs_DeleteDefaultConstraint]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[gcs_DeleteDefaultConstraint]
	@schema_name [nvarchar](65),
	@table_name [nvarchar](65),
	@column_name [nvarchar](65)
WITH EXECUTE AS CALLER
AS
DECLARE @constraint_name nvarchar(255)
DECLARE @sql nvarchar(255)

  SELECT @constraint_name = sysobjects.name from sysobjects where sysobjects.id =
	(SELECT cdefault from syscolumns where syscolumns.name = @column_name AND 
	syscolumns.id = (SELECT sysobjects.id from sysobjects where sysobjects.name = @table_name AND 
	sysobjects.xtype = 'U') )
	AND sysobjects.xtype = 'D'
  BEGIN
--    print @table_name
--    print @COLUMN_NAME
    SET @sql = N'ALTER TABLE '
	if @schema_name is not null AND len(@schema_name) > 0
	BEGIN
		set @sql = @sql + @schema_name + '.'
	END
    SET @sql = @sql + @table_name
    SET @sql = @sql + N' DROP CONSTRAINT ' + @constraint_name
    print @sql
    execute sp_executesql @sql 
  END  
GO
ALTER AUTHORIZATION ON [dbo].[gcs_DeleteDefaultConstraint] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcs_DeleteDefaultConstraint] TO [public] AS [dbo]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesIndexExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [dbo].[fn_GCSDoesIndexExist](@table_name [nvarchar](65), @index_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN
  DECLARE @result as int
  SELECT @result = count(*) from sysindexes where sysindexes.name = @index_name AND
	sysindexes.id = 
	(SELECT sysobjects.id FROM sysobjects where sysobjects.name = @table_name AND sysobjects.xtype = 'U')
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesIndexExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesIndexExist] TO [public] AS [dbo]
GO



if dbo.fn_GCSDoesColumnExist('gcsAudit', 'UserId') = 0
BEGIN
	ALTER TABLE [GCS].[gcsAudit]
	ADD UserId uniqueidentifier  NULL
END
go  



if dbo.[fn_GCSDoesIndexExist]('AccessPortalActivityEvent', 'idxAccessPortalActivityEvent') = 1
BEGIN
	/****** Object:  Index [idxAccessPortalActivityEvent]    Script Date: 2/17/2023 8:20:08 AM ******/
	DROP INDEX [idxAccessPortalActivityEvent] ON [GCS].[AccessPortalActivityEvent]
END
GO

if dbo.[fn_GCSDoesIndexExist]('AccessPortalActivityEvent', 'idxAccessPortalActivityEventDateTime') = 1
BEGIN
	/****** Object:  Index [idxAccessPortalActivityEventDateTime]    Script Date: 2/17/2023 8:20:56 AM ******/
	DROP INDEX [idxAccessPortalActivityEventDateTime] ON [GCS].[AccessPortalActivityEvent]
END
GO

if dbo.[fn_GCSDoesIndexExist]('AccessPortalActivityEvent', 'idxAccessPortalActivityEventUniqueId') = 1
BEGIN
	/****** Object:  Index [idxAccessPortalActivityEventUniqueId]    Script Date: 2/17/2023 8:21:35 AM ******/
	DROP INDEX [idxAccessPortalActivityEventUniqueId] ON [GCS].[AccessPortalActivityEvent]
END
GO

if dbo.gcs_GetColumnDataType( 'GCS', 'AccessPortalActivityEvent', 'ActivityDateTime') <> 'datetimeoffset'
begin

	alter table GCS.AccessPortalActivityEvent
	drop column ActivityDateTimeUTC
	
	alter table GCS.AccessPortalActivityEvent 
	alter column ActivityDateTime datetimeoffset(7) not null
end
go

if dbo.fn_GCSDoesColumnExist('AccessPortalActivityEvent', 'ActivityDateTimeUTC') = 0
BEGIN
	ALTER TABLE GCS.AccessPortalActivityEvent
	ADD ActivityDateTimeUTC as ActivityDateTime AT TIME ZONE 'UTC'
END
GO

/****** Object:  Index [idxAccessPortalActivityEvent]    Script Date: 2/17/2023 8:20:08 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxAccessPortalActivityEvent] ON [GCS].[AccessPortalActivityEvent]
(
	[CpuUid] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


/****** Object:  Index [idxAccessPortalActivityEventDateTime]    Script Date: 2/17/2023 8:20:56 AM ******/
CREATE NONCLUSTERED INDEX [idxAccessPortalActivityEventDateTime] ON [GCS].[AccessPortalActivityEvent]
(
	[ActivityDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [idxAccessPortalActivityEventUniqueId]    Script Date: 2/17/2023 8:21:35 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxAccessPortalActivityEventUniqueId] ON [GCS].[AccessPortalActivityEvent]
(
	[CpuNumber] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


if dbo.[fn_GCSDoesIndexExist]('GalaxyPanelActivityEvent', 'idxGalaxyPanelActivityEvent') = 1
BEGIN
	/****** Object:  Index [idxGalaxyPanelActivityEvent]    Script Date: 2/17/2023 9:14:15 AM ******/
	DROP INDEX [idxGalaxyPanelActivityEvent] ON [GCS].[GalaxyPanelActivityEvent]
END
GO

if dbo.[fn_GCSDoesIndexExist]('GalaxyPanelActivityEvent', 'idxGalaxyPanelActivityEventDateTime') = 1
BEGIN
	/****** Object:  Index [idxGalaxyPanelActivityEventDateTime]    Script Date: 2/17/2023 9:16:28 AM ******/
	DROP INDEX [idxGalaxyPanelActivityEventDateTime] ON [GCS].[GalaxyPanelActivityEvent]
END
GO

if dbo.gcs_GetColumnDataType( 'GCS', 'GalaxyPanelActivityEvent', 'ActivityDateTime') <> 'datetimeoffset'
begin
	
	alter table GCS.GalaxyPanelActivityEvent
	drop column ActivityDateTimeUTC
		
	alter table GCS.GalaxyPanelActivityEvent 
	alter column ActivityDateTime datetimeoffset(7) not null
end
go

if dbo.fn_GCSDoesColumnExist('GalaxyPanelActivityEvent', 'ActivityDateTimeUTC') = 0
BEGIN
	ALTER TABLE GCS.GalaxyPanelActivityEvent
	ADD ActivityDateTimeUTC as ActivityDateTime AT TIME ZONE 'UTC'
END
GO

/****** Object:  Index [idxGalaxyPanelActivityEvent]    Script Date: 2/17/2023 9:15:55 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxGalaxyPanelActivityEvent] ON [GCS].[GalaxyPanelActivityEvent]
(
	[ActivityDateTime] ASC,
	[CpuUid] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [idxGalaxyPanelActivityEventDateTime]    Script Date: 2/17/2023 9:16:28 AM ******/
CREATE NONCLUSTERED INDEX [idxGalaxyPanelActivityEventDateTime] ON [GCS].[GalaxyPanelActivityEvent]
(
	[ActivityDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


if dbo.[fn_GCSDoesIndexExist]('InputDeviceActivityEvent', 'idxInputDeviceActivityEvent') = 1
BEGIN
	/****** Object:  Index [idxInputDeviceActivityEvent]    Script Date: 2/17/2023 9:18:07 AM ******/
	DROP INDEX [idxInputDeviceActivityEvent] ON [GCS].[InputDeviceActivityEvent]
END
GO

if dbo.[fn_GCSDoesIndexExist]('InputDeviceActivityEvent', 'idxInputDeviceActivityEventDateTime') = 1
BEGIN
	/****** Object:  Index [idxInputDeviceActivityEventDateTime]    Script Date: 2/17/2023 9:18:31 AM ******/
	DROP INDEX [idxInputDeviceActivityEventDateTime] ON [GCS].[InputDeviceActivityEvent]
END
GO

if dbo.gcs_GetColumnDataType( 'GCS', 'InputDeviceActivityEvent', 'ActivityDateTime') <> 'datetimeoffset'
begin
	alter table GCS.InputDeviceActivityEvent
	drop column ActivityDateTimeUTC

	alter table GCS.InputDeviceActivityEvent 
	alter column ActivityDateTime datetimeoffset(7) not null
end
go

if dbo.fn_GCSDoesColumnExist('InputDeviceActivityEvent', 'ActivityDateTimeUTC') = 0
BEGIN
	ALTER TABLE GCS.InputDeviceActivityEvent
	ADD ActivityDateTimeUTC as ActivityDateTime AT TIME ZONE 'UTC'
END
GO

/****** Object:  Index [idxInputDeviceActivityEvent]    Script Date: 2/17/2023 9:18:08 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxInputDeviceActivityEvent] ON [GCS].[InputDeviceActivityEvent]
(
	[CpuUid] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


/****** Object:  Index [idxInputDeviceActivityEventDateTime]    Script Date: 2/17/2023 9:18:32 AM ******/
CREATE NONCLUSTERED INDEX [idxInputDeviceActivityEventDateTime] ON [GCS].[InputDeviceActivityEvent]
(
	[ActivityDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO



if dbo.[fn_GCSDoesIndexExist]('OutputDeviceActivityEvent', 'idxOutputDeviceActivityEvent') = 1
BEGIN
	/****** Object:  Index [idxOutputDeviceActivityEvent]    Script Date: 2/17/2023 9:20:49 AM ******/
	DROP INDEX [idxOutputDeviceActivityEvent] ON [GCS].[OutputDeviceActivityEvent]
END
GO

if dbo.[fn_GCSDoesIndexExist]('OutputDeviceActivityEvent', 'idxOutputDeviceActivityEventDateTime') = 1
BEGIN
	/****** Object:  Index [idxOutputDeviceActivityEventDateTime]    Script Date: 2/17/2023 9:21:31 AM ******/
	DROP INDEX [idxOutputDeviceActivityEventDateTime] ON [GCS].[OutputDeviceActivityEvent]
END
GO

if dbo.gcs_GetColumnDataType( 'GCS', 'OutputDeviceActivityEvent', 'ActivityDateTime') <> 'datetimeoffset'
begin
	alter table GCS.OutputDeviceActivityEvent
	drop column ActivityDateTimeUTC

	alter table GCS.OutputDeviceActivityEvent 
	alter column ActivityDateTime datetimeoffset(7) not null
end
go

if dbo.fn_GCSDoesColumnExist('OutputDeviceActivityEvent', 'ActivityDateTimeUTC') = 0
BEGIN
	ALTER TABLE GCS.OutputDeviceActivityEvent
	ADD ActivityDateTimeUTC as ActivityDateTime AT TIME ZONE 'UTC'
END
GO


/****** Object:  Index [idxOutputDeviceActivityEvent]    Script Date: 2/17/2023 9:20:49 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxOutputDeviceActivityEvent] ON [GCS].[OutputDeviceActivityEvent]
(
	[CpuUid] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [idxOutputDeviceActivityEventDateTime]    Script Date: 2/17/2023 9:21:31 AM ******/
CREATE NONCLUSTERED INDEX [idxOutputDeviceActivityEventDateTime] ON [GCS].[OutputDeviceActivityEvent]
(
	[ActivityDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


exec dbo.gcs_DeleteDefaultConstraint 'GCS','AccessPortalActivityEvent', 'InsertDate'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'AccessPortalActivityEvent', 'InsertDate') <> 'datetimeoffset'
begin
	alter table GCS.AccessPortalActivityEvent 
	alter column InsertDate datetimeoffset(7) not null
end
go

alter table GCS.AccessPortalActivityEvent 
ADD CONSTRAINT DF_AccessPortalActivityEvent_InsertDate DEFAULT SYSDATETIMEOFFSET() FOR InsertDate
go


exec dbo.gcs_DeleteDefaultConstraint 'GCS','GalaxyPanelActivityEvent', 'InsertDate'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'GalaxyPanelActivityEvent', 'InsertDate') <> 'datetimeoffset'
begin
	alter table GCS.GalaxyPanelActivityEvent 
	alter column InsertDate datetimeoffset(7) not null
end
go

alter table GCS.GalaxyPanelActivityEvent 
ADD CONSTRAINT DF_GalaxyPanelActivityEvent_InsertDate DEFAULT SYSDATETIMEOFFSET() FOR InsertDate
go


exec dbo.gcs_DeleteDefaultConstraint 'GCS','InputDeviceActivityEvent', 'InsertDate'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'InputDeviceActivityEvent', 'InsertDate') <> 'datetimeoffset'
begin
	alter table GCS.InputDeviceActivityEvent 
	alter column InsertDate datetimeoffset(7) not null
end
go

alter table GCS.InputDeviceActivityEvent 
ADD CONSTRAINT DF_InputDeviceActivityEvent_InsertDate DEFAULT SYSDATETIMEOFFSET() FOR InsertDate
go


exec dbo.gcs_DeleteDefaultConstraint 'GCS','OutputDeviceActivityEvent', 'InsertDate'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'OutputDeviceActivityEvent', 'InsertDate') <> 'datetimeoffset'
begin
	alter table GCS.OutputDeviceActivityEvent 
	alter column InsertDate datetimeoffset(7) not null
end
go

alter table GCS.OutputDeviceActivityEvent 
ADD CONSTRAINT DF_OutputDeviceActivityEvent_InsertDate DEFAULT SYSDATETIMEOFFSET() FOR InsertDate
go

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GCS].[GalaxyRawActivityEvent]') AND type in (N'U'))
BEGIN
	DROP TABLE GCS.GalaxyRawActivityEvent
END
GO


CREATE TABLE [GCS].[GalaxyRawActivityEvent](
	[GalaxyRawActivityEventUid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CpuUid] [uniqueidentifier] NULL,
	[InsertDate] [datetimeoffset](7) NOT NULL,
	[ClusterGroupId] [int] NOT NULL,
	[ClusterNumber] [int] NOT NULL,
	[PanelNumber] [int] NOT NULL,
	[CpuNumber] [smallint] NOT NULL,
	[EventDateTime] [datetimeoffset](7) NOT NULL,
	[EventType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BufferIndex] [int] NOT NULL,
	[CredentialBytes] [varbinary](32) NULL,
	[Pin] [int] NULL,
	[BitCount] [smallint] NULL,
	[InputOutputGroupNumber] [smallint] NULL,
	[BoardNumber] [smallint] NULL,
	[SectionNumber] [smallint] NULL,
	[ModuleNumber] [smallint] NULL,
	[NodeNumber] [smallint] NULL,
	[RawData] [varbinary](1024) NOT NULL,
	[WhenProcessed] [datetimeoffset](7) NULL,
	[UniqueEventId]  AS ((((((((((((((((((((CONVERT([varchar](5),[ClusterGroupId])+':')+CONVERT([varchar](5),[ClusterNumber]))+':')+CONVERT([varchar](5),[PanelNumber]))+':')+CONVERT([char](1),[CpuNumber]))+':')+CONVERT([varchar](10),[BufferIndex]))+':')+CONVERT([varchar](4),datepart(year,[EventDateTime])))+'-')+CONVERT([varchar](2),datepart(month,[EventDateTime])))+'-')+CONVERT([varchar](2),datepart(day,[EventDateTime])))+'T')+CONVERT([varchar](2),datepart(hour,[EventDateTime])))+':')+CONVERT([varchar](2),datepart(minute,[EventDateTime])))+':')+CONVERT([varchar](2),datepart(second,[EventDateTime]))) PERSISTED NOT NULL CONSTRAINT [PK_GALAXYRAWACTIVITYEVENT] PRIMARY KEY CLUSTERED 
(
	[GalaxyRawActivityEventUid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyRawActivityEvent].[GalaxyRawActivityEventUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindrule @rulename=N'[GCS].[R_GalaxyClusterId]', @objname=N'[GCS].[GalaxyRawActivityEvent].[ClusterNumber]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_1]', @objname=N'[GCS].[GalaxyRawActivityEvent].[PanelNumber]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindrule @rulename=N'[GCS].[R_GalaxyPanelNumber]', @objname=N'[GCS].[GalaxyRawActivityEvent].[PanelNumber]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_1]', @objname=N'[GCS].[GalaxyRawActivityEvent].[CpuNumber]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindrule @rulename=N'[GCS].[R_GalaxyCpuNumber]', @objname=N'[GCS].[GalaxyRawActivityEvent].[CpuNumber]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[GalaxyRawActivityEvent] TO  SCHEMA OWNER 
GO

ALTER TABLE [GCS].[GalaxyRawActivityEvent] ADD DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GCS].[PanelDataPacketLog]') AND type in (N'U'))
BEGIN
	DROP TABLE GCS.PanelDataPacketLog
END
GO


CREATE TABLE [GCS].[PanelDataPacketLog](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
	[UpdateDate] [datetimeoffset] NULL,
	[Length] [smallint] NOT NULL,
	[Distribute] [smallint] NOT NULL,
	[ClusterId] [int] NOT NULL,
	[PanelId] [int] NOT NULL,
	[CpuId] [smallint] NOT NULL,
	[BoardNumber] [int] NOT NULL,
	[SectionNumber] [smallint] NOT NULL,
	[SecondsFromWeekStart] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[RawData] [varbinary](max) NOT NULL,
	[Direction] [bit] NULL,
 CONSTRAINT [PK_PANELDATAPACKETLOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[PanelDataPacketLog].[Id]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[PanelDataPacketLog] TO  SCHEMA OWNER 
GO

ALTER TABLE [GCS].[PanelDataPacketLog] ADD  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[PanelDataPacketLog] ADD  DEFAULT (SYSDATETIMEOFFSET()) FOR [UpdateDate]
GO


exec dbo.gcs_DeleteDefaultConstraint 'GCS','gcsAudit', 'InsertDate'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'gcsAudit', 'InsertDate') <> 'datetimeoffset'
begin
	alter table GCS.gcsAudit 
	alter column InsertDate datetimeoffset not null
end
go


alter table GCS.gcsAudit 
ADD CONSTRAINT DF_gcsAudit_InsertDate DEFAULT SYSDATETIMEOFFSET() FOR InsertDate
go


exec dbo.gcs_DeleteDefaultConstraint 'GCS','gcsAuditXml', 'UpdateDateTime'
go

if dbo.gcs_GetColumnDataType( 'GCS', 'gcsAuditXml', 'UpdateDateTime') <> 'datetimeoffset'
begin
	alter table GCS.gcsAuditXml 
	alter column UpdateDateTime datetimeoffset null
end
go

alter table GCS.gcsAuditXml 
ADD CONSTRAINT DF_gcsAuditXml_UpdateDateTime DEFAULT SYSDATETIMEOFFSET() FOR UpdateDateTime
go


