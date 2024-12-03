using Booking.Domain.Entities;

namespace Booking.Application.ExternalServices.Repositories
{
    /// <summary>
    /// Репозиторий отвечающий за сущность
    /// </summary>
    public interface IGroundRepository
    {
        /// <summary>
        /// Получение поля по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор поля.</param>
        public Task<Ground> GetGroundById(long id);
    }
}
