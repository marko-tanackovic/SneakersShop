using FluentValidation;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected SneakersShopContext Context { get; }

        protected EfUseCase(SneakersShopContext context)
        {
            Context = context;
        }
    }
}
