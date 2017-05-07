declare @NhomID as bigint
select top 1  @NhomID=NhomID from nhomnguoidung order by nhomid desc

update nguoidung set nhomid=@nhomID 
where IdBacSi in (select idbacsi from bacsi   where idphongkhambenh in (select idphongkhambenh from phongkhambenh where loaiphong=1))



