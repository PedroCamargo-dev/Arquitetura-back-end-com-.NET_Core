using curso.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adcionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
