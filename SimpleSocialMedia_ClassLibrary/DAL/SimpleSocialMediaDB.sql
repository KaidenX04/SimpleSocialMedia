CREATE TABLE Account (
	AccountID int not null identity(0, 1) primary key,
	Username varchar(30) not null,
	Password varchar(30) not null
);

CREATE TABLE Post (
	PostID int not null identity(0, 1) primary key,
	AccountID int not null foreign key references Account(AccountID),
	Text varchar(300) not null,
	Likes int not null
);

CREATE TABLE Comment (
	CommentID int not null identity(0, 1) primary key,
	AccountID int not null foreign key references Account(AccountID),
	PostID int not null foreign key references Post(PostID),
	Text varchar(300) not null,
	Likes int not null
);