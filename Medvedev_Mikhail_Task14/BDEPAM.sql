USE master
IF (db_id(N'UserAndAwards')) IS NOT NULL	
	DROP DATABASE UserAndAwards

CREATE DATABASE UserAndAwards
GO

USE UserAndAwards
CREATE TABLE Users(
[Id] int not null primary key identity(1,1),
[Name] nvarchar(150),
[Surname] nvarchar(150),
[Birthdate] datetime2)

INSERT INTO Users
VALUES(N'Arnold', N'Layne','1980-10-02')
INSERT INTO Users
VALUES(N'Artem',N'Durakov', '1988-12-12')
INSERT INTO Users
VALUES(N'Lena', N'Shmidt', '1977-02-12')


CREATE TABLE Awards(
[Id] int not null primary key identity(1,1),
[Title] nvarchar(150),
[Description] nvarchar(150) )

INSERT INTO Awards
VALUES(N'nobel prize', N'epic award')
INSERT INTO Awards
VALUES(N'another prize', N'common award')

CREATE TABLE Relations(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,
	[AwardId] INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
	FOREIGN KEY (AwardId) REFERENCES Awards(Id) ON DELETE CASCADE,
	)

INSERT INTO Relations
VALUES(1, 1), (1,2),(2,2)
GO

CREATE PROCEDURE AddAward(                    /*ADD AWARD*/
	@name nvarchar(150),
	@description nvarchar(150))
AS
BEGIN
	DECLARE @insertedAwards TABLE (AwardId int)
	INSERT INTO [Awards]([Title], [Description])
	OUTPUT inserted.Id INTO @insertedAwards(AwardId)
	VALUES(@name, @description)
	RETURN SELECT AwardId FROM @insertedAwards

	/*DECLARE @insertedUsers TABLE (UserId int);
	INSERT INTO [Users]([Name], [Surname], Birthdate)
		OUTPUT INSERTED.Id INTO @insertedUsers(UserId)
			VALUES(@name, @surname, @birthdate)
	RETURN SELECT UserId FROM @insertedUsers*/
END
GO

EXEC AddAward N'best guy', N'for really cool man'
GO

CREATE TYPE AwardsIds
AS TABLE(id int)

USE [UserAndAwards]
GO
/*go*/

CREATE PROCEDURE GetUsers								/*GET USERS*/
As
	RETURN SELECT Id, [Name], [Surname], [Birthdate]
		FROM [Users]
Go

CREATE PROCEDURE GetUserById(@id int)
As
	RETURN SELECT Id, [Name], [Surname], [Birthdate]
		FROM [Users]
			WHERE Id = @id
Go

CREATE PROCEDURE InsertUser(							/*INSERT USERS*/
	@name nvarchar(100),
	@surname nvarchar(100),
	@birthdate datetime2)
As
	DECLARE @insertedUsers TABLE (UserId int);
	INSERT INTO [Users]([Name], [Surname], Birthdate)
		OUTPUT INSERTED.Id INTO @insertedUsers(UserId)
			VALUES(@name, @surname, @birthdate)					
	 RETURN SELECT UserId FROM @insertedUsers


Go


/*DECLARE @returnvalue int
	 INSERT INTO @returnvalue SELECT UserId FROM @insertedUsers
	 RETURN @returnvalue*/

EXEC InsertUser N'best guy', N'for really cool man', N'2012-12-12'
GO

CREATE PROCEDURE DeleteUser(@userId int)				/*DELETE*/
As
	DELETE FROM [Users] WHERE Id = @userId;
Go

CREATE PROCEDURE DeleteAward(@awardId int)
As
	DELETE FROM [Awards] WHERE Id = @awardId;
Go


CREATE PROCEDURE GetAwards
As
	RETURN SELECT Id, [Title],[Description]
		FROM [Awards]
Go

CREATE PROCEDURE GetUsersAwards(@userId int)		
AS	 	
	RETURN SELECT [AwardId]
		FROM [Relations]
			WHERE UserId = @userId
GO

CREATE PROCEDURE UpdateUser (						/*UPDATE*/
		@userId int,
		@name nvarchar(150),
		@surname nvarchar(150),
		@birthday datetime2)
AS
	/*SELECT [Name],[Surname],[Birthdate] FROM [Users]
	EXEC*/
	UPDATE dbo.Users
	SET [Name] = @name,
		[Surname] = @surname,
		[Birthdate] = @birthday WHERE Id=@userId
GO

CREATE PROCEDURE UpdateAward (
		@awardId int,
		@title nvarchar(150),
		@description nvarchar(150))
AS
	/*SELECT [Name],[Surname],[Birthdate] FROM [Users]
	EXEC*/
	UPDATE dbo.Awards
	SET [Title] = @title,
		[Description] = @description WHERE Id=@awardId
GO


CREATE PROCEDURE [dbo].[InsertUserRewards](
	@userId int,
	@rewardIds AS dbo.Awards READONLY)
As
	INSERT INTO Relations(UserId, AwardId)
		SELECT @userId, AwardId FROM @rewardIds

GO

	/*
	добавление пользователя+
	удаление пользователя +
	обновление пользователя+

	добавление наград+
	удаление наград +
	обновление наград+
	
	получение всех наград выбранного пользователя +
	
	ALTER PROCEDURE AddUser(
	@name nvarchar(150),
	@bdate datetime2,
	@awardIds AwardsIds readonly)
AS
BEGIN
	DECLARE @userId AS TABLE(id int)

	INSERT INTO Users
	OUTPUT Inserted.Id INTO @userId
	VALUES(@name, @bdate)

	INSERT INTO Relations
	SELECT [@userId].id, [@awardIds].id FROM @awardIds, @userId
END
*/

/*SELECT * FROM dbo.Users

DELETE FROM dbo.Users
WHERE id IN (SELECT TOP(2) id FROM dbo.Users)

UPDATE dbo.Users
SET Name = 'asdqqwe45'
WHERE Id = 1*/