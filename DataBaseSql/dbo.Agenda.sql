USE [Gerencia]
GO

/****** Object:  Table [dbo].[Agenda]    Script Date: 12/04/2020 20:16:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agenda](
	[AGENDA_ID] [int] IDENTITY(1,1) NOT NULL,
	[DATA_INICIO_D] [datetime] NOT NULL,
	[DATA_FIM_D] [datetime] NOT NULL,
	[INDR_STATUS_N] [numeric](1, 0) NOT NULL,
	[CLINICA_ID] [int] NOT NULL,
	[PACIENTE_ID] [int] NOT NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[AGENDA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Agenda]  WITH NOCHECK ADD  CONSTRAINT [FK_Agenda_Clinica] FOREIGN KEY([CLINICA_ID])
REFERENCES [dbo].[Pessoa] ([PESSOA_ID])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Clinica]
GO

ALTER TABLE [dbo].[Agenda]  WITH NOCHECK ADD  CONSTRAINT [FK_Agenda_Paciente] FOREIGN KEY([PACIENTE_ID])
REFERENCES [dbo].[Pessoa] ([PESSOA_ID])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Paciente]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id da Clínica' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agenda', @level2type=N'COLUMN',@level2name=N'CLINICA_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Paciente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agenda', @level2type=N'COLUMN',@level2name=N'PACIENTE_ID'
GO


