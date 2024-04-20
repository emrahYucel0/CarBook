﻿using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreatSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public CreatSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new SocialMedia
        {
            Icon = request.Icon,
            Name = request.Name,
            Url = request.Url,
        });
    }
}
