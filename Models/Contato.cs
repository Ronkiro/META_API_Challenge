using System.ComponentModel.DataAnnotations;


namespace ContatoAPI.Models
{
    public class Contato  
    {  
        [Key]
        public string IdContato { get; set; }  
        public string Nome { get; set; }  
        public string Canal { get; set; }  
        public string Valor { get; set; }  
        public string Obs { get; set; }
    }  
}