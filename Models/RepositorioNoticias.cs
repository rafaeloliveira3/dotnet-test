using System;
using Microsoft.EntityFrameworkCore;

namespace ProjetoExemplo.Models{

    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Noticia> Noticias {get; set;}
    }

    public class RepositorioNoticias {

        private readonly AppDbContext _context;

        public RepositorioNoticias(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Noticia>> GetNoticias() {

            return await _context.Noticias.ToListAsync();
        }

        public async Task<bool> AdicionarNoticia(Noticia noticia){
            
            try {
                _context.Noticias.Add(noticia);
                await _context.SaveChangesAsync();
            } catch( Exception) {
                return false;
            }
            
            return true;
        }

        public async Task<bool> RemoverNoticia(int Id){

            try {
                var noticia = await _context.Noticias.FindAsync(Id);

                if (noticia != null)
                {
                    _context.Noticias.Remove(noticia);
                    await _context.SaveChangesAsync();
                    return true;
                }

            } catch(Exception) {
                return false;
            }
            
            return false;
        }
    }

}