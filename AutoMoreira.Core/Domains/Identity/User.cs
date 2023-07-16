namespace AutoMoreira.Core.Domains.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public FUNCAO Funcao { get; private set; }
        public string Descricao { get; private set; }
        public string ImagemUrl { get; private set; }

        //Um User pode ter muitas Roles
        public virtual IEnumerable<UserRole> UserRoles { get; private set; }
    }
}
