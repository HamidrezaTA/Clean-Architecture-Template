## commands

*install application*

To begin, rename the file `.env.example` to `.env` and fill in all the values. Then start the project using the following command:

```shell
bash make.sh install
```

> 🔰 **Notice** 🔰
> 
> If you need to build a GUI for monitoring the database or Redis, use the following command:
> 
> ```shell
> bash make.sh install-with-gui
> ```
> 
> | service         | port |
> | --------------- | ---- |
> | phpmyadmin      | 8080 |
> | redis commander | 8081|

*create migration files:*

```shell
bash make.sh migration-add <migration_name>
```

---

*up migrations:*

```shell
bash make.sh migration-update
```

---

*rollback migrations:*

```shell
bash make.sh migration-rollback <migration_name>
```

---



# Clean architecture template
