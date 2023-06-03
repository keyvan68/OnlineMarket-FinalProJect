using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IApplicationUserApplicationService
    {
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task ConfirmByAdmin(int id);

    }
}
