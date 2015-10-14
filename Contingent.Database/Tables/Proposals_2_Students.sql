CREATE TABLE [dbo].[Proposals_2_Students]
(
	ProposalId uniqueidentifier not null,
	StudentId uniqueidentifier not null,
	constraint PK_Proposals_2_Students primary key clustered (ProposalId asc, StudentId asc),
	constraint FK_Proposals_2_Students_Proposals foreign key (ProposalId) references Proposals(Id) on delete cascade
)
