using Azure.Storage.Blobs;
using UploadFile.Model;

namespace UploadFile.Service
{
    public class UploadFileService
    { 
        public UploadFileService() { }

        public async Task<string> SendFile(Playload file)
        {
            var result = "";

            var fileName = Guid.NewGuid().ToString() + ".webp";

            var bytes = await GetByteArray(file.Image);
           
            try
            {
                var blobClient = new BlobClient("string de conexão", "container", fileName);

                using (var ms = new MemoryStream(bytes))
                {
                    blobClient.Upload(ms);
                }
                result = blobClient.Uri.AbsoluteUri;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          

            return result;
        }
        public async Task<byte[]> GetByteArray(IFormFile file)
        {
            byte[] bytes = null;
            try
            {
                using(var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    bytes = stream.ToArray();
                }
            } 
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            return bytes;
        }
    }
}
