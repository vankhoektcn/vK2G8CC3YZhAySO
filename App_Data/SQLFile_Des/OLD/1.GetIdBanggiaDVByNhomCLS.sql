ALTER FUNCTION [dbo].[GetIdBanggiaDVByNhomCLS] (@idnhom Int)
RETURNS nvarchar(MAX)
AS
BEGIN
DECLARE @String nVARCHAR(MAX)
SELECT @String = ISNULL(@String , '') + CAST(idbangiadichvu AS NVARCHAR(100)) + ','
 from KB_ChitietNhomCLS nhomCLS  where status ='True' and nhomID=@idnhom
RETURN isnull(@String,0)
END
