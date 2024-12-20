use cafeteriaDB
go

create or alter view V_Menu
as
	select id menuID, Title menuName, ParentId menuParent
    from AspNetMenu
go

create or alter view V_Role_Menu
as
	select distinct anr.Name roleName, anrm.MenuId menuID, anrm.Id rolemenuID, p.Id permissionID
    from AspNetRoles anr, AspNetRoleMenu anrm, Permission p, MenuPermission mp
    where anr.id = anrm.RoleId
        and p.Id = mp.PermissionId
        and mp.RoleMenuId = anrm.Id
go

create or alter view V_MenuRolePerm
as
	select distinct anr.Name roleName, anrm.MenuId menuID, anrm.Id rolemenuID, p.Id permissionID, anm.Title menuName
    from AspNetRoles anr, AspNetRoleMenu anrm, Permission p, MenuPermission mp, AspNetMenu anm
    where anr.id = anrm.RoleId
        and p.Id = mp.PermissionId
        and mp.RoleMenuId = anrm.Id
        and anm.Id = anrm.MenuId
go

create or alter view V_Role
as
    SELECT 
        anr.Id AS RoleID, 
        anr.Name AS RoleName, 
        COUNT(anu.Id) AS UserCount
    FROM 
        AspNetRoles anr
    LEFT JOIN 
        AspNetUserRoles anur ON anr.Id = anur.RoleId
    LEFT JOIN 
        AspNetUsers anu ON anur.UserId = anu.Id
    GROUP BY 
        anr.Id, anr.Name;
go

create or alter view V_Permission_RoleMenu
as
	select distinct mp.RoleMenuId rolemenuID, p.Name permissionName, p.id permissionID
    from MenuPermission mp, Permission p
    where mp.PermissionId = p.Id
go

create or alter view V_RoleMenuPerm
as
	select distinct 
        vrole.RoleID, vrole.RoleName, UserCount, anm.Id MenuID, anm.Title MenuName, p.Id PermID, p.Name PermName
    from 
        V_Role vrole inner join AspNetRoleMenu anrm on vrole.RoleID = anrm.RoleId
                    inner join AspNetMenu anm on anrm.MenuId = anm.Id
                    inner join MenuPermission mp on anrm.Id = mp.RoleMenuId
                    inner join Permission p on mp.PermissionId = p.Id
go

create or alter view V_User_Role
as
	select distinct users.UserName UserName, roles.Name RoleName
    from AspNetUsers users, AspNetUserRoles userRoles, AspNetRoles roles
    where users.Id = userRoles.UserId
        and userRoles.RoleId = roles.Id
go

Create Or Alter Proc sp_TakeRoleFromUser
    @UserName nvarchar(50)
AS
BEGIN
    Select RoleName
    From V_User_Role
    Where UserName = @UserName
END

exec sp_TakeRoleFromUser 'deeznut2@example.com';
go

Create Or Alter Proc sp_UpdateRoleMenuPerms
    @RoleID nvarchar(50),
    @MenuID int,
    @PermID int
AS
BEGIN
    Update MenuPermission
    Set PermissionId = @PermID
    From AspNetRoleMenu anrm
    Where anrm.MenuId = @MenuID
        and anrm.RoleId = @RoleID
        and anrm.Id = RoleMenuId
END

--exec sp_UpdateRoleMenuPerms '2077F726-A824-4785-A394-010BB886CE69', 1, 2;