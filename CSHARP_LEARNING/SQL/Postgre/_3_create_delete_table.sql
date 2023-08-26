CREATE TABLE Users
(
	Id SERIAL PRIMARY KEY,
	FirstName CHARACTER VARYING(60),
	LastName CHARACTER VARYING(60),
	MiddleName CHARACTER VARYING(60),
	Email CHARACTER VARYING(60),
	Age INTEGER
);

SELECT * FROM Users;

DROP TABLE Users;