using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentItemController : ControllerBase
    {
        private readonly IShipmentItemRepository _shipmentItemRepository;
        public ShipmentItemController(IShipmentItemRepository shipmentItemRepository)
        {
            _shipmentItemRepository = shipmentItemRepository;
        }

        #region Get

        [HttpGet ("GetAllCorrect")]
        public IActionResult GetAllById_Correct(int id)
        {
            var result = _shipmentItemRepository.GetAll_Correct(id);
            return Ok(result);
        }

        [HttpGet("GetAllInCorrect")]
        public IActionResult GetAllById_InCorrect(int id)
        {
            var result = _shipmentItemRepository.GetAll_InCorrect(id);
            return Ok(result);
        }

        #endregion

        #region Insert

        [HttpPost("InsertCorrect")]
        public async Task<IActionResult> InsertCorrect([FromBody] ShipmentItem shipmentItem)
        {
            var result = await _shipmentItemRepository.Insert_Correct(shipmentItem);
            return Ok(result);
        }

        [HttpPost("Insert_InCorrect")]
        public async Task<IActionResult> InsertInCorrect([FromBody] ShipmentItem shipmentItem)
        {
            var result = await _shipmentItemRepository.Insert_InCorrect(shipmentItem);
            return Ok(result);
        }

        #endregion

        #region Update

        [HttpPut("UpdateCorrect")]
        public async Task<IActionResult> UpdateCorrect(int id, [FromBody] ShipmentItem shipmentItem)
        {
            var result = await _shipmentItemRepository.Update_Correct(id, shipmentItem);
            return Ok(result);
        }

        [HttpPut("UpdateInCorrect")]
        public async Task<IActionResult> UpdateInCorrect(int id, [FromBody] ShipmentItem shipmentItem)
        {
            var result = await _shipmentItemRepository.Update_InCorrect(id, shipmentItem);
            return Ok(result);
        }

        [HttpPut("UpdateCommodityCodeCorrect")]
        public async Task<IActionResult> UpdateCommodityCodeCorrect(int id, [FromBody] string newCommodityCode)
        {
            var result = await _shipmentItemRepository.UpdateShipmentItemsByShipmentId_Correct(id, newCommodityCode);
            return Ok(result);
        }

        [HttpPut("UpdateCommodityCodeInCorrect")]
        public async Task<IActionResult> UpdateCommodityCodeInCorrect(int id, [FromBody] string newCommodityCode)
        {
            var result = await _shipmentItemRepository.UpdateShipmentItemsByShipmentId_InCorrect(id, newCommodityCode);
            return Ok(result);
        }

        #endregion
    }
}
