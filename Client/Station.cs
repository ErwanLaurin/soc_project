using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Client
{
    class Station
    {
        public int number;
        public String name;
        public String contractName;
        public String address;
        public JObject position;
        public bool banking;
        public bool bonus;
        public String status;
        public bool connected;
        public JObject totalStands;
        public JObject mainStands;

        public String display()
        {
            return "Numéro : " + this.number +
                "\r\nNom : " + this.name +
                "\r\nContrat : " + this.contractName +
                "\r\nAdresse : " + this.address +
                "\r\nPosition : (" + this.position["latitude"] + ";" + this.position["longitude"] + ")" +
                "\r\nTerminal de paiement : " + this.banking +
                "\r\nBonus : " + this.bonus +
                "\r\nStatut : " + this.status +
                "\r\nConnectée au système central : " + this.connected +
                "\r\nEmplacements : " + this.totalStands["capacity"] +
                "\r\nEmplacements libres : " + this.totalStands["availabilities"]["stands"] +
                "\r\nVélos présents : " + this.totalStands["availabilities"]["bikes"] +
                "\r\n\tDont : Points d'accroche physiques : " + this.mainStands["capacity"] +
                "\r\n\t          Points d'accroche disponibles : " + this.mainStands["availabilities"]["stands"] +
                "\r\n\t          Vélos attachés : " + this.mainStands["availabilities"]["bikes"];
        }
    }
}
