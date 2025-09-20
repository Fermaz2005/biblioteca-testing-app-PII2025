using System;
using System.Collections.Generic;

namespace App.Entidades
{
    public class Biblioteca
    {
        private List<Libro> _libros;

        public Biblioteca()
        {
            _libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }

        public void PrestarLibro(string titulo)
        {
            var libro = _libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new ArgumentException("El libro no existe en la biblioteca.");

            libro.Prestar();
        }

        public void DevolverLibro(string titulo)
        {
            var libro = _libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new ArgumentException("El libro no existe en la biblioteca.");

            libro.Devolver();
        }

        public List<Libro> ObtenerLibros()
        {
            return _libros;
        }
    }
}