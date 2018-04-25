using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TairaiShopService
{
    public class Shop
    {
        public IWebDriver driver { get; set; }
        public string PopUpText { get; set; }
        TimeSpan timeout = new TimeSpan(00, 01, 00);

        public Shop(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Catalog() //витрина магазина с услугами
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://tairai.itech-test.ru/catalog/");
            var clickCard = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"shop__goods-inner\"]/div[1]/div[2]/a[1]")));
                clickCard.Click(); Task.Delay(3500).Wait();
            var addCard = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cntr\"]/button")));
                addCard.Click(); Task.Delay(2500).Wait();
            var clickCard1 = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"to-cart\"]/a/span[1]")));
                clickCard1.Click();
        }

        public void Deliviry() //доставка курьером
        {
            var deliveru = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("cart__delivery-way")));
                deliveru.Click();
            var deliveruPrice = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cart__delivery-inner\"]/div[3]/div[2]/label")));
                deliveruPrice.Click();
        }

        public void Pickup()//самовывоз
        {
            var pickup = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cart__delivery\"]/div/div[2]/label")));
                pickup.Click();                                                                                    
        }

        public void Forms() //корзина, оформление заказа наличными
        {
            var name = driver.FindElement(By.Name("NAME"));
                name.SendKeys("Тест");
            var email = driver.FindElement(By.Name("EMAIL"));
                email.SendKeys("Test@mail.ru");
            var phone = driver.FindElement(By.Name("PHONE"));
                phone.SendKeys("9297909097");
            var street = driver.FindElement(By.Name("ADDRESS"));
                street.SendKeys("Ленина");
            var checkbox = driver.FindElement(By.XPath("//*[@id=\"js-vue-cart-app\"]/div[2]/div/form/div[5]/div/label/i"));
                checkbox.Click();
        }

        public void PayMoney()//по умолчанию оплата наличными
        { 
            var shoping = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cart__to-pay\"]/button")));
                shoping.Click();
                PopUpText = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("js-msg"))).Text;
        }

        public void PayBankCard()//оплата банковской картой 
        {                                                                                                                      
            var BankCard = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cart__full-form-inner\"]/div[3]/div[1]/div[2]/div[2]/label")));
                BankCard.Click();
            var shoping = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"cart__to-pay\"]/button")));
                shoping.Click();
        }

    }
}