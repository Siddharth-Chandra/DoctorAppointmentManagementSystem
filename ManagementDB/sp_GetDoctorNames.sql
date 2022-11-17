CREATE PROCEDURE [dbo].[sp_GetDoctorNames]
AS
BEGIN
	SELECT Id,DoctorName from DoctorsData
END
