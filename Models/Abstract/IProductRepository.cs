﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
