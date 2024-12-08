using Booking.Application.ExternalServices.Repositories;
using Booking.DAL.DataBase;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.Repositories
{
    public class GroundRepository : IGroundRepository
    {
        private readonly ApplicationContext _context;

        public GroundRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Ground?> GetGroundById(long id)
        {
            var result = await _context.Grounds.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
