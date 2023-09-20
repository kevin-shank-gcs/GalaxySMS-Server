USE [master]
GO

--/****** Object:  Database [GalaxySMS-AuditActivity]    Script Date: 8/31/2020 3:08:14 PM ******/
--CREATE DATABASE [GalaxySMS-AuditActivity]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'GalaxySMS-AuditActivity', FILENAME = N'E:\MyStuff\SQLDataFiles\SQL2016\MSSQL13.SQL2016DEV\MSSQL\DATA\GalaxySMS-AuditActivity1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'GalaxySMS-AuditActivity_log', FILENAME = N'E:\MyStuff\SQLDataFiles\SQL2016\MSSQL13.SQL2016DEV\MSSQL\DATA\GalaxySMS-AuditActivity1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GalaxySMS-AuditActivity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ARITHABORT OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET  DISABLE_BROKER 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET  MULTI_USER 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET QUERY_STORE = OFF
GO

ALTER DATABASE [GalaxySMS-AuditActivity] SET  READ_WRITE 
GO

USE [GalaxySMS-AuditActivity]
GO

CREATE SCHEMA [GCS] AUTHORIZATION [dbo]
GO


--/****** Object:  User [GalaxySMSClient]    Script Date: 8/31/2020 2:21:51 PM ******/
--CREATE USER [GalaxySMSClient] FOR LOGIN [GalaxySMSClient] WITH DEFAULT_SCHEMA=[GCS]
--GO
--ALTER ROLE [db_datareader] ADD MEMBER [GalaxySMSClient]
--GO
--ALTER ROLE [db_datawriter] ADD MEMBER [GalaxySMSClient]
--GO

/****** Object:  Default [D_0]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_0] 
AS
0
GO
/****** Object:  Default [D_1]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_1] 
AS
1
GO
/****** Object:  Default [D_NewID]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_NewID] 
AS
NEWID()
GO
/****** Object:  Default [D_No]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_No] 
AS
0
GO
/****** Object:  Default [D_Off]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_Off] 
AS
0
GO
/****** Object:  Default [D_On]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_On] 
AS
1
GO
/****** Object:  Default [D_Yes]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE DEFAULT [GCS].[D_Yes] 
AS
1
GO

/****** Object:  UserDefinedDataType [GCS].[Text100]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE TYPE [GCS].[Text100] FROM [nvarchar](100) NOT NULL
GO
ALTER AUTHORIZATION ON TYPE::[GCS].[Text100] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedDataType [GCS].[Text256]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE TYPE [GCS].[Text256] FROM [nvarchar](256) NOT NULL
GO
ALTER AUTHORIZATION ON TYPE::[GCS].[Text256] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedDataType [GCS].[Text255]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE TYPE [GCS].[Text255] FROM [nvarchar](255) NOT NULL
GO
ALTER AUTHORIZATION ON TYPE::[GCS].[Text255] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedDataType [GCS].[Text128]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE TYPE [GCS].[Text128] FROM [nvarchar](128) NOT NULL
GO
ALTER AUTHORIZATION ON TYPE::[GCS].[Text128] TO  SCHEMA OWNER 
GO
/****** Object:  UserDefinedDataType [GCS].[Text65]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE TYPE [GCS].[Text65] FROM [nvarchar](65) NOT NULL
GO
ALTER AUTHORIZATION ON TYPE::[GCS].[Text65] TO  SCHEMA OWNER 
GO

/****** Object:  Rule [R_AccessGroupNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_AccessGroupNumber] 
AS
@column between 0 and 2001
GO
/****** Object:  Rule [R_AreaNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_AreaNumber] 
AS
@column between 0 and 255
GO
/****** Object:  Rule [R_GalaxyClusterId]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_GalaxyClusterId] 
AS
@column between 1 and 65535
GO
/****** Object:  Rule [R_GalaxyCpuNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_GalaxyCpuNumber] 
AS
@column between 1 and 2
GO
/****** Object:  Rule [R_GalaxyPanelNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_GalaxyPanelNumber] 
AS
(@column between 1 and 254) OR (@column between 256 and 65534)
GO
/****** Object:  Rule [R_InputOutputGroupNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_InputOutputGroupNumber] 
AS
@column between 0 and 255
GO
/****** Object:  Rule [R_OnOff]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_OnOff] 
AS
@column in (0,1)
GO
/****** Object:  Rule [R_TimePeriodNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_TimePeriodNumber] 
AS
@column between 0 and 255
GO
/****** Object:  Rule [R_TimeScheduleNumber]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_TimeScheduleNumber] 
AS
@column between 0 and 255
GO
/****** Object:  Rule [R_YesNo]    Script Date: 8/31/2020 2:21:51 PM ******/
CREATE RULE [GCS].[R_YesNo] 
AS
@column in (0,1)
GO

