create function [dbo].[KB_GetNoiDungDKCLS](@IdBenhNhan as bigint)
returns nvarchar(200)
as
begin
declare @N as nvarchar(200)

select top 1 @N= N'Đăng ký CLS'
from benhnhanChoCLS a
left join benhnhan b on a.idbenhnhan=B.idbenhnhan
where B.idbenhnhan=@IdBenhNhan
 and convert(nvarchar(20),A.ngaytiepnhan,103)=convert(nvarchar(20),A.NgayTiepNhan,103)
order by a.ngaytiepnhan desc
return @N

end


