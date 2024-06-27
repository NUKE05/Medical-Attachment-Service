namespace Medical_Attachment_Service.Contracts
{
    public record UserRequest(
        string Login,
        string Password,
        bool isAdmin,
        Guid MedicalOrganizationId);
}
