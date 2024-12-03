namespace Booking.WebApi.Models.Booking
{
    /// <summary>
    /// Запрос для создания бронирования.
    /// </summary>
    public class CreateBookingRequest
    {
        /// <summary>
        /// Идентификатор площадки.
        /// </summary>
        public long GroundId { get; set; }

        /// <summary>
        /// Контактный номер, кто хочет арендовать.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Интервал времени.
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// ФИО, кто хочет арендовать.
        /// </summary>
        public string? FIO { get; set; }
    }
}
