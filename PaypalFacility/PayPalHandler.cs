using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PaypalFacility
{
    public class PayPalHandler
    {
        private bool hasBeenRedirected;
        private string baseUrl;
        private string notifyUrl;
        private string successUrl;
        private string cancelUrl;
        public Invoice invoice;
        private HttpResponse response = null;
        private string businessEmail = null;
        private string buyerEmail;
        public HttpContext _HttpContext { get; set; }

        public PayPalHandler(string baseUrl, string businessEmail, string successUrl, string cancelUrl, string notifyUrl, string buyerEmail)
        {
            this.baseUrl = baseUrl;
            this.hasBeenRedirected = false;
            this.businessEmail = businessEmail;
            this.successUrl = successUrl;
            this.cancelUrl = cancelUrl;
            this.notifyUrl = notifyUrl;
            this.buyerEmail = buyerEmail;
        }

        public string RedirectToPayPal(List<Product> productArray)
        {
            //fill In invoice Details

            StringBuilder prodNames = new StringBuilder();
            decimal amount = 0;
            foreach (var prod in productArray)
            {
                amount += prod.Amount;
                prodNames.Append(prod.ProductName + ";");
            }

            invoice = new Invoice(productArray, amount, buyerEmail);
            if (productArray.Any())
            {
                invoice.InvoiceNo = productArray.First().InvoiceId;

                hasBeenRedirected = true;
                URLBuilder urlBuilder = new URLBuilder(businessEmail, successUrl, cancelUrl, notifyUrl, buyerEmail, invoice);
                string requestUrl = baseUrl + urlBuilder.getFullCommandParameters();
                return requestUrl;
            }
            return string.Empty;
        }

        public bool HasBeenRequested
        {
            get { return hasBeenRedirected; }
            set { hasBeenRedirected = false; }
        }

        public string CancelUrl
        {
            get { return cancelUrl; }
            set { cancelUrl = value; }
        }
        public string NotifyUrl
        {
            get { return notifyUrl; }
            set { notifyUrl = value; }
        }
        public string BuyerEmail
        {
            get { return buyerEmail; }
            set { buyerEmail = value; }
        }
    }
}
