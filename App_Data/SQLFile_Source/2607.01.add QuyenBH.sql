CREATE TABLE [dbo].[KB_QuyenBH](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaQuyen] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenQuyen] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_KB_QuyenBH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'1',N'1',N'Nhóm I(mã thẻ DN, HX, CH, NN, TK, HC, XK, CA, TN,HD)')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'2',N'2',N'Nhóm II(mã thẻ HT, TB, MS, XB, XN, CC, CK, CB, KC,BT, TC, TQ, TA, TY, HG, NO)')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'3',N'3',N'Nhóm III(mã thẻ HN, CN)')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'4',N'4',N'Nhóm IV')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'5',N'5',N'Nhóm V(ma thẻ LS,HS)')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'6',N'6',N'Nhóm VI(mã thẻ GD, TL, XV)')
 INSERT INTO KB_QuyenBH(ID,MaQuyen,TenQuyen) VALUES(N'7',N'7',N'Nhóm VII')
