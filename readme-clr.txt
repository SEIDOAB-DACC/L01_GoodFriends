To create the L01_GoodFriends

1. With Terminal in folder AppGoodFriendsWebApi run: dotnet build 
   Ensure no errors, only wanrnings if any

2. Run AppGoodFriendsWebApi from debugger
   Verify application execution
   The only controller implemented is Health->Heartbeat

3. Run AppGoodFriendsWebApi without debugger
   With Terminal in folder AppGoodFriendsWebApi run: 
   dotnet run -lp https 

   Verify application execution
   https://localhost:7066/swagger
   The only controller implemented is Health->Heartbeat

   Try to understand the output of the Heartbeat

