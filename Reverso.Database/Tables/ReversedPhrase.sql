CREATE TABLE [dbo].[ReversedPhrase]
(
	[Id]				INT				NOT NULL IDENTITY(1,1),
	[OriginalPhrase]	nvarchar(MAX)	NOT NULL,
	[ReversedPhrase]	nvarchar(MAX)	NOT NULL,
	[Reversed]			datetime		NOT NULL
)
