USE [DIGPES]
GO

/****** Objeto: Table [dbo].[Pesquisa] Data do Script: 20/05/2018 13:56:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pesquisa] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [OS]             INT            NOT NULL,
    [Codigo_Produto] NVARCHAR (50)  NOT NULL,
    [Nome]           NVARCHAR (50)  NOT NULL,
    [Data]           DATE           NOT NULL,
    [QuestaoA]       INT            NULL,
    [QuestaoB]       INT            NULL,
    [QuestaoC]       INT            NULL,
    [QuestaoD]       INT            NULL,
    [QuestaoE]       INT            NULL,
    [Justificativa]  NVARCHAR (500) NULL
);


