CREATE TABLE [dbo].[PatientsData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PatientName] NVARCHAR(50) NULL, 
    [PatientEmail] NVARCHAR(50) NULL, 
    [AppointmentDate] DATETIME NULL, 
    [DoctorName] NVARCHAR(50) NULL, 
    [Message] NVARCHAR(128) NULL
)
