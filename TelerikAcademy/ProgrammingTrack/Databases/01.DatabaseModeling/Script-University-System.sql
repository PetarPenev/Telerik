USE [master]
CREATE DATABASE [UniversityDatabase]
GO

USE [UniversityDatabase]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NULL,
	[ProfessorId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsTitles]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsTitles](
	[ProfessorId] [int] NOT NULL,
	[TitleId] [int] NOT NULL,
 CONSTRAINT [PK_ProfessorsTitles] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[TitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsCourses]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsCourses](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentsCourses] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 10.7.2013 г. 21:48:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [DepartmentId], [ProfessorId]) VALUES (1, N'Cryptography Basics', 4, 1)
INSERT [dbo].[Courses] ([Id], [Name], [DepartmentId], [ProfessorId]) VALUES (2, N'AI Basics', 2, 3)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (1, N'Hydrodynamics', 4)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (2, N'AI', 2)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (3, N'IT Security', 2)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (4, N'Cryptography', 2)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (1, N'Chemistry')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (2, N'Informatics')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (3, N'Economics')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (4, N'Physics')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Professors] ON 

INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [DepartmentId]) VALUES (1, N'Stoil', N'Mitev', 2)
INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [DepartmentId]) VALUES (2, N'Ivan', N'Ivanov', 2)
INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [DepartmentId]) VALUES (3, N'Blagoi', N'Stoyanov', 2)
SET IDENTITY_INSERT [dbo].[Professors] OFF
INSERT [dbo].[ProfessorsTitles] ([ProfessorId], [TitleId]) VALUES (1, 1)
INSERT [dbo].[ProfessorsTitles] ([ProfessorId], [TitleId]) VALUES (1, 2)
INSERT [dbo].[ProfessorsTitles] ([ProfessorId], [TitleId]) VALUES (2, 2)
INSERT [dbo].[ProfessorsTitles] ([ProfessorId], [TitleId]) VALUES (3, 1)
INSERT [dbo].[ProfessorsTitles] ([ProfessorId], [TitleId]) VALUES (3, 4)
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (2, N'Ivan', N'Neshev', 2)
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (3, N'Stoyan ', N'Borislavov', 1)
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (4, N'Bobi', N'Jambazov', 2)
SET IDENTITY_INSERT [dbo].[Students] OFF
INSERT [dbo].[StudentsCourses] ([StudentId], [CourseId]) VALUES (2, 1)
INSERT [dbo].[StudentsCourses] ([StudentId], [CourseId]) VALUES (2, 2)
INSERT [dbo].[StudentsCourses] ([StudentId], [CourseId]) VALUES (3, 2)
INSERT [dbo].[StudentsCourses] ([StudentId], [CourseId]) VALUES (4, 2)
SET IDENTITY_INSERT [dbo].[Titles] ON 

INSERT [dbo].[Titles] ([Id], [TitleName]) VALUES (1, N'PhD')
INSERT [dbo].[Titles] ([Id], [TitleName]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Titles] ([Id], [TitleName]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Titles] ([Id], [TitleName]) VALUES (4, N'Academic')
SET IDENTITY_INSERT [dbo].[Titles] OFF
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Professors]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[ProfessorsTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsTitles_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[ProfessorsTitles] CHECK CONSTRAINT [FK_ProfessorsTitles_Professors]
GO
ALTER TABLE [dbo].[ProfessorsTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsTitles_Titles] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Titles] ([Id])
GO
ALTER TABLE [dbo].[ProfessorsTitles] CHECK CONSTRAINT [FK_ProfessorsTitles_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[StudentsCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsCourses_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[StudentsCourses] CHECK CONSTRAINT [FK_StudentsCourses_Courses]
GO
ALTER TABLE [dbo].[StudentsCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsCourses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[StudentsCourses] CHECK CONSTRAINT [FK_StudentsCourses_Students]
GO
