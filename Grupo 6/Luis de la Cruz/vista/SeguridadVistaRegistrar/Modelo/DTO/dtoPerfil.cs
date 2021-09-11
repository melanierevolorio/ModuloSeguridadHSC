namespace Modelo.DTO
{
    public class dtoPerfil
    {
        public string pkId { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }

        public dtoPerfil()
        {
        }


        public dtoPerfil(string Id, string Nombre, string Estado)
        {
            pkId = Id;
            nombre = Nombre;
            estado = Estado;
            //para cuando sean ints
            //int numeroValor = 0;
            //int.TryParse(numero, out numeroValor);
            //Numero = numeroValor;
        }
    }

}