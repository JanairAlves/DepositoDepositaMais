﻿
namespace DepositoDepositaMais.Application.ViewModels
{
    public class IncomingInvoiceViewModel
    {
        public IncomingInvoiceViewModel(int idIncomingInvoice, string companyName, string cNPJCompany, string cPFCompany, string carrierName, string carPlate, string cNPJCarrier, string cPFCarrier)
        {
            IdIncomingInvoice = idIncomingInvoice;
            CompanyName = companyName;
            CNPJCompany = cNPJCompany;
            CPFCompany = cPFCompany;
            CarrierName = carrierName;
            CarPlate = carPlate;
            CNPJCarrier = cNPJCarrier;
            CPFCarrier = cPFCarrier;
        }
        #region  Dados da empresa
        public int IdIncomingInvoice { get; }
        public string CompanyName { get; private set; }
        public string CNPJCompany { get; private set; }
        public string CPFCompany { get; private set; }
        #endregion

        #region Dados da transportadora
        public string CarrierName { get; private set; }
        public string CarPlate { get; private set; }
        public string CNPJCarrier { get; private set; }
        public string CPFCarrier { get; private set; }
        #endregion 
    }
}
