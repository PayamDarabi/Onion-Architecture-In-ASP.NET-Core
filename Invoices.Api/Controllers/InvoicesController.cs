using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Invoices.Api.Resources;
using Invoices.Api.Validators;
using Invoices.Core.Models;
using Invoices.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController :ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoiceService invoiceService, IMapper mapper)
        {
            this._mapper = mapper;
            this._invoiceService = invoiceService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllProducts()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            var invoiceResources = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(invoices);

            return Ok(invoiceResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceResource>> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            var invoiceResource = _mapper.Map<Invoice, InvoiceResource>(invoice);
            return Ok(invoiceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<InvoiceResource>> CreateInvoice([FromBody] SaveInvoiceResource saveInvoiceResource)
        {
            var validator = new SaveInvoiceResourceValidator();
            var validationResult = await validator.ValidateAsync(saveInvoiceResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var invoiceToCreate = _mapper.Map<SaveInvoiceResource, Invoice>(saveInvoiceResource);

            var newInvoice = await _invoiceService.CreateInvoice(invoiceToCreate);

            var invoice = await _invoiceService.GetInvoiceById(newInvoice.Id);

            var invoiceResource = _mapper.Map<Invoice, InvoiceResource>(invoice);

            return Ok(invoiceResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceResource>> UpdateProduct(int id, [FromBody] SaveInvoiceResource saveInvoiceResource)
        {
            var validator = new SaveInvoiceResourceValidator();
            var validationResult = await validator.ValidateAsync(saveInvoiceResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var invoiceToBeUpdate = await _invoiceService.GetInvoiceById(id);

            if (invoiceToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveInvoiceResource, Invoice>(saveInvoiceResource);

            await _invoiceService.UpdateInvoice(invoiceToBeUpdate, product);

            var updatedInvoice = await _invoiceService.GetInvoiceById(id);
            var updatedInvoiceResource = _mapper.Map<Invoice, InvoiceResource>(updatedInvoice);

            return Ok(updatedInvoiceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var invoice = await _invoiceService.GetInvoiceById(id);

            if (invoice == null)
                return NotFound();

            await _invoiceService.DeleteInvoice(invoice);

            return NoContent();
        }
    }
}