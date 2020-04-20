#!/bin/bash

#
sed -i 's/${GOOGLE_CLIENT_ID}/'${GOOGLE_CLIENT_ID}/ /app/appsettings.json
sed -i 's/${GOOGLE_SECRET}/'${GOOGLE_SECRET}/ /app/appsettings.json
sed -i 's/${SQL_SOURCE}/'${SQL_SOURCE}/ /app/appsettings.json
sed -i 's/${SQL_USER}/'${SQL_USER}/ /app/appsettings.json
sed -i 's/${SQL_PASSWORD}/'${SQL_PASSWORD}/ /app/appsettings.json
