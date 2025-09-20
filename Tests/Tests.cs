using App.Entidades;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private Biblioteca _biblioteca;
        private Libro _libro1;
        private Libro _libro2;

        [SetUp]
        public void Setup()
        {
            _biblioteca = new Biblioteca();
            _libro1 = new Libro("1984", "George Orwell");
            _libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry");
            _biblioteca.AgregarLibro(_libro1);
            _biblioteca.AgregarLibro(_libro2);
        }

        [Test]
        public void PrestarLibro_LibroDisponible_PrestaLibroCorrectamente()
        {
            // Act
            _biblioteca.PrestarLibro("1984");

            // Assert
            Assert.IsTrue(_libro1.EstaPrestado, "El libro debería estar marcado como prestado");
        }

        [Test]
        public void PrestarLibro_LibroNoDisponible_LanzaExcepcion()
        {
            // Arrange
            _biblioteca.PrestarLibro("1984");

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _biblioteca.PrestarLibro("1984"));
            Assert.That(ex.Message, Is.EqualTo("El libro ya está prestado."));
        }

        [Test]
        public void DevolverLibro_LibroPrestado_DevuelveLibroCorrectamente()
        {
            // Arrange
            _biblioteca.PrestarLibro("1984");

            // Act
            _biblioteca.DevolverLibro("1984");

            // Assert
            Assert.IsFalse(_libro1.EstaPrestado, "El libro debería estar disponible después de devolverlo");
        }

        [Test]
        public void DevolverLibro_LibroNoPrestado_LanzaExcepcion()
        {
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _biblioteca.DevolverLibro("1984"));
            Assert.That(ex.Message, Is.EqualTo("El libro no está prestado."));
        }

        [Test]
        public void PrestarLibro_LibroNoExiste_LanzaExcepcion()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _biblioteca.PrestarLibro("LibroInexistente"));
            Assert.That(ex.Message, Is.EqualTo("El libro no existe en la biblioteca."));
        }

        [Test]
        public void DevolverLibro_LibroNoExiste_LanzaExcepcion()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _biblioteca.DevolverLibro("LibroInexistente"));
            Assert.That(ex.Message, Is.EqualTo("El libro no existe en la biblioteca."));
        }
    }
}