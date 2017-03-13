USE [TechOfficeDev]
GO

/****** Object:  Table [dbo].[[ThuTuc_CoQuanThucHien]]    Script Date: 3/9/2017 9:13:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ThuTuc_CoQuanThucHien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThuTucId] [int] NOT NULL,
	[CoQuanId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CoQuanThucHien_ThuTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ThuTuc_CoQuanThucHien] ADD  CONSTRAINT [DF_CoQuanLienQuan_ThuTuc_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[ThuTuc_CoQuanThucHien]  WITH CHECK ADD  CONSTRAINT [FK_ThuTuc_CoQuanThucHien_CoQuan] FOREIGN KEY([CoQuanId])
REFERENCES [dbo].[CoQuan] ([Id])
GO

ALTER TABLE [dbo].[ThuTuc_CoQuanThucHien] CHECK CONSTRAINT [FK_ThuTuc_CoQuanThucHien_CoQuan]
GO

ALTER TABLE [dbo].[ThuTuc_CoQuanThucHien]  WITH CHECK ADD  CONSTRAINT [FK_ThuTuc_CoQuanThucHien_ThuTuc] FOREIGN KEY([ThuTucId])
REFERENCES [dbo].[ThuTuc] ([Id])
GO

ALTER TABLE [dbo].[ThuTuc_CoQuanThucHien] CHECK CONSTRAINT [FK_ThuTuc_CoQuanThucHien_ThuTuc]
GO

ALTER TABLE ThuTuc
DROP CONSTRAINT FK_ThuTuc_CoQuan

ALTER TABLE ThuTuc
DROP COLUMN CoQuanThucHienId