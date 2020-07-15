using System;
using System.Threading.Tasks;
using gRPC.AppMesh.InventoryManager.Protos;
using Grpc.Core;

namespace gRPC.AppMesh.InventoryManager.GrpcServices
{
    public class InventoryManagerGrpcService : InventoryManagerService.InventoryManagerServiceBase
    {
        public override Task<InventoryAdjustmentResponse> AdjustInventory(InventoryAdjustmentRequest request, 
            ServerCallContext context)
        {
            var random = new Random();
            
            return Task.FromResult(new InventoryAdjustmentResponse
            {
                AvailableQuantity = ( random.Next(1000,2000) - request.Quantity )
            });
        }
    }
}