using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Rwd.DAL;
using Npgsql;

/// <summary>
/// Summary description for NoticiasBLL
/// </summary>
/// 

namespace Rwd.BLL
{

    [DataObject(true)]
    public class BusinessLogic
    {
        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE PÁGINAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InserePaginas(string pag_nome, string pag_descricao, string pag_conteudo, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);
                db.AddParameter("@pag_menu", pag_menu);

                db.ExecuteNonQuery("insere_paginas");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaPaginasDr(int pag_cod, string pag_nome, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                db.Parameters.Add(new NpgsqlParameter("@pag_menu", pag_menu));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_paginas");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasDs(int pag_cod, string pag_nome, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@pag_cod", pag_cod));
                db.Parameters.Add(new NpgsqlParameter("@pag_nome", pag_nome));
                db.Parameters.Add(new NpgsqlParameter("@pag_menu", pag_menu));
                DataSet ds = db.ExecuteDataSet("seleciona_paginas");
                return ds;
            }
        }

        //Seleciona nomes paginas por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaPaginasNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_paginas_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaPaginas(int pag_cod, string pag_nome, string pag_descricao, string pag_conteudo, string pag_menu)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);
                db.AddParameter("@pag_nome", pag_nome);
                db.AddParameter("@pag_descricao", pag_descricao);
                db.AddParameter("@pag_conteudo", pag_conteudo);
                db.AddParameter("@pag_menu", pag_menu);

                db.ExecuteNonQuery("atualiza_paginas");
            }
        }

        //Exclui
        public static void ExcluiPaginas(int pag_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@pag_cod", pag_cod);

                db.ExecuteNonQuery("exclui_paginas");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE URLs
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereUrls(string url_nome, string url_link)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@url_nome", url_nome);
                db.AddParameter("@url_link", url_link);

                db.ExecuteNonQuery("insere_urls");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaUrlsDr(int url_cod, string url_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@url_cod", url_cod));
                db.Parameters.Add(new NpgsqlParameter("@url_nome", url_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_urls");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaUrlsDs(int url_cod, string url_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@url_cod", url_cod));
                db.Parameters.Add(new NpgsqlParameter("@url_nome", url_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_urls");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaUrls(int url_cod, string url_nome, string url_link)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@url_cod", url_cod);
                db.AddParameter("@url_nome", url_nome);
                db.AddParameter("@url_link", url_link);

                db.ExecuteNonQuery("atualiza_urls");
            }
        }

        //Exclui
        public static void ExcluiUrls(int url_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@url_cod", url_cod);

                db.ExecuteNonQuery("exclui_urls");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE WEBSITE
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereWebsite(
            string web_nome,
            string web_slogan,
            string web_contato,
            string web_fantasia,
            string web_cpf_cnpj,
            string web_endereco,
            string web_cidade,
            string web_estado,
            string web_cep,
            string web_site,
            byte[] web_logo,
            string web_telefone1, 
            string web_telefone2, 
            string web_email1, 
            string web_email2, 
            string web_skype, 
            string web_publicidade1, 
            string web_publicidade2, 
            string web_mapa)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@web_nome", web_nome);
                db.AddParameter("@web_slogan", web_slogan);
                db.AddParameter("@web_contato", web_contato);
                db.AddParameter("@web_fantasia", web_fantasia);
                db.AddParameter("@web_cpf_cnpj", web_cpf_cnpj);
                db.AddParameter("@web_endereco", web_endereco);
                db.AddParameter("@web_cidade", web_cidade);
                db.AddParameter("@web_estado", web_estado);
                db.AddParameter("@web_cep", web_cep);
                db.AddParameter("@web_site", web_site);

                if (web_logo == null)
                {
                    db.AddParameter("@web_logo", web_logo);
                }
                else
                {
                    db.AddParameter("@web_logo", ResizeImageFile(web_logo, 176));
                }

                db.AddParameter("@web_telefone1", web_telefone1);
                db.AddParameter("@web_telefone2", web_telefone2);
                db.AddParameter("@web_email1", web_email1);
                db.AddParameter("@web_email2", web_email2);
                db.AddParameter("@web_skype", web_skype);
                db.AddParameter("@web_publicidade1", web_publicidade1);
                db.AddParameter("@web_publicidade2", web_publicidade2);
                db.AddParameter("@web_mapa", web_mapa);

                db.ExecuteNonQuery("insere_website");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaWebsiteDr()
        {
            using (DataAccess db = new DataAccess())
            {
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_website");
                return dr;
            }
        }

        //Atualiza
        public static void AtualizaWebsite(
            int web_cod,
            string web_nome,
            string web_slogan,
            string web_contato,
            string web_fantasia,
            string web_cpf_cnpj,
            string web_endereco,
            string web_cidade,
            string web_estado,
            string web_cep,
            string web_site,
            string web_telefone1,
            string web_telefone2,
            string web_email1,
            string web_email2,
            string web_skype,
            string web_publicidade1,
            string web_publicidade2,
            string web_mapa)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@web_cod", web_cod);
                db.AddParameter("@web_nome", web_nome);
                db.AddParameter("@web_slogan", web_slogan);
                db.AddParameter("@web_contato", web_contato);
                db.AddParameter("@web_fantasia", web_fantasia);
                db.AddParameter("@web_cpf_cnpj", web_cpf_cnpj);
                db.AddParameter("@web_endereco", web_endereco);
                db.AddParameter("@web_cidade", web_cidade);
                db.AddParameter("@web_estado", web_estado);
                db.AddParameter("@web_cep", web_cep);
                db.AddParameter("@web_site", web_site);
                db.AddParameter("@web_telefone1", web_telefone1);
                db.AddParameter("@web_telefone2", web_telefone2);
                db.AddParameter("@web_email1", web_email1);
                db.AddParameter("@web_email2", web_email2);
                db.AddParameter("@web_skype", web_skype);
                db.AddParameter("@web_publicidade1", web_publicidade1);
                db.AddParameter("@web_publicidade2", web_publicidade2);
                db.AddParameter("@web_mapa", web_mapa);

                db.ExecuteNonQuery("atualiza_website");
            }
        }

        //Atualiza imagem
        public static void AtualizaWebsiteImagem(int web_cod, byte[] web_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@web_cod", web_cod);

                if (web_logo == null)
                {
                    db.AddParameter("@web_logo", web_logo);
                }
                else
                {
                    db.AddParameter("@web_logo", ResizeImageFile(web_logo, 176));
                }

                db.ExecuteNonQuery("atualiza_website_imagem");
            }
        }

        //Exclui
        public static void ExcluiWebsite(int web_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@web_cod", web_cod);

                db.ExecuteNonQuery("exclui_website");
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE NOTÍCIAS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereNoticias(
            string not_legenda,
            string not_titulo,
            string not_sumario,
            string not_fonte,
            string not_autor,
            string not_autoremail,
            string not_noticia)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_legenda", not_legenda);
                db.AddParameter("@not_titulo", not_titulo);
                db.AddParameter("@not_sumario", not_sumario);
                db.AddParameter("@not_fonte", not_fonte);
                db.AddParameter("@not_autor", not_autor);
                db.AddParameter("@not_autoremail", not_autoremail);
                db.AddParameter("@not_noticia", not_noticia);

                db.ExecuteNonQuery("insere_noticias");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaNoticiasDr(int not_cod, string not_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                db.Parameters.Add(new NpgsqlParameter("@not_titulo", not_titulo));

                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_noticias");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaNoticiasDs(int not_cod, string not_titulo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                db.Parameters.Add(new NpgsqlParameter("@not_titulo", not_titulo));

                DataSet ds = db.ExecuteDataSet("seleciona_noticias");
                return ds;
            }
        }

        //Seleciona notícias publicadas por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaNoticiasPublicadasDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_noticias_exibe_todas");
                return ds;
            }
        }

        //Seleciona 10 notícias por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet Seleciona10NoticiasDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_noticias_10");
                return ds;
            }
        }

        //Seleciona última notícia publicada por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaNoticiasUltimaDr()
        {
            using (DataAccess db = new DataAccess())
            {
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_noticias_ultima");
                return dr;
            }
        }

        //Atualiza
        public static void AtualizaNoticias(
            int not_cod,
            DateTime not_dataalteracao,
            string not_legenda,
            string not_titulo,
            string not_sumario,
            string not_fonte,
            string not_autor,
            string not_autoremail,
            string not_noticia)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@not_dataalteracao", not_dataalteracao);
                db.AddParameter("@not_legenda", not_legenda);
                db.AddParameter("@not_titulo", not_titulo);
                db.AddParameter("@not_sumario", not_sumario);
                db.AddParameter("@not_fonte", not_fonte);
                db.AddParameter("@not_autor", not_autor);
                db.AddParameter("@not_autoremail", not_autoremail);
                db.AddParameter("@not_noticia", not_noticia);

                db.ExecuteNonQuery("atualiza_noticias");
            }
        }
        
        //Atualiza publicação
        public static void AtualizaNoticiasPublicacao(int not_cod, string not_status)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@not_status", not_status);

                db.ExecuteNonQuery("atualiza_noticias_publicacao");
            }
        }

        //Atualiza visualização
        public static void AtualizaNoticiasVisualizao(int codigo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@codigo", codigo);

                db.ExecuteNonQuery("atualiza_noticias_visualizacoes");
            }
        }

        //Exclui
        public static void ExcluiNoticias(int not_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);

                db.ExecuteNonQuery("exclui_noticias");
            }
        }
        ////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE IMAGENS DA NOTÍCIA
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereImagensnoticia(
            int not_cod,
            byte[] foto,
            int ima_foto_tamanho,
            string ima_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@ima_foto_mini", ResizeImageFile(foto, 200));
                db.AddParameter("@ima_foto_normal", ResizeImageFile(foto, 500));
                db.AddParameter("@ima_foto_ampliada", ResizeImageFile(foto, 900));
                db.AddParameter("@ima_foto_tamanho", ima_foto_tamanho);
                db.AddParameter("@ima_legenda", ima_legenda);

                db.ExecuteNonQuery("insere_imagensnoticia");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaImagensnoticiaDr(int url_cod, string url_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@url_cod", url_cod));
                db.Parameters.Add(new NpgsqlParameter("@url_nome", url_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_imagensnoticia");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaImagensnoticiaDs(int not_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@not_cod", not_cod));
                DataSet ds = db.ExecuteDataSet("seleciona_imagensnoticia");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaImagensnoticia(
            int ima_cod,
            int not_cod,
            byte[] foto,
            int ima_foto_tamanho,
            string ima_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@ima_cod", ima_cod);
                db.AddParameter("@not_cod", not_cod);
                db.AddParameter("@ima_foto_mini", ResizeImageFile(foto, 200));
                db.AddParameter("@ima_foto_normal", ResizeImageFile(foto, 500));
                db.AddParameter("@ima_foto_ampliada", ResizeImageFile(foto, 900));
                db.AddParameter("@ima_foto_tamanho", ima_foto_tamanho);
                db.AddParameter("@ima_legenda", ima_legenda);

                db.ExecuteNonQuery("atualiza_imagensnoticia");
            }
        }

        //Exclui
        public static void ExcluiImagensnoticia(int ima_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@ima_cod", ima_cod);

                db.ExecuteNonQuery("exclui_imagensnoticia");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE MUNICÍPIOS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereMunicipios(
            string mun_nome, 
            string mun_gestor,
            string mun_estado, 
            string mun_cep,
            string mun_site, 
            string mun_mapa,
            byte[] mun_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@mun_nome", mun_nome);
                db.AddParameter("@mun_gestor", mun_gestor);
                db.AddParameter("@mun_estado", mun_estado);
                db.AddParameter("@mun_cep", mun_cep);
                db.AddParameter("@mun_site", mun_site);
                db.AddParameter("@mun_mapa", mun_mapa);
                if (mun_logo == null)
                {
                    db.AddParameter("@mun_logo", mun_logo);
                }
                else
                {
                    db.AddParameter("@mun_logo", ResizeImageFile(mun_logo, 200));
                }

                db.ExecuteNonQuery("insere_municipios");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaMunicipiosDr(int mun_cod, string mun_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@mun_cod", mun_cod));
                db.Parameters.Add(new NpgsqlParameter("@mun_nome", mun_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_municipios");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaMunicipiosDs(int mun_cod, string mun_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@mun_cod", mun_cod));
                db.Parameters.Add(new NpgsqlParameter("@mun_nome", mun_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_municipios");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaMunicipios(
            int mun_cod,
            string mun_nome,
            string mun_gestor,
            string mun_estado,
            string mun_cep,
            string mun_site,
            string mun_mapa)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@mun_cod", mun_cod);
                db.AddParameter("@mun_nome", mun_nome);
                db.AddParameter("@mun_gestor", mun_gestor);
                db.AddParameter("@mun_estado", mun_estado);
                db.AddParameter("@mun_cep", mun_cep);
                db.AddParameter("@mun_site", mun_site);
                db.AddParameter("@mun_mapa", mun_mapa);

                db.ExecuteNonQuery("atualiza_municipios");
            }
        }

        //Atualiza imagem
        public static void AtualizaMunicipiosImagem(int mun_cod, byte[] mun_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@mun_cod", mun_cod);
                if (mun_logo == null)
                {
                    db.AddParameter("@mun_logo", mun_logo);
                }
                else
                {
                    db.AddParameter("@mun_logo", ResizeImageFile(mun_logo, 200));
                }

                db.ExecuteNonQuery("atualiza_municipios_imagem");
            }
        }

        //Exclui
        public static void ExcluiMunicipios(int mun_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@mun_cod", mun_cod);

                db.ExecuteNonQuery("exclui_municipios");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE FILIADOS
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereFiliados(
            int mun_cod, 
            string fil_nome,
            string fil_responsavel, 
            string fil_endereco,
            string fil_site, 
            string fil_telefone,
            string fil_email, 
            byte[] fil_logo,
            string fil_tipo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@mun_cod", mun_cod);
                db.AddParameter("@fil_nome", fil_nome);
                db.AddParameter("@fil_responsavel", fil_responsavel);
                db.AddParameter("@fil_endereco", fil_endereco);
                db.AddParameter("@fil_site", fil_site);
                db.AddParameter("@fil_telefone", fil_telefone);
                db.AddParameter("@fil_email", fil_email);
                if (fil_logo == null)
                {
                    db.AddParameter("@fil_logo", fil_logo);
                }
                else
                {
                    db.AddParameter("@fil_logo", ResizeImageFile(fil_logo, 200));
                }
                db.AddParameter("@fil_tipo", fil_tipo);

                db.ExecuteNonQuery("insere_filiados");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaFiliadosDr(int fil_cod, string fil_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fil_cod", fil_cod));
                db.Parameters.Add(new NpgsqlParameter("@fil_nome", fil_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_filiados");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaFiliadosDs(int fil_cod, string fil_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fil_cod", fil_cod));
                db.Parameters.Add(new NpgsqlParameter("@fil_nome", fil_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_filiados");
                return ds;
            }
        }

        //Seleciona filiados e municipios por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaFiliadosMunicipiosDs(int fil_cod, string mun_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fil_cod", fil_cod));
                db.Parameters.Add(new NpgsqlParameter("@mun_nome", mun_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_filiados_municipio");
                return ds;
            }
        }

        //Seleciona nomes filiados por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaFiliadosNomesDs()
        {
            using (DataAccess db = new DataAccess())
            {
                DataSet ds = db.ExecuteDataSet("seleciona_filiados_nome");
                return ds;
            }
        }

        //Atualiza
        public static void AtualizaFiliados(
            int fil_cod, 
            int mun_cod,
            string fil_nome,
            string fil_responsavel,
            string fil_endereco,
            string fil_site,
            string fil_telefone,
            string fil_email,
            string fil_tipo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@fil_cod", fil_cod);
                db.AddParameter("@mun_cod", mun_cod);
                db.AddParameter("@fil_nome", fil_nome);
                db.AddParameter("@fil_responsavel", fil_responsavel);
                db.AddParameter("@fil_endereco", fil_endereco);
                db.AddParameter("@fil_site", fil_site);
                db.AddParameter("@fil_telefone", fil_telefone);
                db.AddParameter("@fil_email", fil_email);
                db.AddParameter("@fil_tipo", fil_tipo);

                db.ExecuteNonQuery("atualiza_filiados");
            }
        }

        //Atualiza imagem
        public static void AtualizaFiliadosImagem(int fil_cod, byte[] fil_logo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@fil_cod", fil_cod);
                if (fil_logo == null)
                {
                    db.AddParameter("@fil_logo", fil_logo);
                }
                else
                {
                    db.AddParameter("@fil_logo", ResizeImageFile(fil_logo, 200));
                }
                
                db.ExecuteNonQuery("atualiza_filiados_imagem");
            }
        }

        //Exclui
        public static void ExcluiFiliados(int fil_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@fil_cod", fil_cod);

                db.ExecuteNonQuery("exclui_filiados");
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE ALBUM
        ////////////////////////////////////////////////////////////////////

        // Insere
        public static void InsereAlbum(string alb_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@alb_nome", alb_nome);

                db.ExecuteNonQuery("insere_album");
            }
        }

        //Atualiza
        public static void AtualizaAlbum(int alb_cod, string alb_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@alb_cod", alb_cod);
                db.AddParameter("@alb_nome", alb_nome);

                db.ExecuteNonQuery("atualiza_album");
            }
        }

        //Exclui
        public static void ExcluiAlbum(int alb_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@alb_cod", alb_cod);

                db.ExecuteNonQuery("exclui_album");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaAlbumDr(int alb_cod, string alb_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@alb_cod", alb_cod));
                db.Parameters.Add(new NpgsqlParameter("@alb_nome", alb_nome));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_album");
                return dr;
            }
        }

        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaAlbumDs(int alb_cod, string alb_nome)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@alb_cod", alb_cod));
                db.Parameters.Add(new NpgsqlParameter("@alb_nome", alb_nome));
                DataSet ds = db.ExecuteDataSet("seleciona_album");
                return ds;
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE FOTOALBUM
        ////////////////////////////////////////////////////////////////////
        // Insere
        public static void InsereFotoAlbum(
            int alb_cod,
            string fot_legenda,
            byte[] foto_original,
            string fot_tipo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@alb_cod", alb_cod);
                db.AddParameter("@fot_legenda", fot_legenda);
                if (foto_original == null)
                {
                    db.AddParameter("@fot_miniatura", foto_original);
                    db.AddParameter("@fot_normal", foto_original);
                }
                else
                {
                    db.AddParameter("@fot_miniatura", ResizeImageFile(foto_original, 100));
                    db.AddParameter("@fot_normal", ResizeImageFile(foto_original, 700));
                }
                db.AddParameter("@fot_tipo", fot_tipo);

                db.ExecuteNonQuery("insere_fotoalbum");
            }
        }

        //Atualiza
        public static void AtualizaFotoAlbum(
            int fot_cod,
            int alb_cod,
            string fot_legenda,
            byte[] foto_original,
            string fot_tipo)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@fot_cod", fot_cod);
                db.AddParameter("@alb_cod", alb_cod);
                db.AddParameter("@fot_legenda", fot_legenda);
                if (foto_original == null)
                {
                    db.AddParameter("@fot_miniatura", foto_original);
                    db.AddParameter("@fot_normal", foto_original);
                }
                else
                {
                    db.AddParameter("@fot_miniatura", ResizeImageFile(foto_original, 100));
                    db.AddParameter("@fot_normal", ResizeImageFile(foto_original, 700));
                }
                db.AddParameter("@fot_tipo", fot_tipo);

                db.ExecuteNonQuery("atualiza_fotoalbum");
            }
        }

        //Exclui
        public static void ExcluiFotoAlbum(int fot_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.AddParameter("@fot_cod", fot_cod);

                db.ExecuteNonQuery("exclui_fotoalbum");
            }
        }

        //Seleciona por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaFotoAlbumDr(int fot_cod, int alb_cod, string fot_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fot_cod", fot_cod));
                db.Parameters.Add(new NpgsqlParameter("@alb_cod", alb_cod));
                db.Parameters.Add(new NpgsqlParameter("@fot_legenda", fot_legenda));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_fotoalbum");
                return dr;
            }
        }

        //Seleciona foto unitaria por DataReader
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static NpgsqlDataReader SelecionaFotoAlbumUnitDr(int fot_cod)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fot_cod", fot_cod));
                NpgsqlDataReader dr = (NpgsqlDataReader)db.ExecuteReader("seleciona_fotoalbum_unitaria");
                return dr;
            }
        }


        //Seleciona por DataSet
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet SelecionaFotoAlbumDs(int fot_cod, int alb_cod, string fot_legenda)
        {
            using (DataAccess db = new DataAccess())
            {
                db.Parameters.Add(new NpgsqlParameter("@fot_cod", fot_cod));
                db.Parameters.Add(new NpgsqlParameter("@alb_cod", alb_cod));
                db.Parameters.Add(new NpgsqlParameter("@fot_legenda", fot_legenda));
                DataSet ds = db.ExecuteDataSet("seleciona_fotoalbum");
                return ds;
            }
        }
        ////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////
        //  LÓGICA DE TRATAMENTO DE IMAGEM
        ////////////////////////////////////////////////////////////////////
        //Helper Functions
        private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
            {
                Size newSize = CalculateDimensions(oldImage.Size, targetSize);                 //Format24bppRgb
                using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format64bppArgb))
                {
                    using (Graphics canvas = Graphics.FromImage(newImage))
                    {
                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                        MemoryStream m = new MemoryStream();
                        newImage.Save(m, ImageFormat.Jpeg);
                        return m.GetBuffer();
                    }
                }
            }
        }

        //Dimensiona
        private static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }

        //Imagens noticia
        public static Stream GetPhoto(int id, TamanhoImagem size)
        {

            DataAccess db = new DataAccess();
            db.AddParameter("@codigo", id);
            db.AddParameter("@tamanho", (int)size);
            object result = db.ExecuteScalar("seleciona_imagensnoticia_imagem");
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }

        }

        //Imagem website
        public static Stream GetPhotoWebsite(int id)
        {

            DataAccess db = new DataAccess();
            db.AddParameter("@codigo", id);
            object result = db.ExecuteScalar("seleciona_website_imagem");
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }

        }

        //Imagem municipio
        public static Stream GetPhotoMunicipios(int id)
        {

            DataAccess db = new DataAccess();
            db.AddParameter("@codigo", id);
            object result = db.ExecuteScalar("seleciona_municipios_imagem");
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }

        }

        //Imagem filiado
        public static Stream GetPhotoFiliados(int id)
        {

            DataAccess db = new DataAccess();
            db.AddParameter("@codigo", id);
            object result = db.ExecuteScalar("seleciona_filiados_imagem");
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }

        }

        //Imagens album
        public static Stream GetFotoAlbum(int id, TamanhoImagem size)
        {

            DataAccess db = new DataAccess();
            db.AddParameter("@codigo", id);
            db.AddParameter("@tamanho", (int)size);
            object result = db.ExecuteScalar("seleciona_fotoalbum_foto");
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }

        }

        //Trata erro relacionado á imagem
        public static Stream GetPhoto(TamanhoImagem size)
        {
            string path = HttpContext.Current.Server.MapPath("~/Images/");
            switch (size)
            {
                case TamanhoImagem.Miniatura:
                    path += "si_200.gif";
                    break;
                case TamanhoImagem.Normal:
                    path += "si_400.gif";
                    break;
                case TamanhoImagem.Ampliado:
                    path += "si_900.gif";
                    break;
                default:
                    path += "si_200.gif";
                    break;
            }
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        ////////////////////////////////////////////////////////////////////
    }
}

public enum TamanhoImagem
{
    Miniatura = 1,	// 200px
    Normal = 2,		// 500px
    Ampliado = 3	// 900px
}