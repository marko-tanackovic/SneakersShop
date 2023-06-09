using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.Extensions
{
    public class UnauthorizedUseCaseAccessException : Exception
    {
        public UnauthorizedUseCaseAccessException(string username, string useCaseName)
            : base($"There was an unauthorized access attempt by {username} for {useCaseName} use case.")
        {

        }
    }
}
