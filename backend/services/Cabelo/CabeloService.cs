using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Dto.Cabelos;
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

        public async Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorForma(string formaCabelo)
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();

            try
            {
                var cabelos = await _context.Cabelos.Where(c => c.Forma == formaCabelo).ToListAsync();
                resposta.Dados=cabelos;
                resposta.Mensagem="Cabelos encontrados";
                return resposta;
                
            }
            catch (Exception e)
            {
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CabeloModel>> BuscarCabeloPorId(int idCabelo)
        {
            ResponseModel<CabeloModel> resposta = new ResponseModel<CabeloModel>();
            try
            {
                var cabelo = await _context.Cabelos.FirstOrDefaultAsync(cabeloBanco=>cabeloBanco.Id==idCabelo);
                if(cabelo==null){
                    resposta.Mensagem="Nenhum registro encontrado";
                    resposta.Dados=cabelo;
                    return resposta;
                }
                resposta.Dados=cabelo;
                resposta.Mensagem="Cabelo localizado";
                return resposta;
            }
            catch (Exception e)
            {
                
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloModel>>> BuscarCabeloPorTextura(string texturaCabelo)
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();
            try
            {
                var  cabelos= await _context.Cabelos.Where(c=>c.Textura==texturaCabelo).ToListAsync();
                resposta.Mensagem="Cabelos encontrados";
                resposta.Dados=cabelos;
                return resposta;
            }
            catch (Exception e)
            {
                
                resposta.Mensagem=e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloModel>>> CriarCabelo(CabeloCriacaoDto cabeloCriacaoDto)
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();

            try
            {
                var cabelo=new CabeloModel(){
                    Composicao=cabeloCriacaoDto.Composicao,
                    Textura=cabeloCriacaoDto.Textura,
                    Forma=cabeloCriacaoDto.Forma,
                };
                _context.Add(cabelo);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Cabelos.ToListAsync();
                resposta.Mensagem="Cabelo criado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloModel>>> EditarCabelo(CabeloEdicaoDto cabeloEdicaoDto)
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();
            try
            {
                var cabelo= await _context.Cabelos.FirstOrDefaultAsync(cabeloBanco=>cabeloBanco.Id==cabeloEdicaoDto.Id);
                if (cabelo==null){
                    resposta.Mensagem="Nenhum cabelo encontrado";
                    return resposta;
                }
                cabelo.Textura=cabeloEdicaoDto.Textura;
                cabelo.Composicao=cabeloEdicaoDto.Composicao;
                cabelo.Forma=cabeloEdicaoDto.Forma;
                _context.Update(cabelo);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Cabelos.ToListAsync();
                resposta.Mensagem="Cabelo alterado com sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CabeloModel>>> ExcluirCabelo(int idCabelo)
        {
            ResponseModel<List<CabeloModel>> resposta = new ResponseModel<List<CabeloModel>>();
            try
            {
                var cabelo=await _context.Cabelos.FirstOrDefaultAsync(cabeloBanco=>cabeloBanco.Id==idCabelo);
                if (cabelo!=null){
                    resposta.Mensagem="Nenhum cabelo encontrado";
                    return resposta;
                }
                _context.Remove(cabelo);
                await _context.SaveChangesAsync();
                resposta.Dados=await _context.Cabelos.ToListAsync();
                resposta.Mensagem="Cabelo excluido";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status=false;
                return resposta;
            }
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