DROP TABLE Products;
CREATE TABLE Products
(
    Id SERIAL PRIMARY KEY,
    ProductName VARCHAR(30) NOT NULL,
    Company VARCHAR(20) NOT NULL,
    ProductCount INT DEFAULT 0,
    Price NUMERIC NOT NULL,
    IsDiscounted BOOL
);
INSERT INTO Products
(ProductName, Company, ProductCount, Price, IsDiscounted)
VALUES
('MILK', 'DANON', 55, 12, FALSE),
('BREAD', 'FGC', 33, 5, FALSE),
('CUCUMBER', 'TOOLS', 123, 2, FALSE),
('APPLE', 'TOOLS', 98, 1, FALSE),
('WATERMELON', 'TOOLS', 18, 7, TRUE),
('CANDY', 'DANON', 544, 1, FALSE),
('CHOCOLATE', 'DANON', 200, 2, FALSE),
('COCONUTE', 'TOOLS', 99, 3, FALSE),
('SALAD', 'COOCKERSON', 30, 8, TRUE);

SELECT 
Company, Price, COUNT(ProductName) 
FROM Products GROUP BY Company, Price;

SELECT * FROM Products;

SELECT IsDiscounted, AVG(Price) FROM Products GROUP BY IsDiscounted HAVING IsDiscounted != TRUE;

SELECT Company FROM Products GROUP BY Company HAVING Company LIKE '%O%';