/****** Object:  UserDefinedFunction [dbo].[fnSPLIT_nVARCHAR]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnSPLIT_nVARCHAR](@STRING [ntext], @DELIMITER [nvarchar](10))
RETURNS @VALUES TABLE (
	[NVARCHAR_DATA] [nvarchar](3900) COLLATE SQL_Latin1_General_CP1_CI_AS
) WITH EXECUTE AS CALLER
AS 
BEGIN

	DECLARE @CONTINUE CHAR(1)
	DECLARE @START_POS INT
	DECLARE @END_POS INT
	DECLARE @NEW_STRING nVARCHAR(3900)
	DECLARE @PAD TINYINT

	SELECT @CONTINUE = 'T', @START_POS = 1, @PAD = DATALENGTH(@DELIMITER) / 2

	WHILE @CONTINUE = 'T'
	BEGIN
		SET @END_POS = CHARINDEX(@DELIMITER, @STRING, @START_POS)
		
		IF @END_POS = 0
		BEGIN
			SET @END_POS = DATALENGTH(@STRING) + 1
			SET @CONTINUE = 'F'

		END

		SET @NEW_STRING = RTRIM(LTRIM(SUBSTRING(@STRING, @START_POS, @END_POS - @START_POS)))
		--IF @NEW_STRING <> ''
		--BEGIN
			INSERT INTO @VALUES SELECT @NEW_STRING
		--END

		SET @START_POS = @END_POS + @PAD
	END

	RETURN

END
GO
ALTER AUTHORIZATION ON [dbo].[fnSPLIT_nVARCHAR] TO  SCHEMA OWNER 
GO
GRANT SELECT ON [dbo].[fnSPLIT_nVARCHAR] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[gcsfunc_IsValidGuid]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[gcsfunc_IsValidGuid](@input [nvarchar](max))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
BEGIN
DECLARE @isValidGuid BIT;
SET @isValidGuid = 0;
SET @input = UPPER(LTRIM(RTRIM(REPLACE(@input, '-', ''))));

IF(@input IS NOT NULL AND LEN(@input) = 32)
BEGIN
DECLARE @indexChar NCHAR(1)
DECLARE @index INT;
SET @index = 1;
WHILE (@index <= 32)
BEGIN
SET @indexChar = SUBSTRING(@input, @index, 1);
IF (ISNUMERIC(@indexChar) = 1 OR @indexChar IN ('A', 'B', 'C', 'D', 'E', 'F'))
SET @index = @index + 1;
ELSE
BREAK;   
END

IF(@index = 33)
SET @isValidGuid = 1;
END

RETURN @isValidGuid;
END
GO
ALTER AUTHORIZATION ON [dbo].[gcsfunc_IsValidGuid] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcsfunc_IsValidGuid] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[gcsfunc_GetUserGuidContextInfo]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[gcsfunc_GetUserGuidContextInfo]()
RETURNS [uniqueidentifier] WITH EXECUTE AS CALLER
AS 
BEGIN

	DECLARE @userId as uniqueidentifier
	SELECT @userId = cast(substring(context_info, 1, 32) as uniqueidentifier)
	FROM master.dbo.sysprocesses
	WHERE spid = @@SPID

	RETURN @userId
END
GO
ALTER AUTHORIZATION ON [dbo].[gcsfunc_GetUserGuidContextInfo] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcsfunc_GetUserGuidContextInfo] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalculatePagedOffset]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_CalculatePagedOffset](@pageNumber [int], @pageSize [int])
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

	if @pageNumber is null OR @pageSize is null or @pageNumber <= 0 or @pageSize <= 0
		return 0

	DECLARE @offset as int = (@pageNumber - 1) * @pageSize
	return @offset
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_CalculatePagedOffset] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_CalculatePagedOffset] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[IsValidGuid]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IsValidGuid](@input [nvarchar](max))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
BEGIN
DECLARE @isValidGuid BIT;
SET @isValidGuid = 0;
SET @input = UPPER(LTRIM(RTRIM(REPLACE(@input, '-', ''))));

IF(@input IS NOT NULL AND LEN(@input) = 32)
BEGIN
DECLARE @indexChar NCHAR(1)
DECLARE @index INT;
SET @index = 1;
WHILE (@index <= 32)
BEGIN
SET @indexChar = SUBSTRING(@input, @index, 1);
IF (ISNUMERIC(@indexChar) = 1 OR @indexChar IN ('A', 'B', 'C', 'D', 'E', 'F'))
SET @index = @index + 1;
ELSE
BREAK;   
END

IF(@index = 33)
SET @isValidGuid = 1;
END

RETURN @isValidGuid;
END
GO
ALTER AUTHORIZATION ON [dbo].[IsValidGuid] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[IsValidGuid] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[DateTime_MinValue]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[DateTime_MinValue]()
RETURNS [datetime] WITH EXECUTE AS CALLER
AS 
BEGIN
        DECLARE @dateTime_min DATETIME ;
        SET @dateTime_min = '1/1/1753 12:00:00 AM'
        RETURN @dateTime_min ;
    END ;
GO
ALTER AUTHORIZATION ON [dbo].[DateTime_MinValue] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[DateTime_MinValue] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKFieldSelect]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GetPKFieldSelect](@schemaName [nvarchar](128), @tName [nvarchar](128))
RETURNS [nvarchar](1000) WITH EXECUTE AS CALLER
AS 
BEGIN
declare @PKFSel nvarchar(1000)
	-- Get primary key fields select for insert
	--select @PKFSel = coalesce(@PKFSel+'.','') + '' + COLUMN_NAME + '' 
	--from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk,
	--INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	--where pk.TABLE_SCHEMA = @schemaName
	--and pk.TABLE_NAME = @tName
	--and CONSTRAINT_TYPE = 'PRIMARY KEY'
	--and c.TABLE_NAME = pk.TABLE_NAME
	--and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	--set @PKFSel = '''' + @PKFSel + ''''
	--return @PKFSel
	select @PKFSel = coalesce(@PKFSel + '.', '') + '' + COLUMN_NAME + '' 
	from INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
	INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
	ON c.TABLE_NAME = pk.TABLE_NAME 
	and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME 
	where pk.TABLE_SCHEMA = @schemaName 
	and pk.TABLE_NAME = @tName 
	and CONSTRAINT_TYPE = 'PRIMARY KEY'
	set @PKFSel = '''' + @PKFSel + ''''
	return @PKFSel


END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GetPKFieldSelect] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GetPKFieldSelect] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_BinaryColumnsDeleted]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_BinaryColumnsDeleted](@schemaName [nvarchar](128), @tName [nvarchar](128))
RETURNS [varbinary](max) WITH EXECUTE AS CALLER
AS 
BEGIN
	DECLARE @ret varbinary(max)
	set @ret = NULL
	DECLARE @maxID int, @len int, @byteCount int, @bitCount int
	
	SELECT @maxID = MAX(COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'ColumnID')) 
		FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @schemaName AND TABLE_NAME = @tName
	
	SET @byteCount = @maxID / 8 + 1
	SET @bitCount = @maxID % 8
			
	WHILE @byteCount > 0
	BEGIN
		IF @ret IS NULL
			SET @ret = 0xFF
		ELSE
			SET @ret = @ret + 0xFF
		SET @byteCount = @byteCount - 1
	END
	return @ret
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_BinaryColumnsDeleted] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_BinaryColumnsDeleted] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKValueSelect]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GetPKValueSelect](@schemaName [nvarchar](128), @tName [nvarchar](128))
RETURNS [nvarchar](1000) WITH EXECUTE AS CALLER
AS 
BEGIN
declare @PKVSel nvarchar(1000)
	-- Get primary key fields select for insert
	--select @PKVSel = coalesce(@PKVSel+'+''.''+','') + 'convert(nvarchar(100), coalesce(i.' + COLUMN_NAME + ',d.' + COLUMN_NAME + '))'
	--from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk,
	--INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	--where pk.TABLE_SCHEMA = @schemaName
	--and pk.TABLE_NAME = @tName  
	--and CONSTRAINT_TYPE = 'PRIMARY KEY'  
	--and c.TABLE_NAME = pk.TABLE_NAME  
	--and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME	

    select @PKVSel = coalesce(@PKVSel + '+''.''+', '') + 'convert(nvarchar(100), coalesce(i.' + COLUMN_NAME + ',d.' + COLUMN_NAME + '))' 
	from INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
	INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
	ON c.TABLE_NAME = pk.TABLE_NAME 
	and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	where pk.TABLE_SCHEMA = @schemaName 
    and pk.TABLE_NAME = @tName 
	and CONSTRAINT_TYPE = 'PRIMARY KEY'
	return @PKVSel
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GetPKValueSelect] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GetPKValueSelect] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKSelect]    Script Date: 8/31/2020 2:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GetPKSelect](@schemaName [nvarchar](128), @tName [nvarchar](128))
RETURNS [nvarchar](1000) WITH EXECUTE AS CALLER
AS 
BEGIN
declare @PKCols nvarchar(1000)

	-- Get primary key columns for full outer join
	--select @PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME
	--from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk,
	--INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	--where pk.TABLE_SCHEMA = @schemaName
	--and pk.TABLE_NAME = @tName
	--and CONSTRAINT_TYPE = 'PRIMARY KEY'
	--and c.TABLE_NAME = pk.TABLE_NAME
	--and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	select @PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME 
	from INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
	INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
	ON c.TABLE_NAME = pk.TABLE_NAME and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME 
	where pk.TABLE_SCHEMA = @schemaName and pk.TABLE_NAME = @tName and CONSTRAINT_TYPE = 'PRIMARY KEY'

	return @PKCols
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GetPKSelect] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GetPKSelect] TO [public] AS [dbo]
GO

/****** Object:  Table [GCS].[InputDeviceActivityEvent]    Script Date: 8/31/2020 2:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[InputDeviceActivityEvent](
	[InputDeviceActivityEventUid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GalaxyActivityEventTypeUid] [uniqueidentifier] NOT NULL,
	[InputDeviceUid] [uniqueidentifier] NOT NULL,
	[CpuUid] [uniqueidentifier] NOT NULL,
	[CpuNumber] [smallint] NOT NULL,
	[ActivityDateTime] [datetimeoffset] NOT NULL,
	[BufferIndex] [int] NOT NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
 CONSTRAINT [PK_INPUTDEVICEACTIVITYEVENT] PRIMARY KEY CLUSTERED 
(
	[InputDeviceActivityEventUid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[InputDeviceActivityEvent].[InputDeviceActivityEventUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[InputDeviceActivityEvent].[GalaxyActivityEventTypeUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[InputDeviceActivityEvent].[InputDeviceUid]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[InputDeviceActivityEvent] TO  SCHEMA OWNER 
GO
/****** Object:  Table [GCS].[OutputDeviceActivityEvent]    Script Date: 8/31/2020 2:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[OutputDeviceActivityEvent](
	[OutputDeviceActivityEventUid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GalaxyActivityEventTypeUid] [uniqueidentifier] NOT NULL,
	[OutputDeviceUid] [uniqueidentifier] NOT NULL,
	[CpuUid] [uniqueidentifier] NOT NULL,
	[CpuNumber] [smallint] NOT NULL,
	[ActivityDateTime] [datetimeoffset] NOT NULL,
	[BufferIndex] [int] NOT NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
 CONSTRAINT [PK_OUTPUTDEVICEACTIVITYEVENT] PRIMARY KEY CLUSTERED 
(
	[OutputDeviceActivityEventUid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[OutputDeviceActivityEvent].[OutputDeviceActivityEventUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[OutputDeviceActivityEvent].[GalaxyActivityEventTypeUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[OutputDeviceActivityEvent].[OutputDeviceUid]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[OutputDeviceActivityEvent] TO  SCHEMA OWNER 
GO
/****** Object:  Table [GCS].[gcsAuditXml]    Script Date: 8/31/2020 2:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[gcsAuditXml](
	[AuditId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TableName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PKField] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PKValue] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FieldName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OldValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NewValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[XmlText] [xml] NULL,
	[UpdateDateTime] [datetimeoffset] NULL,
	[UserName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HostMachineName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AppName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NTDomain] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NTUserName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NETAddress] [nvarchar](12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ApplicationUserId] [uniqueidentifier] NULL,
	[TransactionID] [uniqueidentifier] NULL,
	[Description] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_GCSAUDITXNK] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [GCS].[gcsAuditXml] TO  SCHEMA OWNER 
GO
/****** Object:  Table [GCS].[GalaxyPanelActivityEvent]    Script Date: 8/31/2020 2:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[GalaxyPanelActivityEvent](
	[GalaxyPanelActivityEventUid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GalaxyActivityEventTypeUid] [uniqueidentifier] NOT NULL,
	[GalaxyPanelUid] [uniqueidentifier] NOT NULL,
	[CredentialUid] [uniqueidentifier] NULL,
	[PersonUid] [uniqueidentifier] NULL,
	[InputOutputGroupUid] [uniqueidentifier] NULL,
	[ActivityDateTime] [datetimeoffset] NOT NULL,
	[CpuUid] [uniqueidentifier] NOT NULL,
	[CpuNumber] [smallint] NOT NULL,
	[BufferIndex] [int] NOT NULL,
	[InputOutputGroupNumber] [int] NULL,
	[BoardNumber] [int] NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
 CONSTRAINT [PK_GALAXYPANELACTIVITYEVENT] PRIMARY KEY CLUSTERED 
(
	[GalaxyPanelActivityEventUid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[GalaxyPanelActivityEventUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[GalaxyActivityEventTypeUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[GalaxyPanelUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[CredentialUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[PersonUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[GalaxyPanelActivityEvent].[InputOutputGroupUid]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[GalaxyPanelActivityEvent] TO  SCHEMA OWNER 
GO
/****** Object:  Table [GCS].[gcsAudit]    Script Date: 8/31/2020 2:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[gcsAudit](
	[AuditId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
	[TableName] [nvarchar](128) NOT NULL,
	[OperationType] [nvarchar](10) NOT NULL,
	[PrimaryKeyColumn] [nvarchar](128) NOT NULL,
	[PrimaryKeyValue] [uniqueidentifier] NOT NULL,
	[RecordTag] [nvarchar](255) NOT NULL,
	[AuditXml] [xml] NULL,
	[ColumnName] [nvarchar](128) NULL,
	[OriginalValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NewValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OriginalBinaryValue] [varbinary](max) NULL,
	[NewBinaryValue] [varbinary](max) NULL,
	[InsertName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_GCSAUDIT] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[gcsAudit].[AuditId]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[gcsAudit].[TransactionId]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[gcsAudit].[PrimaryKeyValue]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[gcsAudit] TO  SCHEMA OWNER 
GO
/****** Object:  Table [GCS].[GalaxyRawActivityEvent]    Script Date: 8/31/2020 2:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [GCS].[PanelDataPacketLog]    Script Date: 8/31/2020 2:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[PanelDataPacketLog](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
	[UpdateDate] [datetimeoffset] NULL,
	[Length] [smallint] NOT NULL,
	[Distribute] [smallint] NOT NULL,
	[ClusterGroupId] [int] NOT NULL,
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
/****** Object:  Table [GCS].[AccessPortalActivityEvent]    Script Date: 8/31/2020 2:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GCS].[AccessPortalActivityEvent](
	[AccessPortalActivityEventUid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GalaxyActivityEventTypeUid] [uniqueidentifier] NOT NULL,
	[AccessPortalUid] [uniqueidentifier] NOT NULL,
	[CredentialUid] [uniqueidentifier] NULL,
	[PersonUid] [uniqueidentifier] NULL,
	[CpuUid] [uniqueidentifier] NOT NULL,
	[CpuNumber] [smallint] NOT NULL,
	[ActivityDateTime] [datetimeoffset] NOT NULL,
	[BufferIndex] [int] NOT NULL,
	[CredentialBytes] [varbinary](32) NULL,
	[InsertDate] [datetimeoffset] NOT NULL,
 CONSTRAINT [PK_ACCESSPORTALACTIVITYEVENT] PRIMARY KEY CLUSTERED 
(
	[AccessPortalActivityEventUid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[AccessPortalActivityEvent].[AccessPortalActivityEventUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[AccessPortalActivityEvent].[GalaxyActivityEventTypeUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[AccessPortalActivityEvent].[AccessPortalUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[AccessPortalActivityEvent].[CredentialUid]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindefault @defname=N'[GCS].[D_NewID]', @objname=N'[GCS].[AccessPortalActivityEvent].[PersonUid]' , @futureonly='futureonly'
GO
ALTER AUTHORIZATION ON [GCS].[AccessPortalActivityEvent] TO  SCHEMA OWNER 
GO
/****** Object:  Index [idxInputDeviceActivityEvent]    Script Date: 8/31/2020 2:22:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxInputDeviceActivityEvent] ON [GCS].[InputDeviceActivityEvent]
(
	[CpuNumber] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idxOutputDeviceActivityEvent]    Script Date: 8/31/2020 2:22:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxOutputDeviceActivityEvent] ON [GCS].[OutputDeviceActivityEvent]
(
	[CpuNumber] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idxGalaxyPanelActivityEvent]    Script Date: 8/31/2020 2:22:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxGalaxyPanelActivityEvent] ON [GCS].[GalaxyPanelActivityEvent]
(
	[ActivityDateTime] ASC,
	[CpuNumber] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF
GO
/****** Object:  Index [idxGalaxyRawActivityEvent]    Script Date: 8/31/2020 2:22:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxGalaxyRawActivityEvent] ON [GCS].[GalaxyRawActivityEvent]
(
	[UniqueEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idxAccessPortalActivityEventUniqueId]    Script Date: 8/31/2020 2:22:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idxAccessPortalActivityEventUniqueId] ON [GCS].[AccessPortalActivityEvent]
(
	[CpuNumber] ASC,
	[ActivityDateTime] ASC,
	[BufferIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [GCS].[InputDeviceActivityEvent] ADD  CONSTRAINT [DF__InputDevi__Inser__4F514DF7]  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[OutputDeviceActivityEvent] ADD  CONSTRAINT [DF__OutputDev__Inser__5321DEDB]  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[gcsAuditXml] ADD  CONSTRAINT [DF__gcsAuditX__Audit__076201D4]  DEFAULT (newsequentialid()) FOR [AuditId]
GO
ALTER TABLE [GCS].[gcsAuditXml] ADD  CONSTRAINT [DF__gcsAuditX__Updat__0856260D]  DEFAULT (SYSDATETIMEOFFSET()) FOR [UpdateDateTime]
GO
ALTER TABLE [GCS].[GalaxyPanelActivityEvent] ADD  CONSTRAINT [DF__GalaxyPan__Inser__31C0EB10]  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[gcsAudit] ADD  CONSTRAINT [DF__gcsAudit__Insert__772B9A0B]  DEFAULT (user_name()) FOR [InsertName]
GO
ALTER TABLE [GCS].[gcsAudit] ADD  CONSTRAINT [DF__gcsAudit__Insert__781FBE44]  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[GalaxyRawActivityEvent] ADD  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[PanelDataPacketLog] ADD  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO
ALTER TABLE [GCS].[PanelDataPacketLog] ADD  DEFAULT (SYSDATETIMEOFFSET()) FOR [UpdateDate]
GO
ALTER TABLE [GCS].[AccessPortalActivityEvent] ADD  CONSTRAINT [DF__AccessPor__Inser__2DF05A2C]  DEFAULT (SYSDATETIMEOFFSET()) FOR [InsertDate]
GO

/****** Object:  StoredProcedure [dbo].[gcs_GetErrorInfo]    Script Date: 8/31/2020 2:22:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gcs_GetErrorInfo]
	@select [smallint],
	@print [smallint],
	@messageOnly [smallint] = 0
WITH EXECUTE AS CALLER
AS
DECLARE @errorNumber int
	DECLARE @errorSeverity int
	DECLARE @errorState int
	DECLARE @errorProcedure nvarchar(126)
	DECLARE @errorLine int
	DECLARE @errorMessage nvarchar(2048)
	
	SELECT @errorNumber = ERROR_NUMBER()
		,@errorSeverity = ERROR_SEVERITY()
		,@errorState = ERROR_STATE()
		,@errorProcedure = ERROR_PROCEDURE()
		,@errorLine = ERROR_LINE()
		,@errorMessage = ERROR_MESSAGE()
		
	IF @messageOnly = 0
	BEGIN
		IF @select <> 0
		BEGIN
			SELECT @errorNumber AS ErrorNumber
			,@errorSeverity AS ErrorSeverity
			,@errorState AS ErrorState
			,@errorProcedure AS ErrorProcedure
			,@errorLine AS ErrorLine
			,@errorMessage AS ErrorMessage
		END
		   
		IF @print <> 0 
		BEGIN
			PRINT 'Error #: ' + ISNULL(cast( @errorNumber as nvarchar), '') + ', Severity: ' + ISNULL(cast(@errorSeverity as nvarchar), '') + ', State: ' + ISNULL(cast( @errorState as nvarchar), '') +
			', Procedure: ' + ISNULL(@errorProcedure, '') + ', Line # ' + ISNULL(cast( @errorLine as nvarchar), '') + ', ' + ISNULL(@errorMessage, '') 
			--PRINT cast( ERROR_PROCEDURE() as nvarchar) + ', Line # ' + cast( ERROR_LINE() as nvarchar)
			--PRINT ERROR_MESSAGE() 
		END
	END
	ELSE
	BEGIN
		IF @select <> 0
		BEGIN
			SELECT @errorMessage AS ErrorMessage
		END
		   
		IF @print <> 0 
		BEGIN
			PRINT ISNULL(@errorMessage, '') 
			--PRINT cast( ERROR_PROCEDURE() as nvarchar) + ', Line # ' + cast( ERROR_LINE() as nvarchar)
			--PRINT ERROR_MESSAGE() 
		END
	END
GO
ALTER AUTHORIZATION ON [dbo].[gcs_GetErrorInfo] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcs_GetErrorInfo] TO [public] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetErrorInfo]    Script Date: 8/31/2020 2:22:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetErrorInfo]
	@select [smallint],
	@print [smallint],
	@messageOnly [smallint] = 0
WITH EXECUTE AS CALLER
AS
DECLARE @errorNumber int
	DECLARE @errorSeverity int
	DECLARE @errorState int
	DECLARE @errorProcedure nvarchar(126)
	DECLARE @errorLine int
	DECLARE @errorMessage nvarchar(2048)
	
	SELECT @errorNumber = ERROR_NUMBER()
		,@errorSeverity = ERROR_SEVERITY()
		,@errorState = ERROR_STATE()
		,@errorProcedure = ERROR_PROCEDURE()
		,@errorLine = ERROR_LINE()
		,@errorMessage = ERROR_MESSAGE()
		
	IF @messageOnly = 0
	BEGIN
		IF @select <> 0
		BEGIN
			SELECT @errorNumber AS ErrorNumber
			,@errorSeverity AS ErrorSeverity
			,@errorState AS ErrorState
			,@errorProcedure AS ErrorProcedure
			,@errorLine AS ErrorLine
			,@errorMessage AS ErrorMessage
		END
		   
		IF @print <> 0 
		BEGIN
			PRINT 'Error #: ' + ISNULL(cast( @errorNumber as nvarchar), '') + ', Severity: ' + ISNULL(cast(@errorSeverity as nvarchar), '') + ', State: ' + ISNULL(cast( @errorState as nvarchar), '') +
			', Procedure: ' + ISNULL(@errorProcedure, '') + ', Line # ' + ISNULL(cast( @errorLine as nvarchar), '') + ', ' + ISNULL(@errorMessage, '') 
			--PRINT cast( ERROR_PROCEDURE() as nvarchar) + ', Line # ' + cast( ERROR_LINE() as nvarchar)
			--PRINT ERROR_MESSAGE() 
		END
	END
	ELSE
	BEGIN
		IF @select <> 0
		BEGIN
			SELECT @errorMessage AS ErrorMessage
		END
		   
		IF @print <> 0 
		BEGIN
			PRINT ISNULL(@errorMessage, '') 
			--PRINT cast( ERROR_PROCEDURE() as nvarchar) + ', Line # ' + cast( ERROR_LINE() as nvarchar)
			--PRINT ERROR_MESSAGE() 
		END
	END
GO
ALTER AUTHORIZATION ON [dbo].[usp_GetErrorInfo] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[usp_GetErrorInfo] TO [public] AS [dbo]
GO
/****** Object:  Trigger [GCS].[ti_inputdeviceactivityevent]    Script Date: 8/31/2020 2:22:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create trigger [GCS].[ti_inputdeviceactivityevent] on [GCS].[InputDeviceActivityEvent] for insert as
begin
    declare
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Parent "GCS.GalaxyActivityEventType" must exist when inserting a child in "GCS.InputDeviceActivityEvent"  */
    if update(GalaxyActivityEventTypeUid)
    begin
       if (select count(*)
           from   GCS.GalaxyActivityEventType t1, inserted t2
           where  t1.GalaxyActivityEventTypeUid = t2.GalaxyActivityEventTypeUid) != @numrows
          begin
             select @errno  = 2,
                    @errmsg = 'Parent does not exist in "GCS.GalaxyActivityEventType". Cannot create child in "GCS.InputDeviceActivityEvent".'
             goto error
          end
    end

    return

