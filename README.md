Attempting to recreate [Issue #3111](https://github.com/getsentry/sentry-dotnet/issue/3111)

There's a docker compose file to fire up a Postgres database... you might need to run the following from the CLI before running the app then:
```
dotnet ef database update
docker-compose up
```