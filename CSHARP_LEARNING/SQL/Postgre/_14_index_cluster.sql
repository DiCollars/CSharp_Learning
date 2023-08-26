create database sqlskills;

create table numbers (numbercol int, charcol varchar (100));

insert into numbers (numbercol, charcol)
select generate_series, left(md5 (random ()::text),100)
from generate_series (1,5000)
order by random ();

select * from numbers;

create index idx_numbers_numbercol on numbers (numbercol);

cluster numbers using idx_numbers_numbercol;

select * from numbers;

select numbercol
from numbers n 
where numbercol = 2500;

explain (analyze, buffers) 
select numbercol
from numbers n 
where numbercol = 2500;