/*  Errors handling  */
error:
    rollback  transaction
    RAISERROR(@errmsg, @errno, 1)
end
GO
ALTER TABLE [GCS].[InputDeviceActivityEvent] ENABLE TRIGGER [ti_inputdeviceactivityevent]
GO
/****** Object:  Trigger [GCS].[tu_inputdeviceactivityevent]    Script Date: 8/31/2020 2:22:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [GCS].[tu_inputdeviceactivityevent] on [GCS].[InputDeviceActivityEvent] for update as
begin
   declare
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return

      /*  Parent "GCS.GalaxyActivityEventType" must exist when updating a child in "GCS.InputDeviceActivityEvent"  */
      if update(GalaxyActivityEventTypeUid)
      begin
         if (select count(*)
             from   GCS.GalaxyActivityEventType t1, inserted t2
             where  t1.GalaxyActivityEventTypeUid = t2.GalaxyActivityEventTypeUid) != @numrows
            begin
               select @errno  = 3,
                      @errmsg = 'GCS.GalaxyActivityEventType" does not exist. Cannot modify child in "GCS.InputDeviceActivityEvent".'
               goto error
            end
      end

      return

/*  Errors handling  */
error:
     rollback  transaction
     RAISERROR(@errmsg, @errno, 1)
end
GO
ALTER TABLE [GCS].[InputDeviceActivityEvent] ENABLE TRIGGER [tu_inputdeviceactivityevent]
GO
/****** Object:  Trigger [GCS].[ti_outputdeviceactivityevent]    Script Date: 8/31/2020 2:22:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create trigger [GCS].[ti_outputdeviceactivityevent] on [GCS].[OutputDeviceActivityEvent] for insert as
begin
    declare
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

    /*  Parent "GCS.GalaxyActivityEventType" must exist when inserting a child in "GCS.OutputDeviceActivityEvent"  */
    if update(GalaxyActivityEventTypeUid)
    begin
       if (select count(*)
           from   GCS.GalaxyActivityEventType t1, inserted t2
           where  t1.GalaxyActivityEventTypeUid = t2.GalaxyActivityEventTypeUid) != @numrows
          begin
             select @errno  = 2,
                    @errmsg = 'Parent does not exist in "GCS.GalaxyActivityEventType". Cannot create child in "GCS.OutputDeviceActivityEvent".'
             goto error
          end
    end

    return

