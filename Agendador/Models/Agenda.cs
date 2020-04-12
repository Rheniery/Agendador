using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agendador.Models
{
    /// <summary>
    /// Enumerador para Status da Consulta
    /// </summary>
    public enum EnumStatus
    {
        [Display(Name ="Aguardando Atendimento")]
        AguardandoAtendimento = 1,
        [Display(Name ="Atendido")]
        Atendido = 2,
        [Display(Name ="Não Compareceu")]
        NaoCompareceu = 3,
        [Display(Name ="Cancelado pelo Usuário")]
        CanceladoUsuario = 4,
        [Display(Name ="Cancelado pelo Clínica")]
        CanceladoClinica = 5
    }

    public partial class Agenda
    {
        /// <summary>
        /// Id da Consulta
        /// </summary>
        public int AgendaId { get; set; }

        /// <summary>
        /// Data e Hora Inicial da Consulta
        /// </summary>
        [Display(Name ="Data e Hora de Início")]
        [DataType(DataType.DateTime, ErrorMessage = "Por favor, entre com uma data válida!")]
        public DateTime DataInicioD { get; set; }

        /// <summary>
        /// Data e Hora Final da Consulta
        /// </summary>
        [Display(Name = "Data e Hora do Fim")]
        [DataType(DataType.DateTime, ErrorMessage = "Por favor, entre com uma data válida!")]
        public DateTime DataFimD { get; set; }

        /// <summary>
        /// Indicador de Status da Consulta
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione um status.")]
        [EnumDataType(typeof(EnumStatus))]
        [Display(Name = "Status")]
        public EnumStatus IndrStatusN { get; set; }

        /// <summary>
        /// Id da Clínica
        /// </summary>
        [Display(Name ="Clínica")]
        [Required(ErrorMessage ="Por favor, selecione uma Clínica.")]
        public int ClinicaId { get; set; }

        /// <summary>
        /// Id do Paciente
        /// </summary>
        [Display(Name ="Paciente")]
        [Required(ErrorMessage = "Por favor, selecione um Paciente.")]
        public int PacienteId { get; set; }

        /// <summary>
        /// Objeto Pessoa Clinica da Consulta
        /// </summary>
        public virtual Pessoa Clinica { get; set; }
        /// <summary>
        /// Objeto Pessoa Paciente da Consulta
        /// </summary>
        public virtual Pessoa Paciente { get; set; }
    }
}
