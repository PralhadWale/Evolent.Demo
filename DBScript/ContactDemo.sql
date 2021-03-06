USE [ContactDEMO]
GO
/****** Object:  Table [dbo].[ContactMaster]    Script Date: 11-08-2021 23:11:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactMaster](
	[ContactId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](150) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ContactMaster] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
