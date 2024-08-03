namespace TequipWiseServer.Helpers
{
    public class FileUploadHelper
    {
        private readonly string _uploadsFolderPath;

        public FileUploadHelper()
        {
            _uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_uploadsFolderPath))
            {
                Directory.CreateDirectory(_uploadsFolderPath);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(_uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("uploads", fileName).Replace("\\", "/");
        }
    }
}
