﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetByCreateDate
{
    public class ShopListsGetByCreateDateQueryRequest : IRequest<ShopListsGetByCreateDateQueryResponse>
    {
        public DateTime CreatedDate { get; set; }
    }
}
