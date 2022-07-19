GO
CREATE TRIGGER product_delete
ON product
INSTEAD OF DELETE
AS
DELETE FROM SellProduct
WHERE SellProduct.[id Product] IN (SELECT id FROM deleted)

DELETE FROM Product
WHERE Product.id IN (Select id FROM deleted)
