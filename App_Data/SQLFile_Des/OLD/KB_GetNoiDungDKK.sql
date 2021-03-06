create function [dbo].[KB_GetNoiDungDKK](@IdBenhNhan as bigint)
returns nvarchar(200)
as
begin
declare @N as nvarchar(200)

select top 1 @N= tendichvu 
from chitietdangkykham a
left join dangkykham b on a.iddangkykham=b.iddangkykham
left join benhnhan c on b.idbenhnhan=c.idbenhnhan
left join banggiadichvu d on a.idbanggiadichvu=d.idbanggiadichvu
where c.idbenhnhan=@IdBenhNhan 
and convert(nvarchar(20),ngaytiepnhan,103)=convert(nvarchar(20),ngaydangky,103)
order by b.ngaydangky desc
return @N

end


