namespace EMusic.Models.APIModels.ViewAttachmentByID
{
    public class ViewAttachmentByIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public string Full_Name { get; set; }
    }
}
