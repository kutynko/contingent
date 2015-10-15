CREATE TABLE [dbo].[Proposals_2_Actions]
(
	ProposalId uniqueidentifier not null,
	ActionId int not null,
	[Values] xml,
	constraint PK_Proposals_2_Actions primary key clustered (ProposalId asc, ActionId asc),
	constraint FK_Proposals_2_Actions_Proposals foreign key (ProposalId) references Proposals(Id) on delete cascade,
	constraint FK_Proposals_2_Actions_Actions foreign key (ActionId) references Actions(Id)
)
