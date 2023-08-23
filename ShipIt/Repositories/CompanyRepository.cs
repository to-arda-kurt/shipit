﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Npgsql;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;

namespace ShipIt.Repositories
{
    public interface ICompanyRepository
    {
        int GetCount();
        CompanyDataModel GetCompany(string gcp);
        void AddCompanies(IEnumerable<Company> companies);
        Dictionary<string, CompanyDataModel> GetAllCompaniesByGcp(IEnumerable<string> companyIds);

    }

    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public int GetCount()
        {
            string CompanyCountSQL = "SELECT COUNT(*) FROM gcp";
            return (int)QueryForLong(CompanyCountSQL);
        }

        public CompanyDataModel GetCompany(string gcp)
        {
            string sql =
                "SELECT gcp_cd, gln_nm, gln_addr_02, gln_addr_03, gln_addr_04, gln_addr_postalcode, gln_addr_city, contact_tel, contact_mail " +
                "FROM gcp " +
                "WHERE gcp_cd = @gcp_cd";
            var parameter = new NpgsqlParameter("@gcp_cd", gcp);
            string noProductWithIdErrorMessage = string.Format("No companies found with gcp: {0}", gcp);
            return base.RunSingleGetQuery(sql, reader => new CompanyDataModel(reader), noProductWithIdErrorMessage, parameter);
        }

        public Dictionary<string, CompanyDataModel> GetAllCompaniesByGcp(IEnumerable<string> companyIds)
        {
            string sql = string.Format("SELECT gcp_cd, gln_nm, gln_addr_02, gln_addr_03, gln_addr_04, gln_addr_postalcode, gln_addr_city, contact_tel, contact_mail FROM gcp WHERE gcp_cd IN ({0})",
                String.Join(",", companyIds.Select(compId => $"'{compId}'")));
            string noProductWithIdErrorMessage = string.Format("No companies found with gcp_cd: {0}", String.Join(",", companyIds)) ;
            var companies = base.RunGetQuery(sql, reader => new CompanyDataModel(reader), noProductWithIdErrorMessage);
            return companies.ToDictionary(c => c.Gcp, c => c);
        }

        public void AddCompanies(IEnumerable<Company> companies)
        {
            string sql =
                "INSERT INTO gcp (gcp_cd, gln_nm, gln_addr_02, gln_addr_03, gln_addr_04, gln_addr_postalcode, gln_addr_city, contact_tel, contact_mail) " +
                "VALUES (@gcp_cd, @gln_nm, @gln_addr_02, @gln_addr_03, @gln_addr_04, @gln_addr_postalcode, @gln_addr_city, @contact_tel, @contact_mail)";

            var parametersList = new List<NpgsqlParameter[]>();
            foreach (var company in companies)
            {
                var companyDataModel = new CompanyDataModel(company);
                parametersList.Add(companyDataModel.GetNpgsqlParameters().ToArray());
            }

            base.RunTransaction(sql, parametersList);
        }
    }

}