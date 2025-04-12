using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.services.Cabelo
{
    public class CabeloService : CabeloInterface
    {
        private readonly AppDbContext _context;

        public CabeloService(AppDbContext context)
        {
            _context=context;
        }

        public Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorForma(string formaCabelo)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CabeloModel>> BuscarCabeloPorId(int idCabelo)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<CabeloModel>>> ListarCabelos()
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();
            try
            {
                var cabelos = await _context.Cabelos.ToListAsync();
                resposta.Dados=cabelos;
                resposta.Mensagem="Todos os autores foram coletados com sucesso";
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