Create proc ULNReg
	@name varchar (50)=null,
	@lastname varchar (50) = null,
	@username varchar (50)=null,
	@LNResult int output,
	@UResult int output
as 	
	declare @LN int
	declare @U int
	set @LN = (Select Count(NAME) from USERS where NAME = @name and LASTNAME = @lastname)
	set @U = (Select Count(USERNAME) from USERS where USERNAME = @username)
	if(@LN >= 1)
	begin
		set @LNResult = 1
	end
	else
	begin
		set @LNResult = 0
	end
	if(@U >= 1)
	begin
		set @UResult = 1
	end
	else
	begin
		set @UResult = 0
	end

Create proc ULNVerify
	@username varchar(50) = null,
	@password varchar(50) = null,
	@UResult int output
as
	declare @U int
	set @U = (select COUNT(USERNAME) from USERS where USERNAME = @username and [PASSWORD] = @password)
	if(@U >= 1)
	begin
		set @UResult = 1
	end
	else
	begin
		set @UResult = 0
	end