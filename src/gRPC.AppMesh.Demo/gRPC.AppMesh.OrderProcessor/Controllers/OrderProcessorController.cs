using System.Threading.Tasks;
using gRPC.AppMesh.OrderProcessor.Dto;
using gRPC.AppMesh.InventoryManager.Protos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gRPC.AppMesh.OrderProcessor.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderProcessorController : ControllerBase
    {
        private readonly ILogger<OrderProcessorController> _logger;
        private readonly InventoryManagerService.InventoryManagerServiceClient _inventoryManagerServiceClient;
        
        public OrderProcessorController(ILogger<OrderProcessorController> logger, 
            InventoryManagerService.InventoryManagerServiceClient inventoryManagerServiceClient)
        {
            _logger = logger;
            _inventoryManagerServiceClient = inventoryManagerServiceClient;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderDto orderDto)
        {
            var inventoryResponse = await _inventoryManagerServiceClient.AdjustInventoryAsync(new InventoryAdjustmentRequest
            {
                Quantity = orderDto.Quantity,
                ProductId = orderDto.ProductId,
                TypeOfAdjustment = "SALE"
            });
            _logger.LogInformation($"Order Placed For {orderDto.ProductId}");
            return Ok(inventoryResponse);
        }
    }
}
