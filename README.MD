# Warehousing microservice

## Build docker image 

1. Open powershell
2. Go to "src" folder
3. Build docker image for Warehousing microservice:
```
docker build -t warehousing .
```
4. Spin up microservice:
```
docker run -p 85:80 warehousing
```
5. The microservice is exposed and can be reached at http://localhost:85. In order to verify its functionality, use the provided Postman collection located at "src" folder
