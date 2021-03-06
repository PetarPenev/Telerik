USE [master]
CREATE DATABASE [MultilingualDictionary]
GO

USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [ntext] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HypernymHyponim]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HypernymHyponim](
	[HypernimId] [int] IDENTITY(1,1) NOT NULL,
	[HyponimId] [int] NOT NULL,
 CONSTRAINT [PK_HypernymHyponim] PRIMARY KEY CLUSTERED 
(
	[HypernimId] ASC,
	[HyponimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordAntonym]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordAntonym](
	[WordId] [int] NOT NULL,
	[AntonymId] [int] NOT NULL,
 CONSTRAINT [PK_WordAntonym] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[AntonymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordExplanation]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordExplanation](
	[WordId] [int] NOT NULL,
	[ExplanationId] [int] NOT NULL,
 CONSTRAINT [PK_WordExplanation] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[PartOfSpeechId] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordSynonim]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordSynonim](
	[WordId] [int] NOT NULL,
	[SynonimId] [int] NOT NULL,
 CONSTRAINT [PK_WordSynonim] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[SynonimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordTranslation]    Script Date: 13.7.2013 г. 15:51:19 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordTranslation](
	[WordId] [int] NOT NULL,
	[TranslationId] [int] NOT NULL,
 CONSTRAINT [PK_WordTranslation] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC,
	[TranslationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[HypernymHyponim]  WITH CHECK ADD  CONSTRAINT [FK_HypernymHyponim_Words] FOREIGN KEY([HypernimId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[HypernymHyponim] CHECK CONSTRAINT [FK_HypernymHyponim_Words]
GO
ALTER TABLE [dbo].[HypernymHyponim]  WITH CHECK ADD  CONSTRAINT [FK_HypernymHyponim_Words1] FOREIGN KEY([HyponimId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[HypernymHyponim] CHECK CONSTRAINT [FK_HypernymHyponim_Words1]
GO
ALTER TABLE [dbo].[WordAntonym]  WITH CHECK ADD  CONSTRAINT [FK_WordAntonym_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordAntonym] CHECK CONSTRAINT [FK_WordAntonym_Words]
GO
ALTER TABLE [dbo].[WordAntonym]  WITH CHECK ADD  CONSTRAINT [FK_WordAntonym_Words1] FOREIGN KEY([AntonymId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordAntonym] CHECK CONSTRAINT [FK_WordAntonym_Words1]
GO
ALTER TABLE [dbo].[WordExplanation]  WITH CHECK ADD  CONSTRAINT [FK_WordExplanation_Explanations] FOREIGN KEY([ExplanationId])
REFERENCES [dbo].[Explanations] ([Id])
GO
ALTER TABLE [dbo].[WordExplanation] CHECK CONSTRAINT [FK_WordExplanation_Explanations]
GO
ALTER TABLE [dbo].[WordExplanation]  WITH CHECK ADD  CONSTRAINT [FK_WordExplanation_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordExplanation] CHECK CONSTRAINT [FK_WordExplanation_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech] FOREIGN KEY([PartOfSpeechId])
REFERENCES [dbo].[PartsOfSpeech] ([Id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech]
GO
ALTER TABLE [dbo].[WordSynonim]  WITH CHECK ADD  CONSTRAINT [FK_WordSynonim_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordSynonim] CHECK CONSTRAINT [FK_WordSynonim_Words]
GO
ALTER TABLE [dbo].[WordSynonim]  WITH CHECK ADD  CONSTRAINT [FK_WordSynonim_Words1] FOREIGN KEY([SynonimId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordSynonim] CHECK CONSTRAINT [FK_WordSynonim_Words1]
GO
ALTER TABLE [dbo].[WordTranslation]  WITH CHECK ADD  CONSTRAINT [FK_WordTranslation_Words3] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordTranslation] CHECK CONSTRAINT [FK_WordTranslation_Words3]
GO
ALTER TABLE [dbo].[WordTranslation]  WITH CHECK ADD  CONSTRAINT [FK_WordTranslation_Words4] FOREIGN KEY([TranslationId])
REFERENCES [dbo].[Words] ([Id])
GO
ALTER TABLE [dbo].[WordTranslation] CHECK CONSTRAINT [FK_WordTranslation_Words4]
GO
