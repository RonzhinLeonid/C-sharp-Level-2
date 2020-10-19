1. Создать БД с именем lesson7
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RonzhinL;Integrated Security=True;Pooling=False


2. Создать таблицу Department
CREATE TABLE [dbo].[Department] (
    [Id]          INT IDENTITY(0, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

3. Создать таблицу Employee
	CREATE TABLE [dbo].[Employee]
	(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    	[Name] NCHAR(20) NULL, 
    	[Suname] NCHAR(30) NULL, 
    	[Age] INT NULL, 
    	[Salary] INT NULL, 
    	[PhoneNumber] NCHAR(20) NULL, 
    	[DepartmentID] INT NULL
	)

4. Для заполнения тестовыми данными запустить LoadBD

