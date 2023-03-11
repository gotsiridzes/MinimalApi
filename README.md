# Async API Approaches

1. Asynchronous Request Reply
2. Callback (webhooks)
3. Persistent connection
   * WebSockets/SignalR
   * 
## Asynchronous Request Reply
Client            Start Endpoint    Status Endpoint   Final Endpoint </br>
#################################################################### </br>
      POST ------> </br>
      <-- HTTP 202 </br>
#################################################################### </br>
      GET -------------------------> </br>
      <-------------------- HTTP 200 </br>
####################################################################
      GET ------------------------------------------->
      <-------------------------------------- HTTP 200
  ##################################################################

## Webhook Callback

Client | Post ->     | Endpoint
Client | <- HTTP 202 | Endpoint
Client |             | Endpoint |             | Callback Service 
Client |             | Endpoint | POST ->     | Callback Service 
Client |             | Endpoint | <- HTTP 201 | Callback Service 
Client | <-------------------------- POST     | Callback Service
Client | HTTP 200 --------------------------> | Callback Service
