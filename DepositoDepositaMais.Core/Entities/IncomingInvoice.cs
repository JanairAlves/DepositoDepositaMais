using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class IncomingInvoice : BaseEntity
    {
        public IncomingInvoice(string companyName, string companyAddress, string cNPJCompany, string cPFCompany, 
            string companyStateRegistration, string carrierName, CodeResponsibilityEnum codeResponsibility, 
            string carPlate, string cNPJCarrier, string cPFCarrier, string carrierAdress, string carrierStateRegistration, 
            int productId, int quantityOfProducts, decimal value, TypeOfVolumeEnum typeOfVolume, 
            int weightOfTheCargo, string description, DateTime receivedIn)
        {
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

            ProductId = productId;
            QuantityOfProducts = quantityOfProducts;
            Value = value;

            TypeOfVolume = typeOfVolume;
            WeightOfTheCargo = weightOfTheCargo;

            Status = IncomingInvoiceStateEnum.Active;
            Description = description;
            CreatedAt = DateTime.Now;
            ReceivedIn = receivedIn;

        }

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
        public int ProductId { get; private set; }
        public int QuantityOfProducts { get; private set; }
        public decimal Value { get; private set; }
        #endregion

        #region Dados da carga
        public TypeOfVolumeEnum TypeOfVolume { get; private set; }
        public int WeightOfTheCargo { get; private set; }
        #endregion

        #region Dados da nota
        public IncomingInvoiceStateEnum Status { get; set; }
        public string   Description { get; private set; }
        public DateTime ReceivedIn { get; private set; }
        public DateTime CreatedAt { get; private set; }
        #endregion

        #region
        public List<IncomingOrder> IncomingOrders { get; private set; }
        #endregion

        public void Update(string companyName, string companyAddress, string cNPJCompany, string cPFCompany, 
            string companyStateRegistration, string carrierName, CodeResponsibilityEnum codeResponsibility, string carPlate, 
            string cNPJCarrier, string cPFCarrier, string carrierAdress, string carrierStateRegistration, int productId,
            decimal value, int quantityOfProducts, TypeOfVolumeEnum typeOfVolume, int weightOfTheCargo,
            IncomingInvoiceStateEnum status, string description, DateTime receivedIn)
        {
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
            ProductId = productId;
            QuantityOfProducts = quantityOfProducts;
            Value = value;
            TypeOfVolume = typeOfVolume;
            WeightOfTheCargo = weightOfTheCargo;
            Status = status;
            Description = description;
            ReceivedIn = receivedIn;
        }

        public void Activate()
        {
            if (Status == IncomingInvoiceStateEnum.Inactive)
                Status = IncomingInvoiceStateEnum.Active;
        }

        public void Inactivate()
        {
            if (Status == IncomingInvoiceStateEnum.Active)
                Status = IncomingInvoiceStateEnum.Inactive;
        }
    }
}
