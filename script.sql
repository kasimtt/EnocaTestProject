USE [EnocaTestProjectDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/6/2023 2:58:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 11/6/2023 2:58:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DataState] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[CarrierId] [int] NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrierReport]    Script Date: 11/6/2023 2:58:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierReportDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DataState] [int] NOT NULL,
 CONSTRAINT [PK_CarrierReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 11/6/2023 2:58:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](64) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DataState] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/6/2023 2:58:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DataState] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231104190828_mig1', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231104200635_mig2', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231105125049_mig3', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231106092140_mig4', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231106094111_mig5', N'6.0.16')
GO
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] ON 

INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (1, 12, 5, CAST(12.00 AS Decimal(18, 2)), CAST(N'2005-12-12T00:00:00.0000000' AS DateTime2), 2, CAST(N'2023-11-05T21:50:19.4855958' AS DateTime2), 1)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (2, 25, 10, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-11-05T16:54:04.4705577' AS DateTime2), 2, NULL, 2)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (3, 24, 20, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-11-05T16:55:16.3789202' AS DateTime2), 2, NULL, 3)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (5, 34, 20, CAST(8.00 AS Decimal(18, 2)), CAST(N'2023-11-05T16:55:53.6354884' AS DateTime2), 2, NULL, 4)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (6, 30, 0, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-11-05T16:56:09.5506503' AS DateTime2), 2, NULL, 5)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (8, 12, 0, CAST(12.00 AS Decimal(18, 2)), CAST(N'2023-11-05T17:09:06.5502258' AS DateTime2), 2, NULL, 7)
INSERT [dbo].[CarrierConfigurations] ([Id], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost], [CreatedDate], [DataState], [UpdatedDate], [CarrierId]) VALUES (9, 30, 12, CAST(15.00 AS Decimal(18, 2)), CAST(N'2023-11-05T17:14:37.5590450' AS DateTime2), 1, CAST(N'2023-11-05T21:55:01.9601226' AS DateTime2), 6)
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] OFF
GO
SET IDENTITY_INSERT [dbo].[CarrierReport] ON 

INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (1, 1, CAST(44.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:37.2477576' AS DateTime2), CAST(N'2023-11-06T10:37:53.8901236' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (2, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:45.6910089' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902113' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (3, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:47.4174932' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902116' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (4, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:49.4756159' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902118' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (5, 4, CAST(80.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:51.0136526' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902120' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (6, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:52.3839617' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902123' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (7, 4, CAST(508.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:53.1317928' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902125' AS DateTime2), NULL, 2)
INSERT [dbo].[CarrierReport] ([Id], [CarrierId], [CarrierCost], [CarrierReportDate], [CreatedDate], [UpdatedDate], [DataState]) VALUES (8, 5, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-11-06T13:37:53.4556326' AS DateTime2), CAST(N'2023-11-06T10:37:53.8902127' AS DateTime2), NULL, 2)
SET IDENTITY_INSERT [dbo].[CarrierReport] OFF
GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (1, N'elmakargo', 1, 33, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, CAST(N'2023-11-05T14:33:19.3090622' AS DateTime2))
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (2, N'yeni isim', 1, 10, CAST(N'2000-12-01T00:00:00.0000000' AS DateTime2), 2, CAST(N'2023-11-05T13:59:53.6619962' AS DateTime2))
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (3, N'ellerkargo', 1, 10, CAST(N'2023-11-05T13:10:42.0362031' AS DateTime2), 2, NULL)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (4, N'ptt kargo', 1, 12, CAST(N'2023-11-05T16:23:24.0779200' AS DateTime2), 2, NULL)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (5, N'arog kargo', 1, 14, CAST(N'2023-11-05T16:23:52.9331359' AS DateTime2), 2, NULL)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (6, N'şimsek kargo', 1, 7, CAST(N'2023-11-05T16:24:13.4772420' AS DateTime2), 1, CAST(N'2023-11-05T21:55:01.9600390' AS DateTime2))
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (7, N'utc kargo', 1, 4, CAST(N'2023-11-05T16:24:29.4097386' AS DateTime2), 2, NULL)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (8, N'armut kargo', 1, 43, CAST(N'2023-11-05T16:24:42.8060726' AS DateTime2), 2, NULL)
INSERT [dbo].[Carriers] ([Id], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CreatedDate], [DataState], [UpdatedDate]) VALUES (9, N'oneday kargo', 1, 3, CAST(N'2023-11-05T16:25:49.3732877' AS DateTime2), 2, NULL)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (1, 1, CAST(N'2000-11-11T00:00:00.0000000' AS DateTime2), CAST(44.00 AS Decimal(18, 2)), 1, CAST(N'2000-11-11T00:00:00.0000000' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (2, 20, CAST(N'2023-11-05T17:18:01.3540000' AS DateTime2), CAST(4.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-05T17:19:32.5134314' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (3, 21, CAST(N'2023-11-05T17:23:19.9940000' AS DateTime2), CAST(4.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-05T17:23:36.6598130' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (4, 22, CAST(N'2023-11-05T17:25:48.7600000' AS DateTime2), CAST(4.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-05T17:26:01.1921935' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (5, 40, CAST(N'2023-11-05T17:56:42.8320000' AS DateTime2), CAST(80.00 AS Decimal(18, 2)), 4, CAST(N'2023-11-05T17:57:35.1435972' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (6, 15, CAST(N'2023-11-06T09:22:45.4730000' AS DateTime2), CAST(4.00 AS Decimal(18, 2)), 2, CAST(N'2023-11-06T09:22:53.7352530' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (7, 75, CAST(N'2023-11-06T09:23:04.1120000' AS DateTime2), CAST(500.00 AS Decimal(18, 2)), 4, CAST(N'2023-11-06T09:23:09.7932790' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (8, 32, CAST(N'2023-11-06T09:23:04.1120000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), 4, CAST(N'2023-11-06T09:23:19.9324115' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (9, 8, CAST(N'2023-11-06T09:23:04.1120000' AS DateTime2), CAST(5.00 AS Decimal(18, 2)), 5, CAST(N'2023-11-06T09:23:29.5797497' AS DateTime2), 2, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDesi], [OrderDate], [OrderCarrierCost], [CarrierId], [CreatedDate], [DataState], [UpdatedDate]) VALUES (10, 29, CAST(N'2023-11-06T11:28:36.5160000' AS DateTime2), CAST(5.00 AS Decimal(18, 2)), 5, CAST(N'2023-11-06T11:28:54.8960944' AS DateTime2), 2, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[CarrierConfigurations] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CarrierConfigurations] ADD  DEFAULT ((0)) FOR [DataState]
GO
ALTER TABLE [dbo].[CarrierConfigurations] ADD  DEFAULT ((0)) FOR [CarrierId]
GO
ALTER TABLE [dbo].[Carriers] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Carriers] ADD  DEFAULT ((0)) FOR [DataState]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [DataState]
GO
ALTER TABLE [dbo].[CarrierConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_CarrierConfigurations_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[CarrierConfigurations] CHECK CONSTRAINT [FK_CarrierConfigurations_Carriers_CarrierId]
GO
ALTER TABLE [dbo].[CarrierReport]  WITH CHECK ADD  CONSTRAINT [FK_CarrierReport_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarrierReport] CHECK CONSTRAINT [FK_CarrierReport_Carriers_CarrierId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Carriers_CarrierId]
GO
