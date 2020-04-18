#!/bin/sh
# This is script will run the Database migration for this project
# Scripts created by Alexandre Yembo
echo "STARTING DATABASE MIGRATION"

echo "processing migration for PersistedGrantDbContext"
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb

echo "processing migration for ConfigurationDbContext"
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb

echo "processing migration for ApplicationDbContext"
dotnet ef migrations add InitialIdentityServerApplicationDbMigration -c ApplicationDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb 
echo "migration finished!"