using Booking.Application.Models.Booking;
using Booking.Application.Services;
using Booking.WebApi.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Booking.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/booking")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Забронировать timeSlots.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <response code="200">Операция бронирования успешно завершилась.</response>  
        /// <remarks>
        /// Базовый пример: 
        /// 
        ///     Post /login
        ///     {
        ///         "userName":"UserTest",
        ///         "password":"X_hlT49j8B"
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateBooking(CreateBookingRequest request)
        {
            var dto = new CreateBookingRequestDto
            {
                PhoneNumber = request.PhoneNumber,
                Date = request.Date,
                FIO = request.FIO,
                GroundId = request.GroundId,
                Interval = request.Interval
            };

            await _bookingService.CreateBooking(dto);

            return Ok();
        }
    }
}
