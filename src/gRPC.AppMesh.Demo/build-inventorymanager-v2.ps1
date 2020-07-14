docker build -t grpc-demo-inventorymanager:v2 -f .\gRPC.AppMesh.InventoryManager\Dockerfile .
docker tag grpc-demo-inventorymanager:v2 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:inventory-manager-v2.0
docker push 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:inventory-manager-v2.0