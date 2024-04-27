namespace AutoMoreira.Tests.Common
{
    public class BaseClassTests
    {
        #region private variables
        public readonly Faker _faker;
        public readonly ITestOutputHelper _output;
        public readonly string _culture;
        public readonly IMapper _mapper;

        #endregion
        public BaseClassTests(ITestOutputHelper output)
        {
            _culture = "en";
            _faker = new Faker(_culture);
            _output = output;

            AutoMoreira.Core.Mapper.AutoMapperProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            //AutoMapperExtensions.Init(_mapper);
        }
    }
}
