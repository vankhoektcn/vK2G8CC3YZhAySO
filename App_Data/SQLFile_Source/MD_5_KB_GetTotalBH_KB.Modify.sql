
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[KB_GetTotalBH_KB](@IDKHAMBENH as bigint)
returns bigint
as
begin

declare @IdLoaiBH as bigint, @DungTuyen as bit
select @IdLoaiBH=B.IdLoaiBH,@DungTuyen=DBO.Get_bitValue(B.DungTuyen)
From KHAMBENH A
left join BenhNhan B on A.IdBenhNhan=B.IdBenhNhan
Where A.IDKHAMBENH=@IDKHAMBENH 
if(@IdLoaiBH is null or @IdLoaiBh=0) return 0

declare @Total as float
Select @Total=DBO.KB_GetTotal_KB(@IDKHAMBENH)


if(@DungTuyen is null or @DungTuyen=0)
			return @Total *(select convert(float,ParaValue)/100 from KB_Parameter where ParaName=N'TLTT')

if(@Total<=(  select convert(int,ParaValue) from KB_Parameter where ParaName='MucTinhBH'))
return @Total

Declare @QuyenLoiC as float
declare @QuyenLoiR as float
declare @TLTT as float

select top 1   @QuyenLoiC=QuyenLoiChung,@QuyenLoiR=KyThuatCao,@TLTT=TLTT
from KB_MucBaoHiem A
left join BenhNhan B on B.idloaibh=A.ID
left join KHAMBENH C on B.IdBenhNhan=C.IdBenhNhan
Where C.IDKHAMBENH=@IDKHAMBENH
--and TuNgay<=C.NgayXuatVien
order by TuNgay desc

 

declare @N as bigint
select @N=

(isnull((
     select sum( A.SoLuong*B.GiaBH)  from KHAMBENHCANLAMSAN A
          left join BangGiaDichVu B on A.IDCANLAMSAN=B.IdBangGiaDichVu
           Where IDKHAMBENH=@IDKHAMBENH and b.IsKTC =1
 
	  ),0) * (@QuyenLoiR/100)
)
 + 
(
isnull((
     select sum( A.SoLuong*B.GiaBH)  from KHAMBENHCANLAMSAN A
          left join BangGiaDichVu B on A.IDCANLAMSAN=B.IdBangGiaDichVu
           Where IDKHAMBENH=@IDKHAMBENH and (b.IsKTC =0 or B.IsKTC is null)
 
	  ),0) * (@QuyenLoiC/100)
)
 + 
(			 isnull( ( select sum(A.SOLUONGKE*DBO.KB_GetGiathuoc(A.IDchitietbenhnhantoathuoc))
			 from chitietbenhnhantoathuoc A
			left join benhnhantoathuoc B on A.idbenhnhantoathuoc=B.idbenhnhantoathuoc
			left join Thuoc C on A.Idthuoc=C.Idthuoc
			where B.IdPhieuThanhToan=@IDKHAMBENH ) ,0) * (@QuyenLoiC/100)
)
+isnull( (
 select top 1 GiaBH from KHAMBENH A 
 LEFT JOIN CHITIETDANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM AND A.IDPHONGKHAMBENH=DBO.KB_GETIDPHONGKHAMBENH(B.IDCHITIETDANGKYKHAM) 
  LEFT JOIN BANGGIADICHVU C ON B.IDBANGGIADICHVU=C.IDBANGGIADICHVU
 where A.IDKHAMBENH=@IDKHAMBENH 
),0) *(@quyenLoiC/100)
 
 
return @N
end
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

