################## Variables ##################
MIGRATION_NAME := $(shell date +"%Y%m%d%H%M%S")
API_CSPROJ = src/API/API.csproj
INFRA_CSPROJ = src/Infrastructure/Infrastructure.csproj
MIGRATION_PATH = Persistance/EFCore/Migrations
include .env

################## Migration ##################
migration-add:
	dotnet ef migrations add $(MIGRATION_NAME) --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ} --output-dir ${MIGRATION_PATH}
migration-update:
	dotnet ef database update --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ}
migration-rollback:
	dotnet ef database update $(MIGRATION_NAME) --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ}

# migration:
# 	@make migration-add
# 	@make migration-update

################## Installation ##################
install:
ifeq ($(findstring $(APP_ENV),Development Local),)
	docker compose --profile $(APP_ENV) up -d
else
	LOCAL_RABBIT_PORT=$(RABBIT_PORT) LOCAL_DB_PORT=$(DB_PORT) LOCAL_REDIS_PORT=$(REDIS_PORT) docker compose --profile $(APP_ENV) up -d
endif
install-with-gui:
ifeq ($(findstring $(APP_ENV),Development Local),)
	docker compose --profile $(APP_ENV) --profile phpmyadmin --profile redis-commander up -d
else
	LOCAL_RABBIT_PORT=$(RABBIT_PORT) LOCAL_RABBIT_MANAGEMENT=$(RABBIT_MANAGEMENT) LOCAL_DB_PORT=$(DB_PORT) LOCAL_REDIS_PORT=$(REDIS_PORT) docker compose --profile $(APP_ENV) --profile phpmyadmin --profile redis-commander up -d
endif

################## phony ##################
.PHONY: migration-create migration-up migration-down install install-with-gui