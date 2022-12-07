CREATE DATABASE MaioresTimes;
USE MaioresTimes;

CREATE TABLE Times (
    ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255),
    LocalFundacao VARCHAR(255),
    Estadio VARCHAR(255),
    Titulos INT,
    Fundacao DATETIME
);

SELECT * FROM Times;