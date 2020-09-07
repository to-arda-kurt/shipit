﻿using ShipIt.Models.DataModels;
using System;
using System.Text;

namespace ShipIt.Models.ApiModels
{
    public class Company
    {
        public string Gcp { get; set; }
        public string Name { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Addr4 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }

        public Company(CompanyDataModel dataModel)
        {
            Gcp = dataModel.Gcp;
            Name = dataModel.Name;
            Addr2 = dataModel.Addr2;
            Addr3 = dataModel.Addr3;
            Addr4 = dataModel.Addr4;
            PostalCode = dataModel.PostalCode;
            City = dataModel.City;
            Tel = dataModel.Tel;
            Mail = dataModel.Mail;
        }

        //Empty constructor needed for Xml serialization
        public Company()
        {
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is Company))
            {
                return false;
            }

            Company company = (Company)obj;

            return Gcp == company.Gcp
                   && Name == company.Name
                   && Addr2 == company.Addr2
                   && Addr3 == company.Addr3
                   && Addr4 == company.Addr4
                   && PostalCode == company.PostalCode
                   && City == company.City
                   && Tel == company.Tel
                   && Mail == company.Mail;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Gcp != null ? Gcp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Addr2 != null ? Addr2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Addr3 != null ? Addr3.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Addr4 != null ? Addr4.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tel != null ? Tel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Mail != null ? Mail.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override String ToString()
        {
            return new StringBuilder()
                .AppendFormat("gcp: {0}, ", Gcp)
                .AppendFormat("name: {0}, ", Name)
                .AppendFormat("addr2: {0}, ", Addr2)
                .AppendFormat("addr3: {0}, ", Addr3)
                .AppendFormat("addr4: {0}, ", Addr4)
                .AppendFormat("postalCode: {0}, ", PostalCode)
                .AppendFormat("city: {0}, ", City)
                .AppendFormat("tel: {0}, ", Tel)
                .AppendFormat("mail: {0}", Mail)
                .ToString();
        }
    }
}