namespace CSV_Reader.Utils
{
    public class FileHelper
    {
        public static async Task SaveFile(IWebHostEnvironment environment, IFormFile file)
        {
            var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Save the CSV file to the specified directory
            var fileName = Path.GetFileName(file.FileName);
            var destinationPath = Path.Combine(uploadsFolder, fileName);

            var stream = new FileStream(destinationPath, FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            stream.Close();
        }
    }
}
