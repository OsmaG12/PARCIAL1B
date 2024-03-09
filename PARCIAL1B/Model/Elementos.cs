﻿using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.Model
{
    public class Elementos
    {
        [Key]
        public int ElementoID { get; set; }
        
        public int EmpresaID {  get; set; }
        public string Elemento { get; set;}
        public string CantidadMinima { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Costo { get; set; }
        public string Estado { get; set;}
        
    
    }
}
