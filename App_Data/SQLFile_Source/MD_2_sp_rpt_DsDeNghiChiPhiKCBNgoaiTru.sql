USE [MinhDuc]
GO
/****** Object:  StoredProcedure [dbo].[sp_rpt_DanhSachChiPhiKCBNgoaiTru]    Script Date: 07/21/2011 13:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<khanhdtn>
-- Create date: <18-07-2011>
-- Description:	<Danh sach de nghi thanh toan kham chua benh ngoai tru theo quy, nam>
-- =============================================
CREATE PROCEDURE [dbo].[sp_rpt_DSDeNghiChiPhiKCBNgoaiTru]
	-- Add the parameters for the stored procedure here
	@tungay smalldatetime,
	@denngay smalldatetime
AS
begin
select * from dbo.func_rpt_DSDeNghiChiPhiKCBNgoaiTru(@tungay,@denngay)
end


