USE [Bootcamps]
GO

/****** Object: SqlProcedure [dbo].[SP_Insert_Role] Script Date: 2/3/2020 4:35:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_Insert_Role]
	@name varchar (50)
	AS
	INSERT INTO AspNetRoles (Name) Values (@name);
