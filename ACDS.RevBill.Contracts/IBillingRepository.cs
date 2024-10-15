﻿using System;
using ACDS.RevBill.Entities.Models;
using ACDS.RevBill.Shared.DataTransferObjects.Billing;
using ACDS.RevBill.Shared.RequestFeatures;

namespace ACDS.RevBill.Contracts
{
	public interface IBillingRepository
	{
        Task<PagedList<Billing>> GetAllBillsAsync(int organisationId, BillingParameters requestParameters, bool trackChanges);
        Task<PagedList<Billing>> GetPayerBillsAsync(int organisationId, int agencyId, BillingParameters requestParameters, bool trackChanges);
        Task<PagedList<Billing>> GetAgencyBillsAsync(int organisationId, int agencyId, BillingParameters requestParameters, bool trackChanges);
        Task<PagedList<Billing>> GetAllBillsAsync(int organisationId, DebtReportParameters param, bool trackChanges);
        Task<Billing> GetBillAsync(int organisationId, long billId, bool trackChanges);
        Task<PagedList<Billing>> GetCustomerBillAsync(int organisationId, int customerId, DefaultParameters requestParameters, bool trackChanges);
        Task<IEnumerable<Billing>> GetCustomerBillHarmonisedIdAsync(int organisationId, int customerId, string harmonisedbillref);
        Task<IEnumerable<Billing>> GetCustomerBillbyYearAsync(int organisationId, int customerId, int propertyId, bool trackChanges);
        void CreatePropertyBill(int organisationId, int propertyId, int customerId, IEnumerable<Billing> billings);
        void CreateBill(int organisationId, int propertyId, int customerId, Billing billings);
        void CreateNonPropertyBill(int organisationId, int customerId, IEnumerable<Billing> billings);
        void CreateAutoGeneratedBill(int organisationId, int propertyId, int customerId, Billing billings);
    }
}