
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[KB_GetTotal_KB](@IDKHAMBENH as bigint)
returns bigint
as
begin
declare @N as bigint
select @N=
isnull((
      select sum( A.SoLuong*B.GiaBH)  from KHAMBENHCANLAMSAN A
	  left join BangGiaDichVu B on A.IDCANLAMSAN=B.IdBangGiaDichVu	
           Where IDKHAMBENH=@IDKHAMBENH
 
	  ),0)
 + 
			 isnull( ( select sum(A.SOLUONGKE*DBO.KB_GetGiathuoc(A.IDchitietbenhnhantoathuoc))
			 from chitietbenhnhantoathuoc A
			left join benhnhantoathuoc B on A.idbenhnhantoathuoc=B.idbenhnhantoathuoc
			left join Thuoc C on A.Idthuoc=C.Idthuoc
			where B.IDKHAMBENH=@IDKHAMBENH ) ,0)
+ isnull( (select top 1 GiaBH from KHAMBENH A 
LEFT JOIN CHITIETDANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM AND A.IDPHONGKHAMBENH=DBO.KB_GETIDPHONGKHAMBENH(B.idCHITIETDANGKYKHAM)  
 LEFT JOIN BANGGIADICHVU C ON B.IDBANGGIADICHVU=C.IDBANGGIADICHVU
 where a.idkhambenh=@IDKHAMBENH)
,0)


return @N
end
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

