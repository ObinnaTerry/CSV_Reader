using AutoMapper;
using CSV_Reader.Data;
using CSV_Reader.Entities;
using CSV_Reader.Interfaces;
using CSV_Reader.Mappings;
using CSV_Reader.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace CSV_Reader.Services
{
    public class CsvService
    {
        private readonly IProductRepo _productRepo;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public CsvService(IProductRepo productRepo, IWebHostEnvironment environment, IMapper mapper)
        {
            _productRepo = productRepo;
            _environment = environment;
            _mapper = mapper;
        }

        public void ImportItemsFromCsv(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var products = csv.GetRecords<ProductModel>().ToList();

                _productRepo.Insert(_mapper.Map<List<Product>>(products));
                _productRepo.Save();

                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Save the CSV file to the specified directory
                var fileName = Path.GetFileName(csvFilePath);
                var destinationPath = Path.Combine(uploadsFolder, fileName);
                File.Copy(csvFilePath, destinationPath, true);
            }
        }
    }
}
