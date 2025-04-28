using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.User;
using backend.models;
using backend.services.User;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInteface;

        public UserController(UserInterface userInterface)
        {
            _userInteface=userInterface;
        }

        [HttpGet("ListarUsers")]
        public async Task<ActionResult<ResponseModel<List<LoginModel>>>> ListarTratamentos(){
            var users = await _userInteface.ListarUsuarios();
            return Ok(users);
        }
        [HttpDelete("DeletarUser")]
        public async Task<ActionResult<ResponseModel<List<LoginModel>>>> DeletarUser(int idUser){
            var user = await _userInteface.RemoverUsuario(idUser);
            return Ok(user);
        }
        public async Task<ActionResult<ResponseModel<List<LoginModel>>>> AtualizarUser(UserEditarDto userEditarDto){
            var user = await _userInteface.AtualizarUser(userEditarDto);
            return Ok(user);
        }
        public async Task<ActionResult<ResponseModel<List<LoginModel>>>> AddUser(UserCriacaoDto userCriacaoDto){
            var user = await _userInteface.AddUser(userCriacaoDto);
            return Ok(user);
        }


    }
}