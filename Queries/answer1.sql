SELECT COUNT(pc.Category) as NumProducts, PC.Category
FROM ProductCategory pc
GROUP BY pc.Category
ORDER BY 1 DESC
