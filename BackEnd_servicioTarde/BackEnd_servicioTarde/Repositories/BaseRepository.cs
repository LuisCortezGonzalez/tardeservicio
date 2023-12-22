using BackEnd_servicioTarde.Data;

namespace cursoInduccion.backend.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}