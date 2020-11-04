using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureBlobStorage.API
{
    public interface IBlobService
    {
        Task<Uri> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName);
        Task DeleteFileBlobAsync(string blobContainerName, string fileName);
    }
}
