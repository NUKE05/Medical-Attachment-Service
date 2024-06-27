namespace Medical_Attachment_Service.Contracts
{
    public record AttachmentRequest_Responce(
        Guid Id,
        DateTime CreationDate,
        DateTime ProcessingDate,
        Guid PatientId,
        Guid MedicalOrganizationId,
        string Status);
}
