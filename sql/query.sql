
use master
go
/*create databae*/
create database lmo_g9
go
use lmo_g9
go
/*create table*/
-- account
drop table account
truncate table account

create table account (
	account_id int identity(1, 1) not null primary key,
	fullname nvarchar(200),
	address nvarchar(200),
	date_of_birth datetime,
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
	name nvarchar(200),
	image_path varchar(200),
	create_by int,
	create_date datetime,
	update_by int,
	update_date datetime
)
go
-- create table composer-music
create table composer_music(
	composer_music_id int identity(1, 1) not null primary key,
	composer_id int,
	music_id int,
	create_by int,
	create_date datetime,
	update_by int,
	update_date datetime
)
go

-----------------------------------------------------------------------------------
/*insert data*/
use lmo_g9
go
insert into account(fullname, address, date_of_birth, role_id, username, password, avatar_path, create_date, create_by, update_date, update_by) values ('Vu Van Hung', 'Thai Binh', '08-28-1999', 1, 'hungvv', '1', null, '12-07-2020', 1, '12-07-2020', 1)
insert into account(fullname, address, date_of_birth, role_id, username, password, avatar_path, create_date, create_by, update_date, update_by) values ('Vu Van Hung', 'Thai Binh', '08-28-1999', 0, 'client', '1', null, '12-07-2020', 1, '12-07-2020', 1)

delete from account where account_id = 3

update account set password = 1 where username = 'hungvv'

-----------------------------------------------------------------------------------
/*UPDATE NEWS*/
use lmo_g9
go
create table news (
	news_id int identity(1, 1) not null primary key,
	title varchar(200),
	short_content varchar(200),
	content text,
	img_path varchar(200),
	create_by int,
	create_date datetime,
	update_by int,
	update_date datetime
)
go