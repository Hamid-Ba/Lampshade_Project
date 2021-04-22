using InventoryManagement.Application.Contract.InventoryAgg;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryApplication _inventoryApplication;

        public InventoryController(IInventoryApplication inventoryApplication) => _inventoryApplication = inventoryApplication;


        [HttpGet("{id}")]
        public IEnumerable<InventoryOperationsVM> GetLogs(long id) => _inventoryApplication.GetAllOperations(id);

        [HttpPost]
        public StatusCheckVM CheckStock([FromBody] CheckCartItemCountVM command) => _inventoryApplication.CheckStock(command);
    }
}

