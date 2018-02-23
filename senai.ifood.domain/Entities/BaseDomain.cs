using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.ifood.domain.Entities
{
    public abstract class BaseDomain
    {
        //BAIXAR PACOTE DO NUGET PARA UTILIZAR O ANNOTATIONS (System.Component.Annotations)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        
    }
}