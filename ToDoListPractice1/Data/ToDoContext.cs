﻿using Microsoft.EntityFrameworkCore;
using ToDoListPractice1.Models;



namespace ToDoListPractice1.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        #region tablas
        public DbSet<Tarea> Tareas { get; set; } // Creacion de la tabla de tareas

        #endregion
    }
}
