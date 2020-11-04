using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobStorage.API.Controllers
{
    /// <summary>
    /// Azure Storage Controller in charge of managing file in a container
    /// </summary>
    [ApiController, Route("[controller]")]
    public class AzureStorageController : ControllerBase
    {
        #region| Fields |

        private readonly IBlobService service;

        #endregion

        #region| Constructor |

        public AzureStorageController(IBlobService blobService)
        {
            service = blobService;
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Upload a file to the Azure Storage Account into the image container
        /// </summary>
        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFileBlobAsync()
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var result = await service.UploadFileBlobAsync(
                    "images",
                    file.OpenReadStream(),
                    file.ContentType,
                    file.FileName);

            var toReturn = result.AbsoluteUri;

            return Ok(new { path = toReturn });
        }

        /// <summary>
        /// Delete a file to the Azure Storage Account into the image container
        /// </summary>
        /// <param name="fileName">file name with the container in the Azure Storage</param>
        [HttpGet("DeleteFile/{fileName}")]
        public async Task<ActionResult> DeleteFileBlobAsync(string fileName)
        {
            await service.DeleteFileBlobAsync("images", fileName);

            return Ok();
        }

        #endregion
    }
}
