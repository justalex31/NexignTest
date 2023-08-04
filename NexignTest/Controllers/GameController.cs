using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NexignTest.Enums;
using NexignTest.Interfaces;
using NexignTest.Models;
using NexignTest.Models.Game;
using System;

namespace NexignTest.Controllers
{
    [ApiController]
    [Route("game")]
    public class GameController
    {
        private readonly IHandler<CreateModel> _createModelHandler;
        private readonly IHandler<JoinModel> _joinModelHandler;
        private readonly IHandler<TurnModel> _turnModelHander;
        private readonly IHandler<StatModel, HttpResult> _statModelHander;

        public GameController(
            IHandler<CreateModel> createModelHandler,
            IHandler<JoinModel> joinModelHandler,
            IHandler<TurnModel> turnModelHander,
            IHandler<StatModel, HttpResult> statModelHander)
        {
            _createModelHandler = createModelHandler;
            _joinModelHandler = joinModelHandler;
            _turnModelHander = turnModelHander;
            _statModelHander = statModelHander;
        }

        public IHandler<CreateModel> CreateModelHandler => _createModelHandler;
        public IHandler<JoinModel> JoinModelHandler => _joinModelHandler;
        public IHandler<TurnModel> TurnModelHandler => _turnModelHander;
        public IHandler<StatModel, HttpResult> StatModelHandler => _statModelHander;

        [HttpGet]
        [Route("create")]
        public HttpResult Create([FromQuery] CreateModel model)
        {
            var result = new HttpResult();
            try
            {
                CreateModelHandler.Handle(model);
                result.Message = "Game created";
            } catch (Exception ex)
            {
                result.Code = ECode.NotFound;
                result.Description = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("{gameId}/join/{userName2}")]
        public HttpResult Join([FromRoute] JoinModel model)
        {
            var result = new HttpResult();
            try
            {
                JoinModelHandler.Handle(model);
                result.Message = "Player added";
            }
            catch (Exception ex)
            {
                result.Code = ECode.NotFound;
                result.Description = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("{gameId}/user/{userId}/{turn}")]
        public HttpResult User([FromRoute] TurnModel model)
        {
            var result = new HttpResult();
            try
            {
                TurnModelHandler.Handle(model);
                result.Message = "Player turned";
            }
            catch (Exception ex)
            {
                result.Code = ECode.NotFound;
                result.Description = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("{gameId:int}/stat")]
        public HttpResult Stat([FromRoute] StatModel model)
        {
            var result = new HttpResult();
            try
            {
                result = StatModelHandler.Handle(model);
                result.Message = "Player added";
            }
            catch (Exception ex)
            {
                result.Code = ECode.NotFound;
                result.Description = ex.Message;
            }

            return result;
        }
    }
}
