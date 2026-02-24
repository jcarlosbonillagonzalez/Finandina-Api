using Finandina_Domain.Interface;

namespace Finandina_Utilities.Services
{
    public class CurrentUser : ICurrentUser
    {
        // En una implementación real, esto vendría del contexto de seguridad (JWT, etc.)
        public Guid UserId => Guid.Empty;
    }
}
