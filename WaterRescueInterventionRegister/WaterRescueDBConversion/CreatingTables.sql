create table Lifeguards (
	LifeguardID int not null PRIMARY KEY,
	LifeguardName varchar(30),
	LifeguardSurname varchar(30) not null,
	LifeguardPhone char(9),
	LifeguardRole int DEFAULT '1'
);

create table Reports (
	InterventionID int not null PRIMARY KEY,
	InterventionDate date,
	InterventionTime Time,
	InterventionReport TEXT
);

CREATE TABLE Interventions (
	InterventionID INT NOT NULL foreign key references Reports(InterventionID),
	LifeguardID INT not NULL foreign key references Lifeguards(LifeguardID),
	ResponseTime INT
	
	CONSTRAINT PKInterventionLifeguard PRIMARY KEY(InterventionID, LifeguardID)
);

CREATE TABLE Roles (
	LifeguardRole int not null PRIMARY KEY,
	RoleName varchar(20)
);

