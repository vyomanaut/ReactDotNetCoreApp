﻿using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity Activity)
        {
            return Ok(await Mediator.Send(new Create.Command { activity = Activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id,Activity Activity)
        {
            Activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { activity = Activity }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActivity(Guid Id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id=Id }));
        }
    }
}
