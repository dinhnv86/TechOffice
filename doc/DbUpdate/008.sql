USE [TechOfficeDev]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NewsCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[MoTa] [ntext] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_NewsCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NewsCategory] ADD  CONSTRAINT [DF_NewsCategory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


