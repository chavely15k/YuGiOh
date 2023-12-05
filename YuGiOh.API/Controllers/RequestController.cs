using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RequestController: ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        [Route("playerId/{id}")]
        public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequestByPlayer(int id)
        {
            var request = await _requestService.GetAllRequestByPlayer(id);
            return Ok(request);
        }

        [HttpGet]
        [Route("adminId/{id}")]
        public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequestByAdmin(int id)
        {
            var request = await _requestService.GetAllRequestByAdmin(id);
            return Ok(request);
        }
        
        [HttpPost]
        [Route("make")]
        public async Task<ActionResult> MakeRequest(RequestDto request)
        {
            var result = await _requestService.CreateRequest(request);
            return Ok(result);
        }   

        [HttpDelete]
        [Route("delete/{PlayerId}/{TournametId}")]
        public async Task<ActionResult> DeleteRequest(int PlayerId, int TournametId )
        {
            var result = await _requestService.DeleteRequest(PlayerId,TournametId);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> PutRequest(RequestDto request)
        {
            var result = await _requestService.UpdateRequest(request);
            return Ok(result);
        }
    }
}