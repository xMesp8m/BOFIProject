using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BOFI.API.Web.Infraestructure;
using BOFI.Dtos;
using BOFI.Services;

namespace BOFI.API.Web.Controllers
{
    //[EnableCors(origins: "http://localhost:65199", headers: "*", methods: "*")]
    public class BoardGameController : ApiController
    {
        private readonly ServicesContext _context;
        private ResponseBuilder _response;
        public BoardGameController()
        {
            _context = new ServicesContext();
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var response = _context.BoardGame.GetAll();
                _response = new ResponseBuilder("ok",response);
                return Request.SendResponse(HttpStatusCode.OK, _response);
            }
            catch (Exception ex)
            {
                return Request.SendErrorResponse(new List<string>{"Error getting Board Games"});
            }
        }
        [HttpGet]
        public HttpResponseMessage GetById(string id)
        {
            try
            {
                var response = _context.BoardGame.GetById(id);
                _response = new ResponseBuilder("ok",response);
                return Request.SendResponse(HttpStatusCode.OK, _response);

            }
            catch (Exception ex)
            {
                return Request.SendErrorResponse(new List<string> { "Error getting Board Game" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody] BoardGameDto boardGame)
        {
            try
            {
                var validation = ValidateBoardGame(boardGame);
                if (validation.Any())
                {
                    return Request.SendErrorResponse(validation);
                }
                var newBoardGame = _context.BoardGame.Add(boardGame);
                _response = new ResponseBuilder("ok", newBoardGame);
                return Request.SendResponse(HttpStatusCode.OK, _response);
            }
            catch (Exception ex)
            {
                return Request.SendErrorResponse(new List<string> { "Error adding Board Game" });
            }

        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] BoardGameDto boardGame,string id)
        {
            try
            {
                boardGame.Id = id;
                var validation = ValidateBoardGame(boardGame);
                if (validation.Any())
                {
                    return Request.SendErrorResponse(validation);
                }
                var modifiedBoardGame = _context.BoardGame.Update(boardGame);
                _response = new ResponseBuilder("ok", modifiedBoardGame);
                return Request.SendResponse(HttpStatusCode.OK, _response);
            }
            catch (Exception ex)
            {
                return Request.SendErrorResponse(new List<string> { "Error updating Board Game" });
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var response = _context.BoardGame.Remove(id);
                _response = new ResponseBuilder("ok", response);
                return Request.SendResponse(HttpStatusCode.OK, _response);

            }
            catch (Exception ex)
            {
                return Request.SendErrorResponse(new List<string> { "Error removing Board Game" });
            }
        }



        #region Private
        private List<string> ValidateBoardGame(BoardGameDto boardGame)
        {
            var response = new List<string>();
            CheckRequiredFields(response, boardGame);
            return response;
        }

        private static void CheckRequiredFields(List<string> response, BoardGameDto boardGame)
        {
            if (string.IsNullOrEmpty(boardGame.Name))
            {
                response.Add("Name is a required field");
            }
        }
        #endregion
    }
}
