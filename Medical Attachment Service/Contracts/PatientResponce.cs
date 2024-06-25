using System.Security;

namespace Medical_Attachment_Service.Contracts
{
    public record PatientResponce(
        Guid Id,
        string LastName,
        string FirstName,
        string MiddleName,
        string Iin);
}
