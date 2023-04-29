namespace EMusic.Models.APIModels.AddAttachment
{
    public class AddAttachmentRequest
    {
        public string Email { get; set; }
        public byte[] AttachmentImage { get; set; }
    }
}
