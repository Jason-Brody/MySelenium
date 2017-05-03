using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using KbWebAutomation.Attributes;
using MySelenium.Temp;

namespace KbWebAutomation {
    public class DataUtils {


        public static T GetSampleData<T>() where T : class, new() {
            T item = new T();
            ReflectUtil.Reflect(item, (o, p) => {
                var sample = p.GetCustomAttribute<SampleDataAttribute>();
                if (sample == null)
                    return false;

                if (sample.Data == null)
                    return true;


                if(p.PropertyType == sample.Data.GetType()) {

                    p.SetValue(o, sample.Data);
                    return true;
                }
                return false;
            }, (o, p) => {
                if (!p.PropertyType.IsClass || p.PropertyType == typeof(string))
                    return null;

                object obj = Activator.CreateInstance(p.PropertyType);
                p.SetValue(o, obj);
                return obj;
            });
            return item;
        }

        public static T GetSampleData<T>(int group = 0) where T : class,new() {
            T item = null;
            foreach(var prop in typeof(T).GetProperties()) {
                var sampleDatas = prop.GetCustomAttributes<SampleDataAttribute>();
                SampleDataAttribute sampleData = null;
                var count = sampleDatas.Count();
                if (count == 0)
                    continue;
                if ( count > group) {
                    sampleData = sampleDatas.ElementAt(group);
                } else if (count == group) {
                    sampleData = sampleDatas.ElementAt(group - 1);
                } else if (count >0) {
                    sampleData = sampleDatas.ElementAt(count - 1);
                } 
               
                if (sampleData != null) {
                    if(item == null) {
                        item = new T();
                    }

                    if (sampleData.Data != null) {
                        prop.SetValue(item, sampleData.Data);
                    }
                    
                }
            }
            return item;
        }
    }
}
