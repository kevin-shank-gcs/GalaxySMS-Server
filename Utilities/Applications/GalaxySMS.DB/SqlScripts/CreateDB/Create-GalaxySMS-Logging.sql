USE [master]
GO

--/****** Object:  Database [GalaxySMS-Logging]    Script Date: 8/31/2020 3:08:14 PM ******/
--CREATE DATABASE [GalaxySMS-Logging]
-- ON  PRIMARY 
--( NAME = N'GalaxySMS-Logging', FILENAME = N'E:\MyStuff\SQLDataFiles\SQL2016\MSSQL13.SQL2016DEV\MSSQL\DATA\GalaxySMS-Logging1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'GalaxySMS-Logging_log', FILENAME = N'E:\MyStuff\SQLDataFiles\SQL2016\MSSQL13.SQL2016DEV\MSSQL\DATA\GalaxySMS-Logging1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO


IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GalaxySMS-Logging].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO


ALTER DATABASE [GalaxySMS-Logging] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET ARITHABORT OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GalaxySMS-Logging] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GalaxySMS-Logging] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET  DISABLE_BROKER 
GO

ALTER DATABASE [GalaxySMS-Logging] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GalaxySMS-Logging] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [GalaxySMS-Logging] SET  MULTI_USER 
GO

ALTER DATABASE [GalaxySMS-Logging] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GalaxySMS-Logging] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GalaxySMS-Logging] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GalaxySMS-Logging] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GalaxySMS-Logging] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GalaxySMS-Logging] SET QUERY_STORE = OFF
GO

ALTER DATABASE [GalaxySMS-Logging] SET  READ_WRITE 
GO

USE [GalaxySMS-Logging]
GO

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
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesColumnHaveRule]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesColumnHaveRule](@table_name [nvarchar](65), @COLUMN_NAME [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from syscolumns where syscolumns.name = @COLUMN_NAME AND
	syscolumns.id = (SELECT sysobjects.id from sysobjects where sysobjects.name = @table_name AND
	sysobjects.xtype = 'U')

  IF @result = 0
	RETURN @result

  SELECT @result = rule_object_id from sys.columns where sys.columns.name = @COLUMN_NAME AND
	sys.columns.object_id = (SELECT sysobjects.id from sysobjects where sysobjects.name = @table_name AND
	sysobjects.xtype = 'U')
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesColumnHaveRule] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesColumnHaveRule] TO [public] AS [dbo]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesDataTypeExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesDataTypeExist](@type_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN
  DECLARE @result as int
  SELECT @result = COUNT(*) from systypes WHERE systypes.name = @type_name
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesDataTypeExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesDataTypeExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesDefaultExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesDefaultExist](@default_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN
  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects WHERE sysobjects.name = @default_name AND sysobjects.TYPE = 'D'
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesDefaultExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesDefaultExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesIndexExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesIndexExist](@table_name [nvarchar](65), @index_name [nvarchar](65))
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
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesRuleExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesRuleExist](@rule_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN
  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects WHERE sysobjects.name = @rule_name AND sysobjects.TYPE = 'R'
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesRuleExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesRuleExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesTableExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesTableExist](@table_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects where sysobjects.name = @table_name AND sysobjects.xtype = 'U'
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesTableExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesTableExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GCSDoesViewExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GCSDoesViewExist](@view_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects where sysobjects.name = @view_name AND sysobjects.xtype = 'V'
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GCSDoesViewExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GCSDoesViewExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKFieldSelect]    Script Date: 8/31/2020 2:21:51 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKSelect]    Script Date: 8/31/2020 2:21:51 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_GetPKValueSelect]    Script Date: 8/31/2020 2:21:51 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_GetSQLVersion]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_GetSQLVersion]()
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN
	DECLARE @sql_ver	varchar(26)
	select @sql_ver = @@VERSION
	SET @sql_ver = RTRIM(@sql_ver)
	SET @sql_ver = RIGHT(@sql_ver, 4)
	return cast(@sql_ver as int)
END
GO
ALTER AUTHORIZATION ON [dbo].[fn_GetSQLVersion] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[fn_GetSQLVersion] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[gcsfunc_DoesTableExist]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[gcsfunc_DoesTableExist](@table_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects where sysobjects.name = @table_name AND sysobjects.xtype = 'U'
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[gcsfunc_DoesTableExist] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcsfunc_DoesTableExist] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[gcsfunc_FileExists]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[gcsfunc_FileExists](@path [varchar](8000))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
BEGIN
     DECLARE @result INT
     EXEC master.dbo.xp_fileexist @path, @result OUTPUT
     RETURN cast(@result as bit)
END;
GO
ALTER AUTHORIZATION ON [dbo].[gcsfunc_FileExists] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcsfunc_FileExists] TO [public] AS [dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[gcsfunc_IsColumnIdentity]    Script Date: 8/31/2020 2:21:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[gcsfunc_IsColumnIdentity](@table_name [nvarchar](65), @column_name [nvarchar](65))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN

  DECLARE @result as int
  SELECT @result = COUNT(*) from sysobjects where sysobjects.name = @table_name AND sysobjects.xtype = 'U'

  SELECT @result = columnproperty(object_id(@table_name),@column_name,'IsIdentity')
  
  RETURN @result
END
GO
ALTER AUTHORIZATION ON [dbo].[gcsfunc_IsColumnIdentity] TO  SCHEMA OWNER 
GO
GRANT EXECUTE ON [dbo].[gcsfunc_IsColumnIdentity] TO [public] AS [dbo]
GO

CREATE SCHEMA [GCS] AUTHORIZATION [dbo]
GO


CREATE TABLE [GCS].[Log4NetLogs](
    [Id] uniqueidentifier NOT NULL default NewID(),
    [Date] [datetime] NOT NULL,
    [Thread] [varchar](255) NOT NULL,
    [Level] [varchar](50) NOT NULL,
    [Logger] [varchar](255) NOT NULL,
    [Message] [nvarchar](max) NOT NULL,
    [Exception] [nvarchar](max) NULL,
    [Source] [varchar](100) NULL,
    [HostName] [nvarchar](255) NULL,
 CONSTRAINT [PK_Log4NetLogs] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsConsoleHostLogs]    Script Date: 4/23/2021 4:16:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GCS].[SmsConsoleHostLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsConsoleHostLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsCoreLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsCoreLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsCoreLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsApiLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsApiLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsApiLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsMercuryApiLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsMercuryApiLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsMercuryApiLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsRecorderLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsRecorderLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsRecorderLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



/****** Object:  Table [GCS].[SmsDistributorLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsDistributorLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsDistributorLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsJobProcessorLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsJobProcessorLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsJobProcessorLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [GCS].[SmsCdnLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsCdnLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsCdnLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [GCS].[SmsSignalRLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsSignalRLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsSignalRLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [GCS].[SmsAdminMgrLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsAdminMgrLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsAdminMgrLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [GCS].[SmsFacilityMgrLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsFacilityMgrLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsFacilityMgrLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsMonitorMgrLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsMonitorMgrLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsMonitorMgrLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [GCS].[SmsMercApiLogs]    Script Date: 4/23/2021 4:16:32 PM ******/

CREATE TABLE [GCS].[SmsMercApiLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmsMercApiLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO






