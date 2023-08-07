################## Variables ##################
MIGRATION_NAME := $(shell date +"%Y%m%d%H%M%S")
API_CSPROJ = src/API/API.csproj
INFRA_CSPROJ = src/Infrastructure/Infrastructure.csproj
MIGRATION_PATH = Persistance/EFCore/Migrations

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
	docker compose up -d
install-with-gui:
	docker compose --profile phpmyadmin --profile redis-commander up -d

################## phony ##################
.PHONY: migration-create migration-up migration-down install install-with-gui