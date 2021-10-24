using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyTasks.Application.MyTasks.Queries.GetTaskList;
using MyTasks.Application.MyTasks.Queries.GetTaskDetails;
using MyTasks.Application.MyTasks.Commands.CreateTask;
using MyTasks.Application.MyTasks.Commands.UpdateTask;
using MyTasks.Application.MyTasks.Commands.DeleteTask;
using MyTasks.Application.MyTasks.Commands.MarkTaskCompleted;
using MyTasks.WebApi.Models;

namespace MyTasks.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of my tasks
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /task
        /// </remarks>
        /// <returns>Returns TaskListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskListVm>> GetAll()
        {
            var query = new GetTaskListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /task/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Task id (guid)</param>
        /// <returns>Returns TaskDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// Creates the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /task
        /// {
        ///     type: "task type",
        ///     description: "task description",
        ///     dateDue: "2021-10-30T17:00:00Z"
        /// }
        /// </remarks>
        /// <param name="createTaskDto">CreateTaskDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        /// <summary>
        /// Updates the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /task
        /// {
        ///     type: "updated task type",
        ///     description: "updated task description",
        ///     dateDue: "2021-10-30T17:00:00Z"
        /// }
        /// </remarks>
        /// <param name="updateTaskDto">UpdateTaskDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Marks the task completed
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /task/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the task (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(Guid id)
        {
            var command = new MarkTaskCompletedCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /task/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the task (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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