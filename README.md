# Order filter service with Asp .net core Web Api and Console as UI
## Run
```sh
git clone https://github.com/donl0/console-order-filtration-app.git
cd console-order-filtration-app
docker compose up --detach

docker attach {UI docker id}
```

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
