alter proc sp_HttpPost (
@Body AS VARCHAR(max),
@ResponseText AS varchar output )
as
DECLARE @Object AS INT;

--DECLARE @Body AS VARCHAR(8000) = 
--'{
--    "OrderNo": 10,
--    "Doctype": 2012
--}'	`1

EXEC sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;
EXEC sp_OAMethod @Object, 'open', NULL, 'post','http://10.0.7.48:45456/Stock', 'false'

EXEC sp_OAMethod @Object, 'setRequestHeader', null, 'Content-Type', 'application/json'
EXEC sp_OAMethod @Object, 'send', null, @body

EXEC sp_OAMethod @Object, 'responseText', @ResponseText OUTPUT
--SELECT @ResponseText

EXEC sp_OADestroy @Object