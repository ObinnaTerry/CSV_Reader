using CSV_Reader.Data;
using CSV_Reader.Entities;
using CSV_Reader.Interfaces;
using CsvHelper;
using System.Globalization;

namespace CSV_Reader.Services
{
    public class CsvService
    {
        private readonly ApplicationContext _context;
        private readonly string _fileDirectory;
        private readonly IProductRepo _productRepo;

        public CsvService(ApplicationContext context, string fileDirectory, IProductRepo productRepo)
        {
            _context = context;
            _fileDirectory = fileDirectory;
            _productRepo = productRepo;
        }

        public void ImportItemsFromCsv(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var products = csv.GetRecords<Product>().ToList();
                _productRepo.Insert(products);
                _productRepo.Save();

                // Save the CSV file to the specified directory
                var fileName = Path.GetFileName(csvFilePath);
                var destinationPath = Path.Combine(_fileDirectory, fileName);
                File.Copy(csvFilePath, destinationPath, true);
            }
        }
    }
}
