using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoMysql.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoMysql.Controllers
{
    public class ContatoController : Controller
    {



        //Trazendo Context do models
        private readonly DataContext _datacontext;

        //Iniciando classe contexto "Cria/inicia db ou table"
        public ContatoController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }



        /*
         * Trazendo informações em list
         */
        public async Task<IActionResult> Index()
        {
            //return View(await _datacontext.Contato.ToListAsync());
            return View(await _datacontext.Contato.OrderByDescending(x => x.Id).ToListAsync());//Traz o ultimo registro no top da lista
        }


        /*
         * Listando informações de forma detalhada
         */
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _datacontext.Contato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }





        /*
         * AÇÃO DE CRIAR CONTATO
         * No httpget abrimos o arquivo com o form
         * No httppost executamos a ação post do formulario que neste caso é adicionar
         * 
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarContato(/*[Bind("Nome,Email,Tel,MSG")] */Contato contato)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(contato);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(contato);
        }





        /*
         * AÇÃO DE EDITAR CONTATO
         * No htppget abriremos o arquivo Edit na view contato
         * No httppos executaremos a atualização post vinda do form
         * 
         */

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Contato contato = _datacontext.Contato.Find(id);
                return View(contato);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarContato(int? id, Contato contato)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _datacontext.Update(contato);
                    await _datacontext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else return View(contato);
            }
            else return View(contato);
        }




        /*
         * AÇÃO DE EXCLUIR CONTATO
         * No httpget abriremos o arquivo delete na view contato e buscaremos pela id
         * No httppost executaremos a exclusão
         *
         */

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Contato contato = _datacontext.Contato.Find(id);
                return View(contato);
            }
            else return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> ExcluirContato(int? id, Contato contato)
        {
            if (id != null)
            {
                _datacontext.Remove(contato);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();
        }



    }
}
