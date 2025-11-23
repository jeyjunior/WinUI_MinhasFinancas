using JJ.Net.WinUI3_CrossData.InfraData;
using JJ.Net.WinUI3_CrossData.Interfaces;
using MF.Domain.Entidades;
using MF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.InfraData.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
