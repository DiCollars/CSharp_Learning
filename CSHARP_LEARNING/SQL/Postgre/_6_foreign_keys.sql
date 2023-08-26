-- FOREIGN KEYS
CREATE TABLE Parent
(
	Id SERIAL PRIMARY KEY,
	Name VARCHAR(40) NOT NULL
);

CREATE TABLE Child
(
	Id SERIAL PRIMARY KEY,
	Name VARCHAR(40) NULL,
	ParentId INTEGER REFERENCES Parent(Id) ON DELETE SET NULL
	-- ON DELETE SET DEFAULT - will set default value if linked parent has been deleted 
	-- ON DELETE SET NULL - will set null if linked parent has been deleted 
	-- ON DELETE CASCADE - will delete this entity if linked parent has been deleted 
	ON UPDATE NO ACTION
);

INSERT INTO Parent 
(Name) 
VALUES 
('Comedy'), 
('Cartoon');

INSERT INTO Child 
(Name, ParentId) 
VALUES 
('Stand-up', 1), 
('Sitcom', 1),
('Anime', 2),
('Plasticine animation', 2),
('Pseudo animation', 2);

SELECT 
P.Name AS Type, 
C.* 
FROM Child AS C
LEFT JOIN Parent AS P ON C.ParentId = P.Id;

SELECT * FROM Parent;
SELECT * FROM Child;

DELETE FROM Parent WHERE Name LIKE 'Cartoon';

DROP TABLE Child;
DROP TABLE Parent;