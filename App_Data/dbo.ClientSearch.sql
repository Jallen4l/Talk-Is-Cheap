CREATE PROCEDURE dbo.ClientSearch
	(
	@PhoneNo text,
	@Lastname text,
	@Postcode text
	)
AS
	SELECT PhoneNo, Firstname + Lastname As Fullname
	FROM ClientDetailsTable
	WHERE PhoneNo = @PhoneNo OR Lastname = @Lastname OR Postcode = @Postcode