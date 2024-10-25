# Order filter service with Asp .net core Web Api and Console as UI
## Run
```sh
git clone https://github.com/donl0/console-order-filtration-app.git
cd console-order-filtration-app
docker compose up --detach

docker attach {UI docker id}
```

## Libs
- [Ef Core](https://github.com/donl0/console-order-filtration-app/blob/main/Infrastructure/Db/OrderDbContext.cs)
- Serilog for collecting logs.
- Postgresql

## Backend
- Made with DDD.
- [Web Api Controllers](https://github.com/donl0/console-order-filtration-app/tree/main/OrderExcecutor/Controllers).
- [Repositories](https://github.com/donl0/console-order-filtration-app/tree/main/Infrastructure/Repositories)
- [Services](https://github.com/donl0/console-order-filtration-app/tree/main/Application/Services)
- [Models](https://github.com/donl0/console-order-filtration-app/tree/main/Domain/Models)

## UI Layer
Used [Machine State](https://github.com/donl0/console-order-filtration-app/blob/main/UI/StateMachine/StateMachine.cs) pattern to describe rules for UI comminication.

## OrderExcecutor Layer
Web Api

## OrderExcecutorApiClient Layer
Share Api client

## Application, Domain Layers
Core Logic.
Encapsulated and isolated models.

## Populate data
```
1
9a18344c-108b-4b3c-9a2b-ca867a5a1ea5
200
piter20
23:33:57
1
9a18344c-108b-4b3c-9a2b-ca867a5a1ea4
200
piter20
23:33:55
1
9a18344c-108b-4b3c-9a2b-ca867a5a1ea1
200
piter20
23:33:59
```
