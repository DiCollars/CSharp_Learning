INSERT INTO "Words" ("Text")
SELECT CONCAT('tEST_wORD_', IDX)
FROM generate_series(1, 1000000) as IDX;

SELECT * FROM "Words" LIMIT 300;

SELECT W."Id", WT."WordId" FROM "WordTranslations" WT
JOIN "Words" W ON W."Id" = WT."WordId"
WHERE "WordId" = 2;

SELECT COUNT(1) FROM "Words" GROUP BY "Text";
SELECT COUNT(*) FROM "Words" GROUP BY "Text";

SELECT WT."WordId" FROM "WordTranslations" WT
JOIN "Words" W ON W."Id" = WT."WordId"
WHERE "WordId" = 2;