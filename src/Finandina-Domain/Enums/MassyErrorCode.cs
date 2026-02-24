using System.ComponentModel;

namespace Finandina_Domain.Enums
{
    public enum ListErrorCode
    {
        [Description("Validation error")]
        E006,

        [Description("Internal server error")]
        E020
    }
}
