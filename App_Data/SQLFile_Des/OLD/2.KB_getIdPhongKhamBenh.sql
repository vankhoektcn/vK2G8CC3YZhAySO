CREATE FUNCTION [dbo].[KB_getIdPhongKhamBenh](@IdChiTietDangKyKham as bigint)
returns bigint
as
begin
  declare @n as bigint
select @N=IdPhongKhamBenh 
From ChiTietDangKyKham A
left join BangGiaDichVu B on A.IdBangGiaDichVu=B.IdBangGiaDichVu
where A.IdChiTietDangKyKham=@IdChiTietDangKyKham
return @N

end
