USE [Question]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CallingId] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Option]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OptionDetails] [nvarchar](max) NULL,
	[QuestionId] [int] NULL,
	[Answer] [bit] NULL,
 CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[ContentId] [int] NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserContent]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ContentId] [int] NULL,
 CONSTRAINT [PK_UserContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserQuestionOption]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQuestionOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OptionId] [int] NULL,
	[UserId] [int] NULL,
	[QuestionId] [int] NULL,
 CONSTRAINT [PK_UserQuestionOption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Userr]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Userr] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Veto]    Script Date: 4.12.2018 20:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Count] [nchar](10) NULL,
	[ContentId] [int] NULL,
 CONSTRAINT [PK_Veto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Option_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Option_Question]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Content] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Content] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Content]
GO
ALTER TABLE [dbo].[UserContent]  WITH CHECK ADD  CONSTRAINT [FK_UserContent_Content] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Content] ([Id])
GO
ALTER TABLE [dbo].[UserContent] CHECK CONSTRAINT [FK_UserContent_Content]
GO
ALTER TABLE [dbo].[UserContent]  WITH CHECK ADD  CONSTRAINT [FK_UserContent_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserContent] CHECK CONSTRAINT [FK_UserContent_Userr]
GO
ALTER TABLE [dbo].[UserQuestionOption]  WITH CHECK ADD  CONSTRAINT [FK_UserQuestionOption_Option] FOREIGN KEY([OptionId])
REFERENCES [dbo].[Option] ([Id])
GO
ALTER TABLE [dbo].[UserQuestionOption] CHECK CONSTRAINT [FK_UserQuestionOption_Option]
GO
ALTER TABLE [dbo].[UserQuestionOption]  WITH CHECK ADD  CONSTRAINT [FK_UserQuestionOption_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[UserQuestionOption] CHECK CONSTRAINT [FK_UserQuestionOption_Question]
GO
ALTER TABLE [dbo].[UserQuestionOption]  WITH CHECK ADD  CONSTRAINT [FK_UserQuestionOption_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserQuestionOption] CHECK CONSTRAINT [FK_UserQuestionOption_Userr]
GO
ALTER TABLE [dbo].[Veto]  WITH CHECK ADD  CONSTRAINT [FK_Veto_Content] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Content] ([Id])
GO
ALTER TABLE [dbo].[Veto] CHECK CONSTRAINT [FK_Veto_Content]
GO
