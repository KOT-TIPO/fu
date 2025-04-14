ALTER TABLE Users
ADD RoleID int,
Foreign key (RoleID) REFERENCES Role(RoleID);