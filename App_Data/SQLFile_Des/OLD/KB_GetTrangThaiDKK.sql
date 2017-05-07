create function [dbo].[KB_GetTrangThaiDKK](@IdBenhNhan as bigint)
returns nvarchar(200)
as
begin
declare @IdPTT as bigint
declare @IdChiTietDangkyKham as bigint

select top 1 @IdPTT=E.idkhambenh,@IdChiTietDangkyKham=a.IdChiTietDangkyKham
from chitietdangkykham a
left join dangkykham b on a.iddangkykham=b.iddangkykham
left join benhnhan c on b.idbenhnhan=c.idbenhnhan
left join banggiadichvu d on a.idbanggiadichvu=d.idbanggiadichvu
left join khambenh E on A.iddangkykham=E.iddangkykham and e.idphongkhambenh=d.idphongkhambenh
where c.idbenhnhan=@IdBenhNhan 
and convert(nvarchar(20),ngaytiepnhan,103)=convert(nvarchar(20),ngaydangky,103)
order by b.ngaydangky desc

if(@IdChiTietDangkyKham is null) return null
if(@IDPTT is null) return N'Đang chờ khám'
return N'Đã khám'

end



