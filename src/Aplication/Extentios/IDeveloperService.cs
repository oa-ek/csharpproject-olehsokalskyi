using Application.Abstractions;
using Application.Commons.Models;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IDeveloperService: IService<DeveloperViewModel, DeveloperCreateModel, DeveloperEditModel>
    {
    }
}
