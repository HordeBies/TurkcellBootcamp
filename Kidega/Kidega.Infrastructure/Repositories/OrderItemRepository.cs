﻿using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using Kidega.Infrastructure.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Infrastructure.Repositories
{
    public class OrderItemRepository(ApplicationDbContext db): Repository<OrderItem>(db), IOrderItemRepository
    {

    }
}
