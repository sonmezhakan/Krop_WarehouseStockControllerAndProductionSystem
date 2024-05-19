﻿using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Branches.Dtos;
using Krop.Business.Features.Departments.Dtos;
using Krop.Business.Services.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBranchDTO createBranchDTO, CancellationToken cancellationToken)
        {
            var result = await _branchService.AddAsync(createBranchDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBranchDTO updateBranchDTO, CancellationToken cancellationToken)
        {
            var result = await _branchService.UpdateAsync(updateBranchDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _branchService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _branchService.GetAllAsync();

            return result.Success ? Ok(result): BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _branchService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
