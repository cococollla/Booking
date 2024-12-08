using Booking.Application.Models.Booking;
using Booking.Application.Services;
using Booking.WebApi.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Booking.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/booking")]
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
        ///     Post /create
        ///     {
        ///         "PhoneNumber":"79803777777",
        ///         "Date":"2024-12-08",
        ///         "FIO":"Иванов Иван Иванович",
        ///         "GroundId":"1",             
        ///         "Interval":"12:11:03" (12-часов, 11-минут, 3-секунды),             
        ///     }
        ///     
        /// </remarks>
        [HttpPost("create")]
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
