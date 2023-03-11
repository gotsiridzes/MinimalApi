# Async API Approaches

1. Asynchronous Request Reply
2. Callback (webhooks)
3. Persistent connection
   * WebSockets/SignalR
## Asynchronous Request Reply
Client            Start Endpoint    Status Endpoint   Final Endpoint
####################################################################
      POST ------>
      <-- HTTP 202
####################################################################
      GET ------------------------->
      <-------------------- HTTP 200
####################################################################
      GET ------------------------------------------->
      <-------------------------------------- HTTP 200
  ##################################################################
