use master
go

Create database QuanLyQuanTraSua
go

use QuanLyQuanTraSua
go

--Food
--Table
--FoodCategory
--Acount
--Bill
--BillInfo
--

create table TableFood
(
	id int identity  primary key,
	name nvarchar(100) not null,
	status nvarchar(100) not null default N'TRỐNG' -- NULL || Da co nguoi
)
go

create table Account
(
	--id int identity  primary key,
	UserName nvarchar (100) not null primary key,
	DisplayName nvarchar (100) not null default N'GONZer',
	Password nvarchar (1000) not null default N'1',
	Type int not null default 0 --1:admin 0:staff
)
go

create table FoodCategory
(
	id int identity  primary key,
	name nvarchar(100) not null default N'Chưa đặt tên'
)
go

create table Food
(
	id int identity  primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
	idCategory int not null,
	price float not null default 0,
	Foreign key (idCategory) references FoodCategory(id)
)
go


create table Bill
(
	id int identity  primary key,
	DateCheckIn datetime not null,
	DateCheckOut datetime,
	idTable int not null,
	status int not null default 0, -- 1: da thanh toan 0:chua thanh toan
	Foreign key (idTable) references TableFood(id)
)
go

create table BillInfo
(
	id int identity  primary key,
	idBill int not null,
	idFood int not null,
	Count int not null default 0,
	Foreign key (idBill) references Bill(id),
	Foreign key (idFood) references Food(id)
)
go



insert into Account (UserName, DisplayName, Password, Type)
values
(
	N'admin',
	N'ADMIN',
	N'1962026656160185351301320480154111117132155',
	1
),
(
	N'staff',
	N'STAFF',
	N'1962026656160185351301320480154111117132155',
	0
)
go


create proc USP_GetAccountByUserName
@userName nvarchar (100)
as
begin
	select * from Account where UserName = @userName
end
go


create proc USP_Login
@userName nvarchar(100), @passWord nvarchar (100)
as
begin
	select * from Account where UserName = @userName and PassWord = @passWord 
end
go

insert into TableFood (name)
values
(N'Bàn 1'),
(N'Bàn 2'),
(N'Bàn 3'),
(N'Bàn 4'),
(N'Bàn 5'),
(N'Bàn 6'),
(N'Bàn 7'),
(N'Bàn 8'),
(N'Bàn 9'),
(N'Bàn 10')
go

create proc USP_GetTableList
as select * from TableFood
go


insert into FoodCategory (name)
values
(N'Trà trái cây'),
(N'Nước trái cây'),
(N'Sữa trái cây'),
(N'Trà Sữa'),
(N'Sữa chua uống'),
(N'Kem Mousse'),
(N'Trà xanh Nhật Bản'),
(N'Trà Đài Loan Đặc Biệt'),
(N'Đồ uống nóng'),
(N'Sô-cô-la & Cà phê')
go

insert into FoodCategory (name)
values
(N'EXTRA TOPPING')
GO


