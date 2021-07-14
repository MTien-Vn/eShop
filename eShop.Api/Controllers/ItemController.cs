using eShop.Business.Entity;
using eShop.Business.Interface.IService;
using eShop.Business.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : BaseEntityController<ItemModel>
    {
        private IItemService itemService;
        public ItemController(IItemService _itemService) : base(_itemService)
        {
            this.itemService = _itemService;
        }
    }
}
