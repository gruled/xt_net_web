USE [master]
GO
/****** Object:  Database [Task11UsersAndAwards]    Script Date: 23.02.2020 11:21:15 ******/
CREATE DATABASE [Task11UsersAndAwards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Task11UsersAndAwards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Task11UsersAndAwards.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Task11UsersAndAwards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Task11UsersAndAwards_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Task11UsersAndAwards] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task11UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task11UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task11UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task11UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Task11UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task11UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Task11UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [Task11UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task11UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task11UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task11UsersAndAwards] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task11UsersAndAwards] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Task11UsersAndAwards] SET QUERY_STORE = OFF
GO
USE [Task11UsersAndAwards]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AwardsAndImages]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardsAndImages](
	[awardId] [int] NULL,
	[imageId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[DateOfBirth] [datetime] NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndAwards]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndAwards](
	[userId] [int] NULL,
	[awardId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndImages]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndImages](
	[userId] [int] NULL,
	[imageId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebUser]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](256) NULL,
	[Password] [nvarchar](256) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_WebUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AwardsAndImages]  WITH CHECK ADD  CONSTRAINT [FK_AwardsAndImages_Award] FOREIGN KEY([awardId])
REFERENCES [dbo].[Award] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AwardsAndImages] CHECK CONSTRAINT [FK_AwardsAndImages_Award]
GO
ALTER TABLE [dbo].[AwardsAndImages]  WITH CHECK ADD  CONSTRAINT [FK_AwardsAndImages_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Image] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AwardsAndImages] CHECK CONSTRAINT [FK_AwardsAndImages_Image]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_Award] FOREIGN KEY([awardId])
REFERENCES [dbo].[Award] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_Award]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_User] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_User]
GO
ALTER TABLE [dbo].[UsersAndImages]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndImages_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Image] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndImages] CHECK CONSTRAINT [FK_UsersAndImages_Image]
GO
ALTER TABLE [dbo].[UsersAndImages]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndImages_User] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndImages] CHECK CONSTRAINT [FK_UsersAndImages_User]
GO
ALTER TABLE [dbo].[WebUser]  WITH CHECK ADD  CONSTRAINT [FK_WebUser_Role] FOREIGN KEY([Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[WebUser] CHECK CONSTRAINT [FK_WebUser_Role]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use Task11UsersAndAwards;
--INSERT INTO Users (Name, Age, DateOfBirth)
--VALUES('dima', 22, '1997.04.06')

--CREATE PROCEDURE AddUser
--	@Name NVARCHAR(256),
--	@DateOfBirth DATETIME,
--	@Age INT,
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Users (Name, Age, DateOfBirth)
--	VALUES(@Name, @Age, @DateOfBirth)
--	SET @id = @@IDENTITY
--END;
CREATE PROCEDURE [dbo].[AddAward]
	@Title NVARCHAR(256),
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO Award (Title)
	VALUES(@Title)
	SET @id = @@IDENTITY
END;
GO
/****** Object:  StoredProcedure [dbo].[AddAwardsAndImagesLink]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddAwardsAndImagesLink]
	@AwardId INT,
	@ImageId INT
as
begin
	insert into AwardsAndImages(awardId, imageId)
	values(@AwardId, @ImageId)
end
GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use Task11UsersAndAwards;
--INSERT INTO Users (Name, Age, DateOfBirth)
--VALUES('dima', 22, '1997.04.06')

--CREATE PROCEDURE AddUser
--	@Name NVARCHAR(256),
--	@DateOfBirth DATETIME,
--	@Age INT,
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Users (Name, Age, DateOfBirth)
--	VALUES(@Name, @Age, @DateOfBirth)
--	SET @id = @@IDENTITY
--END;

--CREATE PROCEDURE AddAward
--	@Title NVARCHAR(256),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Award (Title)
--	VALUES(@Title)
--	SET @id = @@IDENTITY
--END;

--USE Task11UsersAndAwards;
--DECLARE @id INT
--EXEC AddAward 'Medal of honor', @id OUTPUT
--PRINT @id

CREATE PROCEDURE [dbo].[AddImage]
	@Value VARBINARY(MAX),
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO Image (Value)
	VALUES(@Value)
	SET @id = @@IDENTITY
END;
GO
/****** Object:  StoredProcedure [dbo].[AddRole]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use Task11UsersAndAwards;
--INSERT INTO Users (Name, Age, DateOfBirth)
--VALUES('dima', 22, '1997.04.06')

--CREATE PROCEDURE AddUser
--	@Name NVARCHAR(256),
--	@DateOfBirth DATETIME,
--	@Age INT,
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Users (Name, Age, DateOfBirth)
--	VALUES(@Name, @Age, @DateOfBirth)
--	SET @id = @@IDENTITY
--END;

--CREATE PROCEDURE AddAward
--	@Title NVARCHAR(256),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Award (Title)
--	VALUES(@Title)
--	SET @id = @@IDENTITY
--END;

--USE Task11UsersAndAwards;
--DECLARE @id INT
--EXEC AddAward 'Medal of honor', @id OUTPUT
--PRINT @id

--CREATE PROCEDURE AddImage
--	@Value VARBINARY(MAX),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Image (Value)
--	VALUES(@Value)
--	SET @id = @@IDENTITY
--END;

CREATE PROCEDURE [dbo].[AddRole]
	@Title NVARCHAR(256),
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO Role(Title)
	VALUES(@Title)
	SET @id = @@IDENTITY
END;
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use Task11UsersAndAwards;
--INSERT INTO Users (Name, Age, DateOfBirth)
--VALUES('dima', 22, '1997.04.06')

CREATE PROCEDURE [dbo].[AddUser]
	@Name NVARCHAR(256),
	@DateOfBirth DATETIME,
	@Age INT,
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO Users (Name, Age, DateOfBirth)
	VALUES(@Name, @Age, @DateOfBirth)
	SET @id = @@IDENTITY
END;
GO
/****** Object:  StoredProcedure [dbo].[AddUsersAndAwardsLink]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddUsersAndAwardsLink]
	@UserId INT,
	@AwardId INT
as
begin
	insert into UsersAndAwards(userId, awardId)
	values(@UserId, @AwardId)
end
GO
/****** Object:  StoredProcedure [dbo].[AddUsersAndImagesLink]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddUsersAndImagesLink]
	@UserId INT,
	@ImageId INT
as
begin
	insert into UsersAndImages(userId, imageId)
	values(@UserId, @ImageId)
end
GO
/****** Object:  StoredProcedure [dbo].[AddWebUser]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use Task11UsersAndAwards;
--INSERT INTO Users (Name, Age, DateOfBirth)
--VALUES('dima', 22, '1997.04.06')

--CREATE PROCEDURE AddUser
--	@Name NVARCHAR(256),
--	@DateOfBirth DATETIME,
--	@Age INT,
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Users (Name, Age, DateOfBirth)
--	VALUES(@Name, @Age, @DateOfBirth)
--	SET @id = @@IDENTITY
--END;

--CREATE PROCEDURE AddAward
--	@Title NVARCHAR(256),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Award (Title)
--	VALUES(@Title)
--	SET @id = @@IDENTITY
--END;

--USE Task11UsersAndAwards;
--DECLARE @id INT
--EXEC AddAward 'Medal of honor', @id OUTPUT
--PRINT @id

--CREATE PROCEDURE AddImage
--	@Value VARBINARY(MAX),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Image (Value)
--	VALUES(@Value)
--	SET @id = @@IDENTITY
--END;

--CREATE PROCEDURE AddRole
--	@Title NVARCHAR(256),
--	@id INT OUTPUT
--AS
--BEGIN
--	INSERT INTO Role(Title)
--	VALUES(@Title)
--	SET @id = @@IDENTITY
--END;

CREATE PROCEDURE [dbo].[AddWebUser]
	@Login NVARCHAR(256),
	@Password NVARCHAR(256),
	@Role INT,
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO WebUser(Login, Password, Role)
	VALUES(@Login, @Password, @Role)
	SET @id = @@IDENTITY
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAwardById]
	@AwardId INT
as
begin
delete Award where Award.Id=@AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardsAndImagesLinkByAwardId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAwardsAndImagesLinkByAwardId]
	@AwardId INT
as
begin
	delete AwardsAndImages where AwardsAndImages.awardId = @AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardsAndImagesLinkByAwardIdAndImageId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAwardsAndImagesLinkByAwardIdAndImageId]
	@AwardId INT,
	@ImageId INT
as
begin
	delete AwardsAndImages where AwardsAndImages.awardId = @AwardId and AwardsAndImages.imageId = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardsAndImagesLinkByImageId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAwardsAndImagesLinkByImageId]
	@ImageId INT
as
begin
	delete AwardsAndImages where AwardsAndImages.imageId = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteImageById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteImageById]
	@ImageId INT
as
begin
	delete Image where Image.Id = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteRoleById]
	@RoleId INT
as
begin
	delete Role where Role.Id = @RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUserById]
	@UserId INT
as
begin
	delete Users where Users.Id = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndAwardsLinkByAwardId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndAwardsLinkByAwardId]
	@AwardId INT
as
begin
	delete UsersAndAwards where UsersAndAwards.awardId = @AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndAwardsLinkByUserId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndAwardsLinkByUserId]
	@UserId INT
as
begin
	delete UsersAndAwards where UsersAndAwards.userId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndAwardsLinkByUserIdAndAwardId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndAwardsLinkByUserIdAndAwardId]
	@UserId INT,
	@AwardId INT
as
begin
	delete UsersAndAwards where UsersAndAwards.userId = @UserId and UsersAndAwards.awardId = @AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndImagesLinkByImageId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndImagesLinkByImageId]
	@ImageId INT
as
begin
	delete UsersAndImages where UsersAndImages.imageId = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndImagesLinkByUserId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndImagesLinkByUserId]
	@UserId INT
as
begin
	delete UsersAndImages where UsersAndImages.userId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAndImagesLinkByUserIdAndImageId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUsersAndImagesLinkByUserIdAndImageId]
	@UserId INT,
	@ImageId INT
as
begin
	delete UsersAndImages where UsersAndImages.userId = @UserId and UsersAndImages.imageId = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteWebUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

--CREATE PROCEDURE GetAllWebUsers
--AS
--BEGIN
--	SELECT * FROM WebUser
--END

CREATE PROCEDURE [dbo].[DeleteWebUserById]
	@WebUserId INT
as
BEGIN
	delete WebUser where WebUser.Id=@WebUserId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

--CREATE PROCEDURE GetAllWebUsers
--AS
--BEGIN
--	SELECT * FROM WebUser
--END

--CREATE PROCEDURE DeleteWebUserById
--	@WebUserId INT
--as
--BEGIN
--	delete WebUser where WebUser.Id=@WebUserId
--END
--create procedure UpdateWebUserById
--	@WebUserId INT,
--	@WebUserLogin NVARCHAR(256),
--	@WebUserPassword NVARCHAR(256),
--	@WebUserRole INT
--as
--begin
--	update WebUser
--	set WebUser.Login = @WebUserLogin, WebUser.Password = @WebUserPassword, WebUser.Role = @WebUserRole
--	where WebUser.Id=@WebUserId
--end

--create procedure DeleteAwardById
--	@AwardId INT
--as
--begin
--delete Award where Award.Id=@AwardId
--end

create procedure [dbo].[GetAllAwards]
as
begin
	select * from Award
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwardsAndImagesLinks]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllAwardsAndImagesLinks]
as
begin
	select * from AwardsAndImages
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllImages]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllImages]
as
begin
	select * from Image
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllRoles]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllRoles]
as
begin
	select * from Role
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT * FROM Users
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsersAndAwardsLinks]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllUsersAndAwardsLinks]
as
begin
	select * from UsersAndAwards
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsersAndImagesLinks]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllUsersAndImagesLinks]
as
begin
	select * from UsersAndImages
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllWebUsers]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

CREATE PROCEDURE [dbo].[GetAllWebUsers]
AS
BEGIN
	SELECT * FROM WebUser
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

--CREATE PROCEDURE GetAllWebUsers
--AS
--BEGIN
--	SELECT * FROM WebUser
--END

--CREATE PROCEDURE DeleteWebUserById
--	@WebUserId INT
--as
--BEGIN
--	delete WebUser where WebUser.Id=@WebUserId
--END
--create procedure UpdateWebUserById
--	@WebUserId INT,
--	@WebUserLogin NVARCHAR(256),
--	@WebUserPassword NVARCHAR(256),
--	@WebUserRole INT
--as
--begin
--	update WebUser
--	set WebUser.Login = @WebUserLogin, WebUser.Password = @WebUserPassword, WebUser.Role = @WebUserRole
--	where WebUser.Id=@WebUserId
--end

--create procedure DeleteAwardById
--	@AwardId INT
--as
--begin
--delete Award where Award.Id=@AwardId
--end

--create procedure GetAllAwards
--as
--begin
--	select * from Award
--end

create procedure [dbo].[GetAwardById]
	@AwardId INT
as
begin
select * from Award where Award.Id = @AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[GetImageById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetImageById]
	@ImageId INT
as
begin
	select * from Image where Image.Id = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[GetRoleById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetRoleById]
	@RoleId INT
as
begin
	select * from Role where Role.Id = @RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[GetRoleByWebUserId]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoleByWebUserId]
	@WebUserId INT,
	@Role INT OUTPUT
AS
BEGIN
	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUserById]
	@UserId INT
as
begin
	select * from Users where Users.Id = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[GetWebUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

CREATE PROCEDURE [dbo].[GetWebUserById]
	@WebUserId INT
AS
BEGIN
	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAwardById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

--CREATE PROCEDURE GetAllWebUsers
--AS
--BEGIN
--	SELECT * FROM WebUser
--END

--CREATE PROCEDURE DeleteWebUserById
--	@WebUserId INT
--as
--BEGIN
--	delete WebUser where WebUser.Id=@WebUserId
--END
--create procedure UpdateWebUserById
--	@WebUserId INT,
--	@WebUserLogin NVARCHAR(256),
--	@WebUserPassword NVARCHAR(256),
--	@WebUserRole INT
--as
--begin
--	update WebUser
--	set WebUser.Login = @WebUserLogin, WebUser.Password = @WebUserPassword, WebUser.Role = @WebUserRole
--	where WebUser.Id=@WebUserId
--end

--create procedure DeleteAwardById
--	@AwardId INT
--as
--begin
--delete Award where Award.Id=@AwardId
--end

--create procedure GetAllAwards
--as
--begin
--	select * from Award
--end

--create procedure GetAwardById
--	@AwardId INT
--as
--begin
--select * from Award where Award.Id = @AwardId
--end

create procedure [dbo].[UpdateAwardById]
	@AwardId INT,
	@AwardTitle NVARCHAR(256)
as
begin
	update Award 
	set Award.Title = @AwardTitle 
	where Award.Id = @AwardId
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateImageById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateImageById]
	@ImageId INT,
	@ImageValue VARBINARY(MAX)
as
begin
	update image
	set Image.Value = @ImageValue
	where Image.Id = @ImageId
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateRoleById]
	@RoleId INT,
	@RoleTitle NVARCHAR(256)
as
begin
	update Role
	set Role.Title = @RoleTitle
	where Role.Id = @RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateUserById]
	@UserId INT,
	@UserName NVARCHAR(256),
	@UserDateOfBirth DATETIME,
	@UserAge INT
as
begin
	update Users
	set Users.Name = @UserName, Users.DateOfBirth = @UserDateOfBirth, Users.Age = @UserAge
	where Users.Id = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateWebUserById]    Script Date: 23.02.2020 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE GetRoleByWebUserId
--	@WebUserId INT,
--	@Role INT OUTPUT
--AS
--BEGIN
--	SET @Role=(SELECT WebUser.Role from WebUser WHERE WebUser.Id=@WebUserId);
--END

--CREATE PROCEDURE GetWebUserById
--	@WebUserId INT
--AS
--BEGIN
--	SELECT * FROM WebUser WHERE WebUser.Id=@WebUserId
--END

--CREATE PROCEDURE GetAllWebUsers
--AS
--BEGIN
--	SELECT * FROM WebUser
--END

--CREATE PROCEDURE DeleteWebUserById
--	@WebUserId INT
--as
--BEGIN
--	delete WebUser where WebUser.Id=@WebUserId
--END
create procedure [dbo].[UpdateWebUserById]
	@WebUserId INT,
	@WebUserLogin NVARCHAR(256),
	@WebUserPassword NVARCHAR(256),
	@WebUserRole INT
as
begin
	update WebUser
	set WebUser.Login = @WebUserLogin, WebUser.Password = @WebUserPassword, WebUser.Role = @WebUserRole
	where WebUser.Id=@WebUserId
end
GO
USE [master]
GO
ALTER DATABASE [Task11UsersAndAwards] SET  READ_WRITE 
GO
