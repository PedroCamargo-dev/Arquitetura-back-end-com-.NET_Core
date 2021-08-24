using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infraestruture.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _context;

        public UsuarioRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adcionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }   

        public Usuario ObterUsuario(string login)
        {
           return _context.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
