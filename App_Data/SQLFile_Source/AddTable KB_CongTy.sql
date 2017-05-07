
CREATE TABLE [dbo].[KB_CongTy](
	[idcongty] [int] IDENTITY(1,1) NOT NULL,
	[macongty] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[tencongty] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_KB_CongTy] PRIMARY KEY CLUSTERED 
(
	[idcongty] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
