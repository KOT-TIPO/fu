CREATE TABLE Role (
	 Roleid INT IDENTITY(1,1) PRIMARY KEY,
	 Role_Name NVARCHAR(50)NOT NULL);

	 INSERT INTO Role(Role_Name) VALUES('Admin'), ('Manager');

