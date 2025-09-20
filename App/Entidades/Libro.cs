using System;

namespace App.Entidades
{
    public class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public bool EstaPrestado { get; private set; }

        public Libro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            EstaPrestado = false;
        }

        public void Prestar()
        {
            if (EstaPrestado)
                throw new InvalidOperationException("El libro ya está prestado.");

            EstaPrestado = true;
        }

        public void Devolver()
        {
            if (!EstaPrestado)
                throw new InvalidOperationException("El libro no está prestado.");

            EstaPrestado = false;
        }
    }
}