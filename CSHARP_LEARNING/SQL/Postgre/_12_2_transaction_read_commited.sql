BEGIN;
--SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
--SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SELECT COUNT(*) FROM  EventLog;

SELECT * FROM  EventLog;

COMMIT;