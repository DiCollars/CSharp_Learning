DROP TABLE Users;

CREATE TABLE Users
(
	Id SERIAL PRIMARY KEY,
	Name VARCHAR(40)
);

INSERT INTO Users
(Name)
VALUES
('Harry'),
('Tobi'),
('Andry'),
('Tom')
RETURNING Id;

SELECT * FROM Users;

UPDATE Users
SET Name = CONCAT('Fucking ', LOWER(Name))
WHERE Id < 3;

SELECT * FROM Users;
