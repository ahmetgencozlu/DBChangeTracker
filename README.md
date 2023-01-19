# DB Change Tracker
Bu proje belirtmiş olduğunu Connection String (Database) deki kod içerisinde verdiğiniz tablo isimlerine göre bir broker işlemi görmektedir. Sadece deneme amaçlı bir Tutorial çalışmasıdır.

 1. Adım
MSSql veri tabanında kendinize ait bir katalog oluşturun.

    Create DATABASE DBChangeTracker

 2. Adım
Oluşturmuş olduğunuz kataloğun Service Broker özelliğini aktif edin.

    ALTER DATABASE DBChangeTracker SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE

 3. Adım
DB de tablonuzu oluşturun.

    CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[PhoneNumber] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
	[IsPhoneAllowed] [varchar](5) NOT NULL,
	[IsEmailAllowed] [varchar](5) NOT NULL,
	[IsCallAllowed] [varchar](5) NOT NULL
)

 4. Adım
Proje içerisinde Connection String kısmının doğru olduğundan emin olun.

 5. Adım
Projeyi çalıştırın ve DB deki tablonuza CRUD işlemleri uygulayın.
