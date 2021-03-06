create function [dbo].[KB_GetTinhTrangDKCLS](@IdBenhNhan as bigint)
returns nvarchar(100)
as
begin
declare @N as nvarchar(100)

select top 1 @N= isnull( (select top 1 N'Đã đóng phí' 
					from KhamBenhCanLamsan
					 where IdBenhNhan=a.IdBenhNhan 
						and convert(nvarchar(20),NgayThu,103)=convert(nvarchar(20),A.NgayTiepNhan,103) 
						and (DaHuy=0 or DaHuy=1)
				),N'Đang chờ đóng phí')
from benhnhanChoCLS a
left join benhnhan b on a.idbenhnhan=B.idbenhnhan
where B.idbenhnhan=@IdBenhNhan
 and convert(nvarchar(20),A.ngaytiepnhan,103)=convert(nvarchar(20),A.NgayTiepNhan,103)
order by a.ngaytiepnhan desc

if(@N=N'Đang chờ đó') set @N=N'Đang chờ đóng phí'
return @N

end



