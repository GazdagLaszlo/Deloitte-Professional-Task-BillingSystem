--Return top 3 products by ordered quantity

SELECT TOP 3 p.Name, SUM(oi.Quantity) AS TotalQuantity
FROM Products p
INNER JOIN OrderItems oi ON p.Id = oi.ProductId
GROUP BY p.Id, p.Name
ORDER BY TotalQuantity DESC;

--Return orders containing at least one hazardous product

SELECT DISTINCT o.Id, o.OrderDate, o.CustomerId
FROM Orders o
INNER JOIN OrderItems oi ON o.Id = oi.OrderId
INNER JOIN Products p ON oi.ProductId = p.Id
WHERE p.IsHazardous = 1;