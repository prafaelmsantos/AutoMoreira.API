namespace AutoMoreira.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //Ele cria do evento para o DTO e do DTO para o Evento
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();

            CreateMap<Marca, MarcaDTO>().ReverseMap();

            CreateMap<Modelo, ModeloDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, UserLoginDTO>().ReverseMap();

            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<Contacto, ContactoDTO>().ReverseMap();

        }
    }
}
