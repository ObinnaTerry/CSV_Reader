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
        private readonly IMapper _mapper;

        public CsvService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public void ImportItemsFromCsv(StreamReader reader)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

            using (var csv = new CsvReader(reader, config))
            {
                var products = csv.GetRecords<ProductModel>().ToList();

                _productRepo.Insert(_mapper.Map<List<Product>>(products));
                _productRepo.Save();
            }
        }
    }
}
