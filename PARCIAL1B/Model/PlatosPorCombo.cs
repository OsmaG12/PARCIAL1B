using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.Model
{
    public class PlatosPorCombo
    {
        [Key]

        public int PlatosPorComboID { get; set; }
        public int EmpresaID { get; set; }

        public int PlatoID { get; set; }
        public string Estado { get; set; }

        
    }
}
