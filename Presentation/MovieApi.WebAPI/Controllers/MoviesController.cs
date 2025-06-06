﻿using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly DeleteMovieCommandHandler _deleteMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;

        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler,
            DeleteMovieCommandHandler deleteMovieCommandHandler,
            UpdateMovieCommandHandler updateMovieCommandHandler,
            GetMovieQueryHandler getMovieQueryHandler, 
            GetMovieByIdQueryHandler getMovieByIdQueryHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _deleteMovieCommandHandler = deleteMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("The movie has been successfully added.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _deleteMovieCommandHandler.Handle(new DeleteMovieCommand(id));
            return Ok("The movie has been successfully deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("The movie has been successfully updated.");

        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
    }
}
