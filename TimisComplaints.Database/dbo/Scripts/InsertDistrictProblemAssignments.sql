insert into DistrictProblemAssignments
select d.Id, p.Id from Districts as d
cross join Problems as p