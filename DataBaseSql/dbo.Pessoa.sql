USE [Gerencia]
GO

/****** Object:  Table [dbo].[Pessoa]    Script Date: 12/04/2020 20:16:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pessoa](
	[PESSOA_ID] [int] IDENTITY(1,1) NOT NULL,
	[DESC_NOME_A] [varchar](200) NOT NULL,
	[DESC_TELEFONE_A] [varchar](20) NOT NULL,
	[DESC_CPFCNPJ_A] [varchar](20) NOT NULL,
	[DESC_ENDERECO_A] [varchar](200) NULL,
	[DESC_EMAIL_A] [varchar](100) NULL,
	[INDR_TIPO_A] [char](1) NOT NULL,
	[INDR_CONVENIO_A] [char](1) NULL,
	[DESC_CONVENIO_A] [varchar](100) NULL,
	[DESC_NUMCONVENIO_A] [varchar](100) NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[PESSOA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id da Pessoa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'PESSOA_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome da Pessoa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_NOME_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição Telefone' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_TELEFONE_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição CPF ou CNPJ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_CPFCNPJ_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do Endereço' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_ENDERECO_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_EMAIL_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador Tipo Pessoa: F-Física e J-Jurídica' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'INDR_TIPO_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador do Convênio: S-Sim e N-Não' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'INDR_CONVENIO_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome do Convênio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_CONVENIO_A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número do Convênio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pessoa', @level2type=N'COLUMN',@level2name=N'DESC_NUMCONVENIO_A'
GO


