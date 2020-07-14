docker build -t grpc-demo-inventorymanager -f .\gRPC.AppMesh.InventoryManager\Dockerfile .
docker tag grpc-demo-inventorymanager:latest 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:inventory-manager-v1.0
docker push 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:inventory-manager-v1.0