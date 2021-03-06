USE [MinhDuc]
GO
/****** Object:  UserDefinedFunction [dbo].[func_rpt_DSDeNghiChiPhiKCBNgoaiTru]    Script Date: 07/23/2011 12:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<khanhdtn>
-- Create date: <22-07-2011>
-- Description:	<Danh sach de nghi thanh toan kham chua benh ngoai tru theo quy, nam>
-- =============================================
CREATE Function [dbo].[func_rpt_DSDeNghiChiPhiKCBNgoaiTru]
	-- Add the parameters for the stored procedure here
	(@tungay smalldatetime,
	@denngay smalldatetime) 

RETURNS TABLE 
AS
RETURN
(
select A.*,isnull(xetnghiem,0)+
isnull(dvktc,0)+isnull(cdha,0)+isnull(thuthuatphauthuat,0)+isnull(thuoc,0)
+isnull(vtyt,0)+isnull(tienkham,0)+ isnull(mau,0)+isnull(vanchuyen,0) +isnull(thaighep,0) as tongcong,
isnull(xetnghiem,0)+
isnull(dvktc,0)+isnull(cdha,0)+isnull(thuthuatphauthuat,0)+isnull(thuoc,0)
+isnull(vtyt,0)+isnull(tienkham,0)+isnull(mau,0)+isnull(vanchuyen,0) +isnull(thaighep,0)- a.bhxhthanhtoan benhnhancungtra,
null chiphingoaids
from (
		
	select bn.tenbenhnhan,dbo.getnamsinh(bn.ngaysinh) ngaysinh, bn.mabenhnhan, case when bn.gioitinh=0 then 'Nam' else N'Nữ' end as gioitinh,
	bn.sobhyt,bn.MaDangKy_KCB_bandau,
	case when left(bn.MaDangKy_KCB_bandau,2)='83' then 
	case when right(bn.MaDangKy_KCB_bandau,5)='009'/*lấy tạm*/ then N'Bệnh nhan nội tỉnh KCB ban đầu' else N'Bệnh nhân nội tỉnh đến' end else N'Bệnh nhân ngoại tỉnh đến' end as loaibenhnhan,
	case when bn.dungtuyen='Y' then N'Đúng tuyến' else N'Trái tuyến' end dungtuyen,
	dkk.ngaydangky ngaykhambenh,
	(select sum(kbcls.soluong*bgdv.giabh) --sum(kbcls.thanhtien)
	from khambenhcanlamsan kbcls
	inner join khambenh kb on kbcls.idkhambenh=kb.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham
			and (kb.isnoitru is null or kb.isnoitru=0)
	inner join banggiadichvu bgdv on kbcls.idcanlamsan = bgdv.idbanggiadichvu
	inner join phongkhambenh p on p.idphongkhambenh=bgdv.idphongkhambenh
		 and p.maphongkhambenh='XN'	
	) xetnghiem, 
	(select sum(kbcls.soluong*bgdv.giabh) --sum(kbcls.thanhtien)
	from khambenhcanlamsan kbcls
	inner join khambenh kb on kbcls.idkhambenh=kb.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham							
			and (kb.isnoitru is null or kb.isnoitru=0)
	inner join banggiadichvu bgdv on kbcls.idcanlamsan = bgdv.idbanggiadichvu
			and bgdv.isktc=1
	) dvktc
	
	,
	(select sum(kbcls.soluong*bgdv.giabh)-- sum(kbcls.thanhtien)
	from khambenhcanlamsan kbcls		
	inner join khambenh kb on kbcls.idkhambenh=kb.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham							
			and (kb.isnoitru is null or kb.isnoitru=0)	
	inner join banggiadichvu bgdv on kbcls.idcanlamsan = bgdv.idbanggiadichvu
			and (bgdv.isktc=0 or bgdv.isktc is null)
	inner join phongkhambenh p on p.idphongkhambenh=bgdv.idphongkhambenh
		and p.maphongkhambenh in ('SA','CTXQ','TDCN')
	) cdha	
	,(select sum(kbcls.soluong*bgdv.giabh) --sum(kbcls.thanhtien)
	from khambenhcanlamsan kbcls
	inner join khambenh kb on kbcls.idkhambenh=kb.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham							
			and (kb.isnoitru is null or kb.isnoitru=0)
	inner join banggiadichvu bgdv on kbcls.idcanlamsan = bgdv.idbanggiadichvu
			and (bgdv.isktc=0 or bgdv.isktc is null)
	inner join phongkhambenh p on p.idphongkhambenh=bgdv.idphongkhambenh
		 and p.maphongkhambenh in ('PTH','PTNS','DVKTKHAC')
	) thuthuatphauthuat 
	,(select sum(cttt.SOLUONGKE*DBO.KB_GetGiathuoc(cttt.IDchitietbenhnhantoathuoc))--sum(cttt.thanhtien)
	from chitietbenhnhantoathuoc cttt
	inner join benhnhantoathuoc tt on tt.idbenhnhantoathuoc=cttt.idbenhnhantoathuoc
	inner join khambenh kb on kb.idkhambenh=tt.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham							
			and (kb.isnoitru=0 or kb.isnoitru is null)	
	inner join thuoc t on cttt.idthuoc=t.idthuoc 
			and (t.isvtyt=0 OR T.isvtyt is null)
	) thuoc,
	(select sum(cttt.SOLUONGKE*DBO.KB_GetGiathuoc(cttt.IDchitietbenhnhantoathuoc))--sum( cttt.thanhtien)
	from chitietbenhnhantoathuoc cttt
	inner join benhnhantoathuoc tt on tt.idbenhnhantoathuoc=cttt.idbenhnhantoathuoc
	inner join khambenh kb on kb.idkhambenh=tt.idkhambenh
			and kb.iddangkykham=dkk.iddangkykham							
			and (kb.isnoitru=0 or kb.isnoitru is null)
	inner join thuoc t on cttt.idthuoc=t.idthuoc 
			and t.isvtyt=1
	) vtyt,	
	
	(select top 1 GiaBH from KHAMBENH A 
  LEFT JOIN CHITIETDANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
		 AND A.IDPHONGKHAMBENH=DBO.KB_GETIDPHONGKHAMBENH(B.IDCHITIETDANGKYKHAM) 
  LEFT JOIN BANGGIADICHVU C ON B.IDBANGGIADICHVU=C.IDBANGGIADICHVU
	
 where a.iddangkykham=dkk.iddangkykham)
		tienkham
	,null mau,
	null vanchuyen,
	(select sum(dbo.kb_GetTotal_kb( kb.idkhambenh))
	from khambenh kb 
	where kb.iddangkykham=dkk.iddangkykham	and	
			(kb.isnoitru = 0 or kb.isnoitru is null	)
	) bhxhthanhtoan, null thaighep	
	
		
	from dangkykham dkk 
	inner join benhnhan bn on bn.idbenhnhan=dkk.idbenhnhan	
			and bn.loai=1 and  bn.MaDangKy_KCB_bandau is not null	
	where dkk.ngaydangky between @tungay and @denngay
	

	
	
) A

)