insert into Food (name, idCategory, price)
values
(N'Trà xanh/đen vị Bưởi',1,32000),
(N'Trà xanh/đen vị Mận',1,32000),
(N'Trà xanh/đen vị Ômai',1,32000),
(N'Trà xanh/đen vị Đào',1,32000),
(N'Trà xanh/đen vị Chanh dây',1,32000),
(N'Trà xanh/đen vị Dâu tây',1,32000),
(N'Trà xanh/đen vị Nho',1,32000),
(N'Trà xanh/đen vị Vải',1,32000),
(N'Trà xanh/đen vị Cam',1,32000),
(N'Trà xanh/đen vị Dứa',1,32000),
(N'Trà xanh/đen vị Xoài',1,32000),
(N'Trà xanh/đen vị Mật ong',1,32000),
(N'Trà xanh Kiwi',1,32000),
(N'Trà xanh vị Quất',1,32000),
(N'Trà Chanh Quất',1,39000),
(N'Trà Đào miếng',1,39000),
(N'Nước Kiwi lô hội',2,37000),
(N'Nước Nho lô hội',2,37000),
(N'Nước Vải lô hội',2,37000),
(N'Nước Mật ong lô hội',2,39000),
(N'Nước Chanh Mận',2,32000),
(N'Nước Chanh Mật ong',2,32000),
(N'Nước Bưởi',2,32000),
(N'Nước Chanh dây',2,32000),
(N'Nước Chanh Quất',2,39000),
(N'Sữa Xoài',3,39000),
(N'Sữa Đào',3,39000),
(N'Sữa Nho',3,39000),
(N'Sữa Dứa',3,39000), 
(N'Sữa Vải',3,39000),
(N'Sữa Dâu tây',3,39000),
(N'Sữa Chanh dây',3,39000),
(N'Hồng trà sữa',4,32000),
(N'Trà sữa vị hoa Nhài',4,32000),
(N'Trà xanh sữa',4,32000),
(N'Trà sữa Ô long',4,32000),
(N'Trà sữa Khoai môn',4,32000),
(N'Trà sữa Mật ong',4,32000),
(N'Trà sữa Trân châu',4,37000),
(N'Trà sữa Thạch rau câu',4,37000),
(N'Trà sữa Thạch dừa',4,37000),
(N'Trà sữa Thạch Pudding',4,37000),
(N'Trà sữa Lô hội',4,37000),
(N'Trà sữa Hokkaido',4,39000),
(N'Trà sữa Đường đen',4,39000),
(N'Trà sữa Hạt dẻ',4,39000),
(N'Trà sữa Va-ni',4,39000),
(N'Trà sữa Đậu đỏ',4,40000),
(N'Sữa chua uống vị Trà xanh',5,39000),
(N'Sữa chua uống vị Chanh',5,39000),
(N'Sữa chua uống vị Chanh dây',5,39000),
(N'Sữa chua uống vị Bưởi',5,39000),
(N'Sữa chua uống vị Nho',5,39000),
(N'Sữa chua uống vị Cam',5,39000),
(N'Sữa chua uống vị Dứa',5,39000),
(N'Sữa chua uống vị Xoài',5,39000),
(N'Sữa chua uống vị Dâu tây',5,39000),
(N'Sữa chua Dâu',5,39000),
(N'Kem Mousse Hồng Trà',6,35000),
(N'Kem Mousse Trà xanh',6,35000),
(N'Kem Mousse Cà phê',6,42000),
(N'Kem Mousse Sô-cô-la',6,42000),
(N'Kem Mousse Khoai môn',6,42000),
(N'Trà xanh Nhật Bản',7,32000),
(N'Trà xanh Nhật Bản Đậu đỏ',7,40000),
(N'Trà xanh Nhật Bản trân châu Pudding',7,42000),
(N'Trà xanh Nhật Bản Hokkaido',7,42000),
(N'Hồng trà',8,25000),
(N'Trà xanh',8,25000),
(N'Trà xanh hoa Nhài',8,25000),
(N'Trà Ô long',8,25000),
(N'Hồng trà Đường đen',8,32000),
(N'Trà Ô long Đường đen',8,32000),
(N'Trà Gừng',9,25000),
(N'Trà Gừng Long nhãn',9,32000),
(N'Trà sữa Gừng',9,32000),
(N'Trà sữa Long nhãn',9,32000),
(N'Trà Long nhãn',9,32000),
(N'Sô-cô-la',10,32000),
(N'Sô-cô-la Đậu đỏ',10,40000),
(N'Sô-cô-la Đường đen',10,39000),
(N'Sô-cô-la Hokkaido',10,39000),
(N'Cà phê Hokkaido',10,39000),
(N'Cà phê Mocha',10,39000),
(N'Cà phê Hạt dẻ',10,39000),
(N'Cà phê Va-ni',10,39000),
(N'Cà phê Đặc biệt',10,32000),
(N'Trân châu',11,5000),
(N'Thạch dừa',11,5000),
(N'Thạch lô hội',11,5000),
(N'Thạch rau câu',11,5000),
(N'Thạch Pudding',11,5000),
(N'Đậu đỏ',11,8000),
(N'Kem Mousse',11,10000),
(N'Trân châu trắng',11,10000)
go


/*insert into Bill
values
(Getdate(),Null,1,0),
(getdate(),Null,2,0),
(getdate(),getdate(),2,1)
go*/

/*insert into BillInfo
values
(1,1,2),
(1,3,4),
(1,5,1),
(2,22,2),
(3,37,2)
go*/

alter table bill
	add discount int
