PROJECT_NAME ?= Neat

.PHONY: migrations db

migrations:
	cd ./Neat.Data && dotnet ef --startup-project ../Neat.Web/ migrations add $(mname) && cd ..

db:
	cd ./Neat.Data && dotnet ef --startup-project ../Neat.Web/ database update && cd ..