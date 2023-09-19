declare @apCount int
declare @inputCount int
declare @outputCount int
declare @roleCount int
declare @total int

select @apCount = count(*) from GCS.AccessPortal
select @inputCount = count(*) from GCS.InputDevice
select @outputCount = count(*) from GCS.OutputDevice
select @roleCount = count(*) from GCS.gcsRole
select @apCount as AccessPortalCount, @roleCount as RoleCount, @apCount * @roleCount as TotalRoleAccessPortalsShouldBe
select @inputCount as InputCount, @roleCount as RoleCount, @inputCount * @roleCount as TotalRoleInputsShouldBe
select @outputCount as OutputCount, @roleCount as RoleCount, @outputCount * @roleCount as TotalRoleOutputsShouldBe

select count(*) as TotalRoleAccessPortal from GCS.RoleAccessPortal
select count(*) as TotalRoleInputDevice from GCS.RoleInputDevice
select count(*) as TotalRoleOutputDevice from GCS.RoleOutputDevice