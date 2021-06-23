using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.Text.RegularExpressions;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography;
using System.IO;
using IronOcr;
using System.Runtime.Serialization.Formatters.Binary;

namespace KingStaccz
{
    public partial class Form1 : Form
    {
        String tiktok = "https://www.instagram.com/KINGSTACCZ/"; //https://www.tiktok.com/@kingstaccz
        String downloadLoc = @"c:\temp\staccz.jpeg";

        public Form1()
        {
            InitializeComponent();

            System.Threading.Thread t = new System.Threading.Thread(Form1_Load);
            t.Start();
        }

        private void Form1_Load()
        {
            ChromeOptions optionsScan = new ChromeOptions();
            ChromeOptions optionsTikTok = new ChromeOptions();

            optionsScan.AddArguments(new List<string>() { "safebrowsing-disable-download-protection", "no-sandbox", "ignore-certificate-errors", "reduce-security-for-testing", "use-fake-device-for-media-stream", "mute-audio", "mute-audio", "user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36" }); // "incognito", "headless", "disable-gpu", "mute-audio"
            optionsTikTok.AddArguments(new List<string>() { "safebrowsing-disable-download-protection", "no-sandbox", "ignore-certificate-errors", "reduce-security-for-testing", "use-fake-device-for-media-stream", "mute-audio", "mute-audio", "user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36" }); // "incognito", "headless", "disable-gpu", "mute-audio"

            optionsScan.AddArgument("--app=https://scan.co.uk");
            optionsTikTok.AddArgument("--app=" + tiktok);

            ChromeDriver chromeDriverScan = new ChromeDriver("lib/", optionsScan);
            ChromeDriver chromeDriverTikTok = new ChromeDriver("lib/", optionsTikTok);

            bool hasPicUpdated = false;
            bool hasEnteredDetails = false;

            String ccNumberText = "";
            String oldccNumberText = "";
            String expNumberText = "";
            String secNumberText = "";

            while (true)
            {
                try
                {
                    chromeDriverTikTok.Navigate().Refresh();
                    WebDriverWait webDriverWait = new WebDriverWait(chromeDriverTikTok, System.TimeSpan.FromSeconds(5));

                    IWebElement pfp = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"react - root\"]/section/main/div/header/div/div/span/img")));
                    String pfpUri = pfp.GetAttribute("src").ToString();

                    if (pfpUri != "")
                    {
                        IronTesseract Ocr = new IronTesseract();
                        WebClient client = new WebClient();

                        client.DownloadFile(new Uri(pfpUri), downloadLoc);

                        OcrResult Result;
                        using (var Input = new OcrInput(downloadLoc))
                        {
                            Input.Deskew();
                            //Input.DeNoise();
                            //Input.DeepCleanBackgroundNoise();
                            Result = Ocr.Read(Input);
                        }

                        Regex ccNumberR = new Regex(@"[0-9]{16,16}");
                        ccNumberText = ccNumberR.Match(Result.Text).ToString();

                        Regex expNumberR = new Regex(@"[0-9]{2,2}\/[0-9]{2,4}");
                        expNumberText = expNumberR.Match(Result.Text).ToString();

                        Regex secNumberR = new Regex(@" ([0-9]{3})");
                        secNumberText = secNumberR.Match(Result.Text).ToString().Trim(' ');

                        if ((ccNumberText != oldccNumberText && ccNumberText != "" && oldccNumberText != "") && ccNumberText != "" && expNumberText != "" && secNumberText != "")
                            hasPicUpdated = true;

                        oldccNumberText = ccNumberText;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                if (!hasEnteredDetails && hasPicUpdated)
                {
                    try
                    {
                        WebDriverWait webDriverWait = new WebDriverWait(chromeDriverScan, System.TimeSpan.FromSeconds(2));
                        IWebElement ccbox = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("CardNumber")));
                        ccbox.SendKeys(ccNumberText);

                        IWebElement expboxmo = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("ExpiryMonth")));
                        expboxmo.SendKeys(expNumberText.Split("/")[0]);

                        IWebElement expboxyr = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("ExpiryYear")));
                        String yearproc = expNumberText.Split("/")[1];
                        yearproc = yearproc.Length == 2 ? "20" + yearproc : yearproc; // Redundancy incase the year is provided as "2021" or "21"
                        expboxyr.SendKeys(yearproc);

                        IWebElement namebox = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("NameOnCard")));
                        namebox.SendKeys("King Staccz");

                        IWebElement secbox = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("SecurityCode")));
                        secbox.SendKeys(secNumberText);

                        IWebElement submitbutton = webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"guestCheckout\"]/div/div/div[2]/section/div[2]/div[3]/form/div/div[5]/button")));
                        submitbutton.Click();

                        hasEnteredDetails = true;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                MethodInvoker invoker = delegate ()
                {
                    ccNumber.Text = ccNumberText;
                    expNumber.Text = expNumberText;
                    secNumber.Text = secNumberText;

                    currentPicture.ImageLocation = downloadLoc;
                    currentPicture.SizeMode = PictureBoxSizeMode.StretchImage;

                    ppeLabel.Text = hasEnteredDetails ? "Entered: YES!!!" : "Entered: No";
                    updLabel.Text = hasPicUpdated ? "Updated: YES!!!" : "Updated: No";
                };
                this.Invoke(invoker);
            }
        }
    }
}