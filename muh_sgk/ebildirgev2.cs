using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace muh_sgk
{
    public partial class ebildirgev2 : Form
    {
        public String html;
        public Uri url;
        


        public ebildirgev2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            string v = textBox1.Text.ToString().Trim();
            driver.Navigate().GoToUrl("https://ebildirge.sgk.gov.tr/EBildirgeV2/login/kullaniciIlkKontrollerGiris.action?username=12178849190&isyeri_kod=084&password=32978025&isyeri_sifre=70272627&isyeri_guvenlik=" + v + "");
            driver.Navigate().GoToUrl("https://ebildirge.sgk.gov.tr/EBildirgeV2/tahakkuk/tahakkukonaylanmisTahakkukDonemSecildi.action?hizmet_yil_ay_index=2&hizmet_yil_ay_index_bitis=3");
 
            ReadOnlyCollection<IWebElement> tahakkukadet = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr"));


            for (int i = 3; i < (tahakkukadet.Count)+1; i++)
            {





                    ReadOnlyCollection<IWebElement> donemay = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[1]"));
                    ReadOnlyCollection<IWebElement> hizmetay = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[2]"));
                    ReadOnlyCollection<IWebElement> belgeturu = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[3]"));
                    ReadOnlyCollection<IWebElement> belgemahiyeti = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[4]"));
                    ReadOnlyCollection<IWebElement> kanunno = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[5]"));
                    ReadOnlyCollection<IWebElement> calisan = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[6]"));
                    ReadOnlyCollection<IWebElement> gun = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[7]"));
                    ReadOnlyCollection<IWebElement> spek = driver.FindElements(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[8]"));

                    IWebElement pdf = driver.FindElement(By.XPath("//*[@id=\"contentContainer\"]/div/table/tbody/tr/td/table/tbody/tr/td/div/table/tbody/tr[" + i + "]/td[10]/div/a[2]"));

                    
                    listBox1.Items.Add(donemay.First().Text).ToString();
                    listBox1.Items.Add(hizmetay.First().Text).ToString();
                    listBox1.Items.Add(belgeturu.First().Text).ToString();
                    listBox1.Items.Add(belgemahiyeti.First().Text).ToString();
                    listBox1.Items.Add(kanunno.First().Text).ToString();
                    listBox1.Items.Add(calisan.First().Text).ToString();
                    listBox1.Items.Add(gun.First().Text).ToString();
                    listBox1.Items.Add(spek.First().Text).ToString();
                    listBox1.Items.Add(pdf.Text).ToString();
                    pdf.Click();
                    
                    

                

            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://ebildirge.sgk.gov.tr/EBildirgeV2/PG");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }

        
     }

}
