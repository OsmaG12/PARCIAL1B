using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.Model
{
    public class ElementosPorPlato
    {
        [Key]

        public int ElementoPorPlatoID { get; set; }
<<<<<<< HEAD
=======
        public int EmpresaID { get; set; }

>>>>>>> 602b26049149cfb7ff1396393ba3d11e26c4908d
        public int PlatoID { get; set; }
        public int  ElementoID { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set;  }


    }
}
