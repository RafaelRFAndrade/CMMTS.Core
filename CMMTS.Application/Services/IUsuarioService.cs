using CMMTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMMTS.Application.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> BuscarUsuarios();
    }
}
