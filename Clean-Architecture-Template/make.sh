#!/bin/bash

################## Variables ##################
# MIGRATION_NAME=$(date +"%Y%m%d%H%M%S")
API_CSPROJ="src/API/API.csproj"
INFRA_CSPROJ="src/Infrastructure/Infrastructure.csproj"
MIGRATION_PATH="Persistance/EFCore/Migrations"
source .env

################## Migration ##################
migration-add() {
    dotnet ef migrations add $MIGRATION_NAME --startup-project $API_CSPROJ --project $INFRA_CSPROJ --output-dir $MIGRATION_PATH
}

migration-update() {
    dotnet ef database update --startup-project $API_CSPROJ --project $INFRA_CSPROJ
}

migration-rollback() {
    dotnet ef database update $MIGRATION_NAME --startup-project $API_CSPROJ --project $INFRA_CSPROJ
}

################## Installation ##################
install() {
    if [[ "$APP_ENV" == "Development" || "$APP_ENV" == "Local" ]]; then
        LOCAL_DB_PORT=$DB_PORT LOCAL_REDIS_PORT=$REDIS_PORT docker compose --profile $APP_ENV up -d
    else
        docker compose --profile $APP_ENV up -d
    fi
}

install-with-gui() {
    if [[ "$APP_ENV" == "Development" || "$APP_ENV" == "Local" ]]; then
        LOCAL_DB_PORT=$DB_PORT LOCAL_REDIS_PORT=$REDIS_PORT docker compose --profile $APP_ENV --profile phpmyadmin --profile redis-commander up -d
    else
        docker compose --profile $APP_ENV --profile phpmyadmin --profile redis-commander up -d
    fi
}

################## Help ##################
display_usage() {
    # Print table header
    printf "%-50s  %-10s\n" "Commands" "Description"

    # Print table rows
    printf "%-50s  %-10s\n" "bash $0 migration-add <migration_name>" "Create a new migration with the specified name"
    printf "%-50s  %-10s\n" "bash $0 migration-update" "Update the database with the applied migrations"
    printf "%-50s  %-10s\n" "bash $0 migration-rollback <migration_name>" "Rollback the database to the specified migration"
    printf "%-50s  %-10s\n" "bash $0 install" "Install the application"
    printf "%-50s  %-10s\n" "bash $0 install-with-gui" "Install the application with GUI tools"
}

################## Main ##################
case "$1" in
    migration-add)
        MIGRATION_NAME="$2"
        migration-add
        ;;
    migration-update)
        migration-update
        ;;
    migration-rollback)
        MIGRATION_NAME="$2"
        migration-rollback
        ;;
    install)
        install
        ;;
    install-with-gui)
        install-with-gui
        ;;
    help)
        display_usage
        ;;
    *)
        echo "Invalid command! for getting all commands run: bash $0 help"
        exit 1
esac

exit 0
