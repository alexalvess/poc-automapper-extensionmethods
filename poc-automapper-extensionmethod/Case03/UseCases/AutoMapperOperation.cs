using AutoMapper;
using poc_automapper_extensionmethod.Case03.Entities;
using poc_automapper_extensionmethod.Case03.Enum;
using poc_automapper_extensionmethod.Case03.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case03.UseCases
{
    public static class AutoMapperOperation
    {
        public static void Start()
        {
            Execution.Execute((i) => {
                if (i == 1)
                    WithMapper<UserModel, User>(InitializeAutomapper(), Mock.GenerateMock().First(), i);
                else
                    WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(i), i);
            });
        }

        public static void WithMapper<TSource, TDestiny>(Mapper mapper, TSource source, int quantity) =>
            RunCases.Execute(() => mapper.Map<TDestiny>(source), "AutoMapper", quantity);

        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactModel, Contact>()
                    .ForMember(dest => dest.ContactType, opt => opt.MapFrom(s => (ContactType)s.ContactType))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Contact));

                cfg.CreateMap<AddressModel, Address>()
                    .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(s => s.Identifier))
                    .ForMember(dest => dest.Street, opt => opt.MapFrom((s, d) => s.Address.Split(";")[0]))
                    .ForMember(dest => dest.Number, opt => opt.MapFrom((s, d) => s.Address.Split(";")[1]));
                
                cfg.CreateMap<UserModel, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                    .ForMember(dest => dest.Score, opt => opt.MapFrom(s => s.Points))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(s => s.BornAt))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(s => s.Location))
                    .ForMember(dest => dest.Contacts, opt => opt.MapFrom(s => s.ContactList));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
