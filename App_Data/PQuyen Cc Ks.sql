-- select Row_number() over (order by PermDesc) as STT, EPID=isnull( B.EPID,0),
--        UserID=1,
--        A.PermID,
--        A.PermDesc,
--      Allow=   Case  isnull( B.EPID,0)  when  0 then convert(bit,0) else   convert(bit,1) end
-- from Permision A
-- left join UserProfile B on A.PermID=B.PermID and B.UserID=1



select * from Permision where PermID=8
select * from UserProfile where UserID=1

SELECT * FROM NHOMNGUOIDUNG 

select * from  nguoidung


insert into Permision(permid,permname,permdesc,Status,isTransfer)
values(13,'khoasan',N'Khoa sản',1,0)
go

insert into Permision(permid,permname,permdesc,Status,isTransfer)
values(14,'capcuu',N'Cấp cứu',1,0)

