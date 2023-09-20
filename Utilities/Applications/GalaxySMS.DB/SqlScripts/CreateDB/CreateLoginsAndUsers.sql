
CREATE PROCEDURE #MyCreateLogin
	(@login_name nvarchar(128),
	@password nvarchar(128),
	@default_db nvarchar(128),
	@from_windows int )
AS
DECLARE @dyn_sql	nvarchar(500)
	IF @from_windows = 0
	BEGIN
		IF( SELECT COUNT(*) FROM sys.server_principals where type = 'S' and name=@login_name ) <> 0 
		BEGIN
			PRINT 'Login ' + @login_name + ' already exists.'
			RETURN
		END

		SET @dyn_sql = 'CREATE LOGIN ' + @login_name + ' WITH PASSWORD = ''' + @password
		SET @dyn_sql = @dyn_sql + ''', DEFAULT_DATABASE = ' + @default_db
	END
	ELSE
	BEGIN
		IF( SELECT COUNT(*) FROM sys.server_principals where type = 'U' and name=@login_name ) <> 0 
		BEGIN
			PRINT 'Login ' + @login_name + ' already exists.'
			RETURN
		END

		SET @dyn_sql = 'CREATE LOGIN [' + @login_name + '] FROM WINDOWS'
		SET @dyn_sql = @dyn_sql + ' WITH DEFAULT_DATABASE = ' + @default_db
	END
	print @dyn_sql
	exec master.sys.sp_executesql @dyn_sql
go

exec #MyCreateLogin '[default_login_name]', '[default_login_name]', '[db_name]', 0
go

GRANT ALTER TO [default_login_name]
go


--DECLARE @hostname nvarchar(40)
--SET @hostname = HOST_NAME() + '\ASPNET'
--exec #MyCreateLogin @hostname, '', 'SysGal', 1
--go

exec #MyCreateLogin 'NT AUTHORITY\NETWORK SERVICE', '', '[db_name]', 1
go

USE [db_name]
go

CREATE PROCEDURE #MyCreateUser
	(@user_name nvarchar(128),
	@login_name nvarchar(128),
	@drop_and_recreate int)
AS

DECLARE @dyn_sql	nvarchar(500)

	IF( SELECT COUNT(*) FROM sys.database_principals where ( type = 's' OR type = 'U' ) and name=@user_name ) <> 0 
	BEGIN
		PRINT 'User ' + @user_name + ' already exists.'
		IF @drop_and_recreate = 0
			RETURN
		SET @dyn_sql = 'DROP USER [' + @user_name + ']'
		print @dyn_sql
		exec sys.sp_executesql @dyn_sql
	END
	SET @dyn_sql = 'CREATE USER [' + @user_name + '] FOR LOGIN [' + @login_name + '] WITH DEFAULT_SCHEMA = dbo'
	print @dyn_sql
	exec sys.sp_executesql @dyn_sql
go

CREATE PROCEDURE #MyDropSchema
	(@schema_name nvarchar(128))
AS

DECLARE @dyn_sql	nvarchar(500)
declare @counter int

	select @counter = count(*) from sys.schemas where name = @schema_name
	print @counter
	IF( @counter ) = 1
	BEGIN
		SET @dyn_sql = 'drop schema [' + @schema_name + ']'
		print @dyn_sql
		exec sys.sp_executesql @dyn_sql
	END
go

DECLARE @login_name nvarchar(200)
DECLARE @user_name nvarchar(200)

set @user_name = '[default_login_name]'
set @login_name = @user_name

exec #MyDropSchema @user_name

EXEC #MyCreateUser @user_name, @login_name, 1
EXEC sp_addrolemember 'db_datareader', @user_name
EXEC sp_addrolemember 'db_datawriter', @user_name
EXEC sp_addrolemember 'db_backupoperator', @user_name

DECLARE @hostname nvarchar(40)
SET @hostname = HOST_NAME() + '\ASPNET'

set @user_name = @hostname
set @login_name = @user_name

exec #MyDropSchema @user_name

EXEC #MyCreateUser @user_name, @login_name, 1
EXEC sp_addrolemember 'db_datareader', @user_name
EXEC sp_addrolemember 'db_datawriter', @user_name
EXEC sp_addrolemember 'db_backupoperator', @user_name

set @user_name = 'NT AUTHORITY\NETWORK SERVICE'
set @login_name = @user_name

exec #MyDropSchema @user_name

EXEC #MyCreateUser @user_name, @login_name, 1
EXEC sp_addrolemember 'db_datareader', @user_name
EXEC sp_addrolemember 'db_datawriter', @user_name
EXEC sp_addrolemember 'db_backupoperator', @user_name


