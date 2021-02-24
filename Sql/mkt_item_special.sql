USE [Pdahub]
GO

/****** Object:  Table [dbo].[mkt_item_special]    Script Date: 24/02/2021 12:35:45 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mkt_item_special](
	[barcode] [char](20) NOT NULL,
	[Notes] [nvarchar](50) NULL,
 CONSTRAINT [PK_mkt_item_spical] PRIMARY KEY CLUSTERED 
(
	[barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,
OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


