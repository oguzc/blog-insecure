use master;
create database [oguzc.blogposts];
GO
use [oguzc.blogposts];
CREATE TABLE [dbo].[BlogPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPostComments] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPostComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostId] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BlogPostComments] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[BlogPostComments]  WITH CHECK ADD  CONSTRAINT [FK_BlogPostComments_BlogPosts] FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPosts] ([Id])
GO
ALTER TABLE [dbo].[BlogPostComments] CHECK CONSTRAINT [FK_BlogPostComments_BlogPosts]
GO

--data
INSERT INTO BlogPosts([Title],[Content]) VALUES('blog post title 1','blog post content 1'),('blog post title 2','blog post content 2');