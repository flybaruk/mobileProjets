using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dto.User;
using backend.models;

namespace backend.services.User
{
    public interface UserInterface
    {
        Task<ResponseModel<List<LoginModel>>> ListarUsuarios();
        Task<ResponseModel<List<LoginModel>>> AddUser(UserCriacaoDto userCriacaoDto);
        Task<ResponseModel<List<LoginModel>>> RemoverUsuario(int idUser);
        Task<ResponseModel<List<LoginModel>>> AtualizarUser(UserEditarDto userEditarDto);

    }
}