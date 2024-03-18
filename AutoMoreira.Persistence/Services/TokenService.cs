namespace AutoMoreira.Persistence.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        //Quando criamos um token, é preciso uma chave de verificação 
        //(chave de segurança- chave de encriptação)
        public readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, UserManager<User> userManager, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
        }
        public async Task<string> CreateToken(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            //Claims são afirmações sobre o utilizador ( nome, idade, foto, ...).
            //Neste caso estou a adicionar para dentro das claims, uma claim do userId e outra do UserName,
            //ou seja, estou a criar claims baseadas no meu utilizador
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName)
            };

            //Vou buscar todas as roles do utilizador
            var roles = await _userManager.GetRolesAsync(user);

            //Ele vai adicionar para dentro de claims varias outras claims(Roles).
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Montar a estrutura do token.
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //O token expira em 1 dia
                Expires = DateTime.Now.AddDays(1),
                //chave de criptografia
                SigningCredentials = creds
            };

            //Formato JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            //Criação do token
            var token = tokenHandler.CreateToken(tokenDescription);

            //Escrevo token no formato JWT
            return tokenHandler.WriteToken(token);
        }
    }
}
