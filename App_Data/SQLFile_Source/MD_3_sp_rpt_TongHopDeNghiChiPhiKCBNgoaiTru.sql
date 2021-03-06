USE [MinhDuc]
GO
/****** Object:  StoredProcedure [dbo].[sp_rpt_TongHopChiPhiKCBNgoaiTru]    Script Date: 07/21/2011 13:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<khanhdtn>
-- Create date: <18-07-2011>
-- Description:	<Danh sach de nghi thanh toan kham chua benh ngoai tru theo quy, nam>
-- =============================================
CREATE PROCEDURE [dbo].[sp_rpt_TongHopDeNghiChiPhiKCBNgoaiTru]
	-- Add the parameters for the stored procedure here
	@tungay smalldatetime,
	@denngay smalldatetime
AS
begin

select loaibenhnhan,dungtuyen, count(*) soluot, sum(xetnghiem) xetnghiem,
sum(cdha) cdha, sum(thuoc) thuoc, sum (mau) mau, sum(thuthuatphauthuat) thuthuatphauthuat,
sum (vtyt) vtyt, sum(dvktc) dvktc, sum(tienkham) tienkham, sum (vanchuyen) vanchuyen,
 sum (tongcong) tongcong, sum(benhnhancungtra) benhnhancungtra, sum(bhxhthanhtoan) bhxhthanhtoan, sum (chiphingoaids) chiphingoaids
from dbo.func_rpt_DSDeNghiChiPhiKCBNgoaiTru(@tungay, @denngay) 
group by loaibenhnhan, dungtuyen

end



