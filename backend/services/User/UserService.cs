using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Dto.User;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.services.User
{
    public class UserService : UserInterface
    {

        private readonly AppDbContext _context;

        public UserService (AppDbContext context){
            _context = context;
        }
        public async Task<ResponseModel<List<LoginModel>>> AddUser(UserCriacaoDto userCriacaoDto)
        {
            ResponseModel<List<LoginModel>> resposta = new ResponseModel<List<LoginModel>>();
            try
            {
                var user = new LoginModel(){
                    login=userCriacaoDto.login,
                    password=userCriacaoDto.password,
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Login.ToListAsync();
                resposta.Mensagem="Usuário criado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LoginModel>>> AtualizarUser(UserEditarDto userEditarDto)
        {
            ResponseModel<List<LoginModel>> resposta = new ResponseModel<List<LoginModel>>();

            try
            {
                var user =await _context.Login.FirstOrDefaultAsync(user=>user.Id==userEditarDto.Id);
                if (user==null){
                    resposta.Mensagem="Nenhum usuário com esse ID";
                    return resposta;
                }
                user.login=userEditarDto.login;
                user.password=userEditarDto.password;
                _context.Update(user);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Login.ToListAsync();
                resposta.Mensagem="Usuário atualizado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LoginModel>>> ListarUsuarios()
        {
            ResponseModel<List<LoginModel>> resposta = new ResponseModel<List<LoginModel>>();
            try
            {
                var login = await _context.Login.ToListAsync();
                resposta.Dados=login;
                resposta.Mensagem="Todos os usuários";
                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LoginModel>>> RemoverUsuario(int idUser)
        {
            ResponseModel<List<LoginModel>> resposta = new ResponseModel<List<LoginModel>>();

            try
            {
                var login = await _context.Login.FirstOrDefaultAsync(login=>login.Id==idUser);
                if(login==null){
                    resposta.Mensagem="Nenhum usuário com esse ID";
                    return resposta;
                }
                _context.Remove(login);
                await _context.SaveChangesAsync();
                resposta.Dados= await _context.Login.ToListAsync();
                resposta.Mensagem = "Usuario removido com sucesso";
                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }
    }
}