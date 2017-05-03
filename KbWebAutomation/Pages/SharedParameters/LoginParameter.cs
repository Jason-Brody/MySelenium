using KbWebAutomation.Attributes;
using KbWebAutomation.Models;
using MySelenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Pages.SharedParameters {
    public class LoginParameter:Parameter {

        public LoginInfo LoginInfo { get; set; }
    }
}
