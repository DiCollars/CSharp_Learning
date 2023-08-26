CREATE TABLE Products
(
    Id SERIAL PRIMARY KEY,
    ProductName VARCHAR(30) NOT NULL,
    Company VARCHAR(20) NOT NULL,
    ProductCount INTEGER DEFAULT 0,
    Price NUMERIC NOT NULL
);
CREATE TABLE Customers
(
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(30) NOT NULL
);
CREATE TABLE Orders
(
    Id SERIAL PRIMARY KEY,
    ProductId INTEGER NOT NULL REFERENCES Products(Id) ON DELETE CASCADE,
    CustomerId INTEGER NOT NULL REFERENCES Customers(Id) ON DELETE CASCADE,
    CreatedAt DATE NOT NULL,
    ProductCount INTEGER DEFAULT 1,
    Price NUMERIC NOT NULL
);

INSERT INTO Products(ProductName, Company, ProductCount, Price) 
VALUES ('iPhone X', 'Apple', 2, 66000),
('iPhone 8', 'Apple', 2, 51000),
('iPhone 7', 'Apple', 5, 42000),
('Galaxy S9', 'Samsung', 2, 56000),
('Galaxy S8 Plus', 'Samsung', 1, 46000),
('Nokia 9', 'HDM Global', 2, 26000),
('Desire 12', 'HTC', 6, 38000);
  
INSERT INTO Customers(FirstName) 
VALUES ('Tom'), ('Bob'),('Sam');
  
INSERT INTO Orders(ProductId, CustomerId, CreatedAt, ProductCount, Price) 
VALUES
( 
    (SELECT Id FROM Products WHERE ProductName='Galaxy S9'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-11',  
    2, 
    (SELECT Price FROM Products WHERE ProductName='Galaxy S9')
),
( 
    (SELECT Id FROM Products WHERE ProductName='iPhone 8'), 
    (SELECT Id FROM Customers WHERE FirstName='Tom'),
    '2017-07-13',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 8')
),
( 
    (SELECT Id FROM Products WHERE ProductName='iPhone 8'), 
    (SELECT Id FROM Customers WHERE FirstName='Bob'),
    '2017-07-11',  
    1, 
    (SELECT Price FROM Products WHERE ProductName='iPhone 8')
);

-- INNER JOIN
SELECT P.ProductName, C.FirstName, O.* FROM Orders O
JOIN Customers C ON C.Id = O.CustomerId
JOIN Products P ON P.Id = O.ProductId;

SELECT * FROM Orders;

-- OUTER JOIN (LEFT, FULL, RIGHT)
SELECT P.ProductName, C.FirstName, O.* FROM Orders O
LEFT JOIN Customers C ON C.Id = O.CustomerId
RIGHT JOIN Products P ON P.Id = O.ProductId;

-- CROSS JOIN
SELECT * FROM Orders CROSS JOIN Customers;

-- GROUP BY IN JOIN
SELECT C.FirstName, AVG(O.Price), STRING_AGG(P.ProductName, ', ') as order_list FROM Orders O
JOIN Customers C ON C.Id = O.CustomerId
JOIN Products P ON P.Id = O.ProductId
GROUP BY C.FirstName;

-- UNION
SELECT 'ANDRY' AS NAME, 'SOFTWEAR DEVELOPER' AS PROFESSION
UNION
SELECT 'HARRY' AS NAME, 'CLEANER' AS PROFESSION;

-- EXCEPT
(SELECT 'ANDRY' AS NAME
	UNION
	SELECT 'RUDOLPH' AS NAME
	UNION
	SELECT 'BRUCE' AS NAME
	UNION
	SELECT 'JOHN' AS NAME)
EXCEPT
(SELECT 'GEOGHT' AS NAME
	UNION
	SELECT 'EARL' AS NAME
	UNION
	SELECT 'BRUCE' AS NAME
	UNION
	SELECT 'JOHN' AS NAME);
	
-- INTERSECT
(SELECT 'ANDRY' AS NAME
	UNION
	SELECT 'RUDOLPH' AS NAME
	UNION
	SELECT 'BRUCE' AS NAME
	UNION
	SELECT 'JOHN' AS NAME)
INTERSECT
(SELECT 'GEOGHT' AS NAME
	UNION
	SELECT 'EARL' AS NAME
	UNION
	SELECT 'BRUCE' AS NAME
	UNION
	SELECT 'JOHN' AS NAME);