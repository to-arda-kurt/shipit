﻿using ShipIt.Models.ApiModels;
using System.Data;

namespace ShipIt.Models.DataModels
{
    public class CompanyDataModel : DataModel
    {
        [DatabaseColumnName("gcp_cd")]
        public string Gcp { get; set; }
        [DatabaseColumnName("gln_nm")]
        public string Name { get; set; }
        [DatabaseColumnName("gln_addr_02")]
        public string Addr2 { get; set; }
        [DatabaseColumnName("gln_addr_03")]
        public string Addr3 { get; set; }
        [DatabaseColumnName("gln_addr_04")]
        public string Addr4 { get; set; }
        [DatabaseColumnName("gln_addr_postalcode")]
        public string PostalCode { get; set; }
        [DatabaseColumnName("gln_addr_city")]
        public string City { get; set; }
        [DatabaseColumnName("contact_tel")]
        public string Tel { get; set; }
        [DatabaseColumnName("contact_mail")]
        public string Mail { get; set; }

        public CompanyDataModel(IDataReader dataReader) :base(dataReader)
        {
        }

        public CompanyDataModel(Company company)
        {
            this.Gcp = company.Gcp;
            this.Name = company.Name;
            this.Addr2 = company.Addr2;
            this.Addr3 = company.Addr3;
            this.Addr4 = company.Addr4;
            this.PostalCode = company.PostalCode;
            this.City = company.City;
            this.Tel = company.Tel;
            this.Mail = company.Mail;
        }
    }
}