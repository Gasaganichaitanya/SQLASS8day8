create database Assesment8Db

use Assesment8Db

create table Products
(PId nvarchar(6) primary key ,
PName nvarchar(50) not null,
PPrice float not null,
MnfDate date not null,
ExpDate date not null
)

insert into Products values('P00001','Smartwatch','3000','06/25/2022','03/08/2024')
insert into Products values('P00002',' SonyTV','50000','05/22/2023','12/12/2026')
insert into Products values('P00003','Liv guard Bttery','10000','02/21/2023','12/04/2026')
insert into Products values('P00004','Shampoo','300','02/23/2022','06/26/2026')
insert into Products values('P00005','detergent','250','04/30/2020','05/11/2024')
insert into Products values('P00006','Cold cream Gel','400','08/29/2021','11/28/2027')
insert into Products values('P00007','Powder ','350','04/23/2023','05/12/2026')
insert into Products values('P00008','Denver ','200','09/21/2018','10/29/2024')
insert into Products values('P00009',' Lays','150','06/07/2020','05/30/2026')
insert into Products values('P00010','Microoven','5000','05/15/2021','09/02/2025')

select * from Products
DELETE FROM Products where PID='P00001'