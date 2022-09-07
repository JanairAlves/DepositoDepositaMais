using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class IncomingInvoiceDetailsViewModel
    {
        public IncomingInvoiceDetailsViewModel(int id, string companyName, string companyAddress, string cNPJCompany, 
            string cPFCompany, string companyStateRegistration, string carrierName, CodeResponsibilityEnum codeResponsibility, 
            string carPlate, string cNPJCarrier, string cPFCarrier, string carrierAdress, string carrierStateRegistration, 
            TypeOfVolumeEnum typeOfVolume, int weightOfTheCargo)
        {
            Id = id;
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            CNPJCompany = cNPJCompany;
            CPFCompany = cPFCompany;
            CompanyStateRegistration = companyStateRegistration;
            CarrierName = carrierName;
            CodeResponsibility = codeResponsibility;
            CarPlate = carPlate;
            CNPJCarrier = cNPJCarrier;
            CPFCarrier = cPFCarrier;
            CarrierAdress = carrierAdress;
            CarrierStateRegistration = carrierStateRegistration;
            TypeOfVolume = typeOfVolume;
            WeightOfTheCargo = weightOfTheCargo;
        }

        public int Id { get; }
        #region Dados da empresa
        public string CompanyName { get; private set; }
        public string CompanyAddress { get; private set; }
        public string CNPJCompany { get; private set; }
        public string CPFCompany { get; private set; }
        public string CompanyStateRegistration { get; private set; }
        #endregion

        #region Dados da transportadora
        public string CarrierName { get; private set; }
        public CodeResponsibilityEnum CodeResponsibility { get; private set; }
        public string CarPlate { get; private set; }
        public string CNPJCarrier { get; private set; }
        public string CPFCarrier { get; private set; }
        public string CarrierAdress { get; private set; }
        public string CarrierStateRegistration { get; private set; }
        #endregion 

        #region Dados dos produtos
        public TypeOfVolumeEnum TypeOfVolume { get; private set; }
        public int WeightOfTheCargo { get; private set; }
        #endregion 
    }
}
