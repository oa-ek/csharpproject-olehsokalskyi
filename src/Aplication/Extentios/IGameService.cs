using Application.Abstractions;
using Application.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IGameService : IService<GameModel, GameCreateModel, GameEditModel>
    {
        Task<DefaultMessageResponse> BuyGame(GameBuyModel model);
    }
}
