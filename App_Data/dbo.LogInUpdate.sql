CREATE PROCEDURE [dbo].[LogInUpdate]
(
	@Username NChar(20),
	@Current Date
)
AS
	UPDATE AdminDetailsTable Set LastLogIn = CurrentLogIn, CurrentLogIn = @Current
	WHERE AdminUsername = @Username
RETURN 0
