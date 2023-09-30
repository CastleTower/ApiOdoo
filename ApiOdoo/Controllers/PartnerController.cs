using ApiOdoo.Controllers;
using ComuncactionComponents.Model.Config;
using ComunicactionComponents.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiOddo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : BaseController
    {

        private static int _companyId = 1;
                
        [HttpPost("[action]")]
        
        public DataResponse Post(RpcConnection conn)
        {
            DataResponse dateResponse = new DataResponse();            
            var rpcContext = new RpcContext(conn, "res.partner");

            try
            {
                rpcContext
                .RpcFilter
                .Or() // burada tanımlı OR operatörü odoo'nun normal kullanımında olduğu gibi önündeki koşulu birbirine bağlar belirtilmez ise AND operatörü gibi çalışır
                .Equal("company_id", _companyId)
                .Equal("company_id", false)
                .Equal("ref", "TO9930914");

                /*
                 * Yukarıdaki koşulun açılımı
                 * if (company_id == 1 or company_id == false) and ref= "TO9930914")
                 */

                rpcContext
                    .AddField("id");
                var data = rpcContext.Execute(true, limit: 1);
                var partner = data.FirstOrDefault();
                if (partner != null)
                {
                    return dateResponse;
                }

                //İl
                var stateId = GetCountryStateByName(conn, "İstanbul");

                //res.partner - Create
                RpcRecord record = new RpcRecord(conn, "res.partner", -1, new List<RpcField>
                {
                    new RpcField{FieldName = "name", Value = "İsmail Eski"},
                    new RpcField{FieldName = "street", Value = "Merkez"},
                    new RpcField{FieldName = "street2", Value = "Merkez Mh."},
                    new RpcField{FieldName = "state_id", Value = stateId},
                    new RpcField{FieldName = "vat", Value = "TR1234567890"}
                });

                record.Save();

            }
            catch (Exception ex)
            {
                dateResponse = FormatException(ex);
            }

            return dateResponse;

        }
        static int GetCountryStateByName(RpcConnection conn, string stateName)
        {
            var rpcContext = new RpcContext(conn, "res.country.state");

            rpcContext
                .RpcFilter.Equal("name", stateName);

            rpcContext
                .AddField("id");

            var data = rpcContext.Execute(limit: 1);
            return data.FirstOrDefault().Id;

        }
    }
}
