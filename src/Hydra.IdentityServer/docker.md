```docker build --build-arg "GOOGLE_CLIENT_ID=<your_client_id --build-arg "GOOGLE_SECRET=<your_secret" --build-arg "SQL_SOURCE=<your_sql_source>" --build-arg "SQL_USER=<your_user" --build-arg "SQL_PASSWORD=<you_password>" -t hydra/identityserver:dev .```

```docker run -it --rm -p 5000:80 --name hydra_identityserver  hydra/identityserver:dev```