﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var values = await _repository.GetByIdAsync(command.CarID);
        values.Fuel = command.Fuel;
        values.Transmission = command.Transmission;
        values.BigImageUrl = command.BigImageUrl;
        values.CoverImageUrl = command.CoverImageUrl;
        values.Km = command.Km;
        values.Seat = command.Seat;
        values.Luggage = command.Luggage;
        values.BrandID = command.BrandID;
        values.Model = command.Model;
    }
}
