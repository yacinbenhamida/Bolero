CREATE TABLE [dbo].[staff] (
    [id]              INT          NOT NULL,
    [username]        VARCHAR (20) NOT NULL,
    [password]        VARCHAR (20) NOT NULL,
    [questionsecrete] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

