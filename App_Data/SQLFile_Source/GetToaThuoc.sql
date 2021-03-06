/*--------------------------/
//TRUONGNHAT-PC
//DATE : 
//DESCRIPTION:LAY TEN TOA THUOC DA DIEU TRI CHO BENH NHAN*/

CREATE FUNCTION [dbo].[GetToaThuoc] (@idbn BigInt)
RETURNS nvarchar(MAX)
AS
BEGIN
	DECLARE @String nVARCHAR(MAX)
	set @String=''
	SELECT  @String = ISNULL(@String , '') + CAST(TENTHUOC AS NVARCHAR(1000)) + ',' FROM THUOC
	LEFT JOIN chitietbenhnhantoathuoc CTTT ON CTTT.IDTHUOC=THUOC.IDTHUOC
	LEFT JOIN benhnhantoathuoc BNTT ON BNTT.IDBENHNHANTOATHUOC=CTTT.IDBENHNHANTOATHUOC
	LEFT JOIN BENHNHAN BN ON BN.IDBENHNHAN=BNTT.IDBENHNHAN
	WHERE BN.IDBENHNHAN=@idbn
RETURN isnull(@String,'')
	
END
