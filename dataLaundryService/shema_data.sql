USE [laundryService]
GO
/****** Object:  Table [dbo].[action]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[clothes]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[customer]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[order]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[orderSub]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[promotion]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[promotionBuy]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[promotionCondition]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
/****** Object:  Table [dbo].[type]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type](
	[TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE_NAME] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 29/4/2018 A.D. 16:42:12 ******/
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
SET IDENTITY_INSERT [dbo].[action] ON 

INSERT [dbo].[action] ([ACTION_ID], [ACTION_DESC], [ACTION_PRICE], [ACTION_REMARK]) VALUES (CAST(1 AS Numeric(18, 0)), N'wash', 10.0000, N'only wash')
INSERT [dbo].[action] ([ACTION_ID], [ACTION_DESC], [ACTION_PRICE], [ACTION_REMARK]) VALUES (CAST(2 AS Numeric(18, 0)), N'iron', 10.0000, N'only iron ')
SET IDENTITY_INSERT [dbo].[action] OFF
SET IDENTITY_INSERT [dbo].[clothes] ON 

INSERT [dbo].[clothes] ([CL_ID], [CL_NAME], [TYPE_ID], [PRICE_ADD]) VALUES (1, N'shrit', 1, N'0.00')
INSERT [dbo].[clothes] ([CL_ID], [CL_NAME], [TYPE_ID], [PRICE_ADD]) VALUES (2, N'pants', 1, N'0.00')
INSERT [dbo].[clothes] ([CL_ID], [CL_NAME], [TYPE_ID], [PRICE_ADD]) VALUES (3, N'shrit-pants', 1, N'0.00')
INSERT [dbo].[clothes] ([CL_ID], [CL_NAME], [TYPE_ID], [PRICE_ADD]) VALUES (4, N'dress', 100, N'10')
SET IDENTITY_INSERT [dbo].[clothes] OFF
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([CUS_ID], [CUS_NAME], [CUS_ADDRESS], [CUS_PHONE]) VALUES (1, N'waan', N'rangsit 2', N'0924874000')
INSERT [dbo].[customer] ([CUS_ID], [CUS_NAME], [CUS_ADDRESS], [CUS_PHONE]) VALUES (2, N'Joe', N'eeeee', N'0813263256')
INSERT [dbo].[customer] ([CUS_ID], [CUS_NAME], [CUS_ADDRESS], [CUS_PHONE]) VALUES (3, N'waan', N'xxxxxxxxxx', N'0813263256')
INSERT [dbo].[customer] ([CUS_ID], [CUS_NAME], [CUS_ADDRESS], [CUS_PHONE]) VALUES (4, N'waan', N'xxxxxxxxxx', N'0813263256')
SET IDENTITY_INSERT [dbo].[customer] OFF
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([ORDER_ID], [ORDER_NO], [ORDER_REGISTER_DATE], [ORDER_COMPETE], [ORDER_EXPIRE], [PROMO_ID]) VALUES (1, N'A20170420-00001
', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[order] ([ORDER_ID], [ORDER_NO], [ORDER_REGISTER_DATE], [ORDER_COMPETE], [ORDER_EXPIRE], [PROMO_ID]) VALUES (2, N'A20170420-00002', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[order] OFF
SET IDENTITY_INSERT [dbo].[orderSub] ON 

INSERT [dbo].[orderSub] ([ORDERSUB_ID], [ORDER_NO], [CL_ID], [ORDERSUB_QTY], [ORDERSUB_PRICE]) VALUES (1, N'A20170420-00001
', 1, 5, NULL)
SET IDENTITY_INSERT [dbo].[orderSub] OFF
SET IDENTITY_INSERT [dbo].[promotion] ON 

INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (1, N'wash100', N'wash100', N'800.00', N'100', N'3')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (2, N'wash-iron50', N'wash-iron50', N'900.00', N'5000', N'3')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (3, N'washwash', N'wash', N'500', N'100', N'1')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (4, N'iron50', N'iron50', N'400', N'50', N'3')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (5, N'dddddddd', N'sasd', N'fcsdv', N'12', N'1')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (7, N'sASs', N'ww', N'wew', N'www', N'ww')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (8, N'zzzzzz', N'ww', N'wew', N'www', N'ww')
INSERT [dbo].[promotion] ([PROMO_ID], [PROMO_NAME], [PROMO_DISCRIPTION], [PROMO_PRICE], [PROMO_QTY], [CL_ID]) VALUES (9, N'dddddddd', N'swqw', N'fcsdv', N'12', N'1')
SET IDENTITY_INSERT [dbo].[promotion] OFF
SET IDENTITY_INSERT [dbo].[promotionBuy] ON 

INSERT [dbo].[promotionBuy] ([PROMOBUY_NO], [PROMO_ID], [CUS_ID], [PROMOBUY_DATE], [TOTAL]) VALUES (1, 1, 1, CAST(N'2017-09-24T00:00:00.000' AS DateTime), 100)
INSERT [dbo].[promotionBuy] ([PROMOBUY_NO], [PROMO_ID], [CUS_ID], [PROMOBUY_DATE], [TOTAL]) VALUES (2, 2, 1, CAST(N'2017-10-20T00:00:00.000' AS DateTime), 50)
SET IDENTITY_INSERT [dbo].[promotionBuy] OFF
SET IDENTITY_INSERT [dbo].[promotionCondition] ON 

INSERT [dbo].[promotionCondition] ([PROMO_CONN_ID], [PROMO_ID], [CUS_ID], [PRO_DATE_BUY], [QTY_ITEM], [BALANCE]) VALUES (5, 1, 1, CAST(N'2017-09-17T00:00:00.000' AS DateTime), 0, 100)
INSERT [dbo].[promotionCondition] ([PROMO_CONN_ID], [PROMO_ID], [CUS_ID], [PRO_DATE_BUY], [QTY_ITEM], [BALANCE]) VALUES (6, 2, 1, CAST(N'2017-09-24T00:00:00.000' AS DateTime), 0, 50)
SET IDENTITY_INSERT [dbo].[promotionCondition] OFF
SET IDENTITY_INSERT [dbo].[type] ON 

INSERT [dbo].[type] ([TYPE_ID], [TYPE_NAME]) VALUES (1, N'clothes')
INSERT [dbo].[type] ([TYPE_ID], [TYPE_NAME]) VALUES (2, N'dresses')
INSERT [dbo].[type] ([TYPE_ID], [TYPE_NAME]) VALUES (3, N'bedding')
INSERT [dbo].[type] ([TYPE_ID], [TYPE_NAME]) VALUES (4, N'suitssss')
INSERT [dbo].[type] ([TYPE_ID], [TYPE_NAME]) VALUES (5, N'dress')
SET IDENTITY_INSERT [dbo].[type] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([USER_ID], [USERNAME], [PASSWORD], [NAME], [EMAIL], [TELEPHONE], [ADDRESS], [ROLE]) VALUES (CAST(1 AS Numeric(18, 0)), N'waan', N'1234', N'waan', N'waan@email.con', N'12345', N'1231', N'ADMINISTRATOR')
SET IDENTITY_INSERT [dbo].[user] OFF
