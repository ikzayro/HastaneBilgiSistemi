USE [hastane]
GO
/****** Object:  Table [dbo].[Bolumler]    Script Date: 16.1.2022 22:40:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolumler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Bolum] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bolumler] PRIMARY KEY CLUSTERED 
(
	[Bolum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastalar]    Script Date: 16.1.2022 22:40:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastalar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Bolum] [nvarchar](50) NOT NULL,
	[DoktorAd] [nvarchar](50) NOT NULL,
	[DoktorSoyad] [nvarchar](50) NOT NULL,
	[HastaOykusu] [nvarchar](max) NULL,
	[Teshis] [nvarchar](50) NULL,
	[Tedavi] [nvarchar](50) NULL,
	[Ilaclar] [nvarchar](50) NULL,
	[LaboratuvarTest] [nvarchar](50) NULL,
	[LaboratuvarSonuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hastalar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 16.1.2022 22:40:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Yetki] [nvarchar](50) NOT NULL,
	[Bolum] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolumler] ON 

INSERT [dbo].[Bolumler] ([Id], [Bolum]) VALUES (19, N'Cildiye')
INSERT [dbo].[Bolumler] ([Id], [Bolum]) VALUES (6, N'Kardiyoloji')
INSERT [dbo].[Bolumler] ([Id], [Bolum]) VALUES (20, N'Nöröloji')
INSERT [dbo].[Bolumler] ([Id], [Bolum]) VALUES (21, N'Ortopedi')
SET IDENTITY_INSERT [dbo].[Bolumler] OFF
GO
SET IDENTITY_INSERT [dbo].[Hastalar] ON 

INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (27, N'Abdulmelik', N'Demiralp', N'Kardiyoloji', N'Sabri', N'Güneruz', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (28, N'Abdulmelik', N'Demiralp', N'Ortopedi', N'Necip', N'Yaşit', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (29, N'Bensu', N'Lağarlı', N'Nöröloji', N'Fırat', N'Şahan', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (30, N'Bensu', N'Lağarlı', N'Ortopedi', N'Necip', N'Yaşit', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (31, N'Bensu', N'Lağarlı', N'Kardiyoloji', N'Halis', N'Yarıcı', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Hastalar] ([Id], [Ad], [Soyad], [Bolum], [DoktorAd], [DoktorSoyad], [HastaOykusu], [Teshis], [Tedavi], [Ilaclar], [LaboratuvarTest], [LaboratuvarSonuc]) VALUES (34, N'Ahmet', N'Hakan', N'Nöröloji', N'Aziz', N'Hiçyılmaz', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (25, N'Fikret', N'Çolakoğlu', N'Admin', NULL, N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (27, N'Abdulmelik', N'Demiralp', N'Hasta', NULL, N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (28, N'Bensu', N'Lağarlı', N'Hasta', NULL, N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (29, N'Naciye', N'Gezer', N'Doktor', N'Cildiye', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (30, N'Ümran', N'Sevimli', N'Doktor', N'Cildiye', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (33, N'Halis', N'Yarıcı', N'Doktor', N'Kardiyoloji', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (34, N'Sabri', N'Güneruz', N'Doktor', N'Kardiyoloji', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (35, N'Fırat', N'Şahan', N'Doktor', N'Nöröloji', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (36, N'Aziz', N'Hiçyılmaz', N'Doktor', N'Nöröloji', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (37, N'Lale', N'Güveren', N'Doktor', N'Ortopedi', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (38, N'Necip', N'Yaşit', N'Doktor', N'Ortopedi', N'123')
INSERT [dbo].[Kullanicilar] ([Id], [Ad], [Soyad], [Yetki], [Bolum], [Sifre]) VALUES (39, N'Nur', N'Kocabaş', N'Lab', NULL, N'123')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
