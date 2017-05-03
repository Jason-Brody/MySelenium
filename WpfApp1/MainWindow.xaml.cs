using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using KbWebAutomation.Pages.Kbservcenter.LeadsManagement;
using KbWebAutomation;
using KbWebAutomation.Pages.Kbservcenter.ShopManagement;
using MySelenium;
using System.IO;
using KbWebAutomation.Scripts;
using System.Diagnostics;

namespace WpfApp1 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        private readonly string leadsFile = "leads.xml";
        private readonly string shopFile = "shops.xml";

        ObservableCollection<CreateLeadsParameter> leadsParameters;
        ObservableCollection<CreateShopParameter> shopParameters;
        ObservableCollection<Parameter> parameters;

        public MainWindow() {
            InitializeComponent();
            loadData();
           
        }

        private void openFileLocation() {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }


        private ServiceReference1.HelloWorldClient client = new ServiceReference1.HelloWorldClient();

        private async void Button_Click(object sender, RoutedEventArgs e) {
           HighlightConfig.NeedHighlight = cb_Highlight.IsChecked.Value;
            saveData();
            object item = lv_Scripts.SelectedItem;
            if(item == null) {
                MessageBox.Show("Please select a data");
                return;
            }
            try {
                await Task.Run(() => {
                    if (item != null) {

                        switch (item) {
                            case CreateShopParameter shop:
                                IScript<CreateShopParameter> script2 = new CreateShopFromKbScript();
                                script2.Run(shop);
                                client.mobileSearchUpdate(shop.Shop.HeadShopName, ServiceReference1.bizType.Shop);
                                break;
                            case CreateLeadsParameter leads:
                                IScript<CreateLeadsParameter> script1 = new CreateLeadsScript();
                                script1.Run(leads);
                                client.mobileSearchUpdate(leads.Shop.HeadShopName, ServiceReference1.bizType.Leads);
                                break;
                           
                        }
                    }
                });
                
            }catch(Exception e1) {
                
                MessageBox.Show(e1.Message);
                MessageBox.Show(e1.StackTrace);
            }
            
        }

        private void loadData() {
            if (File.Exists(leadsFile)) {
                leadsParameters = SeleniumExtension.ReadFromXml<ObservableCollection<CreateLeadsParameter>>(leadsFile);
                leadsParameters.ToList().ForEach(e => e.CaseId = "TEST01");
                //var items = SeleniumExtension.ReadFromXml<ObservableCollection<CreateLeadsParameter>>(leadsFile);
                //leadsParameters = new ObservableCollection<Parameter>(items.Cast<Parameter>());
            } else {
                leadsParameters = new ObservableCollection<CreateLeadsParameter>();
                leadsParameters.Add(DataUtils.GetSampleData<CreateLeadsParameter>());

            }
            if (File.Exists(shopFile)) {
                shopParameters = SeleniumExtension.ReadFromXml<ObservableCollection<CreateShopParameter>>(shopFile);
                shopParameters.ToList().ForEach(e => e.CaseId = "TEST02");
                //var items = SeleniumExtension.ReadFromXml<ObservableCollection<CreateShopParameter>>(shopFile);
                //shopParameters = new ObservableCollection<Parameter>(items.Cast<Parameter>());
            } else {
                shopParameters = new ObservableCollection<CreateShopParameter>();
                shopParameters.Add(DataUtils.GetSampleData<CreateShopParameter>());
            }
        }
        private void saveData() {
            leadsParameters.SaveAsXml(leadsFile);
            shopParameters.SaveAsXml(shopFile);
        }

        private void cb_scriptType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cb_scriptType.SelectedIndex == 0) {
                lv_Scripts.DataContext = leadsParameters;
               
            }
            if(cb_scriptType.SelectedIndex == 1) {
                lv_Scripts.DataContext = shopParameters;
              
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            openFileLocation();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            if(cb_BizType.SelectedValue != null && !string.IsNullOrEmpty(tb_Shop.Text)) {
                switch (cb_BizType.SelectedValue.ToString()) {
                    case "Leads":
                        client.mobileSearchUpdate(tb_Shop.Text, ServiceReference1.bizType.Leads);
                        break;
                    case "Shop":
                        client.mobileSearchUpdate(tb_Shop.Text, ServiceReference1.bizType.Shop);
                        break;
                    case "Order":
                        client.mobileSearchUpdate(tb_Shop.Text, ServiceReference1.bizType.Order);
                        break;
                }
            }
        }
    }

    
}
