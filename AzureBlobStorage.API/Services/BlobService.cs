using System.IO;
using System;
using System.Threading.Tasks;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureBlobStorage.API
{
    /// <summary>
    /// Azure Blob Storage Service
    /// </summary>
    public class BlobService : IBlobService
    {
        #region| Fields |

        private readonly BlobServiceClient _blobServiceClient;

        #endregion

        #region| Constructor |

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        #endregion

        #region| Methods |

        public async Task<Uri> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName)
        {
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });

            return blobClient.Uri;
        }

        public async Task DeleteFileBlobAsync(string blobContainerName, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);

            await containerClient.DeleteBlobIfExistsAsync(fileName);
        }

        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);

            containerClient.CreateIfNotExists(PublicAccessType.Blob);

            return containerClient;
        } 

        #endregion
    }
}