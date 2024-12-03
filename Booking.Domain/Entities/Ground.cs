using System.ComponentModel.DataAnnotations;

namespace Booking.Domain.Entities
{
    /// <summary>
    /// Площадка.
    /// </summary>
    public class Ground
    {
        /// <summary>
        /// Идентификатор. 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фотографии. TODO: Нужно будет их как то хранить и тд.
        /// </summary>
        public string[] Photos { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Общее описание.
        /// </summary>
        public string GeneralDescription { get; set; }

        /// <summary>
        /// Параметры (например: Крытая площадка, Искусственная трава, Душевые и тд).
        /// </summary>
        public IEnumerable<Parameter> Parameters { get; set; } = Enumerable.Empty<Parameter>();

        /// <summary>
        /// Цена за один timeSlot.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Арендодатель.
        /// </summary>
        public Profile Owner { get; set; }

        /// <summary>
        /// TimeSlots.
        /// </summary>
        public ICollection<TimeSlot> TimeSlots { get; set; } = Array.Empty<TimeSlot>();
    }

    /// <summary>
    /// TimeSlots
    /// </summary>
    public class TimeSlot
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Интервал времени.
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// Признак занятости.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Цена для конкретного timeSlot. <b>Здесь Цена может быть со знаком МИНУС</b>
        /// </summary>
        public decimal? AdditionalPrice { get; set; }

        /// <summary>
        /// Для оптимистической блокировки
        /// </summary>
        [Timestamp]
        public byte[] ConcurrencyToken { get; private set; }
    }

    /// <summary>
    /// Правила бронирования.
    /// </summary>
    public class BookingRule
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Минимальное кол-во слотов.
        /// </summary>
        public short MinSlots { get; set; }

        /*
         Пока не смог нормально придумать. Но суть этот класс будет отвечать за правила бронирование таймлостов и за скидки.
         То есть в теории здесь должны быть правила по тип -> c открытия до обеда можно забронировать минимум 2 слота. После обеда минимум 3 и тд. Тоесть настраиваемая вещь.
         И так же скидки если человек забронировал 6 слотов то скидка 10% и тд.
         
         */
    }
}
