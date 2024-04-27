namespace AutoMoreira.Core.Domains
{
    /// <summary>
    /// Class Domain Resource for domain exception
    /// </summary>

    public static class DomainResource
    {
        #region Mark
        public static readonly string MarkNotFoundException = "Marca não encontrada.";
        public static readonly string MarkIdNeedsToBeSpecifiedException = "O id da marca é invalido.";
        public static readonly string MarkNameNeedsToBeSpecifiedException = "O nome da marca é invalido.";
        public static readonly string MarkAlreadyExistsException = "A marca já existe.";
        public static readonly string AddMarkAsyncException = "Erro ao tentar criar a marca.";
        public static readonly string UpdateMarkAsyncException = "Erro ao tentar atualizar a marca.";
        public static readonly string GetAllMarksAsyncException = "Erro ao tentar encontrar marcas.";
        public static readonly string GetMarkByIdAsyncException = "Erro ao tentar encontrar marca por id.";
        public static readonly string DeleteMarksAsyncException = "Erro ao tentar encontrar apagar a marca.";
        #endregion

        #region Model
        public static readonly string ModelNotFoundException = "Modelo não encontrado.";
        public static readonly string ModelIdNeedsToBeSpecifiedException = "O id do modelo é invalido.";
        public static readonly string ModelNameNeedsToBeSpecifiedException = "O nome do modelo é invalido.";
        public static readonly string ModelAlreadyExistsException = "O modelo já existe.";
        public static readonly string AddModelAsyncException = "Erro ao tentar criar o modelo.";
        public static readonly string UpdateModelAsyncException = "Erro ao tentar atualizar o modelo.";
        public static readonly string GetAllModelsAsyncException = "Erro ao tentar encontrar modelos.";
        public static readonly string GetModelByIdAsyncException = "Erro ao tentar encontrar modelo por id.";
        public static readonly string GetModelsByMarkIdAsyncException = "Erro ao tentar encontrar modelos por marca id.";
        public static readonly string DeleteModelsAsyncException = "Erro ao tentar encontrar apagar o modelo.";
        #endregion

        #region VehicleImage
        public static readonly string VehicleImageUrlNeedsToBeSpecifiedException = "O url da imagem do veículo é invalido.";
        #endregion

        #region User
        public static readonly string UserNotFoundException = "Utilizador não encontrado.";
        public static readonly string UserIdNeedsToBeSpecifiedException = "O id do utilizador é invalido.";
        public static readonly string UserEmailNeedsToBeSpecifiedException = "O email do utilizador é invalido.";
        public static readonly string UserPhoneNumberNeedsToBeSpecifiedException = "O contacto do utilizador é invalido.";
        public static readonly string UserFirstNameNeedsToBeSpecifiedException = "O primeiro nome do utilizador é invalido.";
        public static readonly string UserLastNameNeedsToBeSpecifiedException = "O ultimo nome do utilizador é invalido.";
        public static readonly string UserImageNeedsToBeSpecifiedException = "A imagem do utilizador é invalido.";
        public static readonly string UserPasswordHashNeedsToBeSpecifiedException = "A password do utilizador é invalido.";
        #endregion

        #region Role
        public static readonly string RoleNotFoundException = "Cargo não encontrado.";
        public static readonly string DefaultRoleNotFoundException = "Cargo padrão não encontrado.";
        public static readonly string RoleIdNeedsToBeSpecifiedException = "O id do cargo é invalido.";
        public static readonly string RoleNameNeedsToBeSpecifiedException = "O nome do cargo é invalido.";
        public static readonly string RoleAlreadyExistsException = "O cargo já existe.";
        public static readonly string AddRoleAsyncException = "Erro ao tentar criar o cargo.";
        public static readonly string UpdateRoleAsyncException = "Erro ao tentar atualizar o cargo.";
        public static readonly string GetAllRolesAsyncException = "Erro ao tentar encontrar cargos.";
        public static readonly string GetRoleByIdAsyncException = "Erro ao tentar encontrar cargo por id.";
        public static readonly string UpdateDefaultRoleException = "Cargo não pode ser atualizado pois é padrão do sistema.";
        public static readonly string DeleteRolesAsyncException = "Erro ao tentar apagar o cargo.";
        public static readonly string DeleteDefaultRoleAsyncException = "O Cargo não pode ser apagado pois é padrão do sistema.";
        #endregion

        #region ClientMessage
        public static readonly string ClientMessageNameNeedsToBeSpecifiedException = "O nome da mensagem de cliente é invalido.";
        public static readonly string ClientMessageEmailNeedsToBeSpecifiedException = "O email da mensagem de cliente é invalido.";
        public static readonly string ClientMessagePhoneNumberNeedsToBeSpecifiedException = "O contacto da mensagem de cliente é invalido.";
        public static readonly string ClientMessageNeedsToBeSpecifiedException = "A mensagem de cliente é invalida.";
        public static readonly string ClientMessageStatusNeedsToBeSpecifiedException = "O estado da mensagem de cliente é invalido.";
        #endregion
    }
}
