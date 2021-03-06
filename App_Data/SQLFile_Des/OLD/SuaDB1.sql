

CREATE TABLE [dbo].[tinh](
	[tinhid] [int] IDENTITY(1,1) NOT NULL,
	[tinhname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tinh] PRIMARY KEY CLUSTERED 
(
	[tinhid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[quanhuyen](
	[quanhuyenid] [int] IDENTITY(1,1) NOT NULL,
	[tinhid] [int] NULL,
	[quanhuyenname] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_quanhuyen] PRIMARY KEY CLUSTERED 
(
	[quanhuyenid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[quanhuyen]  WITH NOCHECK ADD  CONSTRAINT [FK_quanhuyen_tinh] FOREIGN KEY([tinhid])
REFERENCES [dbo].[tinh] ([tinhid])
GO

ALTER TABLE [dbo].[quanhuyen] CHECK CONSTRAINT [FK_quanhuyen_tinh]
GO


CREATE TABLE [dbo].[phuongxa](
	[phuongxaid] [int] IDENTITY(1,1) NOT NULL,
	[quanhuyenid] [int] NOT NULL,
	[tenphuongxa] [nvarchar](70) NOT NULL
) ON [PRIMARY]

GO


alter table benhnhan
add tinhid int,
	quanhuyenid int,
	phuongxaid int,
	sonha nvarchar(50)

go

if( not exists(select idbanggiadichvu from banggiadichvu where tendichvu=N'Sổ khám bệnh') ) 
insert into banggiadichvu values(N'Sổ khám bệnh',N'Sổ khám bệnh',null,'5000','0','1','0',
null,null,'5000',null,null,'0','11')
