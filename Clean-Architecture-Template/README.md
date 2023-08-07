## commands

*install application*

To begin, rename the file `.env.example` to `.env` and fill in all the values. Then start the project using the following command:

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
make migration-add MIGRATION_NAME=<migration-name>
```

---

*up migrations:*

```shell
make migration-update
```

---

*rollback migrations:*

```shell
make migration-rollback MIGRATION_NAME=<migration-name>
```

---



# Clean architecture template
