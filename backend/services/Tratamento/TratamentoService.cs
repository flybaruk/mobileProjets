using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Dto.Tratamentos;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.services.Tratamento
{
    public class TratamentoService : TratamentoInterface
    {
        private readonly AppDbContext _context;

        public TratamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TratamentoModel>>> BuscarTratamentoPorBeneficio(string? Beneficio)
        {
            ResponseModel<List<TratamentoModel>> resposta = new ResponseModel<List<TratamentoModel>>();

            try
            {
                var tratamentos=await _context.Tratamentos.Where(t=>t.Beneficios.ToLower().Contains(Beneficio.ToLower())).ToListAsync();
                if (tratamentos==null)
                {
                    resposta.Dados=tratamentos;
                    resposta.Mensagem="Nenhum tratamento encontrado";
                    return resposta;
                }
                resposta.Dados=tratamentos;
                resposta.Mensagem="Todos os tratamentos foram encontrados";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TratamentoModel>>> CriarTratamento(TratamentoCriacaoDto tratamentoCriacaoDto)
        {
            ResponseModel<List<TratamentoModel>> resposta = new ResponseModel<List<TratamentoModel>>();

            try
            {
                var tratamento= new TratamentoModel(){
                    Beneficios=tratamentoCriacaoDto.Beneficios,
                    Produtos=tratamentoCriacaoDto.Produtos,
                    Funcao=tratamentoCriacaoDto.Funcao,
                    Descritivo=tratamentoCriacaoDto.Descritivo,
                };
                _context.Add(tratamento);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Tratamentos.ToListAsync();
                resposta.Mensagem="Tratamento criado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }


        public async Task<ResponseModel<List<TratamentoModel>>> EditarTratamento(TratamentoEdicaoDto tratamentoEdicaoDto)
        {
            ResponseModel<List<TratamentoModel>> resposta = new ResponseModel<List<TratamentoModel>>();
            try
            {
                var tratamento = await _context.Tratamentos.FirstOrDefaultAsync(tratamentoBanco=> tratamentoBanco.Id==tratamentoEdicaoDto.Id);
                if (tratamento==null){
                    resposta.Mensagem="Nenhum tratamento com esse Id";
                    return resposta;
                }
                tratamento.Produtos=tratamentoEdicaoDto.Produtos;
                tratamento.Funcao=tratamentoEdicaoDto.Funcao;
                tratamento.Descritivo=tratamentoEdicaoDto.Descritivo;
                tratamento.Beneficios=tratamentoEdicaoDto.Beneficios;
                _context .Update(tratamento);
                await  _context.SaveChangesAsync();
                resposta.Dados=await _context.Tratamentos.ToListAsync();
                resposta.Mensagem="Tratamento atualizado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TratamentoModel>>> ExcluirTratamento(int idTratamento)
        {
            ResponseModel<List<TratamentoModel>> resposta = new ResponseModel<List<TratamentoModel>>();

            try
            {
                var tratamentos=await _context.Tratamentos.FirstOrDefaultAsync();
                if (tratamentos==null){
                    resposta.Mensagem="Não existe tratamento com esse id";
                    return resposta;
                }
                _context.Remove(tratamentos);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Tratamentos.ToListAsync();
                resposta.Mensagem="Tratamento removido com sucesso";
                return resposta;
            }
            catch (System.Exception)
            {
                resposta.Dados=await _context.Tratamentos.ToListAsync();
                resposta.Mensagem="Tratamento atualizado com sucesso";
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TratamentoModel>>> ListarTratamentos()
        {
            ResponseModel<List<TratamentoModel>> resposta = new ResponseModel<List<TratamentoModel>>();
            
            try
            {
                var tratamentos = await _context.Tratamentos.ToListAsync();
                resposta.Dados=tratamentos;
                resposta.Mensagem="Todos tratamentos retornados";
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