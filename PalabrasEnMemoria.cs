using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly List<string> _palabrasActuales;

        // Diccionario con las categorías y palabras sugeridas
        private readonly Dictionary<string, List<string>> _diccionarioCategorias = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Arquitectura", new List<string> { "arquitectura", "componente", "descomposición", "dependencia", "acoplamiento" } },
            { "POO", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstracción", "clase" } },
            { ".NET", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
        };

        public PalabrasEnMemoria()
        {
        }

        // El constructor recibe la categoría elegida y filtra la lista
        public PalabrasEnMemoria(string categoriaElegida)
        {
            if (_diccionarioCategorias.ContainsKey(categoriaElegida))
            {
                _palabrasActuales = _diccionarioCategorias[categoriaElegida];
            }
            else
            {
                // Valor por defecto en caso de que el usuario ingrese algo incorrecto
                _palabrasActuales = _diccionarioCategorias["Arquitectura"];
            }
        }

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();
            return _palabrasActuales[random.Next(_palabrasActuales.Count)];
        }
    }
}