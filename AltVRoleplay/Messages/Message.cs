using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltVRoleplay
{
    public class Message
    {
        public static readonly string notAdmin = "[Error]Dein Adminlevel ist zu niedrig!";
        public static readonly string alwayRentingVeh = "[Warnung]Du mietest schon ein Fahrzeug nutze /unrent";
        public static readonly string notEnoughMoney = "[Warnung]Du hast nicht genug Bargeld dabei";
        public static readonly string notOpen = "[Warnung]Geschlossen";
        public static readonly string noStreet = "[Warnung]Du hast keine Anschrift, such dir erstmal eine Wohnung";
        public static readonly string noOwnPerso = "[Warnung]Du hast kein Personalausweis von dir dabei";
        public static readonly string noBankKonto = "[Warnung]Du hast kein Bankkonto";
        public static readonly string hasMiniJob = "[Warnung]Du hast bereits ein Job gestartet";
        public static readonly string notEnougInvPlace = "[Warnung]Nicht genug Inventar Platz";
        public static readonly string firmaNotEnoughKonto = "[Warnung]Zu wenig Geld auf dem Firmen Konto";
        public static readonly string carDealerMaxContracts = "[Warnung]Du musst erst ein Fahrzeug abholen";
        public static readonly string noVehicleNearBy = "[Warnung]Kein Fahrzeug in der Nähe";
    }
}
