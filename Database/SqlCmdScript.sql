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
--INSERT INTO Applicants([Name],[Email],[Address],[PhoneNo]) VALUES('Josh Dillinger','josh903902@gmail.com','P.O. Box 184, 8629 A, Ave','1-509-324-5745'),('Vance','erat.nonummy@Nullaaliquet.co.uk','P.O. Box 281, 3168 Nulla Ave','1-451-284-3449'),('Lee','aliquet.lobortis@Nullamut.com','Ap #259-5713 Erat, Avenue','1-526-114-4025'),('Tanisha','Suspendisse.sagittis@mitempor.ca','Ap #220-3725 Donec St.','1-372-601-6991'),('Prescott','Suspendisse.aliquet@incursus.co.uk','P.O. Box 248, 9885 In Rd.','1-443-179-4456'),('Bruce','lectus@arcu.net','Ap #712-620 Cursus. Av.','1-616-100-8361'),('Justin','mollis.dui.in@pede.co.uk','272-6182 Curabitur Rd.','1-441-243-3710'),('Penelope','inceptos.hymenaeos.Mauris@sedtortor.net','892-2321 Sodales. Rd.','1-553-633-7203'),('Amena','bibendum@sapien.co.uk','Ap #291-7263 Feugiat Ave','1-689-762-4168'),('Zenaida','non@risusodio.ca','Ap #922-9109 Neque Ave','1-735-619-7338');
--INSERT INTO Applicants([Name],[Email],[Address],[PhoneNo]) VALUES('Micah','penatibus@at.edu','P.O. Box 703, 2230 Fringilla Street','1-441-833-0075'),('Vivian','odio.Aliquam@facilisis.com','937-3205 Elit Rd.','1-269-130-6315'),('Hilel','ultricies.sem@egetipsumSuspendisse.net','P.O. Box 730, 377 Ut, Rd.','1-265-435-5162'),('Joelle','adipiscing.lacus@Nullatempor.net','P.O. Box 200, 3623 Ac Ave','1-774-496-4023'),('Doris','malesuada.fringilla@magnaPhasellus.ca','897-3445 Etiam Ave','1-805-501-1838'),('Madeson','amet@Uttinciduntvehicula.com','7307 Ac Rd.','1-334-730-8395'),('Dalton','ullamcorper.viverra.Maecenas@tempus.edu','Ap #250-6679 Semper Ave','1-932-757-7168'),('Melissa','scelerisque.scelerisque.dui@odioEtiamligula.co.uk','389-1352 Tellus. Street','1-772-921-7051'),('Briar','vitae.purus.gravida@Aliquamerat.edu','958-2858 Quisque Ave','1-907-581-9797'),('Brock','et.ultrices.posuere@velvulputate.co.uk','Ap #351-3919 In, St.','1-812-582-0934');