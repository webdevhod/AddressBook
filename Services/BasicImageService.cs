using AddressBook.Services.Interfaces;

namespace AddressBook.Services
{
    public class BasicImageService : IImageService
    {
        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using MemoryStream stream = new MemoryStream();
            await file.CopyToAsync(stream);
            byte[] bytes = stream.ToArray();
            return bytes;
        }

        public string getConvertedByteArrayToString(byte[] fileData, string extension)
        {
            if (fileData == null) return string.Empty;
            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
//            return $"data:{extension};base64,{Convert.ToBase64String(fileData)}";
        }
    }
}
