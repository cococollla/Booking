using Booking.Application.ExternalServices.Repositories;
using Booking.Application.Models.Booking;

namespace Booking.Application.Services
{
    /// <summary>
    /// Сервис бронирования.
    /// </summary>
    public class BookingService
    {
        private readonly IGroundRepository _groundRepository;

        public BookingService(IGroundRepository groundRepository)
        {
            _groundRepository = groundRepository;
        }

        public async Task CreateBooking(CreateBookingRequestDto request)
        {
            var test = await _groundRepository.GetGroundById(1);

            /*Обязательно учесть оптимистичные блокировки на timeSlot. Обернут изменение в транзакции EF core. 
              Так как для нас критически важно что бы не получилось ситуация, когда два бронирования на один timeSlot.             
             */

            /* Алгоритм 
              1. Получить поле 
              2. Валидация его. 
                2.1 По правилам адекватности которые вообще не меняются. Условно нельзя забронировать раньше или позже закрытия. Или в слоты которые заняты
                2.2 Подумать и применить класс BookingRule
              3. Пометить слот/слоты как занятые
              4. Сохранить результат.
             */

            /*
             На данном этапе результатом будет правильно забронированые слоты на поле.
             */

            throw new NotImplementedException();
        }
    }
}
