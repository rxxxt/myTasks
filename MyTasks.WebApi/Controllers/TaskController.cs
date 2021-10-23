using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyTasks.Application.MyTasks.Queries.GetTaskList;
using MyTasks.Application.MyTasks.Queries.GetTaskDetails;
using MyTasks.Application.MyTasks.Commands.CreateTask;
using MyTasks.Application.MyTasks.Commands.UpdateTask;
using MyTasks.Application.MyTasks.Commands.DeleteTask;
using MyTasks.WebApi.Models;

//using MyTasks.WebApi.Models;

namespace MyTasks.WebApi.Controllers
{
    //[ApiVersion("1.0")]
    //[Produces("application/json")]
    //[Route("api/{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        //[Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TaskListVm>> GetAll()
        {
            var query = new GetTaskListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Note id (guid)</param>
        /// <returns>Returns NoteDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TaskDetailsVm>> Get(Guid id)
        {
            var query = new GetTaskDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /note
        /// {
        ///     title: "note title",
        ///     details: "note details"
        /// }
        /// </remarks>
        /// <param name="createNoteDto">CreateNoteDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        /// <summary>
        /// Updates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /note
        /// {
        ///     title: "updated note title"
        /// }
        /// </remarks>
        /// <param name="updateNoteDto">UpdateNoteDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /note/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the note (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
      //  [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}