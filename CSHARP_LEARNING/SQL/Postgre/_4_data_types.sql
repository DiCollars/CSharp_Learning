CREATE TABLE Test
(
	Number serial, -- from 1 to 2147483647  (4 bytes)
	SmallNumber smallserial, -- from 1 to 32767  (2 bytes)
	BigNumber bigserial, -- from 1 to 9223372036854775807  (8 bytes)
	
	SmallAge smallint, -- from -32768 to +32767  (2 bytes)
	Age int, -- from -2147483648 to +2147483647  (4 bytes)
	BigAge bigint, -- from -9223372036854775808 to +9223372036854775807  (8 bytes)
	
	GamePointBalance numeric(1000, 2), -- numeric(precision: 1000, scale: 16383) Same as decimal type
	
	BonusAccount real, -- from 1E-37 to 1E+37  (4 bytes)
	
	BankAccount money, -- from -92233720368547758.08 to +92233720368547758.07  (8 bytes)
	
	AdressIndex character(6), -- fixed lenght string
	FirstName varchar(50), -- string with max characters of 50
	Comment text, -- string of arbitrary lenght
	
	CreatedAtDate date, -- date year from 4713 to 5874897 (4 bytes)
	CreatedAtTime time, -- from 00:00:00 to 24:00:00  (8 bytes)
	CreatedAt timestamp, -- datetime (8 bytes)
	
	IsDeleted bool, -- just bool
	
	NestedObject json -- json object
);

SELECT * FROM Test;

INSERT INTO Test 
(
	Number,
	SmallNumber,
	BigNumber,
	SmallAge,
	Age,
	BigAge,
	GamePointBalance,
	BonusAccount,
	BankAccount,
	AdressIndex,
	FirstName,
	Comment,
	CreatedAtDate,
	CreatedAtTime,
	CreatedAt,
	IsDeleted,
	NestedObject
) 
VALUES 
(
	2147483647,
	32767,
	9223372036854775807,
	32767,
	2147483647,
	9223372036854775807,
	1.5,
	77.21,
	4.20,
	'39408',
	'Daniel',
	'The chiken was so cold, I cant stand it anymore!',
	'01.01.01',
	'00:00:00',
	'01.01.01 - 00:00:00',
	TRUE,
	'{"objKey": 1}'
);

DROP TABLE Test;
