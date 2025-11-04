## Decisiones
Meto el proyecto en una ruta adicional para no tocar nada de vuestro template.
He movido el Dockerfile a la raiz y preparado un compose con MongoDb y MongoDb Express para poder verificar.
He intentado seguir toda la arquitectura aunque sin autenticación, y sin seguir algunos detalles menores que he visto a medio implementar, ya que no se pedía en la prueba como tal y me tenía que centrar en lo pedido.

## Preguntas
- Sobre: La flota no debe de contener vehículos cuya fecha de fabricación sea superior a 5 años. 

La flota no debe de contener o a la flota no se le puede permitir agregar? 
(pasado un tiempo sin un proceso específico no podemos determinar que un vehiculo no tenga en ese momento ya más de 5 años.)

- Sobre: Poder alquilar un vehículo.

Tenemos fecha de finalización del servicio contratado?
y debemos guardar la fecha real de entrega para verificar sobre una fecha concreta de entrega/finalización? 
(esto permite cancelar el servicio antes y poder ajustar las validaciones de reserva activa)
*He decidido hacer esto último aunque creo que puede ser algo más de lo pedido

## Ejecución
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