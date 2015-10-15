CREATE TABLE [dbo].[Orders]
(
	[Id] uniqueidentifier not null,
	ProposalId uniqueidentifier not null,
	RefNumber nvarchar(100) ,
	SignedBy nvarchar(100),
	SignedOn date not null,
	Comments nvarchar(1000),
	constraint PK_Orders primary key clustered (Id asc),
	constraint FK_Orders_Proposals foreign key (ProposalId) references Proposals(Id)
)
