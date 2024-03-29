
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adres](
	[KodPocztowy] [varchar](6) NULL,
	[Miasto] [varchar](50) NULL,
	[AdresObiektu] [varchar](100) NULL,
	[Kraj] [varchar](50) NULL,
	[AdresID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Adres] PRIMARY KEY CLUSTERED 
(
	[AdresID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klient](
	[KlientID] [int] IDENTITY(1,1) NOT NULL,
	[UzytkownikID] [int] NULL,
 CONSTRAINT [PK_Klient] PRIMARY KEY CLUSTERED 
(
	[KlientID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ksiegowa](
	[KsiegowaID] [int] IDENTITY(1,1) NOT NULL,
	[PlatnoscID] [int] NULL,
	[UzytkownikID] [int] NULL,
 CONSTRAINT [PK_Ksiegowa] PRIMARY KEY CLUSTERED 
(
	[KsiegowaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Miejsce](
	[TypKrainyGeograficznej] [varchar](50) NULL,
	[NazwaKrainyGeograficznej] [varchar](50) NULL,
	[MiejsceID] [int] IDENTITY(1,1) NOT NULL,
	[AdresID] [int] NULL,
 CONSTRAINT [PK_Miejsce] PRIMARY KEY CLUSTERED 
(
	[MiejsceID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obiektdowynajecia](
	[NazwaObiektu] [varchar](50) NULL,
	[CenaZaDobe] [numeric](18, 2) NULL,
	[ObiektdowynajeciaID] [int] IDENTITY(1,1) NOT NULL,
	[MiejsceID] [int] NULL,
	[WlascicielObiektuID] [int] NULL,
	[UdogodnieniaID] [int] NULL,
	[Metraz] [numeric](18, 2) NULL,
	[IloscMiejsc] [int] NULL,
	[Adres] [varchar](100) NULL,
	[KodPocztowy] [varchar](8) NULL,
	[Kraj] [varchar](25) NULL,
 CONSTRAINT [PK_Obiektdowynajecia] PRIMARY KEY CLUSTERED 
(
	[ObiektdowynajeciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oferta](
	[OfertaID] [int] IDENTITY(1,1) NOT NULL,
	[ObiektdowynajeciaID] [int] NULL,
	[WlascicielObiektuID] [int] NULL,
 CONSTRAINT [PK_Oferta] PRIMARY KEY CLUSTERED 
(
	[OfertaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platnosc](
	[SposobPlatnosci] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[PlatnoscID] [int] IDENTITY(1,1) NOT NULL,
	[KlientID] [int] NULL,
	[PracownikBokID] [int] NULL,
	[RezerwacjaID] [int] NULL,
 CONSTRAINT [PK_Platnosc] PRIMARY KEY CLUSTERED 
(
	[PlatnoscID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracownikBok](
	[PracownikBokID] [int] IDENTITY(1,1) NOT NULL,
	[RezerwacjaID] [int] NULL,
	[UzytkownikID] [int] NULL,
 CONSTRAINT [PK_PracownikBok] PRIMARY KEY CLUSTERED 
(
	[PracownikBokID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reklama](
	[NazwaReklamy] [varchar](100) NULL,
	[OpisReklamy] [varchar](300) NULL,
	[ReklamaID] [int] IDENTITY(1,1) NOT NULL,
	[WlascicielObiektuID] [int] NULL,
 CONSTRAINT [PK_Reklama] PRIMARY KEY CLUSTERED 
(
	[ReklamaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezerwacja](
	[CenaRezerwacji] [numeric](18, 2) NULL,
	[Przyjazd] [date] NULL,
	[Wyjazd] [date] NULL,
	[RezerwacjaID] [int] IDENTITY(1,1) NOT NULL,
	[KlientID] [int] NULL,
	[OfertaID] [int] NULL,
 CONSTRAINT [PK_Rezerwacja] PRIMARY KEY CLUSTERED 
(
	[RezerwacjaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Udogodnienia](
	[UdogodnieniaID] [int] IDENTITY(1,1) NOT NULL,
	[Udogodnienia_2ID] [int] NULL,
	[ObiektID] [int] NULL,
 CONSTRAINT [PK_Udogodnienia] PRIMARY KEY CLUSTERED 
(
	[UdogodnieniaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Udogodnienia_2](
	[Nazwa] [varchar](50) NULL,
	[Udogodnienia_2ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Udogodnienia_2] PRIMARY KEY CLUSTERED 
(
	[Udogodnienia_2ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uzytkownik](
	[Imie] [varchar](50) NULL,
	[Nazwisko] [varchar](50) NULL,
	[NrTelefonu] [numeric](12, 0) NULL,
	[E-mail] [varchar](50) NULL,
	[Haslo] [varchar](100) NULL,
	[UzytkownikID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Uzytkownik] PRIMARY KEY CLUSTERED 
(
	[UzytkownikID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WlascicielObiektu](
	[WlascicielObiektuID] [int] IDENTITY(1,1) NOT NULL,
	[UzytkownikID] [int] NULL,
 CONSTRAINT [PK_WlascicielObiektu] PRIMARY KEY CLUSTERED 
(
	[WlascicielObiektuID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Klient]  WITH CHECK ADD  CONSTRAINT [FK_Klient_Uzytkownik] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Klient] CHECK CONSTRAINT [FK_Klient_Uzytkownik]
GO
ALTER TABLE [dbo].[Ksiegowa]  WITH CHECK ADD  CONSTRAINT [FK_Ksiegowa_ma dostęp do wszystkich...] FOREIGN KEY([PlatnoscID])
REFERENCES [dbo].[Platnosc] ([PlatnoscID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ksiegowa] CHECK CONSTRAINT [FK_Ksiegowa_ma dostęp do wszystkich...]
GO
ALTER TABLE [dbo].[Ksiegowa]  WITH CHECK ADD  CONSTRAINT [FK_Ksiegowa_Uzytkownik] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ksiegowa] CHECK CONSTRAINT [FK_Ksiegowa_Uzytkownik]
GO
ALTER TABLE [dbo].[Miejsce]  WITH CHECK ADD  CONSTRAINT [FK_Miejsce_Adres] FOREIGN KEY([AdresID])
REFERENCES [dbo].[Adres] ([AdresID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Miejsce] CHECK CONSTRAINT [FK_Miejsce_Adres]
GO
ALTER TABLE [dbo].[Obiektdowynajecia]  WITH CHECK ADD  CONSTRAINT [FK_ObiektDoWynajecia_jakie połozenie obiektu...] FOREIGN KEY([MiejsceID])
REFERENCES [dbo].[Miejsce] ([MiejsceID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Obiektdowynajecia] CHECK CONSTRAINT [FK_ObiektDoWynajecia_jakie połozenie obiektu...]
GO
ALTER TABLE [dbo].[Obiektdowynajecia]  WITH CHECK ADD  CONSTRAINT [FK_ObiektDoWynajecia_jakie posiada obiekt...] FOREIGN KEY([UdogodnieniaID])
REFERENCES [dbo].[Udogodnienia] ([UdogodnieniaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Obiektdowynajecia] CHECK CONSTRAINT [FK_ObiektDoWynajecia_jakie posiada obiekt...]
GO
ALTER TABLE [dbo].[Obiektdowynajecia]  WITH CHECK ADD  CONSTRAINT [FK_ObiektDoWynajecia_jest właścicielem...] FOREIGN KEY([WlascicielObiektuID])
REFERENCES [dbo].[WlascicielObiektu] ([WlascicielObiektuID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Obiektdowynajecia] CHECK CONSTRAINT [FK_ObiektDoWynajecia_jest właścicielem...]
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD  CONSTRAINT [FK_Oferta_która dotyczy] FOREIGN KEY([ObiektdowynajeciaID])
REFERENCES [dbo].[Obiektdowynajecia] ([ObiektdowynajeciaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Oferta] CHECK CONSTRAINT [FK_Oferta_która dotyczy]
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD  CONSTRAINT [FK_Oferta_wystawił ofertę...] FOREIGN KEY([WlascicielObiektuID])
REFERENCES [dbo].[WlascicielObiektu] ([WlascicielObiektuID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Oferta] CHECK CONSTRAINT [FK_Oferta_wystawił ofertę...]
GO
ALTER TABLE [dbo].[Platnosc]  WITH CHECK ADD  CONSTRAINT [FK_Platnosc_dotyczy..] FOREIGN KEY([KlientID])
REFERENCES [dbo].[Klient] ([KlientID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Platnosc] CHECK CONSTRAINT [FK_Platnosc_dotyczy..]
GO
ALTER TABLE [dbo].[Platnosc]  WITH CHECK ADD  CONSTRAINT [FK_Platnosc_ma dostęp do wszystkich...] FOREIGN KEY([PracownikBokID])
REFERENCES [dbo].[PracownikBok] ([PracownikBokID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Platnosc] CHECK CONSTRAINT [FK_Platnosc_ma dostęp do wszystkich...]
GO
ALTER TABLE [dbo].[Platnosc]  WITH CHECK ADD  CONSTRAINT [FK_Platnosc_Rezerwacja] FOREIGN KEY([RezerwacjaID])
REFERENCES [dbo].[Rezerwacja] ([RezerwacjaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Platnosc] CHECK CONSTRAINT [FK_Platnosc_Rezerwacja]
GO
ALTER TABLE [dbo].[PracownikBok]  WITH CHECK ADD  CONSTRAINT [FK_Pracownik BOK_posiada dostęp do wszystkich...] FOREIGN KEY([RezerwacjaID])
REFERENCES [dbo].[Rezerwacja] ([RezerwacjaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PracownikBok] CHECK CONSTRAINT [FK_Pracownik BOK_posiada dostęp do wszystkich...]
GO
ALTER TABLE [dbo].[PracownikBok]  WITH CHECK ADD  CONSTRAINT [FK_PracownikBok_Uzytkownik] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PracownikBok] CHECK CONSTRAINT [FK_PracownikBok_Uzytkownik]
GO
ALTER TABLE [dbo].[Reklama]  WITH CHECK ADD  CONSTRAINT [FK_Reklama_chce rozpowszechnic oferte...] FOREIGN KEY([WlascicielObiektuID])
REFERENCES [dbo].[WlascicielObiektu] ([WlascicielObiektuID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Reklama] CHECK CONSTRAINT [FK_Reklama_chce rozpowszechnic oferte...]
GO
ALTER TABLE [dbo].[Rezerwacja]  WITH CHECK ADD  CONSTRAINT [FK_Rezerwacja_dokonuje...] FOREIGN KEY([KlientID])
REFERENCES [dbo].[Klient] ([KlientID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Rezerwacja] CHECK CONSTRAINT [FK_Rezerwacja_dokonuje...]
GO
ALTER TABLE [dbo].[Rezerwacja]  WITH CHECK ADD  CONSTRAINT [FK_Rezerwacja_stanowi rezerwacje...] FOREIGN KEY([OfertaID])
REFERENCES [dbo].[Oferta] ([OfertaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Rezerwacja] CHECK CONSTRAINT [FK_Rezerwacja_stanowi rezerwacje...]
GO
ALTER TABLE [dbo].[Udogodnienia]  WITH CHECK ADD  CONSTRAINT [FK_Udogodnienia_Udogodnienia_2] FOREIGN KEY([Udogodnienia_2ID])
REFERENCES [dbo].[Udogodnienia_2] ([Udogodnienia_2ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Udogodnienia] CHECK CONSTRAINT [FK_Udogodnienia_Udogodnienia_2]
GO
ALTER TABLE [dbo].[WlascicielObiektu]  WITH CHECK ADD  CONSTRAINT [FK_WlascicielObiektu_Uzytkownik] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[WlascicielObiektu] CHECK CONSTRAINT [FK_WlascicielObiektu_Uzytkownik]
GO
