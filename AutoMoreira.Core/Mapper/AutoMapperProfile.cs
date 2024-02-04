namespace AutoMoreira.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();

            CreateMap<VehicleImage, VehicleImageDTO>().ReverseMap();

            CreateMap<Mark, MarkDTO>().ReverseMap();

            CreateMap<Model, ModelDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, UserLoginDTO>().ReverseMap();

            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<ClientMessage, ClientMessageDTO>().ReverseMap();

        }
    }
}
