using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleperformanceProject.ShoppingList.Application.DTOs;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.ShopLists.ShopListsAdd;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.ShopLists.ShopListsIsComplete;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.ShopLists.ShopListsRemove;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.ShopLists.ShopListsUpdate;
using TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetByCategoryId;
using TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetByCreateDate;
using TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetById;
using TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetByShopListsName;
using TeleperformanceProject.ShoppingList.Application.Features.Queries.ShopLists.GetLists;
using TeleperformanceProject.ShoppingList.Persistence.Contexts;

namespace TeleperformanceProject.ShoppingList.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Authorize(Roles = "User,Admin")]

    [Route("api/[controller]")]
    [ApiController]
   
    public class ShopListController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public ShopListController(IMediator mediator)
        {
           
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddLists([FromBody] ShopListsAddCommandRequest shopListsAddCommandRequest)
        {
            ShopListsAddCommandResponse response = await _mediator.Send(shopListsAddCommandRequest);
           
            return Ok("Eklendi");

        }
        [HttpDelete("[action]")]

        public async Task<IActionResult> RemoveList([FromQuery]ShopListsRemoveCommandRequest shopListsRemoveCommandRequest)
        {
            ShopListsRemoveCommanResponse response = await _mediator.Send(shopListsRemoveCommandRequest);
            return Ok("Silindi");
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateList([FromQuery]ShopListsUpdateCommandRequest shopListsUpdateCommandRequest)
        {
            ShopListsupdateCommandResponse response = await _mediator.Send(shopListsUpdateCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLists([FromQuery]GetShopListsQueryRequest shopListsGetByCategoryIdQueryRequest)
        {
            GetShopListsQueryResponse response = await _mediator.Send(shopListsGetByCategoryIdQueryRequest);
            return Ok(response);
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> ShopListsIsCompleted([FromQuery]ShopListsIsCompleteCommandRequest shopListsIsCompleteCommandRequest)
        {
            ShopListsIsCompleteCommandResponse response = await _mediator.Send(shopListsIsCompleteCommandRequest);
            return Ok(response);
        }

        
        }


        
        


    }

