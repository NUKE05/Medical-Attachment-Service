namespace Medical_Attachment_Service.Contracts
{
    public record AttachmentRequest_Request(
        DateTime CreationDate,
        DateTime ProcessingDate,
        Guid PatientId,
        Guid MedicalOrganizationId,
        string Status);
}
