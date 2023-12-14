# A very brief rundown
Because I haven't documented this yet (but definitely plan to!)

NEAT (New Electronic Asset Management) is an asset management application to replace that crappy excel spreadsheet you use (HEAVILY IN DEVELOPMENT).


Neat.Web, Neat.Data, and Neat.Services contain the backend of the application. Use `cd Neat.Data && dotnet build` to build Neat.Data, and you can do the same for Neat.Services.
To start the API server, use `cd Neat.Web && dotnet run`. Note that you'll need access to the database this relies on (which you probably don't but you can just make a migration using the existing models in Neat.Data).

Then, for development, use `cd Neat-vue && npm i && npm run dev` to install the required packages and start the client web server.

If you need more information, I apologize, I just don't have the time nor energy at the time of writing this README. This will definitely be getting updated with more information in the near future.

## SDKs & Other versions
.NET 8.0.0
Node v21.2.0
