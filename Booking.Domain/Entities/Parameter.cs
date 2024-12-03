namespace Booking.Domain.Entities
{
    /// <summary>
    /// Параметры (например: Крытая площадка, Искусственная трава, Душевые и тд).
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Иконка.
        /// </summary>
        public string? Icon { get; set; }
    }
}
