FROM mysql:5.7
ENV MYSQL_DATABASE=projekt
ENV MYSQL_ROOT_PASSWORD=
ENV MYSQL_ALLOW_EMPTY_PASSWORD=yes
COPY ./data.sql /docker-entrypoint-initdb.d/
