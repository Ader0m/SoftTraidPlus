USE [СофтТрейдПлюс]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 17.07.2022 1:35:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[State] [nvarchar](15) NOT NULL,
	[id Manager] [int] NOT NULL,
	[Entity] [bit] NOT NULL,
	[Contact] [nvarchar](20)
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Manager] FOREIGN KEY([id Manager])
REFERENCES [dbo].[Manager] ([id])
GO

ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Manager]
GO


