SELECT COUNT(P.ProductId) as ProductsInCategory, P.Name
FROM ProductCategory PC
INNER JOIN Product P ON P.ProductId = PC.ProductId
GROUP BY P.Name
HAVING COUNT(*)> 1
ORDER BY 1 DESC