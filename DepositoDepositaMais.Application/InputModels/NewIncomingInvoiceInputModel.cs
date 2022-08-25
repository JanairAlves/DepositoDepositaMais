using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewIncomingInvoiceInputModel
    {
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

        #region Dados da carga
        public int WeightOfTheCargo { get; private set; }
        public TypeOfVolumeEnum TypeOfVolume { get; private set; }
        #endregion

        #region Dados da nota
        public IncomingInvoiceStateEnum Status { get; private set; }
        public string   Description { get; private set; }
        public DateTime ReceivedIn { get; private set; }
        public DateTime CreatedAt { get; private set; }
        #endregion

    }
}
