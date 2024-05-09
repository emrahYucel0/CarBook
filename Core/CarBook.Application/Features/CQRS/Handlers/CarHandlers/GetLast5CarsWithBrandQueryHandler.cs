using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetLast5CarsWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle()
    {
        var values = await _carRepository.GetLast5CarsWithBrands();
        return values.Select(x => new GetLast5CarsWithBrandQueryResult
        {
            CarID = x.CarID,
            BrandID = x.BrandID,
            BigImageUrl = x.BigImageUrl,
            CoverImageUrl = x.CoverImageUrl,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            Model = x.Model,
            Seat = x.Seat,
            Transmission = x.Transmission,
            BrandName = x.Brand.Name
        }).ToList();
    }
}
