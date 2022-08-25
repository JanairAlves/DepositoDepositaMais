using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateIncomingInvoiceInputModel
    {
        public int Id { get; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CNPJCompany { get; set; }
        public string CPFCompany { get; set; }
        public string CompanyStateRegistration { get; set; }
        public string CarrierName { get; set; }
        public CodeResponsibilityEnum CodeResponsibility { get; set; }
        public string CarPlate { get; set; }
        public string CNPJCarrier { get; set; }
        public string CPFCarrier { get; set; }
        public string CarrierAdress { get; set; }
        public string CarrierStateRegistration { get; set; }
        public TypeOfVolumeEnum TypeOfVolume { get; set; }
        public int WeightOfTheCargo { get; set; }
        public IncomingInvoiceStateEnum Status { get; set; }
        public string Description { get; private set; }
        public DateTime ReceivedIn { get; private set; }
    }
}
