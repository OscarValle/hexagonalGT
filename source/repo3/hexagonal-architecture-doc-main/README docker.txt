--Docker Compose direct:
docker-compose up -d --build; Start-Sleep -Seconds 3; Start-Process "http://localhost:8080"
docker-compose logs -f
docker-compose down


--Build Dockerfile (Need the mongo config in):
docker build -t estimate-microservice .
docker run -it -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development estimate-microservice
Start-Sleep -Seconds 3
Start-Process "http://localhost:8080"

--Build Dockerfile 
docker run -it -p 8080:8080 -p 8443:443 \
-e ASPNETCORE_ENVIRONMENT=Development \
-e ASPNETCORE_URLS=http://+:8080 \
-e "MongoDb__ConnectionString=mongodb://admin:admin123@localhost:27017/?authSource=admin" \
-e MongoDb__MongoDbDatabaseName=estimate-db \
estimate-microservice
Start-Sleep -Seconds 3
Start-Process "http://localhost:8080"

--Mongo user and pass:
admin
admin1234