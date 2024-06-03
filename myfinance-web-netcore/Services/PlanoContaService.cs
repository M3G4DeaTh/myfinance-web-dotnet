using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;

        public PlanoContaService(MyFinanceDbContext myFinanceDbContext, IMapper mapper)
        {
        
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            _myFinanceDbContext.Attach(item);
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public List<PlanoContaModel> ListarRegistros()
        {
            var listaPlanoConta = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<List<PlanoContaModel>>(listaPlanoConta);
            return lista;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            var registro =_mapper.Map<PlanoContaModel>(item);
            return registro;
        }

        public void Salvar(PlanoContaModel model)
        {
            var item = _mapper.Map<PlanoConta>(model);
            var dbSet = _myFinanceDbContext.PlanoConta;

            if(item.Id == 0){
                dbSet.Add(item);
            }
            else{
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
    }
}