﻿namespace SibSample.API.Features.v1
{
    using System.Collections.Generic;
    using Configuration.ProblemDetails.Helpers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Banks;
    using Application.Banks.AddBank;
    using Application.Banks.BulkInsert;
    using Application.Banks.GetAllBanks;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/banks")]
    [Produces("application/json")]
    [ServiceFilter(typeof(ProblemDetailsFilter))]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBank([FromBody] BankContract request)
        {
            return Created("",
                await _mediator.Send(new AddBankCommand(request)));
        }

        [HttpPost("import-data")]
        public async Task<IActionResult> ImportData(ICollection<BankContract> request)
        {
            return Accepted(await _mediator.Send(new BulkInsertCommand(request)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanks()
        {
            return Ok(await _mediator.Send(new GetBankQuery()));
        }
    }
}