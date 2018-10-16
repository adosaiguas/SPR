USE [master]
IF EXISTS(select * from sys.databases where name ='BD_SPR_BS')
	DROP DATABASE BD_SPR_BS
ELSE
	CREATE DATABASE BD_SPR_BS
	GO 
	USE [BD_SPR_BS]
GO

IF OBJECT_ID('dbo.Receivers', 'U') IS NOT NULL
	DROP TABLE dbo.Receivers;
CREATE TABLE Receivers (
    Receiver_ID uniqueidentifier PRIMARY KEY default NEWID(),
    Receiver_LastName nchar(255) NOT NULL,
    Receiver_FirstName nchar(255),
);

IF OBJECT_ID('dbo.Emails', 'U') IS NOT NULL
	DROP TABLE dbo.Emails;
CREATE TABLE Emails (
	Receiver_Email_ID uniqueidentifier PRIMARY KEY default NEWID(),
	Receiver_EmailAddress nchar(40),
	Receiver_EmailSubject nchar(40) NOT NULL,
	Receiver_EmailBody nchar(128) NOT NULL
);

IF OBJECT_ID('dbo.ServerPerformances', 'U') IS NOT NULL
	DROP TABLE dbo.ServerPerformances;
CREATE TABLE ServerPerformances (
	ServerPerformace_ID uniqueidentifier PRIMARY KEY default NEWID(),
	ServerPerformance_CPU nchar(15) NOT NULL,
	ServerPerformance_RAM nchar(15) NOT NULL,
	ServerPerformance_IO_DISK nchar(15)NOT NULL,
	ServerPerformance_IIS_Sessions nchar(128) NOT NULL
);

----Transact
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('insertEmail'))
BEGIN
    DROP PROCEDURE insertEmail
END
	
SET ANSI_NULLS ON
GO 
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE insertEmail(@lastName nchar(40),
 @firstName nchar(40), @emailAddress nchar(40),
@emailSubject nchar(40), @emailBody nchar(128),
@CPU nchar(15), @RAM nchar(15), @IO_Disk nchar(15), 
@IIS_Sessions nchar(40))
AS
BEGIN

DECLARE @ID UNIQUEIDENTIFIER;
SET @ID = NEWID();

INSERT INTO [dbo].ServerPerformances VALUES (@ID, @CPU, @RAM, @IO_Disk, @IIS_Sessions);
INSERT INTO [dbo].Emails VALUES (@ID, @emailAddress, @emailSubject, @emailBody);
INSERT INTO [dbo].Receivers VALUES (@ID, @lastName, @firstName);

END