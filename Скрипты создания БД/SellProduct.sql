USE [СофтТрейдПлюс]
GO

/****** Object:  Table [dbo].[SellProduct]    Script Date: 17.07.2022 1:37:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SellProduct](
	[id Product] [int] NOT NULL,
	[id Client] [int] NOT NULL,
	[Data Sell] [date] NOT NULL
	
 CONSTRAINT [PK_SellProduct] PRIMARY KEY CLUSTERED 
(
	[id Product] ASC,
	[id Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SellProduct]  WITH CHECK ADD  CONSTRAINT [FK_SellProduct_Client] FOREIGN KEY([id Client])
REFERENCES [dbo].[Client] ([id])
GO

ALTER TABLE [dbo].[SellProduct] CHECK CONSTRAINT [FK_SellProduct_Client]
GO

ALTER TABLE [dbo].[SellProduct]  WITH CHECK ADD  CONSTRAINT [FK_SellProduct_Product] FOREIGN KEY([id Product])
REFERENCES [dbo].[Product] ([id])
GO

ALTER TABLE [dbo].[SellProduct] CHECK CONSTRAINT [FK_SellProduct_Product]
GO


