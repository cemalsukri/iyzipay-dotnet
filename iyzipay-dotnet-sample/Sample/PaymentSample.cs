﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iyzipay.Model;
using Iyzipay.Request;
using System.Collections.Generic;

namespace IyzipaySample.Sample
{
    [TestClass]
    public class PaymentSample : Sample
    {
        [TestMethod]
        public void Should_Create_Payment()
        {
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.1";
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.Currency = Currency.TRY.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "İstanbul";
            buyer.Country = "Türkiye";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "İstanbul";
            shippingAddress.Country = "Türkiye";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "İstanbul";
            billingAddress.Country = "Türkiye";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            PrintResponse<Payment>(payment);

            Assert.IsNotNull(payment.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.GetName(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
        }

        [TestMethod]
        public void Should_Create_Marketplace_Payment()
        {
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.1";
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.Currency = Currency.TRY.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2020";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "İstanbul";
            buyer.Country = "Türkiye";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "İstanbul";
            shippingAddress.Country = "Türkiye";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "İstanbul";
            billingAddress.Country = "Türkiye";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            firstBasketItem.SubMerchantKey = "sub merchant key";
            firstBasketItem.SubMerchantPrice = "0.27";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            secondBasketItem.SubMerchantKey = "sub merchant key";
            secondBasketItem.SubMerchantPrice = "0.42";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            thirdBasketItem.SubMerchantKey = "sub merchant key";
            thirdBasketItem.SubMerchantPrice = "0.18";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            PrintResponse<Payment>(payment);

            Assert.IsNotNull(payment.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.GetName(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
        }

        [TestMethod]
        public void Should_Create_Payment_With_Registered_Card()
        {
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.1";
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.SUBSCRIPTION.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.Currency = Currency.TRY.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardUserKey = "card user key";
            paymentCard.CardToken = "card token";
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "İstanbul";
            buyer.Country = "Türkiye";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "İstanbul";
            shippingAddress.Country = "Türkiye";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "İstanbul";
            billingAddress.Country = "Türkiye";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            PrintResponse<Payment>(payment);

            Assert.IsNotNull(payment.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.GetName(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
        }

        [TestMethod]
        public void Should_Retrieve_Payment_Result()
        {
            RetrievePaymentRequest request = new RetrievePaymentRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.PaymentId = "1";
            request.PaymentConversationId = "123456789";

            Payment payment = Payment.Retrieve(request, options);

            PrintResponse<Payment>(payment);

            Assert.IsNotNull(payment.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.GetName(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
        }
    }
}
