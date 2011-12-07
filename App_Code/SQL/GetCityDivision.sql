SELECT DISTINCT  Address.division AS CityDivision, School.address_id
FROM         School INNER JOIN
                      Address ON School.address_id = Address.id