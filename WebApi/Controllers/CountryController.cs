using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class CountryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")] //Indicar la version del api
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(countries);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return _mapper.Map<CountryDto>(country);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (country == null)
        {
            return BadRequest();
        }
        countryDto.Id = country.Id;
        return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
    {
        if (countryDto == null)
            return BadRequest();

        if (countryDto.Id == 0)
            countryDto.Id = id;

        if (countryDto.Id != id)
            return NotFound();
        var countries = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Update(countries);
        await _unitOfWork.SaveAsync();
        return countryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
            return NotFound();

        _unitOfWork.Countries.Remove(country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}