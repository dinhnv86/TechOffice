USE [TechOfficeDev]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PageReference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UrlImage] [nvarchar](255) NOT NULL,
	[UrlLink] [varchar](255) not null,
	[Alt] [nvarchar](255) NULL,
	[IsNewPage] [bit] NOT NULL default 0,
	[IsDeleted] [bit] NOT NULL default 0,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_PageReference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

