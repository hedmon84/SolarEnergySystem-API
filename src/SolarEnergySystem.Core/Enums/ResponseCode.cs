using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Enums
{
    public enum ResponseCode
    {
        Success,
        Error,
        InternalServerError = 500,
        NotFound
    }
}
