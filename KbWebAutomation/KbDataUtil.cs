using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KbWebAutomation {

    internal class UpdateString {
        public string db { get; set; }

        public string table { get; set; }

        public string keys { get; set; }
    }

    public class KbDataUtil {

        //{"db":"shop_info","table":"shop_info","keys":"46:2017033100077000000004363746"}
        public static string GetMobileSearchString(string tableName,params string[] ids) {
            string value = "";
            foreach(var id in ids) {
                value += $"{id.Substring(id.Length - 2, 2)}:{id},";
            }
            value = value.Substring(0, value.Length - 1);
            UpdateString us = new UpdateString() {
                db = tableName,
                table = tableName,
                keys = value
            };
            return JsonConvert.SerializeObject(us);
        }

    }
}
