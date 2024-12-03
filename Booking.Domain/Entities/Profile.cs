using System.ComponentModel.DataAnnotations;

namespace Booking.Domain.Entities
{
    /// <summary>
    /// Профиль пользователя.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public required string Patronymic { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Социальные сети.
        /// </summary>
        public IEnumerable<string>? SocialNetworks { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Phone]
        public required string PhoneNumber { get; set; }
    }
}
