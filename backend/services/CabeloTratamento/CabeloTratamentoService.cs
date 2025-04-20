using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Dto.CabelosTratamentos;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.services.CabeloTratamento
{
    public class CabeloTratamentoService : CabeloTratamentoInterface
    {

        private readonly AppDbContext _context;

        public CabeloTratamentoService (AppDbContext context){
            _context = context;
        }


        public async Task<ResponseModel<List<CabeloTratamentoModel>>> CriarCabeloTratamento(int IdCabelo, int IdTratamento)
        {
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();
            try
            {

                var cabelo = await _context.Cabelos.FirstOrDefaultAsync(c => c.Id == IdCabelo);
                if (cabelo == null){
                    resposta.Mensagem="O Cabelo não existe";
                    return resposta;
                }
                var tratamento = await _context.Tratamentos.FirstOrDefaultAsync(trata => trata.Id==IdTratamento);
                if (tratamento == null){
                    resposta.Mensagem="O Tratamento não existe";
                    return resposta;
                }

                var duplicados = await _context.CabeloTratamento.FirstOrDefaultAsync(t => t.Tratamento == tratamento && t.Cabelo == cabelo);
                if (duplicados != null){
                    resposta.Mensagem="Já existe esse vinculo cadastrado";
                    return resposta;
                }
                var cabeloTratamento= new CabeloTratamentoModel(){
                    Cabelo=cabelo,
                    Tratamento=tratamento
                };

                _context.Add(cabeloTratamento);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.CabeloTratamento.ToListAsync();
                resposta.Mensagem="Cadastrado novo tratamento para o cabelo";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public Task<ResponseModel<List<CabeloTratamentoModel>>> EditarCabeloTratamento()
        {
            throw new NotImplementedException();
            /*
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();

            try
            {
                
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
            */
        }

        public async Task<ResponseModel<List<CabeloTratamentoModel>>> ExcluirCabeloTratamento(int IdCabTrat)
        {
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();
            try
            {
                var cabTrat = await _context.CabeloTratamento.FirstOrDefaultAsync(ct=>ct.Id==IdCabTrat);
                if (cabTrat==null){
                    resposta.Mensagem="Não existe esse cabelo vinculado a tratamento";
                    return resposta;
                }
                _context.Remove(cabTrat);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.CabeloTratamento.ToListAsync();
                resposta.Mensagem="Cabelo disvinulado ao tratamento";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloTratamentoModel>>> ListarCabeloTratamento()
        {
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();

            try
            {
                var cabeloTratamento = await _context.CabeloTratamento.Include(c=>c.Cabelo).Include(t=>t.Tratamento)
                .Select(ct=>new CabeloTratamentoModel{
                        Id=ct.Id,
                        Cabelo=new CabeloModel{
                            Id=ct.Cabelo.Id,
                            Composicao=ct.Cabelo.Composicao,
                            Forma=ct.Cabelo.Forma,
                            Textura=ct.Cabelo.Textura,
                        },
                        Tratamento=new TratamentoModel{
                            Id=ct.Tratamento.Id,
                            Beneficios=ct.Tratamento.Beneficios,
                            Produtos=ct.Tratamento.Produtos,
                            Funcao=ct.Tratamento.Funcao,
                            Descritivo=ct.Tratamento.Descritivo,
                        }
                    }).ToListAsync();
                resposta.Dados=cabeloTratamento;
                resposta.Mensagem="tudo buscado";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloTratamentoModel>>> ListarTratamentoPorForma(string forma)
        {
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();
            try
            {
                var cabeloTratamento = await _context.CabeloTratamento.Include(c=>c.Cabelo).Include(t=>t.Tratamento) 
                    .Where(ct=>ct.Cabelo.Forma==forma)
                    .Select(ct=>new CabeloTratamentoModel{
                        Id=ct.Id,
                        Cabelo=new CabeloModel{
                            Id=ct.Cabelo.Id,
                            Composicao=ct.Cabelo.Composicao,
                            Forma=ct.Cabelo.Forma,
                            Textura=ct.Cabelo.Textura,
                        },
                        Tratamento=new TratamentoModel{
                            Id=ct.Tratamento.Id,
                            Beneficios=ct.Tratamento.Beneficios,
                            Produtos=ct.Tratamento.Produtos,
                            Funcao=ct.Tratamento.Funcao,
                            Descritivo=ct.Tratamento.Descritivo,
                        }
                    }).ToListAsync();
                resposta.Dados=cabeloTratamento;
                resposta.Mensagem="Tudo buscado";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloTratamentoModel>>> ListarTratamentoPorNome(string nome)
        {
            ResponseModel<List<CabeloTratamentoModel>> resposta = new ResponseModel<List<CabeloTratamentoModel>>();
            try
            {
                var cabeloTratamento = await _context.CabeloTratamento.Include(c=>c.Cabelo).Include(t=>t.Tratamento) 
                    .Where(ct=>ct.Tratamento.Nome==nome)
                    .Select(ct=>new CabeloTratamentoModel{
                        Id=ct.Id,
                        Cabelo=new CabeloModel{
                            Id=ct.Cabelo.Id,
                            Composicao=ct.Cabelo.Composicao,
                            Forma=ct.Cabelo.Forma,
                            Textura=ct.Cabelo.Textura,
                        },
                        Tratamento=new TratamentoModel{
                            Id=ct.Tratamento.Id,
                            Beneficios=ct.Tratamento.Beneficios,
                            Produtos=ct.Tratamento.Produtos,
                            Funcao=ct.Tratamento.Funcao,
                            Descritivo=ct.Tratamento.Descritivo,
                        }
                    }).ToListAsync();
                resposta.Dados=cabeloTratamento;
                resposta.Mensagem="Tudo buscado";
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