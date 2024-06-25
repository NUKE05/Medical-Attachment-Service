namespace Medical_Attachment_Service.Contracts
{
    public record PatientRequest(
        string LastName,
        string FirstName,
        string MiddleName,
        string Iin);
}
