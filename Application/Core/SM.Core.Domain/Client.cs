﻿namespace SM.Core.Domain
{
    public partial class Client
    {
        public int Dclink { get; set; }
        public string? Account { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public decimal PriceHalf { get; set; }
        public string? Init { get; set; }
        public string? ContactPerson { get; set; }
        public string? Physical1 { get; set; }
        public string? Physical2 { get; set; }
        public string? Physical3 { get; set; }
        public string? Physical4 { get; set; }
        public string? Physical5 { get; set; }
        public string? PhysicalPc { get; set; }
        public string? Addressee { get; set; }
        public string? Post1 { get; set; }
        public string? Post2 { get; set; }
        public string? Post3 { get; set; }
        public string? Post4 { get; set; }
        public string? Post5 { get; set; }
        public string? PostPc { get; set; }
        public string? DeliveredTo { get; set; }
        public string? Telephone { get; set; }
        public string? Telephone2 { get; set; }
        public string? Fax1 { get; set; }
        public string? Fax2 { get; set; }
        public int? AccountTerms { get; set; }
        public bool Ct { get; set; }
        public string? TaxNumber { get; set; }
        public string? Registration { get; set; }
        public double? CreditLimit { get; set; }
        public int? RepId { get; set; }
        public double? InterestRate { get; set; }
        public double? Discount { get; set; }
        public bool OnHold { get; set; }
        public int? BfopenType { get; set; }
        public string? Email { get; set; }
        public int? BankLink { get; set; }
        public string? BranchCode { get; set; }
        public string? BankAccNum { get; set; }
        public string? BankAccType { get; set; }
        public double? AutoDisc { get; set; }
        public int? DiscMtrxRow { get; set; }
        public int? MainAccLink { get; set; }
        public bool CashDebtor { get; set; }
        public double? Dcbalance { get; set; }
        public bool CheckTerms { get; set; }
        public bool UseEmail { get; set; }
        public int? IIncidentTypeId { get; set; }
        public int? IBusTypeId { get; set; }
        public int? IBusClassId { get; set; }
        public int? ICountryId { get; set; }
        public int? IAgentId { get; set; }
        public DateTime? DTimeStamp { get; set; }
        public string? CAccDescription { get; set; }
        public string? CWebPage { get; set; }
        public int? IClassId { get; set; }
        public int? IAreasId { get; set; }
        public string? CBankRefNr { get; set; }
        public int? ICurrencyId { get; set; }
        public bool BStatPrint { get; set; }
        public bool BStatEmail { get; set; }
        public string? CStatEmailPass { get; set; }
        public bool BForCurAcc { get; set; }
        public double? FForeignBalance { get; set; }
        public bool? BTaxPrompt { get; set; }
        public int? IArpriceListNameId { get; set; }
        public int ISettlementTermsId { get; set; }
        public bool? BSourceDocPrint { get; set; }
        public bool BSourceDocEmail { get; set; }
        public int IEucountryId { get; set; }
        public int IDefTaxTypeId { get; set; }
        public bool BCodaccount { get; set; }
        public DateTime? UdArdate { get; set; }
        public int? UiArdeliveryMethod { get; set; }
        public string? TOrderNotes { get; set; }
        public int? UiArcatid { get; set; }
        public decimal FuelLevyPercen { get; set; }
        public int Flid { get; set; }
        public int AccountStatusId { get; set; }
        public double IgufabRate { get; set; }
        public double CreditPercentage { get; set; }
        public double TotalDebitBalance { get; set; }
        public double TotInvoiced { get; set; }
        public double TotPending { get; set; }
        public double TotReceived { get; set; }
        public bool IsGlobalAcc { get; set; }
        public bool IsProspect { get; set; }
        public string CardIdentification { get; set; } = null!;
        public string? LegalName { get; set; }
        public string? TrustName { get; set; }
        public DateTime? BusinessEstablished { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Acn { get; set; }
        public string? Token { get; set; }
        public int EntityStructureId { get; set; }
        public int InsuredId { get; set; }
        public DateTime? CreditApplicationDate { get; set; }
        public DateTime? PpsExpiryDate { get; set; }
        public string? PersonalGurantee { get; set; }
        public string? CcNameOnCard { get; set; }
        public string? CcCardNumber { get; set; }
        public DateTime? CcExpiryDate { get; set; }
        public string? Bsb { get; set; }
        public string? AcountNumber { get; set; }
        public string? AcountName { get; set; }
        public DateTime? CreditSearch { get; set; }
        public string? Goni { get; set; }
        public bool BSendOrderConfirmations { get; set; }
        public string EmailOrderConfirmationTo { get; set; } = null!;
        public string EmailTaxInvoicesTo { get; set; } = null!;
        public string EmailStatementsTo { get; set; } = null!;
        public int RebateId { get; set; }
        public string XeroGuid { get; set; } = null!;
    }
}
