﻿using System.Threading.Tasks;
using Splatools.Domain.Entities.Dto;

namespace Splatools.Domain.Services.Interfaces;

public interface ITokenService
{
    Task<GetSplatokenResponse> GetSplatoken(GetSplatokenRequest req);
}