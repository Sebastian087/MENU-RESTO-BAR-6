﻿using MENU_RESTO_BAR_6.Models;
using Microsoft.EntityFrameworkCore;

namespace MENU_RESTO_BAR_6.Context

{



    public class CafeDel6DbContext : DbContext
    {
        public CafeDel6DbContext(DbContextOptions<CafeDel6DbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cancelacion> Cancelacion { get; set; }

        public DbSet<CarritoItem> CarritoItems { get; set; }

        public DbSet<Carrito> Carritos { get; set; }



    }

}

