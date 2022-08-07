using AutoMapper;
using Invoices.Api.Resources;
using Invoices.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductResource>();
            CreateMap<Invoice, InvoiceResource>().ForMember(x => x.InvoiceItemResource, x => x.MapFrom(x => x.InvoiceItems)) ;
            CreateMap<InvoiceItems, InvoiceItemResource>();
          
            // Resource to Domain
            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>();

            CreateMap<InvoiceResource, Invoice>().ForMember(x => x.InvoiceItems, x => x.MapFrom(x => x.InvoiceItemResource));
            CreateMap<SaveInvoiceResource, Invoice>().ForMember(x => x.InvoiceItems, x => x.MapFrom(x => x.SaveInvoiceItemResource));

            CreateMap<InvoiceItemResource, InvoiceItems>();
            CreateMap<SaveInvoiceItemResource, InvoiceItems>();
        }
    }
}