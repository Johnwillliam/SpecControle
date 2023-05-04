
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2023 16:40:29
-- Generated from EDMX file: D:\Projecten\MichaelTan\Systemair B.V\SpecificationsTesting\SpecificationsTesting\EntityFrameworkModel\SpecificationsDatabaseModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_CatTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_CatTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_CustomOrderMotors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_CustomOrderMotors];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_CustomOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_CustomOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilator_SoundLevelType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilator_SoundLevelType];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_GroupTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_GroupTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_TemperatureClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_TemperatureClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilators_VentilatorTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilators] DROP CONSTRAINT [FK_CustomOrderVentilators_VentilatorTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilatorTests_CustomOrderVentilators1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilatorTests] DROP CONSTRAINT [FK_CustomOrderVentilatorTests_CustomOrderVentilators1];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomOrderVentilatorTests_CustomOrderVentilators]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomOrderVentilatorTests] DROP CONSTRAINT [FK_CustomOrderVentilatorTests_CustomOrderVentilators];
GO
IF OBJECT_ID(N'[dbo].[FK_Ventilator_SoundLevelType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TemplateVentilators] DROP CONSTRAINT [FK_Ventilator_SoundLevelType];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateVentilators_VentilatorType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TemplateVentilators] DROP CONSTRAINT [FK_TemplateVentilators_VentilatorType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ATEXTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ATEXTypes];
GO
IF OBJECT_ID(N'[dbo].[CatTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatTypes];
GO
IF OBJECT_ID(N'[dbo].[CustomOrderMotors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomOrderMotors];
GO
IF OBJECT_ID(N'[dbo].[CustomOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomOrders];
GO
IF OBJECT_ID(N'[dbo].[CustomOrderVentilators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomOrderVentilators];
GO
IF OBJECT_ID(N'[dbo].[CustomOrderVentilatorTests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomOrderVentilatorTests];
GO
IF OBJECT_ID(N'[dbo].[GroupTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupTypes];
GO
IF OBJECT_ID(N'[dbo].[SoundLevelTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoundLevelTypes];
GO
IF OBJECT_ID(N'[dbo].[TemperatureClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemperatureClasses];
GO
IF OBJECT_ID(N'[dbo].[TemplateMotors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateMotors];
GO
IF OBJECT_ID(N'[dbo].[TemplateVentilators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateVentilators];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[VentilatorTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VentilatorTypes];
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

-- Creating table 'CatTypes'
CREATE TABLE [dbo].[CatTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomOrderMotors'
CREATE TABLE [dbo].[CustomOrderMotors] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NULL,
    [IEC] int  NULL,
    [IP] int  NULL,
    [BuildingType] nvarchar(max)  NULL,
    [ISO] nvarchar(max)  NULL,
    [HighPower] decimal(18,2)  NULL,
    [LowPower] decimal(18,2)  NULL,
    [HighRPM] int  NULL,
    [LowRPM] int  NULL,
    [HighAmperage] decimal(18,2)  NULL,
    [LowAmperage] decimal(18,2)  NULL,
    [StartupAmperage] decimal(18,2)  NULL,
    [VoltageType] nvarchar(max)  NULL,
    [Frequency] int  NULL,
    [PowerFactor] int  NULL
);
GO

-- Creating table 'CustomOrders'
CREATE TABLE [dbo].[CustomOrders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CustomOrderNumber] int  NOT NULL,
    [Debtor] nvarchar(max)  NULL,
    [Reference] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'CustomOrderVentilators'
CREATE TABLE [dbo].[CustomOrderVentilators] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CustomOrderID] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CustomOrderMotorID] int  NOT NULL,
    [VentilatorTypeID] int  NULL,
    [HighAirVolume] int  NULL,
    [LowAirVolume] int  NULL,
    [HighPressureTotal] int  NULL,
    [LowPressureTotal] int  NULL,
    [HighPressureStatic] int  NULL,
    [LowPressureStatic] int  NULL,
    [HighPressureDynamic] int  NULL,
    [LowPressureDynamic] int  NULL,
    [HighRPM] int  NULL,
    [LowRPM] int  NULL,
    [Efficiency] int  NULL,
    [HighShaftPower] decimal(18,2)  NULL,
    [LowShaftPower] decimal(18,2)  NULL,
    [SoundLevel] int  NULL,
    [SoundLevelTypeID] int  NULL,
    [BladeAngle] int  NULL,
    [Atex] nvarchar(max)  NULL,
    [GroupTypeID] int  NULL,
    [TemperatureClassID] int  NULL,
    [CatID] int  NULL,
    [CatOutID] int  NULL
);
GO

-- Creating table 'CustomOrderVentilatorTests'
CREATE TABLE [dbo].[CustomOrderVentilatorTests] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CustomOrderVentilatorID] int  NOT NULL,
    [MeasuredVentilatorHighRPM] int  NULL,
    [MeasuredVentilatorLowRPM] int  NULL,
    [MeasuredMotorHighRPM] int  NULL,
    [MeasuredMotorLowRPM] int  NULL,
    [MeasuredBladeAngle] int  NULL,
    [Cover] int  NULL,
    [MotorNumber] nvarchar(max)  NULL,
    [Weight] int  NULL,
    [Date] datetime  NULL,
    [UserID] int  NULL,
    [I1High] decimal(18,2)  NULL,
    [I1Low] decimal(18,2)  NULL,
    [I2High] decimal(18,2)  NULL,
    [I2Low] decimal(18,2)  NULL,
    [I3High] decimal(18,2)  NULL,
    [I3Low] decimal(18,2)  NULL,
    [BuildSize] int  NULL
);
GO

-- Creating table 'GroupTypes'
CREATE TABLE [dbo].[GroupTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
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

-- Creating table 'TemplateMotors'
CREATE TABLE [dbo].[TemplateMotors] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NULL,
    [Version] nvarchar(max)  NULL,
    [IEC] int  NULL,
    [IP] int  NULL,
    [BuildingType] nvarchar(max)  NULL,
    [ISO] nvarchar(max)  NULL,
    [HighPower] decimal(18,2)  NULL,
    [LowPower] decimal(18,2)  NULL,
    [HighRPM] int  NULL,
    [LowRPM] int  NULL,
    [HighAmperage] decimal(18,2)  NULL,
    [LowAmperage] decimal(18,2)  NULL,
    [StartupAmperage] decimal(18,2)  NULL,
    [VoltageType] nvarchar(max)  NULL,
    [Frequency] int  NULL,
    [PowerFactor] int  NULL
);
GO

-- Creating table 'TemplateVentilators'
CREATE TABLE [dbo].[TemplateVentilators] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [VentilatorTypeID] int  NULL,
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'VentilatorTypes'
CREATE TABLE [dbo].[VentilatorTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
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

-- Creating primary key on [ID] in table 'CatTypes'
ALTER TABLE [dbo].[CatTypes]
ADD CONSTRAINT [PK_CatTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomOrderMotors'
ALTER TABLE [dbo].[CustomOrderMotors]
ADD CONSTRAINT [PK_CustomOrderMotors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomOrders'
ALTER TABLE [dbo].[CustomOrders]
ADD CONSTRAINT [PK_CustomOrders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [PK_CustomOrderVentilators]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomOrderVentilatorTests'
ALTER TABLE [dbo].[CustomOrderVentilatorTests]
ADD CONSTRAINT [PK_CustomOrderVentilatorTests]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupTypes'
ALTER TABLE [dbo].[GroupTypes]
ADD CONSTRAINT [PK_GroupTypes]
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

-- Creating primary key on [ID] in table 'TemplateMotors'
ALTER TABLE [dbo].[TemplateMotors]
ADD CONSTRAINT [PK_TemplateMotors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateVentilators'
ALTER TABLE [dbo].[TemplateVentilators]
ADD CONSTRAINT [PK_TemplateVentilators]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VentilatorTypes'
ALTER TABLE [dbo].[VentilatorTypes]
ADD CONSTRAINT [PK_VentilatorTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CatID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_CatTypes]
    FOREIGN KEY ([CatID])
    REFERENCES [dbo].[CatTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_CatTypes'
CREATE INDEX [IX_FK_CustomOrderVentilators_CatTypes]
ON [dbo].[CustomOrderVentilators]
    ([CatID]);
GO

-- Creating foreign key on [CustomOrderMotorID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_CustomOrderMotors]
    FOREIGN KEY ([CustomOrderMotorID])
    REFERENCES [dbo].[CustomOrderMotors]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_CustomOrderMotors'
CREATE INDEX [IX_FK_CustomOrderVentilators_CustomOrderMotors]
ON [dbo].[CustomOrderVentilators]
    ([CustomOrderMotorID]);
GO

-- Creating foreign key on [CustomOrderID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_CustomOrders]
    FOREIGN KEY ([CustomOrderID])
    REFERENCES [dbo].[CustomOrders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_CustomOrders'
CREATE INDEX [IX_FK_CustomOrderVentilators_CustomOrders]
ON [dbo].[CustomOrderVentilators]
    ([CustomOrderID]);
GO

-- Creating foreign key on [SoundLevelTypeID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilator_SoundLevelType]
    FOREIGN KEY ([SoundLevelTypeID])
    REFERENCES [dbo].[SoundLevelTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilator_SoundLevelType'
CREATE INDEX [IX_FK_CustomOrderVentilator_SoundLevelType]
ON [dbo].[CustomOrderVentilators]
    ([SoundLevelTypeID]);
GO

-- Creating foreign key on [GroupTypeID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_GroupTypes]
    FOREIGN KEY ([GroupTypeID])
    REFERENCES [dbo].[GroupTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_GroupTypes'
CREATE INDEX [IX_FK_CustomOrderVentilators_GroupTypes]
ON [dbo].[CustomOrderVentilators]
    ([GroupTypeID]);
GO

-- Creating foreign key on [TemperatureClassID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_TemperatureClasses]
    FOREIGN KEY ([TemperatureClassID])
    REFERENCES [dbo].[TemperatureClasses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_TemperatureClasses'
CREATE INDEX [IX_FK_CustomOrderVentilators_TemperatureClasses]
ON [dbo].[CustomOrderVentilators]
    ([TemperatureClassID]);
GO

-- Creating foreign key on [VentilatorTypeID] in table 'CustomOrderVentilators'
ALTER TABLE [dbo].[CustomOrderVentilators]
ADD CONSTRAINT [FK_CustomOrderVentilators_VentilatorTypes]
    FOREIGN KEY ([VentilatorTypeID])
    REFERENCES [dbo].[VentilatorTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilators_VentilatorTypes'
CREATE INDEX [IX_FK_CustomOrderVentilators_VentilatorTypes]
ON [dbo].[CustomOrderVentilators]
    ([VentilatorTypeID]);
GO

-- Creating foreign key on [CustomOrderVentilatorID] in table 'CustomOrderVentilatorTests'
ALTER TABLE [dbo].[CustomOrderVentilatorTests]
ADD CONSTRAINT [FK_CustomOrderVentilatorTests_CustomOrderVentilators1]
    FOREIGN KEY ([CustomOrderVentilatorID])
    REFERENCES [dbo].[CustomOrderVentilators]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilatorTests_CustomOrderVentilators1'
CREATE INDEX [IX_FK_CustomOrderVentilatorTests_CustomOrderVentilators1]
ON [dbo].[CustomOrderVentilatorTests]
    ([CustomOrderVentilatorID]);
GO

-- Creating foreign key on [UserID] in table 'CustomOrderVentilatorTests'
ALTER TABLE [dbo].[CustomOrderVentilatorTests]
ADD CONSTRAINT [FK_CustomOrderVentilatorTests_CustomOrderVentilators]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomOrderVentilatorTests_CustomOrderVentilators'
CREATE INDEX [IX_FK_CustomOrderVentilatorTests_CustomOrderVentilators]
ON [dbo].[CustomOrderVentilatorTests]
    ([UserID]);
GO

-- Creating foreign key on [SoundLevelTypeID] in table 'TemplateVentilators'
ALTER TABLE [dbo].[TemplateVentilators]
ADD CONSTRAINT [FK_Ventilator_SoundLevelType]
    FOREIGN KEY ([SoundLevelTypeID])
    REFERENCES [dbo].[SoundLevelTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ventilator_SoundLevelType'
CREATE INDEX [IX_FK_Ventilator_SoundLevelType]
ON [dbo].[TemplateVentilators]
    ([SoundLevelTypeID]);
GO

-- Creating foreign key on [VentilatorTypeID] in table 'TemplateVentilators'
ALTER TABLE [dbo].[TemplateVentilators]
ADD CONSTRAINT [FK_TemplateVentilators_VentilatorType]
    FOREIGN KEY ([VentilatorTypeID])
    REFERENCES [dbo].[VentilatorTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TemplateVentilators_VentilatorType'
CREATE INDEX [IX_FK_TemplateVentilators_VentilatorType]
ON [dbo].[TemplateVentilators]
    ([VentilatorTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------