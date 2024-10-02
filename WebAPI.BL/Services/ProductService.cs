using Microsoft.EntityFrameworkCore;
using WebAPI.BL.DTO.Exceptions;
using WebAPI.BL.DTO.Product;
using WebAPI.BL.Services.Base;
using WebAPI.DAL;
using WebAPI.DAL.Entities.Database;

namespace WebAPI.BL.Services
{
    public class ProductService : BaseService<Product, int>
    {
        public ProductService(ApplicationDbContext dbContext) : base(dbContext) { }

        public new async Task<List<ProductResponse>> GetAllAsync()
        {
            var products = await _dbContext.Products.AsNoTracking()
                .Include(x => x.Manufacturer)
                .Select(x => new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Shape = x.Shape,
                    Dosage = x.Dosage,
                    ReleaseDate = x.ReleaseDate,
                    ExpirationDate = x.ExpirationDate,
                    ManufacturerId = x.ManufacturerId,
                    Manufacturer = x.Manufacturer,
                }).ToListAsync();

            return products;
        }

        public new async Task<ProductResponse?> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.AsNoTracking()
                .Include(x => x.Manufacturer)
                .Where(x => x.Id == id)
                .Select(x => new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Shape = x.Shape,
                    Dosage = x.Dosage,
                    ReleaseDate = x.ReleaseDate,
                    ExpirationDate = x.ExpirationDate,
                    ManufacturerId = x.ManufacturerId,
                    Manufacturer = x.Manufacturer,
                }).FirstOrDefaultAsync();

            return product;
        }

        public async Task<bool> CreateAsync(ProductRequest request)
        {
            Product newProduct = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Shape = request.Shape,
                Dosage = request.Dosage,
                ReleaseDate = request.ReleaseDate,
                ExpirationDate = request.ExpirationDate,
                ManufacturerId = request.ManufacturerId,
            };

            await _dbContext.Products.AddAsync(newProduct);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(ProductRequest request)
        {
            var product = await _dbContext.Products.FindAsync(request.Id);
            if (product is null)
                throw new CustomException("Продукт не найден!");

            product.Name = request.Name;
            product.Shape = request.Shape;
            product.Dosage = request.Dosage;
            product.ReleaseDate = request.ReleaseDate;
            product.ExpirationDate = request.ExpirationDate;
            product.ManufacturerId = request.ManufacturerId;

            _dbContext.Entry(product).State = EntityState.Modified;
            return await SaveAsync();
        }
    }
}
