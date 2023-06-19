create database DB_SISTEMA
on primary
(
name = DB_SISTEMA_DATO,
Filename='C:\DataBase\dbSistema\DB_SISTEMA_DATO.mdf',
size=10MB,
maxsize=50MB,
filegrowth=5%
)
log on
(
name = DB_SISTEMA_LOGICA,
Filename='C:\DataBase\dbSistema\DB_SISTEMA_LOGICA.ldf',
size=5MB,
maxsize=30MB,
filegrowth=5%
)

use db_sistema

