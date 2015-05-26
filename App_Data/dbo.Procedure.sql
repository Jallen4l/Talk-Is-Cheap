CREATE PROCEDURE dbo.ClientLogin
	@Username int,
	@Passcode text
AS
	SELECT PhoneNo, Firstname, Lastname, DOB, Gender, Addr, City, Postcode, EmailAddress Passcode
	FROM ClientDetailsTable
	WHERE PhoneNo = @Username AND Passcode = @Passcode
