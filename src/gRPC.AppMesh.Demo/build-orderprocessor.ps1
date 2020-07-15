docker build -t grpc-demo-orderprocessor -f .\gRPC.AppMesh.OrderProcessor\Dockerfile .
docker tag grpc-demo-orderprocessor:latest 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:order-processor-v1.0
docker push 489440960698.dkr.ecr.us-east-1.amazonaws.com/grpc-demo:order-processor-v1.0