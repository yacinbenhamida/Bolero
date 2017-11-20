CREATE TABLE [dbo].[Utilisateur] (
    [Id]              INT          NOT NULL,
    [Nom]             VARCHAR (50) NOT NULL,
    [password]        VARCHAR (50) NOT NULL,
    [questionsecrete] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

