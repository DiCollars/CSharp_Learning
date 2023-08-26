-- PRIMARY KEY
CREATE TABLE Lol
(
	Id serial PRIMARY KEY
	--PRIMARY KEY(Id)
);

CREATE TABLE Kek
(
	Id int,
	Name varchar(50),
	PRIMARY KEY(Id, name)
);

INSERT INTO Kek 
(Id, Name) 
VALUES 
(55, 'lOL'), 
(55, 'KEK'),
(55, 'HI'),
(55, 'BYE'),
(10, 'lOL');

SELECT * FROM Kek WHERE Id = 55 AND Name LIKE 'lOL'; -- 27 - 39 MS
SELECT * FROM Kek WHERE Name LIKE 'lOL' AND Id = 55; -- 26 - 41 MS
SELECT * FROM Kek WHERE Id = 55

DROP TABLE Lol;
DROP TABLE Kek;

-- UNIQUE
CREATE TABLE Cartoon
(
	Id serial PRIMARY KEY,
	Name varchar(55) UNIQUE
);

INSERT INTO Cartoon (Name) VALUES ('Rick&Morty');

SELECT * FROM Cartoon;

DROP TABLE Cartoon;

-- NULL/NOT NULL
CREATE TABLE Friend
(
	Id serial PRIMARY KEY,
	Name varchar(10) NOT NULL,
	LastName varchar(10) NULL
);

INSERT INTO Friend (Name, LastName) VALUES ('Chandler', NULL);

SELECT * FROM Friend;

DROP TABLE Friend;

-- DEFAULT
CREATE TABLE LogEntity
(
	Id SERIAL PRIMARY KEY,
	Text TEXT NOT NULL,
	CreateAt TIMESTAMP DEFAULT NOW()
);

INSERT INTO LogEntity (Text) VALUES ('Try get user by user id: 11 - ERROR 404 NOT FOUND');

SELECT * FROM LogEntity;

DROP TABLE LogEntity;

-- CHECK
CREATE TABLE MyDate
(
	_Day SMALLINT NOT NULL CHECK(_Day > 0 AND _Day < 32),
	_Month SMALLINT NOT NULL CHECK(_Month > 0 AND _Month < 13),
	_Year SMALLINT NOT NULL CHECK(_Year > 0 AND _Year < 9999)
);

INSERT INTO MyDate (_Day, _Month, _Year) VALUES (29, 11, 1997);

SELECT * FROM MyDate;

INSERT INTO MyDate (_Day, _Month, _Year) VALUES (32, 13, 1997);

SELECT * FROM MyDate;

DROP TABLE MyDate;

-- CONSTRAINT
CREATE TABLE LogEntity
(
	Id SERIAL PRIMARY KEY,
	Text TEXT CONSTRAINT text_not_null UNIQUE,
	CreateAt TIMESTAMP DEFAULT NOW()
);

DROP TABLE LogEntity;