go

update bill set discount = 0

go

create Proc USP_InsertBill
@idTable int
as
begin
	insert Bill (DateCheckIn, DateCheckOut, idTable, status, discount)
	values
	(Getdate(),null,@idTable,0,0)
end
go

/*create Proc USP_InsertBillInfo
@idBill int , @idFood int , @count int
as
begin
	insert BillInfo (idBill, idFood, count)
	values
	(@idBill , @idFood , @count)
end
go*/

create proc USP_InsertBillInfo
@idBill int, @idFood int, @count int
as
begin
	declare @isExitsBillInfo int
	declare @foodCount int = 1

	select @isExitsBillInfo = id, @foodCount = b.count
	from BillInfo as b
	where idBill = @idBill and idFood = @idFood

	if (@isExitsBillInfo > 0) 
	begin 
		declare @newCount int = @foodCount + @count
		if (@newCount > 0)
			Update BillInfo set Count = @foodCount + @count where idFood = @idFood and idBill = @idBill
		else
			delete BillInfo where idBill = @idBill and idFood = @idFood
	end
	else
	begin
		insert BillInfo (idBill, idFood, Count)
		values (@idBill,@idFood,@count)
	end
end
go

/*select * from Account

USP_InsertBillInfo @idBill , @idFood , @count{ idBill , idFood , count }

go*/

CREATE trigger UTG_UpdateBillInfo
On BillInfo for insert , update 
as

begin
	declare @idBill int

	select @idBill = idBill From inserted 

	declare @idTable int

	select @idTable = idTable from Bill where id = @idBill and status = 0

	declare @count int

	select @count = count (*) from BillInfo where idBill=@idBill

	if (@count>0)

	update TableFood set status = N'Có người' where id = @idTable

	else

	update TableFood set status = N'TRỐNG' where id = @idTable

end
go


create  trigger UTG_UpdateBill
on Bill for update
as
begin
	declare @idBill int

	select @idBill = id from inserted

	declare @idTable int

	select @idTable = idTable from Bill where id = @idBill

	declare @count  int = 0

	select @count = count (*) from bill where idTable = @idTable  and status = 0

	if (@count = 0) 
		update TableFood set status = N'TRỐNG' where id = @idtable
end
go





CREATE  proc USP_SwitchTable

@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'TRỐNG' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'TRỐNG' WHERE id = @idTable1
END
go


alter table dbo.bill add totalPrice float
go

CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

create trigger UTG_DeleteBillInfo
on BillInfo for delete 
as
begin
	declare @idBillInfo int
	declare @idBill int

	select @idBillInfo =id, @idBill = deleted.idBill from deleted

	declare @idTable int

	select @idTable = idTable from Bill where id =@idBill

	declare @count int = 0

	select @count = COUNT(*) From BillInfo as bi, Bill as b where  b.id = bi.idBill  and b.id = @idBill and b.status = 0

	if (@count = 0)
		update TableFood set status = N'TRỐNG' where id = @idTable
end
go


CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

go
create PROC [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date,@page int

AS 
BEGIN
    DECLARE @pageRows INT=10
	DECLARE @selectRows INT=@pageRows
	DECLARE @exceptRow INT=(@page-1)* @pageRows
	;WITH BillShow As (SELECT b.ID ,t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)
	SELECT TOP (@selectRows)* from BillShow where id NOT IN(select TOP (@exceptRow) id From BillShow)
	
END
GO
CREATE PROC [dbo].[USP_GetNumListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT count(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO
CREATE PROC [dbo].[USP_GetListBillByDateReport]

AS 
BEGIN
	SELECT t.name , b.totalPrice , DateCheckIn , DateCheckOut , discount 
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE  b.status = 1
	AND t.id = b.idTable
END
GO


create Proc [dbo].[USP_PrintBillReport]
@idBill int
as
begin
	select TableFood.name, Bill.DateCheckIn, Bill.DateCheckOut, Food.name, BillInfo.Count, Food.price, Food.price*BillInfo.Count as totalPrice, Bill.discount
	from Bill, BillInfo, TableFood, Food
	where Bill.idTable = TableFood.id and BillInfo.idBill = @idBill and BillInfo.idFood = Food.id and BillInfo.idBill = Bill.id
	

end

go
