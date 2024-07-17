using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IFileRecordService
    {
        Task UploadFile(CreateFileRecordDTO dto);
    }
}