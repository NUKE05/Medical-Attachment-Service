namespace Medical_Attachment_Service.Contracts
{
    public record UserResponce(
        Guid Id,
        string Login, 
        string Password,
        bool isAdmin,
        Guid MedicalOrganizationId);
}
