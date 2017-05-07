CREATE FUNCTION KB_getIdPhongKhamBenhCLS(@IdKHAMBENHCANLAMSAN as bigint)
returns bigint
as
begin
  declare @n as bigint
select @N=IdPhongKhamBenh 
From KHAMBENHCANLAMSAN A
left join BangGiaDichVu B on A.IDCANLAMSAN=B.IdBangGiaDichVu
where A.IdKHAMBENHCANLAMSAN=@IdKHAMBENHCANLAMSAN
return @N

end