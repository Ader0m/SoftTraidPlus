
GO
CREATE TRIGGER manager_delete
ON manager
INSTEAD OF DELETE
AS
DELETE FROM Client
WHERE Client.[id Manager] IN (SELECT id FROM deleted)

DELETE FROM Manager
WHERE Manager.id IN (Select id FROM deleted)