CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(18, 2) NOT NULL,
    DateCreated DATETIME DEFAULT GETDATE()
);

go

create procedure sp_products
(
	@Name NVARCHAR(100) ,
    @Description NVARCHAR(255),
    @Price DECIMAL(18, 2) ,
    @DateCreated DATETIME  
)
as
begin
	insert into Products(Name,Description,Price,DateCreated) values(@Name,@Description,@Price,@DateCreated)
End

go

create procedure sp_Update_products
(
	@Id INT,
	@Name NVARCHAR(100) ,
    @Description NVARCHAR(255),
    @Price DECIMAL(18, 2) ,
    @DateCreated DATETIME  
)
as
begin
	update Products set Name = @Name, Description = @Description ,Price = @Price ,DateCreated = @DateCreated where ID = @ID
End

go

create procedure sp_Get_products

as
begin
	select * from Products
End

go

create procedure sp_Delete_products
(@ID int)
as
begin
	delete  from Products where ID = @ID
End

go

create procedure sp_Get_ByID_products
(@ID int)
as
begin
	select * from Products where ID = @ID
End
