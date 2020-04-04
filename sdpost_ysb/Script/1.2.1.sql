BEGIN TRANSACTION;
ALTER TABLE sdpost_Member rename to sdpost_Member_Old;
CREATE TABLE [sdpost_Member] (
	[ID] nvarchar(50) NOT NULL PRIMARY KEY, 
	[MemberNo] nvarchar(50), 
	[MemberName] nvarchar(50), 
	[PhoneNo] nvarchar(50), 
	[MemberType] nvarchar(50), 
	[IDNo] nvarchar(50), 
	[Address] nvarchar(254), 
	[Status] integer, 
	[Memo] nvarchar(50), 
	[CreateTime] datetime, 
	[UpdateTime] datetime, 
	[Modifier] nvarchar(50), 
	[Scores] float DEFAULT 0, 
	[Birthday] datetime,
	[ShortCode] nvarchar(50)
);
CREATE UNIQUE INDEX IF NOT EXISTS [Unique_PhoneNo]
	ON [sdpost_Member] ([PhoneNo]);
CREATE UNIQUE INDEX IF NOT EXISTS [Unique_MemberNo]
	ON [sdpost_Member] ([MemberNo]);
INSERT INTO [sdpost_Member]([ID],[MemberNo],[MemberName],[PhoneNo],[MemberType],[IDNo],[Address],[Status],[Memo],[CreateTime],[UpdateTime],[Modifier],[Scores],[Birthday],[ShortCode])
SELECT [ID],[MemberNo],[MemberName],[PhoneNo],[MemberType],[IDNo],[Address],[Status],[Memo],[CreateTime],[UpdateTime],[Modifier],[Scores],null,'' FROM sdpost_Member_Old;
DROP TABLE IF EXISTS sdpost_Member_Old;
COMMIT;