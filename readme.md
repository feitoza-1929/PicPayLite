# PicPayLiteAPI
PicPayLite is a API that mimic the basic behavior of a digital wallet as currency transfer and account system.
## Summary
- [Running Application With Docker](#RunningApplicationWithDocker)
- [Endpoints](#Endpoints)
	- [Client](#Client)
		- [POST/client/create](#POST/client/create)
		- [POST/client/:document/token](#POST/client/:document/token)
	- [Account](#Account)
		- [POST/account/create](#POST/account/create)
		- [POST/account/:accountNumber/balance](#POST/account/:accountNumber/balance)
		- [GET/account/:clientDocument](#GET/account/:clientDocument)
	- [Todo](#Todo) 

## Running Application With Docker
To run the application with Docker you gonna need [Docker](https://docs.docker.com/desktop/install/windows-install/) installed in your computer and Docker-Compose. After that in the root directory of the project you gonna type into your terminal
```
docker-compose up -d
```
Docker will pull some images and after that you can access the application `localhost:5048` and database adminer `localhost:8080`. 

To have access to the local adminer database you just have fill the fields:
|				   |							 |
|----------|---------------|
| System   | PostgresSQL   |
| Server   |  db           |
| Username | postgres      |
| Password | postgres      |
| Database  | picpaylite_db|


## Endpoints
Here we have endpoints query definition to allow you to consume our routes

## Client

### POST/client/create
To make all subsequent operations into our API you need to have a created client. If you try to make some other request before that you will receive a ClientNotFound error as response.

**Body params**

| **Property Name** | **Data Type** | **Description**                                            |
|-------------------|---------------|------------------------------------------------------------|
| name              | string        | client name, should have first and last names              |
| email             | string        | client email, should be a valid email                      |
| type              | int           | type of client, 0=natural person and 1=legal person. |
| document          | object        | document object                                            |
| document.type     | int           | type of document, 0=CPF and 1=CNPJ                   |
| document.value    | string        | value of the document without mask, ex: 05522233310  |

**Request Body**
```json
{
  "name": "João Victor",
  "email": "babayaga@example.com",
  "type": 0,
  "document": {
    "type": 0,
    "value": "08844535522"
  }
}
```

**Response**
*Status 201 Created*
```json
{
	"id":  "86484bdb-681e-46b4-a0fe-8faca8d2af20",
	"name":  "Jesse Faden",
	"email":  "takethecontrol@gmail.com",
	"type":  0,
	"document":  {
		"type":  0,
		"value":  "81396161090"
	}
}
```

### GET/client/:document/token
After create a client you need to get access token to make all subsequent requests. If you try to make some other request before that you will receive a 401 Unauthorized error as response.

**Path params**

| **Property Name** | **Description**                                            |
|-------------------|------------------------------------------------------------
| document    			| value of the document without mask, ex: 05522233310				 |
    
**Request**
```json
https://localhost:5048/api/client/66288118087/token
```

**Response**
*Status 200 OK*
```json
{
	"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjbGllbnRfaWQiOiI4NjQ4NGJkYi02ODFlLTQ2YjQtYTBmZS04ZmFjYThkMmFmMjAiLCJlbWFpbCI6InRha2V0aGVjb250cm9sQGdtYWlsLmNvbSIsImV4cCI6MTY4MzQzNzYxOSwiaXNzIjoiaXNzdWVyIiwiYXVkIjoiYXVkaWVuY2UifQ.jBsUXM9EBqsZbiUx4hGziyhlnPGEbiGY0vvv40wm6P8"
}
```

## Account

###  POST/account/create
This endpoint creates a account for a client and  return the account number. After that will be possible make transfers between accounts.

**Header Params**
| Property Name  | Description                                         |
|----------------|-----------------------------------------------------|
| Authorization  | Bearer Token                                        |


**Body Params**
| Property Name  | Data Type |  Description                                        |
|----------------|-----------|-----------------------------------------------------|
| document       | object    | document object                                     |
| document.type  | int       | type of document, 0=CPF and 1=CNPJ                  |
| document.value | string    | value of the document without mask, ex: 05522233310 |


**Resquest Body**
```json
{
	"document":  {
		"type":  0,
		"value":  "66288118087"
	}
}
```

**Response**
*Status 201 Created*
```json
{
	"number":  1369
}
```

###  POST/account/:accountNumber/balance
This endpoint get the account balance returning the value and actual currency. For default the account will have a balance value of 500 BRL currency. 

**Header Params**
| Property Name  | Description                                         |
|----------------|-----------------------------------------------------|
| Authorization  | Bearer Token                                        |


**Path Params**
| Property Name  |  Description                                        |
|----------------|-----------------------------------------------------|
| accountNumber  | account number                                     |


**Resquest**
```json
https://localhost:5048/api/account/1369/balance
```

**Response**
*Status 200 OK*
```json
{
	"currency":  "BRL",
	"amount":  500
}
```

### GET/account/:clientDocument
This endpoint get a account number for a client.

**Header Params**
| Property Name  | Description                                         |
|----------------|-----------------------------------------------------|
| Authorization  | Bearer Token                                        |


**Path Params**
| Property Name  |  Description                                        |
|----------------|-----------------------------------------------------|
| clientDocument | value of the document without mask, ex: 05522233310 |

**Request**
```json
https://localhost:5048/api/account/66288118087
```

**Response**
*Status 200 OK*
```json
{
	"number":  1369
}
```

### Todo
- [ ]  GET client by id endpoint
- [ ]  PATCH deactivate account endpoint
- [ ]  Improve some error messages and validation
- [ ]  Implement send email service to handle a successfully transfer result
- [ ]  Concurrency problem
- [ ]  Improve request perfomance with caching