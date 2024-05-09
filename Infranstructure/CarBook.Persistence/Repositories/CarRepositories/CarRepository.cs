using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories;

public class CarRepository : ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarsListWithBrands()
    {
        var values = await _context.Cars.Include(x=>x.Brand).ToListAsync();
        return values;
    }

    public async Task<List<Car>> GetLast5CarsWithBrands()
    {
        var values = await _context.Cars.Include(x=> x.Brand)
            .OrderByDescending(x=>x.CarID).Take(5).ToListAsync();
        return values;
    }

}
