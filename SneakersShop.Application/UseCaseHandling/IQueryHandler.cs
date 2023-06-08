﻿using SneakersShop.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCaseHandling
{
    public interface IQueryHandler
    {
        TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class;
    }
}
