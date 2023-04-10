CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- Section Recipes

CREATE Table
    recipes(
        id int AUTO_INCREMENT not Null PRIMARY KEY,
        name varchar(50) not NULL,
        instructions VARCHAR(1000),
        instructionsPic varchar(500),
        img VARCHAR(500) not null,
        category VARCHAR(50) not null,
        creatorId VARCHAR(255) NOT NULL,
        isPrivate BOOLEAN not null DEFAULT false,
        Foreign Key (creatorId) REFERENCES accounts(id) on Delete CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

-- Section Ingredients

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        name VARCHAR(500) NOT NULL,
        measurement VARCHAR(500) NOT NULL,
        quantity INT NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

insert into
    ingredients (
        name,
        measurement,
        quantity,
        recipeId
    )
VALUES ("milk", "cups", 2, 3);

create table
    branches (
        id int AUTO_INCREMENT PRIMARY KEY not NULL,
        name VARCHAR(255) not null,
        description VARCHAR(500) not null,
        img VARCHAR(500) not null,
        isPrivate BOOLEAN not NULL DEFAULT false,
        creatorId VARCHAR(255) not null,
        Foreign Key (creatorId) REFERENCES accounts(id) on delete CASCADE
    ) default charset utf8 COMMENT '';