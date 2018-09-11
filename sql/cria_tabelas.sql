
USE SimpleBot

CREATE TABLE UserProfile (
	Id VARCHAR(50) PRIMARY KEY,
	Visitas INT NOT NULL	
)

CREATE TABLE [Message] (
	Id VARCHAR(50) PRIMARY KEY,
	[User] VARCHAR(256) NOT NULL,
	[Text] TEXT NOT NULL
)

GO
CREATE OR ALTER PROCEDURE UpInsertProfile
	@Id VARCHAR(50),
	@Visitas INT
AS
	BEGIN
	IF (SELECT COUNT(Id) FROM UserProfile WHERE Id = @Id) > 0
		BEGIN
			UPDATE 
				UserProfile
			SET
				Visitas = Visitas + 1
			WHERE
				Id = @Id
		END
	ELSE
		BEGIN
			INSERT INTO 
				UserProfile 
					(Id, Visitas) 
			VALUES 
				(@Id, @Visitas)
		END
	END
