SELECT 	p.id AS Id, 
		p.tradingname AS Trading_Name, 
		p.ownername AS Owner_Name, 
		p.document AS Document, 
		a.coordinates AS Address,
		ca.coordinates AS Coverage_Area
	FROM Partners p
		INNER JOIN Coverage_Area ca ON p.coverageareaid = ca.id
		INNER JOIN Address a ON p.addressid = a.id;


SELECT * FROM Coverage_Area;
SELECT * FROM Address;
SELECT * FROM Partners;