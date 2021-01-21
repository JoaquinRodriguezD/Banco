﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banco.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BancoEntities : DbContext
    {
        public BancoEntities()
            : base("name=BancoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bitacora> bitacora { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<cuenta> cuenta { get; set; }
    
        public virtual int borrar_cliente(Nullable<int> no_cuenta)
        {
            var no_cuentaParameter = no_cuenta.HasValue ?
                new ObjectParameter("no_cuenta", no_cuenta) :
                new ObjectParameter("no_cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("borrar_cliente", no_cuentaParameter);
        }
    
        public virtual int deposito(Nullable<int> no_cuenta, Nullable<int> monto)
        {
            var no_cuentaParameter = no_cuenta.HasValue ?
                new ObjectParameter("no_cuenta", no_cuenta) :
                new ObjectParameter("no_cuenta", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deposito", no_cuentaParameter, montoParameter);
        }
    
        public virtual int ingresar_cliente(string nombre, string apellido_p, string apellido_m, string telefono_cliente, Nullable<System.DateTime> fecha_nacimiento, Nullable<int> nip)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellido_pParameter = apellido_p != null ?
                new ObjectParameter("apellido_p", apellido_p) :
                new ObjectParameter("apellido_p", typeof(string));
    
            var apellido_mParameter = apellido_m != null ?
                new ObjectParameter("apellido_m", apellido_m) :
                new ObjectParameter("apellido_m", typeof(string));
    
            var telefono_clienteParameter = telefono_cliente != null ?
                new ObjectParameter("telefono_cliente", telefono_cliente) :
                new ObjectParameter("telefono_cliente", typeof(string));
    
            var fecha_nacimientoParameter = fecha_nacimiento.HasValue ?
                new ObjectParameter("fecha_nacimiento", fecha_nacimiento) :
                new ObjectParameter("fecha_nacimiento", typeof(System.DateTime));
    
            var nipParameter = nip.HasValue ?
                new ObjectParameter("nip", nip) :
                new ObjectParameter("nip", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ingresar_cliente", nombreParameter, apellido_pParameter, apellido_mParameter, telefono_clienteParameter, fecha_nacimientoParameter, nipParameter);
        }
    
        public virtual int retiro(Nullable<int> no_cuenta, Nullable<int> monto)
        {
            var no_cuentaParameter = no_cuenta.HasValue ?
                new ObjectParameter("no_cuenta", no_cuenta) :
                new ObjectParameter("no_cuenta", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("retiro", no_cuentaParameter, montoParameter);
        }
    
        public virtual int transferencia(Nullable<int> no_cuenta, Nullable<int> no_cuenta2, Nullable<int> monto)
        {
            var no_cuentaParameter = no_cuenta.HasValue ?
                new ObjectParameter("no_cuenta", no_cuenta) :
                new ObjectParameter("no_cuenta", typeof(int));
    
            var no_cuenta2Parameter = no_cuenta2.HasValue ?
                new ObjectParameter("no_cuenta2", no_cuenta2) :
                new ObjectParameter("no_cuenta2", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("transferencia", no_cuentaParameter, no_cuenta2Parameter, montoParameter);
        }
    }
}
