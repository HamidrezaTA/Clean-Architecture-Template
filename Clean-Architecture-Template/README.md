## commands

### Setup Instructions:

1. Rename the file .env.example to .env and fill in all the necessary values.
2. Install Make on your operating system using one of the following methods:
    - Linux/Mac: Run the command apt install make in the terminal.
    - Windows: [Installation](https://stackoverflow.com/a/32127632/4418533). (I recommend using Chocolatey)

### Usage:

Once the setup is complete, you can use the following commands:

*install application*

```shell
make install
```

> 🔰 **Notice** 🔰
> 
> If you need to build a GUI for monitoring the database or Redis, use the following command:
> 
> ```shell
> make install-with-gui
> ```
> 
> | service         | port |
> | --------------- | ---- |
> | phpmyadmin      | 8080 |
> | redis commander | 8081|

*create migration files:*

```shell
make migration-add MIGRATION_NAME=<migration_name>
```

---

*up migrations:*

```shell
make migration-update
```

---

*rollback migrations:*

```shell
make migration-rollback MIGRATION_NAME=<migration_name>
```

---



# Clean architecture template
