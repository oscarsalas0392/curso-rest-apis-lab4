DROP PROCEDURE IF EXISTS [dbo].[sp_HelloWorld]
GO
CREATE PROCEDURE sp_HelloWorld
AS
BEGIN
    declare @var1 nvarchar(max) = 'Hello, World! DB';

    SELECT @var1 as Result
    PRINT @var1;
END

--DECLARE @RC int
--EXECUTE @RC = [dbo].[sp_HelloWorld] 
--GO