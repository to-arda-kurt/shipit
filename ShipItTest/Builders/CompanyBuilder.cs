﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShipIt.Models.ApiModels;

namespace ShipItTest.Builders
{
    public class CompanyBuilder
    {
        private String Gcp = "0000346";
        private String Name = "Robert Bosch Tool Corporation";
        private String Addr2 = "1800 West Central";
        private String Addr3 = "";
        private String Addr4 = "IL";
        private String PostalCode = "60056";
        private String City = "Mount Prospect";
        private String Tel = "(224) 232-2407";
        private String Mail = "info@gs1us.org";

        public CompanyBuilder setGcp(String gcp)
        {
            this.Gcp = gcp;
            return this;
        }

        public CompanyBuilder setName(String name)
        {
            this.Name = name;
            return this;
        }

        public CompanyBuilder setAddr2(String addr2)
        {
            this.Addr2= addr2;
            return this;
        }

        public CompanyBuilder setAddr3(String addr3)
        {
            this.Addr3 = addr3;
            return this;
        }

        public CompanyBuilder setAddr4(String addr4)
        {
            this.Addr4 = addr4;
            return this;
        }

        public CompanyBuilder setPostalCode(String postalCode)
        {
            this.PostalCode = postalCode;
            return this;
        }

        public CompanyBuilder setCity(String city)
        {
            this.City = city;
            return this;
        }

        public CompanyBuilder setTel(String tel)
        {
            this.Tel = tel;
            return this;
        }

        public CompanyBuilder setMail(String mail)
        {
            this.Mail = mail;
            return this;
        }

        public Company CreateCompany()
        {
            return new Company()
            {
                Gcp = this.Gcp,
                Name = this.Name,
                Addr2 = this.Addr2,
                Addr3 = this.Addr3,
                Addr4 = this.Addr4,
                PostalCode = this.PostalCode,
                City = this.City,
                Tel = this.Tel,
                Mail = this.Mail
            };
        }

        public AddCompaniesRequest CreateAddCompaniesRequest()
        {
            return new AddCompaniesRequest()
            {
                companies = new List<Company>()
                {
                    new Company()
                    {
                        Gcp = this.Gcp,
                        Name = this.Name,
                        Addr2 = this.Addr2,
                        Addr3 = this.Addr3,
                        Addr4 = this.Addr4,
                        PostalCode = this.PostalCode,
                        City = this.City,
                        Tel = this.Tel,
                        Mail = this.Mail
                    }
                }
            };
        }
    }
}
