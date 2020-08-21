using Microsoft.AspNetCore.Mvc;
using Demo.API.Common;
using Demo.Application.Interfaces;
using Demo.Application.ViewModels;
using System;
using System.Linq;

namespace Demo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientController : ApiBaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Json(_clientService.GetAll().ToList());
        }

        [HttpGet]
        [Route("get/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_clientService.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] ClientViewModel viewModelRequest)
        {
            return JsonOrError(_clientService.Add(viewModelRequest));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] ClientViewModel viewModelRequest)
        {
            return JsonOrError(_clientService.Update(viewModelRequest));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            return JsonOrError(_clientService.Remove(id));
        }
    }
}