USE [laundryService]
GO
/****** Object:  Table [dbo].[action]    Script Date: 29/4/2018 A.D. 15:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[action](
	[ACTION_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ACTION_DESC] [nvarchar](50) NULL,
	[ACTION_PRICE] [money] NULL,
	[ACTION_REMARK] [nvarchar](max) NULL,
 CONSTRAINT [PK_action] PRIMARY KEY CLUSTERED 
(
	[ACTION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clothes]    Script Date: 29/4/2018 A.D. 15:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clothes](
	[CL_ID] [int] IDENTITY(1,1) NOT NULL,
	[CL_NAME] [nvarchar](255) NULL,
	[TYPE_ID] [int] NULL,
	[PRICE_ADD] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[CUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_NAME] [nvarchar](255) NULL,
	[CUS_ADDRESS] [nvarchar](255) NULL,
	[CUS_PHONE] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[ORDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NO] [varchar](50) NOT NULL,
	[ORDER_REGISTER_DATE] [datetime] SPARSE  NULL,
	[ORDER_COMPETE] [datetime] NULL,
	[ORDER_EXPIRE] [datetime] NULL,
	[PROMO_ID] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[ORDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderSub]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderSub](
	[ORDERSUB_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_NO] [nvarchar](50) NULL,
	[CL_ID] [int] NULL,
	[ORDERSUB_QTY] [int] NULL,
	[ORDERSUB_PRICE] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotion]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotion](
	[PROMO_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROMO_NAME] [nvarchar](255) NULL,
	[PROMO_DISCRIPTION] [nvarchar](255) NULL,
	[PROMO_PRICE] [nvarchar](255) NULL,
	[PROMO_QTY] [nvarchar](255) NULL,
	[CL_ID] [nvarchar](255) NULL,
 CONSTRAINT [PK_promotion] PRIMARY KEY CLUSTERED 
(
	[PROMO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotionBuy]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotionBuy](
	[PROMOBUY_NO] [int] IDENTITY(1,1) NOT NULL,
	[PROMO_ID] [int] NULL,
	[CUS_ID] [int] NULL,
	[PROMOBUY_DATE] [datetime] NULL,
	[TOTAL] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotionCondition]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotionCondition](
	[PROMO_CONN_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROMO_ID] [int] NOT NULL,
	[CUS_ID] [int] NULL,
	[PRO_DATE_BUY] [datetime] NULL,
	[QTY_ITEM] [int] NOT NULL,
	[BALANCE] [int] NULL,
 CONSTRAINT [PK_promotionCondition] PRIMARY KEY CLUSTERED 
(
	[PROMO_CONN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type](
	[TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE_NAME] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 29/4/2018 A.D. 15:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[USER_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](250) NULL,
	[NAME] [nvarchar](50) NULL,
	[EMAIL] [text] NULL,
	[TELEPHONE] [text] NULL,
	[ADDRESS] [text] NULL,
	[ROLE] [nvarchar](100) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
