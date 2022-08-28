CREATE TABLE [dbo].[ReversedPhrase]
(
	[Id]				INT				NOT NULL IDENTITY(1,1),
	[OriginalText]	nvarchar(MAX)	NOT NULL,
	[ReversedText]	nvarchar(MAX)	NOT NULL,
	[Reversed]			datetime		NOT NULL
)
