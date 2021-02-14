using AutoMapper;
using SaleOrganizer.Application.DTOs;
using SaleOrganizer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cloth, ClothDto>();
            CreateMap<Offering, OfferingDto>();
            CreateMap<Purchase, PurchaseDto>();
            CreateMap<ClothStatus, ClothStatusDto>();
            CreateMap<TradeType, TradeTypeDto>();
            CreateMap<DeliveryType, DeliveryTypeDto>();
        }
    }
}
