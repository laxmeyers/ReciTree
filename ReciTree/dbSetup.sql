CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

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