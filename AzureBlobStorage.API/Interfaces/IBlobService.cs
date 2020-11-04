using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureBlobStorage.API
{
    /// <summary>
    /// Blob Service Interface
    /// </summary>
    public interface IBlobService
    {
        /// <summary>
        /// Upload a file to the Azure Storage Account into the image container
        /// </summary>
        /// <param name="blobContainerName">blobContainerName</param>
        /// <param name="content">file stream content</param>
        /// <param name="contentType">contentType</param>
        /// <param name="fileName">fileName</param>
        /// <returns>Uri</returns>
        Task<Uri> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName);

        /// <summary>
        /// Delete a file to the Azure Storage Account into the image container 
        /// </summary>
        /// <param name="blobContainerName">blobContainerName</param>
        /// <param name="fileName">fileName</param>
        Task DeleteFileBlobAsync(string blobContainerName, string fileName);
    }
}