/*  Errors handling  */
error:
    rollback  transaction
    RAISERROR(@errmsg, @errno, 1)
end
GO
ALTER TABLE [GCS].[OutputDeviceActivityEvent] ENABLE TRIGGER [ti_outputdeviceactivityevent]
GO
/****** Object:  Trigger [GCS].[tu_outputdeviceactivityevent]    Script Date: 8/31/2020 2:22:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [GCS].[tu_outputdeviceactivityevent] on [GCS].[OutputDeviceActivityEvent] for update as
begin
   declare
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return

      /*  Parent "GCS.GalaxyActivityEventType" must exist when updating a child in "GCS.OutputDeviceActivityEvent"  */
      if update(GalaxyActivityEventTypeUid)
      begin
         if (select count(*)
             from   GCS.GalaxyActivityEventType t1, inserted t2
             where  t1.GalaxyActivityEventTypeUid = t2.GalaxyActivityEventTypeUid) != @numrows
            begin
               select @errno  = 3,
                      @errmsg = 'GCS.GalaxyActivityEventType" does not exist. Cannot modify child in "GCS.OutputDeviceActivityEvent".'
               goto error
            end
      end

      return

/*  Errors handling  */
error:
     rollback  transaction
     RAISERROR(@errmsg, @errno, 1)
end
GO
ALTER TABLE [GCS].[OutputDeviceActivityEvent] ENABLE TRIGGER [tu_outputdeviceactivityevent]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores activity events that are panel related' , @level0type=N'SCHEMA',@level0name=N'GCS', @level1type=N'TABLE',@level1name=N'GalaxyPanelActivityEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores Galaxy activity event data in a partially decoded form. ' , @level0type=N'SCHEMA',@level0name=N'GCS', @level1type=N'TABLE',@level1name=N'GalaxyRawActivityEvent'
GO

