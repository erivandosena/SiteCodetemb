using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Npgsql;
using Rwd.BLL;

public partial class Fotos : System.Web.UI.Page
{
    public string MetaDescription
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "description";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    public string MetaKeywords
    {
        set
        {
            using (HtmlHead head = Master.Page.Header)
            {
                using (HtmlMeta meta = new HtmlMeta())
                {
                    meta.Name = "keywords";
                    meta.Content = value;
                    head.Controls.Add(meta);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CarregaDadosWebsite();
    }

    private void CarregaDadosWebsite()
    {
        using (NpgsqlDataReader dr = BusinessLogic.SelecionaWebsiteDr())
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Adiciona na barra de titulo
                    Page.Header.Title = dr["web_nome"].ToString() + " - Fotos";

                    using (DataSet ds = BusinessLogic.SelecionaFiliadosNomesDs())
                    {
                        //Adiciona keywords Meta control 
                        MetaKeywords = DatasetToString(ds, BusinessLogic.SelecionaPaginasNomesDs());
                    }

                }
            }
        }
    }

    private string DatasetToString(DataSet ds, DataSet ds2)
    {
        Int32 i = 0;
        String str = "RWD_Sites";
        DataTable dt = ds.Tables[0];
        while (i < dt.Rows.Count)
        {
            str += ", " + dt.Rows[i][0].ToString() + ", " + dt.Rows[i][1].ToString();
            i++;
        }

        i = 0;
        String str2 = "";
        DataTable dt2 = ds2.Tables[0];
        while (i < dt2.Rows.Count)
        {
            str2 += ", " + dt2.Rows[i][0].ToString();
            i++;
        }

        return (str + str2);
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataList1.DataBind();
    }
}
