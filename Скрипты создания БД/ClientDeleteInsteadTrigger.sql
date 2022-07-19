
GO
CREATE TRIGGER client_delete
ON Client
INSTEAD OF DELETE
AS
DELETE FROM SellProduct
WHERE SellProduct.[id Client] IN (SELECT id FROM deleted)

DELETE FROM Client
WHERE Client.id IN (Select id FROM deleted)
