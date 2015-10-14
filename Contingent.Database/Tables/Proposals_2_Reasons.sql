CREATE TABLE [dbo].Proposals_2_Reasons
(
	ProposalId uniqueidentifier not null,
	ReasonId int not null,
	[Values] xml,
	constraint PK_Proposals_2_Reasons primary key clustered (ProposalId asc, ReasonId asc),
	constraint FK_Proposals_2_Reasons_Proposals foreign key (ProposalId) references Proposals(Id) on delete cascade,
	constraint FK_Proposals_2_Reasons_Actions foreign key (ReasonId) references Reasons(Id)
)
