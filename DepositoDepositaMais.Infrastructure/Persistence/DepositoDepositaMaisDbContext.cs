using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Infrastructure.Persistence
{
    public class DepositoDepositaMaisDbContext
    {
        public DepositoDepositaMaisDbContext()
        {
            Products = new List<Product>
            {
                new Product ("78945613254", 1, "Feijão São José", "15", "20", "Fardo"),
                new Product ("78912345632", 2, "Arroz São José", "20", "30", "Fardo"),
                new Product ("78912378912", 3, "Requijão aromatico e saboroso", "12", "10", "Caixa")
            };

            Users = new List<User>
            {
                new User ("Janair Alves", "janair@gmail.com", new DateTime(1984, 10, 06), Skills2),
                new User ("Jonas Natanael", "jonas@gmail.com", new DateTime(1930, 06, 02), Skills2),
                new User ("Fablício Aparacido", "fablicio@gmail.com", new DateTime(1993, 01,12), Skills2)
            };

            Skills2 = new List<UserSkill>
            {
                new UserSkill (1, 2),
                new UserSkill (2, 1),
                new UserSkill (5, 21)
            };

            Skills = new List<Skill>
            {
                new Skill ("Conferente recepção"),
                new Skill ("Conferente expedição"),
                new Skill ("Novos pedidos"),
                new Skill ("Cancelamento de pedidos"),
                new Skill ("Conferente recepção"),
                new Skill ("Conferente expedição")
            };

            Storagehouse = new List<Storage>
            {
                new Storage (1, 2110, 1000, 4000, "B1"),
                new Storage (2, 10010, 1000, 4000, "A2"),
                new Storage (3, 5800, 1000, 7000, "B3")
            };

            Deposits = new List<Deposit>
            {
                new Deposit ("Depósito deposita mais - Jaraguá", "Depósito na cidade São Paulo-SP", "45.145.354/0001-01"),
                new Deposit ("Depósito deposita mais - Sorrocaba", "Depósito na cidade de Sorocaba-SP", "45.145.354/0001-02"),
                new Deposit ("Depósito deposita mais - Floripa", "Depósito na cidade Florianópolis-SC", "45.145.354/0001-03")
            };

            Categories = new List<Category>
            {
                new Category ("Farinaceos", "Armazena produtos relacionados com farinhas"),
                new Category ("Liquida", "Produtos liquidos"),
                new Category ("Limpeza", "Produtos de limpesa"),
                new Category ("Higiene", "Produtos de higiene pessoal")
            };

            IncomingInvoices = new List<IncomingInvoice>
            {
                new IncomingInvoice ("Companhia que vende 1", "endereço 1", "461616", "6554546", "5645.66", "Transportadora 2", CodeResponsibilityEnum.LiabilityOfTheIssuer, "C4S578", "554557", "646", "rua 1 ", "557536", 45, 100, 950.10m, TypeOfVolumeEnum.Weight, 102, "descrição teste", new DateTime(2022-19-04)),
                new IncomingInvoice ("Companhia que vende 2", "endereço 2", "461616", "6554546", "5645.66", "Transportadora 3", CodeResponsibilityEnum.LiabilityOfTheRecipient, "C4S578", "554557", "646", "rua 1 ", "557536", 45, 51, 221.00m, TypeOfVolumeEnum.Weight, 103, "descrição teste", new DateTime(2022-19-04)),
                new IncomingInvoice ("Companhia que vende 3", "endereço 3", "461616", "6554546", "5645.66", "Transportadora 1", CodeResponsibilityEnum.LiabilityOfTheIssuer, "C4S578", "554557", "646", "rua 1 ", "557536", 45, 351, 523.03m, TypeOfVolumeEnum.Millimeter, 104, "descrição teste", new DateTime(2022-19-04))
            };

            IncomingOrders = new List<IncomingOrder>
            {
                new IncomingOrder ( 1,  2, 1, 5, 43, 50, 55.23M, "Descrição do pedido.", IncomingOrderStatusEnum.Active, new DateTime(2022-26-05)),
                new IncomingOrder ( 2,  3, 3, 5, 11, 16, 102.53M, "Descrição do pedido.", IncomingOrderStatusEnum.Active, new DateTime(2022-28-05)),
                new IncomingOrder ( 4,  1, 3, 1, 51, 11, 1220.21M, "Descrição do pedido.", IncomingOrderStatusEnum.Active, new DateTime(2022-02-06))
            };

            OutgoingInvoices = new List<OutgoingInvoice>
            {
                new OutgoingInvoice (1, 3, 43, 21, 63M, "description os outgoing invoive", new DateTime(2022-10-10)),
                new OutgoingInvoice (2, 4, 23, 31, 100M, "description os outgoing invoive", new DateTime(2022-11-06)),
                new OutgoingInvoice (3, 1, 2, 01, 45.21M, "description os outgoing invoive", new DateTime(2022-01-08))
            };

            OutgoingOrders = new List<OutgoingOrder>
            {
                new OutgoingOrder (2, 1, 43, 21, 151.33M, "Descrição do pedido", new DateTime(2022-22-05)),
                new OutgoingOrder (1, 2, 33, 58, 59.31M, "Descrição do pedido", new DateTime(2022-22-05)),
                new OutgoingOrder (4, 1, 01, 10, 101.25M, "Descrição do pedido", new DateTime(2022-22-05))
            };

            Providers = new List<Provider>
            {
                new Provider ("Provider 1", "Description 1", "45.464.646/0001-01", "www.Site.com", "email1@a.com", "11 921350-1011", ProviderTypeEnum.Provider),
                new Provider ("Provider 2", "Description 1", "51.894.640/0003-01", "www.Site2.com", "email2@a.com", "44 944330-1511", ProviderTypeEnum.Provider),
                new Provider ("Provider 4", "Description 1", "78.466.789/0002-04", "www.Site3.com", "email3@a.com", "21 956321-1611", ProviderTypeEnum.Provider)
            };

            Representatives = new List<Representative>
            {
                new Representative (1, "representante 1", new DateTime(2000/03/01), "465.789.123-54", "22 4641-6748", "email@email.com", "descrição 1"),
                new Representative (2, "representante 6", new DateTime(1995/01/17), "478.713.177-51", "22 4641-6748", "email@email.com", "descrição 2"),
                new Representative (5, "representante 2", new DateTime(2000/09/21), "655.456.543-89", "22 4641-6748", "email@email.com", "descrição 3")
            };
        }


        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<UserSkill> Skills2 { get; set; }
        public List<Storage> Storagehouse { get; set; }
        public List<Deposit> Deposits { get; set; }
        public List<IncomingInvoice> IncomingInvoices { get; set; }
        public List<IncomingOrder> IncomingOrders { get; set; }
        public List<OutgoingInvoice> OutgoingInvoices { get; set; }
        public List<OutgoingOrder> OutgoingOrders { get; set; }
        public List<Provider> Providers { get; set; }
        public List<Representative> Representatives { get; set; }
    }
}
