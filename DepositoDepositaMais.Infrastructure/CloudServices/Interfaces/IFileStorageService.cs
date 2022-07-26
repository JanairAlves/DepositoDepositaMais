
namespace DepositoDepositaMais.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStoragePlaceService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
