create FUNCTION [dbo].KB_GetPhongKhambenh (@idbn Int,@ngaybd datetime, @ngaykt datetime)
RETURNS nvarchar(MAX)
AS
BEGIN
	DECLARE @String nVARCHAR(MAX)
	set @String=''
	SELECT distinct  @String = ISNULL(@String , '') + CAST(tenPhongkhambenh AS NVARCHAR(1000)) + ','
	 from khambenhcanlamsan kbcls  left join banggiadichvu bg on			bg.idbanggiadichvu =kbcls.idcanlamsan
	 left join phongkhambenh pkb on bg.idphongkhambenh=pkb.idphongkhambenh
	 where (dbo.kb_getidbenhnhan(idkhambenhcanlamsan)  = @idbn)
	or (kbcls.idkhambenh in (select idkhambenh from khambenh where idbenhnhan = @idbn)) and ngaythu >=@ngaybd and ngaythu<=@ngaykt

if(@String<>'')
 set @String=left(@String,len(@String)-1)
RETURN isnull(@String,'')
	
END



