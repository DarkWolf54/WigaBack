using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using apiWigaPrueba.Models;


namespace apiWigaPrueba.DTOs
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(x => x.Facturas, o => o.Ignore())
                .ReverseMap();

            CreateMap<Factura, FacturaDTO>()
                 .ForMember(x => x.Detalles, o => o.Ignore())
                 .ReverseMap();

            CreateMap<DetalleFactura, DetalleFacturaDTO>()
                 .ReverseMap();

            CreateMap<Producto, ProductoDTO>()
                 .ForMember(x => x.Detalles, o => o.Ignore())
                 .ReverseMap();
        }
        //public static void Configure()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Cliente, ClienteDTO>()
        //           .ForMember(x => x.Facturas, o => o.Ignore())
        //           .ReverseMap();

        //        cfg.CreateMap<Factura, FacturaDTO>()
        //           .ForMember(x => x.Detalles, o => o.Ignore())
        //           .ReverseMap();

        //        cfg.CreateMap<DetalleFactura, DetalleFacturaDTO>()
        //           .ReverseMap();

        //        cfg.CreateMap<Producto, ProductoDTO>()
        //           .ForMember(x => x.Detalles, o => o.Ignore())
        //           .ReverseMap();
        //    });
        //}
    }
}
