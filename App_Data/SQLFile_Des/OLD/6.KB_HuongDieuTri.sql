CREATE TABLE [dbo].[KB_HuongDieuTri](
	[HuongDieuTriId] [bigint] NOT NULL,
	[TenHuongDieuTri] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_KB_HuongDieuTri] PRIMARY KEY CLUSTERED 
(
	[HuongDieuTriId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
