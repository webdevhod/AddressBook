﻿namespace AddressBook.Services.Interfaces
{
    public interface IImageService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string getConvertedByteArrayToString(byte[] fileData, string extension);
    }
}
