using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TairaiShopService
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;
        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ShopDeliveryMoney()//доставка курьером и оплата наличными
        {
            var actualPopUP = "Ваш заказ успешно принят";

            Shop shop = new Shop(driver);
            shop.Catalog();
            shop.Deliviry();
            shop.Forms();
            shop.PayMoney();


            Assert.AreEqual(shop.PopUpText, actualPopUP);
        }

        [Test]
        public void ShopDeliveryBankCard()//доставка курьером и оплата банковской картой
        {
            var actualSum = "";

            Shop shop = new Shop(driver);
            shop.Catalog();
            shop.Deliviry();
            shop.Forms();
            shop.PayBankCard();

            //Assert.AreEqual(shop.PopUpText,actualSum );
        }

        [Test]
        public void ShopPickup()//Самовывоз с наличным расчетом
        {
            Shop shop = new Shop(driver);
            shop.Catalog();
            shop.Pickup();
            shop.Forms();
            shop.PayMoney();
        }

    }
}
