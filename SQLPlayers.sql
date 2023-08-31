create database Players
use Players
create table Players
(PId int,
FName nvarchar(50),
LName nvarchar(50),
JerseyNumber int,
Position nvarchar(50),
Team nvarchar(50));

insert into Players values (1,'Dhoni','Ms',10,'Batsman','CSK'),(2,'Ravindra','jadeja',11,'All rounder','CSK')