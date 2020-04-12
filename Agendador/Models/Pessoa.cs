using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agendador.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            AgendaClinica = new HashSet<Agenda>();
            AgendaPaciente = new HashSet<Agenda>();
        }

        /// <summary>
        /// Id da Pessoa
        /// </summary>
        public int PessoaId { get; set; }

        /// <summary>
        /// Nome da Pessoa
        /// </summary>
        [Required (ErrorMessage = "Nome é obrigatório.")]
        [Display(Name = "Nome*")]
        public string DescNomeA { get; set; }

        /// <summary>
        /// Telefone da Pessoa
        /// </summary>
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [Display(Name = "Telefone*")]
        public string DescTelefoneA { get; set; }

        /// <summary>
        /// CPF ou CNPJ da Pessoa
        /// </summary>
        [Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório.")]
        [Display(Name = "CPF/CNPJ*")]
        public string DescCpfcnpjA { get; set; }

        /// <summary>
        /// Endereço da Pessoa
        /// </summary>
        [Display(Name ="Endereço")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public string DescEnderecoA { get; set; }

        /// <summary>
        /// Email da Pessoa
        /// </summary>
        [Display(Name="Email")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, entre com um email válido!")]
        public string DescEmailA { get; set; }

        /// <summary>
        /// Indicador de Tipo de Pessoa
        /// F - Física e J - Jurídica
        /// </summary>
        [Required(ErrorMessage ="Por favor, selecione um Tipo de Pessoa.")]
        public string IndrTipoA { get; set; }

        /// <summary>
        /// Indicador Pessoa Conveniada
        /// S - Sim e N - Não
        /// </summary>
        [Display(Name="Conveniado?")]
        public string IndrConvenioA { get; set; }

        /// <summary>
        /// Descrição do nome do Convênio da Pessoa
        /// </summary>
        [Display(Name="Nome do Convênio")]
        public string DescConvenioA { get; set; }

        /// <summary>
        /// Número do Convênio da Pessoa
        /// </summary>
        [Display(Name="Número do Convênio")]
        public string DescNumconvenioA { get; set; }

        /// <summary>
        /// Descrição para o Tipo de Pessoa
        /// </summary>
        [Display(Name = "Tipo de Pessoa")]
        public string DescTipoPessoa
        {
            get
            {
                if(IndrTipoA == "F")
                {
                    return "Física";
                }
                else if(IndrTipoA == "J")
                {
                    return "Jurídica";
                }
                else
                {
                    return "Desconhecido";
                }
            }
        }

        public virtual ICollection<Agenda> AgendaClinica { get; set; }
        public virtual ICollection<Agenda> AgendaPaciente { get; set; }
    }
}
