using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        #region Incorrect Functions for Find Shipment By Id

        /// <summary>
        /// The current implementation includes three endpoints that essentially perform the same operation but with different sets of included related entities.
        /// This results in code duplication, where each new inclusion requires the addition of a new endpoint or a new function.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpPost("FindByIdIncorrect1")]
        public async Task<IActionResult> FindById_Incorrect1(int id)
        {
            var result = await _shipmentRepository.FindByIdAsync_Incorrect1(id);
            return Ok(result);
        }

        [HttpPost("FindByIdIncorrect2")]
        public async Task<IActionResult> FindById_Incorrect2(int id)
        {
            var result = await _shipmentRepository.FindByIdAsync_Incorrect2(id);
            return Ok(result);
        }

        [HttpPost("FindByIdIncorrect3")]
        public async Task<IActionResult> FindById_Incorrect3(int id)
        {
            var result = await _shipmentRepository.FindByIdAsync_Incorrect3(id);
            return Ok(result);
        }

        #endregion

        #region     Correct Function for Find Shipment By Id

        /// <summary>
        /// This function support dynamic includes,
        ///  By doing so, you can provide a single endpoint that accepts the desired related entities as parameters, eliminating the need for duplicating code.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shipmentModules"></param>
        /// <returns></returns>
        [HttpPost("FindByIdCorrect")]
        public async Task<IActionResult> FindById(int id, [FromBody] ShipmentModules[] shipmentModules)
        {
            var result = await _shipmentRepository.FindByIdAsync_Correct(id, shipmentModules);
            return Ok(result);
        }

        #endregion

    }
}
