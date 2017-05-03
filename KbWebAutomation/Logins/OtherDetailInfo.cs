using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Logins {
    public class OtherDetailInfo {

        //外部门店编号
        public string OuterShopCode { get; set; }

        public string BusinessTime { get; set; }

        public string AvgPrice { get; set; }

        public string WifiName { get; set; }

        public string WifiPassword { get; set; }

        public bool Parking { get; set; }

        public string ParkingPrice { get; set; }


        public bool HasBox { get; set; }

        public bool IsNoSmoking { get; set; }

    }
}
