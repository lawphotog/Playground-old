
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2013 22:16:00
-- Generated from EDMX file: C:\MyProjects\DurhamUniversity\DurhamUniversity\DurhamUniEf.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DurhamUniversity];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_StudentCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseModule_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseModule] DROP CONSTRAINT [FK_CourseModule_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseModule_Module]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseModule] DROP CONSTRAINT [FK_CourseModule_Module];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Modules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modules];
GO
IF OBJECT_ID(N'[dbo].[CourseModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseModule];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Modules'
CREATE TABLE [dbo].[Modules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CourseModule'
CREATE TABLE [dbo].[CourseModule] (
    [Courses_Id] int  NOT NULL,
    [Modules_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [PK_Modules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Courses_Id], [Modules_Id] in table 'CourseModule'
ALTER TABLE [dbo].[CourseModule]
ADD CONSTRAINT [PK_CourseModule]
    PRIMARY KEY NONCLUSTERED ([Courses_Id], [Modules_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_StudentCourse]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse'
CREATE INDEX [IX_FK_StudentCourse]
ON [dbo].[Students]
    ([CourseId]);
GO

-- Creating foreign key on [Courses_Id] in table 'CourseModule'
ALTER TABLE [dbo].[CourseModule]
ADD CONSTRAINT [FK_CourseModule_Course]
    FOREIGN KEY ([Courses_Id])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Modules_Id] in table 'CourseModule'
ALTER TABLE [dbo].[CourseModule]
ADD CONSTRAINT [FK_CourseModule_Module]
    FOREIGN KEY ([Modules_Id])
    REFERENCES [dbo].[Modules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseModule_Module'
CREATE INDEX [IX_FK_CourseModule_Module]
ON [dbo].[CourseModule]
    ([Modules_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------