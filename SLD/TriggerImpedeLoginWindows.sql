CREATE TRIGGER ImpedeConexaoViaWindowsAuthentication
ON ALL SERVER WITH EXECUTE AS 'sa'
FOR LOGON
AS
BEGIN
IF(EXISTS(SELECT TOP 1 1 FROM sys.dm_exec_sessions WHERE is_user_process = 1 AND LEN(LTRIM(RTRIM(nt_domain))) > 0 AND original_login_name LIKE ORIGINAL_LOGIN()))
    ROLLBACK;
END;