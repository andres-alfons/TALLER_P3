using System.Collections.Generic;

namespace ENTITY
{
    public interface IReservaRepository<T>
    {

        // se agrega un objeto al repositorio 
        string Agregar(T entity);

        //devuelve la lista de los objetos almacenados
        List<T> ObtenerTodas();

    }
}