﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Products
{
    public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);
    
}
