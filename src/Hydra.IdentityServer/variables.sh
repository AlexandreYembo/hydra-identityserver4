#!/bin/bash

#
sed -i 's/${GOOGLE_CLIENT_ID}/'${GOOGLE_CLIENT_ID}/ appsettings.json
sed -i 's/${GOOGLE_SECRET}/'${GOOGLE_SECRET}/ appsettings.json
sed -i 'S/${SQL_SOURCE}/' ${SQL_SOURCE}/ appsettings.json
sed -i 's/${SQL_USER}/'${SQL_USER}/ /appsettings.json
sed -i 's/${SQL_PASSWORD}/'${SQL_PASSWORD}/ appsettings.json