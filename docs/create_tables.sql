DROP TABLE IF EXISTS Partners;
DROP TABLE IF EXISTS Coverage_Area;
DROP TABLE IF EXISTS Address;

-- Criação da tabela de área de cobertura
CREATE TABLE Coverage_Area (
	id SERIAL PRIMARY KEY,
	type VARCHAR(255),
	coordinates GEOMETRY(MultiPolygon)
);

-- Criação da tabela de endereço
CREATE TABLE Address (
	id SERIAL PRIMARY KEY,
	type VARCHAR(255),
	coordinates GEOMETRY(Point)
);

-- Criação da tabela principal
CREATE TABLE Partners (
	id SERIAL PRIMARY KEY,
	tradingName VARCHAR(255),
	ownerName VARCHAR(255),
	document VARCHAR(255),
	coverageAreaId INT,
	addressId INT,
	UNIQUE(document),
	FOREIGN KEY (coverageAreaId) REFERENCES Coverage_Area(id),
	FOREIGN KEY (addressId) REFERENCES Address(id)
);
