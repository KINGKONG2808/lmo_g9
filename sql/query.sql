drop database lmo_g9
/*create database for lmo_g9*/
use master
go
/*create databae*/
create database lmo_g9
go
use lmo_g9
go
/*create table*/
-- account
create table account (
	account_id int identity(1, 1) not null primary key,
	fullname nvarchar(200),
	address nvarchar(200),
	date_of_birth varchar(200),
	role_id int, -- 0: user, 1: admin
	username varchar(200),
	password varchar(200),
	avatar_path varchar(200),
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- category
create table category (
	category_id int identity(1, 1) not null primary key,
	name nvarchar(200),
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- singer
create table singer (
	singer_id int identity(1, 1) not null primary key,
	name nvarchar(200),
	image_path varchar(200),
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- music
/*use lmo_g9
go
drop table music*/
create table music (
	music_id int identity(1, 1) not null primary key,
	name nvarchar(200),
	file_path varchar(200),
	image_path varchar(200),
	singer_id int,
	category_id int,
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- music factory
create table music_factory (
	music_factory_id int identity(1, 1) not null primary key,
	music_id int,
	singer_id int,
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- music_favorite
create table music_favorite (
	music_favorite_id int identity(1, 1) not null primary key,
	music_id int,
	account_id int,
	create_date datetime,
	create_by int,
	update_date datetime,
	update_by int
)
go
-- create table composer
create table composer(
	composer_id int identity(1, 1) not null primary key,
	music_id int,
	name nvarchar(200),
	image_path varchar(200),
	create_by int,
	create_date datetime,
	update_by int,
	update_date datetime
)
go