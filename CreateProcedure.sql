ALTER PROCEDURE AddTHP	
   @Chanel INT,
   @Value FLOAT,
   @RecDate nvarchar(50), 
   @RetValue INT OUTPUT
AS
BEGIN
	INSERT INTO dbo.tblMain( type,val, dt )VALUES  ( @Chanel, @Value, @RecDate ) 
	SET @RetValue = 0
END