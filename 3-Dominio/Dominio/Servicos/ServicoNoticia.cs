﻿using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoNoticia : IServicoNoticia
    {
        private readonly INoticia _iNoticia;

        public ServicoNoticia(INoticia iNoticia)
        {
            _iNoticia = iNoticia;
        }

        public async Task AdicionaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidarPropriedadeString(noticia.Informacao, "Informação");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _iNoticia.Adicionar(noticia);
            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidarPropriedadeString(noticia.Informacao, "Informação");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _iNoticia.Atualizar(noticia);
            }
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _iNoticia.ListarNoticias(n => n.Ativo);
        }
    }
}
