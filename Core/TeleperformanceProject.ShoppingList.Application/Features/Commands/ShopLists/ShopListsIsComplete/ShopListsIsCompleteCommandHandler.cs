using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeleperformanceProject.ShoppingList.Application.DTOs;
using TeleperformanceProject.ShoppingList.Application.Repositories.RabbitMq;
using TeleperformanceProject.ShoppingList.Application.Repositories.ShopLists;
using TeleperformanceProject.ShoppingList.Domain.Entities;

namespace TeleperformanceProject.ShoppingList.Application.Features.Commands.ShopLists.ShopListsIsComplete
{
    public class ShopListsIsCompleteCommandHandler : IRequestHandler<ShopListsIsCompleteCommandRequest, ShopListsIsCompleteCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IListsReadRepository _read;
        private readonly IPublisherService _publisherService;
        public ShopListsIsCompleteCommandHandler(IMapper mapper, IListsReadRepository read, IPublisherService publisherService)
        {
            _mapper = mapper;
            _read = read;
            _publisherService = publisherService;
        }

        public async Task<ShopListsIsCompleteCommandResponse> Handle(ShopListsIsCompleteCommandRequest request, CancellationToken cancellationToken)
        {



            ShoppList list1 = await _read.GetByIdAsync(request.Id);

            if (list1.IsCompleted == request.IsComplete)
            {
                throw new Exception("değişmedi");
            }
            list1.IsCompleted = request.IsComplete;
            list1.CompletedDate = DateTime.UtcNow;
            await _read.SaveAsync();

            var lists = _mapper.Map<ShopListDto>(list1);
            

            return new()
            {
                ShopList = lists,
            };
        }
    }
}
