﻿using Application.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IPlatformRepository : IRepository<Platform, Guid>
    {
        public Task<Platform> GetPlatformByName(string name);

    }
}