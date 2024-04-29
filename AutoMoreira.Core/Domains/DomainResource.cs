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
        public static readonly string DeleteMarksAsyncException = "Erro ao tentar encontrar apagar marcas.";
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
        public static readonly string DeleteModelsAsyncException = "Erro ao tentar encontrar apagar modelos.";
        #endregion

        #region Vehicle

        public static readonly string VehicleNotFoundException = "Veículo não encontrado.";

        public static readonly string VehicleIdNeedsToBeSpecifiedException = "O id da veículo é invalido.";
        public static readonly string VehicleModelIdNeedsToBeSpecifiedException = "O id do modelo da veículo é invalido.";
        public static readonly string VehicleFuelTypeNeedsToBeSpecifiedException = "O tipo de combustível do veículo é invalido.";
        public static readonly string VehiclePriceNeedsToBeSpecifiedException = "O preço do veículo é invalido.";
        public static readonly string VehicleMileageNeedsToBeSpecifiedException = "O numero de quilómetros do veículo é invalido.";
        public static readonly string VehicleYearNeedsToBeSpecifiedException = "O ano do veículo é invalido.";
        public static readonly string VehicleDoorsNeedsToBeSpecifiedException = "O numero de portas do veículo é invalido.";
        public static readonly string VehicleTransmissionNeedsToBeSpecifiedException = "A transmissão do veículo é invalida.";
        public static readonly string VehicleEngineSizeNeedsToBeSpecifiedException = "O tamanho do motor do veículo é invalido.";
        public static readonly string VehiclePowerNeedsToBeSpecifiedException = "A potência do veículo é invalida.";

        public static readonly string GetAllVehiclesAsyncException = "Erro ao tentar encontrar veículos.";
        public static readonly string GetVehicleByIdAsyncException = "Erro ao tentar encontrar veículo por id.";
        public static readonly string GetVehicleCountersAsyncException = "Erro ao tentar encontrar o numero total de veículos.";
        public static readonly string GetAllVehiclesWithYearComparisonAsyncException = "Erro ao tentar encontrar dados de vendas (por ano) de veículos.";
        public static readonly string GetAllVehiclesWithMonthComparisonAsyncException = "Erro ao tentar encontrar dados de vendas (por mês) de veículos.";
        public static readonly string GetVehiclePieStatisticsAsyncException = "Erro ao tentar encontrar dados de vendas de veículos.";
        public static readonly string AddVehicleAsyncException = "Erro ao tentar criar o veículo.";
        public static readonly string UpdateVehicleAsyncException = "Erro ao tentar atualizar o veículo.";

        #endregion

        #region Vehicle Image

        public static readonly string VehicleImageUrlNeedsToBeSpecifiedException = "O endereço da imagem do veículo é invalido.";

        #endregion

        #region User
        public static readonly string UserNotFoundException = "Utilizador não encontrado.";
        public static readonly string UserPasswordNotFoundException = "A palavra-passe é invalida para este utilizador.";
        
        public static readonly string UserIdNeedsToBeSpecifiedException = "O id do utilizador é invalido.";
        public static readonly string DeleteDefaultUserAsyncException = "O utilizador não pode ser apagado pois é padrão do sistema.";      
        public static readonly string UserEmailNeedsToBeSpecifiedException = "O email do utilizador é invalido.";
        public static readonly string UserPhoneNumberNeedsToBeSpecifiedException = "O contacto do utilizador é invalido.";
        public static readonly string UserFirstNameNeedsToBeSpecifiedException = "O primeiro nome do utilizador é invalido.";
        public static readonly string UserLastNameNeedsToBeSpecifiedException = "O ultimo nome do utilizador é invalido.";
        public static readonly string UserImageNeedsToBeSpecifiedException = "A imagem do utilizador é invalido.";
        public static readonly string UserPasswordHashNeedsToBeSpecifiedException = "A password do utilizador é invalido.";
        public static readonly string UserAlreadyExistsException = "O utilizador já existe.";

        public static readonly string GetAllUsersAsyncException = "Erro ao tentar encontrar utilizadores.";
        public static readonly string GetUserByIdAsyncException = "Erro ao tentar encontrar utilizador por id.";
        public static readonly string LoginUserAsyncException = "Erro ao tentar iniciar sessão do utilizador.";
        public static readonly string AddUserAsyncException = "Erro ao tentar criar o utilizador.";
        public static readonly string UpdateUserAsyncException = "Erro ao tentar atualizar o utilizador.";
        public static readonly string UpdateUserModeAsyncException = "Erro ao tentar atualizar o modo do utilizador.";
        public static readonly string UpdateUserImageAsyncException = "Erro ao tentar atualizar a foto de perfil do utilizador.";
        public static readonly string UpdateUserPasswordAsyncException = "Erro ao tentar atualizar a palavra-passe do utilizador.";
        public static readonly string ResetUserPasswordAsyncException = "Erro ao tentar criar uma nova palavra-passe do utilizador.";
        public static readonly string DeleteUsersAsyncException = "Erro ao tentar apagar utilizadores.";
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
        public static readonly string DeleteRolesAsyncException = "Erro ao tentar apagar cargos.";
        public static readonly string DeleteDefaultRoleAsyncException = "O cargo não pode ser apagado pois é padrão do sistema.";
        #endregion

        #region Client Message

        public static readonly string ClientMessageNotFoundException = "Mensagem de cliente não encontrada.";

        public static readonly string ClientMessageIdNeedsToBeSpecifiedException = "O id da marca é invalido.";      
        public static readonly string ClientMessageNameNeedsToBeSpecifiedException = "O nome da mensagem de cliente é invalido.";
        public static readonly string ClientMessageEmailNeedsToBeSpecifiedException = "O email da mensagem de cliente é invalido.";
        public static readonly string ClientMessagePhoneNumberNeedsToBeSpecifiedException = "O contacto da mensagem de cliente é invalido.";
        public static readonly string ClientMessageNeedsToBeSpecifiedException = "A mensagem de cliente é invalida.";
        public static readonly string ClientMessageStatusNeedsToBeSpecifiedException = "O estado da mensagem de cliente é invalido.";

        public static readonly string GetAllClientMessagesAsyncException = "Erro ao tentar encontrar mensagens de clientes.";
        public static readonly string GetClientMessageByIdAsyncException = "Erro ao tentar encontrar mensagem de cliente por id.";
        public static readonly string AddClientMessageAsyncException = "Erro ao tentar criar a mensagem de cliente.";
        public static readonly string UpdateClientMessageAsyncException = "Erro ao tentar atualizar a mensagem de cliente.";
        public static readonly string DeleteClientMessagesAsyncException = "Erro ao tentar encontrar apagar mensagens de clientes.";

        #endregion

        #region Visitor

        public static readonly string GetVisitorCountersAsyncException = "Erro ao tentar encontrar o numero total de visitantes.";
        public static readonly string GetAllVisitorsWithYearComparisonAsyncException = "Erro ao tentar encontrar dados (por ano) de visitantes.";
        public static readonly string GetAllVisitorsWithMonthComparisonAsyncException = "Erro ao tentar encontrar dados (por mês) de visitantes.";
        public static readonly string CreateOrUpdateVisitorAsyncException = "Erro ao tentar criar/editar o numero total de visitantes.";
        
        #endregion
    }
}
