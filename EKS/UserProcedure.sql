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
------------------------------------------------------------------------------------------------
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
------------------------------------------------------------------------------------------------
Create proc AuthorityProc --Kullanmadik
	@AutUserName varchar(50) = null,
	@AResult varchar(10) output
	as
	set nocount on;
	Select @AResult=AUTHORITY 
	from USERS 
	where USERNAME = @AutUserName;
	Return
	go
------------------------------------------------------------------------------------------------
create Procedure AVerify
	@Aut int output
	as
	declare @U int
	set @U = (Select COUNT(AUTHORITY) from USERS where AUTHORITY = 'ADMIN')
	if(@U >= 1)
	begin
		Set @Aut = 1;
	end
	else
	begin
		Set @Aut = 0;
	end
------------------------------------------------------------------------------------------------
	create proc AddValues
	@BOLGE nvarchar(20) = null,
	@MAKINA nvarchar(20) = null,
	@BILGISAYARLOKASYONU nvarchar(20) = null,
	@BACKUPADI nvarchar(max) = null,
	@BACKUPTARIHI datetime = null,
	@BACKUPPROGRAMADI nvarchar(20) = null,
	@BACKUPTIPI nchar(10) = null,
	@BACKUPVERSIYONU nchar(5) = null,
	@BACKUPALANPERSONEL nvarchar(20),
	@BACKUPNEDENI nvarchar(20) = null,
	@BILGISAYARMODELI nvarchar(25) = null,
	@ISLETIMSISTEMI nvarchar(15) = null,
	@HARDDISKBILGISI nvarchar(50) = null,
	@OTOMASYONIP nvarchar(15) = null,
	@MAKINAIP nvarchar(15) = null,
	@ACIKLAMALAR nvarchar(max) = null
	as
	INSERT INTO BACKUPANDRECOVERTABLE (BOLGE, MAKINA, [BILGISAYAR LOKASYONU],
	[BACKUP ADI], [BACKUP TARIHI], [BACKUP PROGRAM ADI], [BACKUP TIPI],
	[BACKUP VERSIYONU], [BACKUP ALAN PERSONEL], [BACKUP NEDENI], [BILGISAYAR MODELI],
	[ISLETIM SISTEMI], [HARDDISK BILGISI], [OTOMASYON IP], [MAKINA IP], ACIKLAMALAR)
	VALUES (@BOLGE, @MAKINA, @BILGISAYARLOKASYONU, @BACKUPADI, 
	@BACKUPTARIHI, @BACKUPPROGRAMADI, @BACKUPTIPI, @BACKUPVERSIYONU, @BACKUPALANPERSONEL,
	@BACKUPNEDENI, @BILGISAYARMODELI, @ISLETIMSISTEMI, @HARDDISKBILGISI, @OTOMASYONIP,
	@MAKINAIP, @ACIKLAMALAR)

	select BOLGE, MAKINA, [BILGISAYAR LOKASYONU],[BACKUP TARIHI], [KAYIT TARIHI], [BACKUP ALAN PERSONEL] from BACKUPANDRECOVERTABLE
------------------------------------------------------------------------------------------------
	
CREATE TABLE [dbo].[BACKUPANDRECOVERTABLE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BOLGE] [nvarchar](25) NOT NULL,
	[MAKINA] [nvarchar](50) NOT NULL,
	[BILGISAYAR LOKASYONU] [nvarchar](20) NOT NULL,
	[BACKUP ADI] [nvarchar](max) NOT NULL,
	[BACKUP TARIHI] [datetime] NOT NULL,
	[BACKUP PROGRAM ADI] [nvarchar](20) NOT NULL,
	[BACKUP TIPI] [nchar](10) NOT NULL,
	[BACKUP VERSIYONU] [nchar](5) NOT NULL,
	[KAYIT TARIHI] [datetime] NULL,
	[BACKUP ALAN PERSONEL] [nvarchar](20) NOT NULL,
	[BACKUP NEDENI] [nvarchar](20) NOT NULL,
	[BILGISAYAR MODELI] [nvarchar](25) NOT NULL,
	[ISLETIM SISTEMI] [nvarchar](15) NOT NULL,
	[HARDDISK BILGISI] [nvarchar](50) NOT NULL,
	[OTOMASYON IP] [nvarchar](15) NOT NULL,
	[MAKINA IP] [nvarchar](15) NOT NULL,
	[PETLAS IP] [nvarchar](15) NULL,
	[LISANS ID] [int] NOT NULL,
	[ACIKLAMALAR] [nvarchar](max) NULL,
 CONSTRAINT [PK_BACKUPANDRECOVERTABLE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[BACKUPANDRECOVERTABLE] ADD  DEFAULT (CONVERT([datetime],getdate(),(104))) FOR [KAYIT TARIHI]
GO

Drop Table BACKUPANDRECOVERTABLE
------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[USERS](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nchar](10) NOT NULL,
	[LASTNAME] [nchar](10) NOT NULL,
	[USERNAME] [nchar](10) NOT NULL,
	[PASSWORD] [nvarchar](50) NOT NULL,
	[AUTHORITY] [varchar](25) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[USERS] ADD  DEFAULT ('UNKNOWN USER') FOR [AUTHORITY]
GO

ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [_AUT] CHECK  (([AUTHORITY]='UNKNOWN USER' OR [AUTHORITY]='OTHER USER' OR [AUTHORITY]='USER' OR [AUTHORITY]='ADMIN'))
GO

ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [_AUT]

select * from BACKUPANDRECOVERTABLE
------------------------------------------------------------------------------------------------

Create proc MachineIsThere
	@bolge varchar (50)=null,
	@makina varchar (50) = null,
	@BLokasyon varchar (50)=null,
	@LNResult int output
as 	
	declare @LN int
	set @LN = (Select Count(BOLGE) from BACKUPANDRECOVERTABLE where BOLGE = @bolge and MAKINA = @makina and [BILGISAYAR LOKASYONU] = @BLokasyon)
	if(@LN > 0)
	begin
		set @LNResult = 1
	end
	else
	begin
		set @LNResult = 0
	end

	Select Count(BOLGE) from BACKUPANDRECOVERTABLE where BOLGE = '02 KALENDER' and MAKINA = 'ESK� ASTAR KALENDER' and [BILGISAYAR LOKASYONU] = 'PROFIL TARAYICI'

	select * from BACKUPANDRECOVERTABLE


	--------------------------------------------------------------------------------------------------

	Create Table LICENSE(
		[LICANSE ID] [int] identity(1,1) primary key NOT NULL,
		[DOSYA YOLU] [nvarchar](max) NOT NULL
	)

	select * from LICENSE

	drop table LICENSE

	----------------------------------------------------------------------------------------------------
