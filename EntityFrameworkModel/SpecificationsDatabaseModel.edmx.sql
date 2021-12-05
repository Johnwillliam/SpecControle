
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2021 15:43:59
-- Generated from EDMX file: D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\EntityFrameworkModel\SpecificationsDatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpecificationsTesting];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomOrder_ATEXType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrder] DROP CONSTRAINT [FK_CustomOrder_ATEXType];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrder_GroupType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrder] DROP CONSTRAINT [FK_CustomOrder_GroupType];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrder_TemperatureClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrder] DROP CONSTRAINT [FK_CustomOrder_TemperatureClass];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrder_Ventilator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrder] DROP CONSTRAINT [FK_CustomOrder_Ventilator];
GO
IF OBJECT_ID(N'[dbo].[FK_Motor_VoltageType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Motor] DROP CONSTRAINT [FK_Motor_VoltageType];
GO
IF OBJECT_ID(N'[dbo].[FK_Ventilator_Motor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ventilator] DROP CONSTRAINT [FK_Ventilator_Motor];
GO
IF OBJECT_ID(N'[dbo].[FK_Ventilator_SoundLevelType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ventilator] DROP CONSTRAINT [FK_Ventilator_SoundLevelType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ATEXType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ATEXType];
GO
IF OBJECT_ID(N'[dbo].[CustomOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomOrder];
GO
IF OBJECT_ID(N'[dbo].[GroupType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupType];
GO
IF OBJECT_ID(N'[dbo].[Motor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Motor];
GO
IF OBJECT_ID(N'[dbo].[SoundLevelType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoundLevelType];
GO
IF OBJECT_ID(N'[dbo].[TemperatureClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemperatureClass];
GO
IF OBJECT_ID(N'[dbo].[Ventilator]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ventilator];
GO
IF OBJECT_ID(N'[dbo].[VoltageType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoltageType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ATEXTypes'
CREATE TABLE [dbo].[ATEXTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomOrders'
CREATE TABLE [dbo].[CustomOrders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CustomOrderNumber] int  NOT NULL,
    [Type] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Debtor] nvarchar(max)  NULL,
    [Reference] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [VentilatorID] int  NULL,
    [ATEXTypeID] int  NULL,
    [GroupTypeID] int  NULL,
    [TemperatureClassID] int  NULL
);
GO

-- Creating table 'GroupTypes'
CREATE TABLE [dbo].[GroupTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Motors'
CREATE TABLE [dbo].[Motors] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [TypeID] int  NOT NULL,
    [Version] nvarchar(max)  NULL,
    [IEC] int  NULL,
    [IP] int  NULL,
    [BuildingType] nvarchar(max)  NULL,
    [ISO] nvarchar(max)  NULL,
    [Power] decimal(18,2)  NULL,
    [RPM] int  NULL,
    [Amperage] int  NULL,
    [StartupAmperage] int  NULL,
    [VoltageTypeID] int  NULL,
    [Frequency] int  NULL,
    [PowerFactor] int  NULL
);
GO

-- Creating table 'SoundLevelTypes'
CREATE TABLE [dbo].[SoundLevelTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [UOM] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TemperatureClasses'
CREATE TABLE [dbo].[TemperatureClasses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(max)  NOT NULL
);
GO

-- Creating table 'Ventilators'
CREATE TABLE [dbo].[Ventilators] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MotorID] int  NOT NULL,
    [AirVolume] int  NULL,
    [PressureTotal] int  NULL,
    [PressureStatic] int  NULL,
    [PressureDynamic] int  NULL,
    [RPM] int  NULL,
    [Efficiency] int  NULL,
    [ShaftPower] int  NULL,
    [SoundLevel] int  NULL,
    [SoundLevelTypeID] int  NULL,
    [BladeAngle] int  NULL
);
GO

-- Creating table 'VoltageTypes'
CREATE TABLE [dbo].[VoltageTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Voltage] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ATEXTypes'
ALTER TABLE [dbo].[ATEXTypes]
ADD CONSTRAINT [PK_ATEXTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [PK_CustomOrders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupTypes'
ALTER TABLE [dbo].[GroupTypes]
ADD CONSTRAINT [PK_GroupTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Motors'
ALTER TABLE [dbo].[Motors]
ADD CONSTRAINT [PK_Motors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SoundLevelTypes'
ALTER TABLE [dbo].[SoundLevelTypes]
ADD CONSTRAINT [PK_SoundLevelTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemperatureClasses'
ALTER TABLE [dbo].[TemperatureClasses]
ADD CONSTRAINT [PK_TemperatureClasses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Ventilators'
ALTER TABLE [dbo].[Ventilators]
ADD CONSTRAINT [PK_Ventilators]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VoltageTypes'
ALTER TABLE [dbo].[VoltageTypes]
ADD CONSTRAINT [PK_VoltageTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ATEXTypeID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [FK_CustomOrder_ATEXType]
    FOREIGN KEY ([ATEXTypeID])
    REFERENCES [dbo].[ATEXTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrder_ATEXType'
CREATE INDEX [IX_FK_CustomOrder_ATEXType]
ON [dbo].[CustomOrders]
    ([ATEXTypeID]);
GO

-- Creating foreign key on [GroupTypeID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [FK_CustomOrder_GroupType]
    FOREIGN KEY ([GroupTypeID])
    REFERENCES [dbo].[GroupTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrder_GroupType'
CREATE INDEX [IX_FK_CustomOrder_GroupType]
ON [dbo].[CustomOrders]
    ([GroupTypeID]);
GO

-- Creating foreign key on [TemperatureClassID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [FK_CustomOrder_TemperatureClass]
    FOREIGN KEY ([TemperatureClassID])
    REFERENCES [dbo].[TemperatureClasses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrder_TemperatureClass'
CREATE INDEX [IX_FK_CustomOrder_TemperatureClass]
ON [dbo].[CustomOrders]
    ([TemperatureClassID]);
GO

-- Creating foreign key on [VentilatorID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [FK_CustomOrder_Ventilator]
    FOREIGN KEY ([VentilatorID])
    REFERENCES [dbo].[Ventilators]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrder_Ventilator'
CREATE INDEX [IX_FK_CustomOrder_Ventilator]
ON [dbo].[CustomOrders]
    ([VentilatorID]);
GO

-- Creating foreign key on [VoltageTypeID] in table 'Motors'
ALTER TABLE [dbo].[Motors]
ADD CONSTRAINT [FK_Motor_VoltageType]
    FOREIGN KEY ([VoltageTypeID])
    REFERENCES [dbo].[VoltageTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Motor_VoltageType'
CREATE INDEX [IX_FK_Motor_VoltageType]
ON [dbo].[Motors]
    ([VoltageTypeID]);
GO

-- Creating foreign key on [MotorID] in table 'Ventilators'
ALTER TABLE [dbo].[Ventilators]
ADD CONSTRAINT [FK_Ventilator_Motor]
    FOREIGN KEY ([MotorID])
    REFERENCES [dbo].[Motors]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ventilator_Motor'
CREATE INDEX [IX_FK_Ventilator_Motor]
ON [dbo].[Ventilators]
    ([MotorID]);
GO

-- Creating foreign key on [SoundLevelTypeID] in table 'Ventilators'
ALTER TABLE [dbo].[Ventilators]
ADD CONSTRAINT [FK_Ventilator_SoundLevelType]
    FOREIGN KEY ([SoundLevelTypeID])
    REFERENCES [dbo].[SoundLevelTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ventilator_SoundLevelType'
CREATE INDEX [IX_FK_Ventilator_SoundLevelType]
ON [dbo].[Ventilators]
    ([SoundLevelTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------