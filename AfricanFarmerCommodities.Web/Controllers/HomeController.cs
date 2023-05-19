using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AfricanFarmersCommodities.ServicesEndPoint.GeneralSevices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmersCommodities.AppConfigurations;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using QRCoder;
using AfricanFarmerCommodities.Web.ViewModels;
using PaymentGateway;
using PaypalFacility;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using AfricanFarmersCommodities.Services.EmailServices;
using AfricanFarmersCommodities.Web.IdentityServices;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AfricanFarmerCommodities.Web.Controllers
{
    [EnableCors(PolicyName = "CorsPolicy")]
    public class HomeController : Controller
    {
        private IMailService _emailService;
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        private ServicesEndPoint _serviceEndPoint;
        private IConfigurationSection _applicationConstants;
        private IConfigurationSection _businessSmtpDetails;
        private IConfigurationSection _twitterProfileFiguration;
        private PaymentsManager PaymentsManager;
        private Mapper _mapper;
        public HomeController(IMailService emailService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, AppSettingsConfigurations appSettings, PaymentsManager paymentsManager, Mapper mapper)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _applicationConstants = appSettings.AppSettings.GetSection("ApplicationConstants");
            _twitterProfileFiguration = appSettings.AppSettings.GetSection("TwitterProfileFiguration");
            _businessSmtpDetails = appSettings.AppSettings.GetSection("BusinessSmtpDetails");
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            PaymentsManager = paymentsManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AuthorizeIdentity]
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] IFormFile fileUpload)
        {
            try
            {
                //Send Email:
                _emailService.SendEmail(new EmailDao { Attachment = fileUpload, EmailBody = Request.Form["emailBody"], EmailFrom = Request.Form["emailFrom"], EmailSubject = Request.Form["emailSubject"], EmailTo = Request.Form["emailTo"] });
                return await Task.FromResult(Ok(new { Succeded = true, Message = "Succesfully Sent Your Email!" }));
            }
            catch (Exception e)
            {
                return await Task.FromResult(Ok(new { Succeded = false, Message = "Failed to Send Your Email!\n" + e.Message + "\n" + e.StackTrace }));
            }
        }

        [AuthorizeIdentity]
        [HttpPost]
        public async Task<IActionResult> SendEmailMultiAttachments()
        {
            try
            {
                //Send Email:
                _emailService.SendEmail(new EmailDao
                {
                    Attachments = Request.Form.Files,
                    EmailBody = @"" +
                "First Name:    " + Request.Form["firstName"] + System.Environment.NewLine +
                "Last Name:    " + Request.Form["lastName"] + System.Environment.NewLine +
                "Preferred Mobile Number:    " + Request.Form["mobileNumber"] + System.Environment.NewLine +
                "Bid Rate Per Hour:    " + Request.Form["bidRatePerHour"] + System.Environment.NewLine +
                "Earliest Start Date    " + Request.Form["earliestStartDate"] + System.Environment.NewLine +
                "Total Amount Per Hour:    " + Request.Form["totalAmountPerHour"] + System.Environment.NewLine +
                "Amount You Will Recieve Minus Service:    " + Request.Form["amountYouWillRecieveMinusService"] + System.Environment.NewLine +
                "Justify Percent Of ServiceFee:    " + Request.Form["justifyPercentOfServiceFee"] + System.Environment.NewLine +
                "Preferred Interview Date:    " + Request.Form["preferredInterviewDate"] + System.Environment.NewLine +
                "Cover Letter:  " + System.Environment.NewLine + Request.Form["coverLetter"],
                    EmailFrom = Request.Form["emailFrom"],
                    EmailSubject = Request.Form["emailSubject"],
                    EmailTo = Request.Form["emailTo"]
                });
                return await Task.FromResult(Ok(new { Succeded = true, Message = "Succesfully Sent Your Email!" }));
            }
            catch (Exception e)
            {
                return await Task.FromResult(Ok(new { Succeded = false, Message = "Failed to Send Your Email!\n" + e.Message + "\n" + e.StackTrace }));
            }
        }

        [AuthorizeIdentity]
        public async Task<IActionResult> GetTransportPricing()
        {
            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);

            TransportPricing[] pricing = await _serviceEndPoint.GetTransportPricing();

            return Ok(pricing);
        }
        
       [AuthorizeIdentity]
        [Route("~/Home/GetUserInvoicedItems/{emailAddress}")]
        public async Task<IActionResult> GetUserInvoicedItems(string emailAddress)
        {

            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            var user = _unitOfWork._userRepository.GetAll().FirstOrDefault(q => q.Email.ToLower().Equals(emailAddress.ToLower()));
            if (user != null)
            {
                var invoices = await _serviceEndPoint.GetUserInvoicedItems(user.UserId);
                if (invoices.Any())
                {
                    var userInvoicesViewModel = _mapper.Map<InvoiceViewModel[]>(invoices);

                    return await Task.FromResult(Ok(userInvoicesViewModel));
                }
            }
            return await Task.FromResult(NotFound(new { Message = "No Invoices are unpaid" }));
        }
        [AuthorizeIdentity]
        [Route("~/Home/GetUnpaidInvoices/{emailAddress}")]
        public async Task<IActionResult> GetUnpaidInvoices(string emailAddress)
        {

            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
            var user =_unitOfWork._userRepository.GetAll().FirstOrDefault(q => q.Email.ToLower().Equals(emailAddress.ToLower()));
            if(user != null)
            {
                var invoices = await _serviceEndPoint.GetUnpaidInvoicesByUsername(user.UserId);
                if (invoices.Any())
                {
                    var unpaidInvoicesViewModel = _mapper.Map<InvoiceViewModel[]>(invoices);

                    return await Task.FromResult(Ok(unpaidInvoicesViewModel));
                }
            }
            return await Task.FromResult(NotFound(new { Message = "No Invoices are unpaid" }));
        }

        [AuthorizeIdentity]
        public async Task<IActionResult> GetDealsPricing()
        {

            _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);

            DealsPricing[] deals = await _serviceEndPoint.GetDealsPricing();

            return Ok(deals);

        }

        [HttpGet]
        [AuthorizeIdentity]
        public async Task<ActionResult> GetTransportScheduleLogs(string username)
        {
            var curUser = this._unitOfWork.AfricanFarmerCommoditiesDbContext.Users.FirstOrDefault(u => u.Email.ToLower().Equals(username.ToLower()));
            if (curUser != null)
            {
                return await Task.FromResult(Ok(this._unitOfWork.AfricanFarmerCommoditiesDbContext.Invoices.Where(q => /*q.HasFullyPaid &&*/ q.UserId.Equals(curUser.UserId)).
                    Select(q => new InvoiceViewModel { InvoiceId = q.InvoiceId, HasFullyPaid = q.HasFullyPaid, InvoiceName = q.InvoiceName, DateUpdated = q.DateUpdated }).ToArray()));
            }
            return NotFound("User has no invoices for transport scheduling");
        }

        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> CreateOrUpdateTransportScheduleLog([FromBody] TransportLogViewModel transportLogViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportLog = _mapper.Map<TransportLog>(transportLogViewModel);
                var currentTrLog =_unitOfWork._transportLogRepository.GetAll().FirstOrDefault(q=> q.TransportScheduleId == transportLog.TransportScheduleId
                && q.InvoiceId == transportLog.InvoiceId);
                
                if(currentTrLog == null)
                {
                    bool result = await _serviceEndPoint.PostCreateTransportScheduleLog(transportLog);
                    if (!result)
                    {
                        return NotFound(transportLogViewModel);
                    }
                    return Ok(new { message = "Succesfully Created!", result = result });
                }
                else
                {
                    var success = _unitOfWork._transportLogRepository.Update(transportLog);
                    _unitOfWork.SaveChanges();
                    if (success)
                    {
                        return Ok(new { message = "Succesfully Updated!", result = success });
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NotFound(new { message = "Failed to Update!", result = false });
        }
        

        [HttpGet]
        [AuthorizeIdentity]
        [Route("~/Home/GetCurrentTransScheduleInvoiceLog/{transportScheduleId}")]
        public async Task<ActionResult> GetCurrentTransScheduleInvoiceId(int transportScheduleId)
        {
            var transLogs = this._unitOfWork._transportLogRepository.AfricanFarmerCommoditiesDBContext.TransportLogs.Where(q => q.TransportScheduleId == transportScheduleId).Include(q => q.Invoice);
            if (transLogs.Any())
            {
                var transLogsViewModel = _mapper.Map<TransportLogViewModel[]>(transLogs.ToList());
                return await Task.FromResult(Ok(transLogsViewModel));
            }
            return await Task.FromResult(NotFound(new { Message = "User has no invoices for transport scheduling"}));
        }


        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> DeleteTransportScheduleLogs([FromBody] TransportLogViewModel transportLogViewModel)
        {
            try
            {
                var _serviceEndPoint = new ServicesEndPoint(_unitOfWork, _emailService);
                var transportLog = _mapper.Map<TransportLog>(transportLogViewModel);
                bool result = await _serviceEndPoint.DeleteTransportScheduleLog(transportLog);
                if (!result)
                {
                    return NotFound(new { message = "Not Found", result = false });
                }
                return Ok(new { message = "Succesfully Deleted!", result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [AuthorizeIdentity]
        public async Task<IActionResult> MakePayment([FromBody] PaymentViewModel paymentViewModel)
        {
            var items = new List<Item>();
            var products = new List<Product>();

            var user = _unitOfWork._userRepository.GetAll().
            FirstOrDefault(q => q.Username.ToLower().Equals(paymentViewModel.Username.ToLower()));
            //Create Invoice:
            var invoice = new AfricanFarmersCommodities.Domain.Invoice
            {
                NetCost = paymentViewModel.AmountPayable,
                GrossCost = paymentViewModel.AmountPayable,
                //InvoicedItems = items,
                InvoiceName = paymentViewModel.Username + "_" + paymentViewModel.Contents.First().CommodityName,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                HasFullyPaid = false,
                //Payee
                UserId = user.UserId
            };
            _unitOfWork._invoiceRepository.Insert(invoice);
            _unitOfWork.SaveChanges();

            foreach (var cmd in paymentViewModel.Contents)
            {
                products.Add(new Product
                {
                    InvoiceId=invoice.InvoiceId,
                    Amount = cmd.CommodityUnitPrice * cmd.NumberOfUnits,
                    HasPaidInfull = false,
                    ProductDescription = cmd.CommodityName,
                    Quantity = (int)cmd.NumberOfUnits,
                    ProductName = cmd.CommodityName
                });

                var itm = new Item
                {
                    ItemCost = cmd.CommodityUnitPrice * cmd.NumberOfUnits,
                    Quantity = (int)cmd.NumberOfUnits,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    InvoiceId = invoice.InvoiceId,
                    ItemName = cmd.CommodityName,
                    CommodityId = cmd.CommodityId
                };

                _unitOfWork._itemRepository.Insert(itm);
                _unitOfWork.SaveChanges();

                items.Add(itm);
            }

            //Call Paypal Facilities:
            var paypalUrl = await PaymentsManager.MakePayments(user.Username, products);
            var commoditiesBought = new StringBuilder();

            var grossPayment = (decimal)0.0;
            foreach (var cmd in paymentViewModel.Contents)
            {
                var actualCommodity = _unitOfWork._commodityRepository.GetById(cmd.CommodityId);
                actualCommodity.NumberOfUnits -= cmd.NumberOfUnits;
                grossPayment += (cmd.NumberOfUnits * cmd.CommodityUnitPrice);
                commoditiesBought.Append(cmd.CommodityName + ": UnitPrice" + cmd.CommodityUnitPrice + ", NumberOfUnits: " + cmd.NumberOfUnits + ", Gross Total Payable: " + cmd.NumberOfUnits * cmd.CommodityUnitPrice + System.Environment.NewLine);

                await _serviceEndPoint.UpdateFarmerCommodity(actualCommodity);
            }
            var commodityDetails = paymentViewModel.Contents.First();
            _emailService.SendEmail(new EmailDao
            {
                EmailTo = paymentViewModel.Username,
                EmailSubject = "Payment For Commodity " + commodityDetails.CommodityName + " is being processed.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.InvoiceMessage).Replace("[[FirstName]]", user.FirstName).
                Replace("[[TransactionCommoditesList]]", commoditiesBought.ToString() + System.Environment.NewLine + "Gross Total: " + grossPayment)
            });
            return await Task.FromResult(Ok(new { payPalRedirectUrl = paypalUrl }));
        }

        
       [HttpPost]
        [AuthorizeIdentity]
        [Route("~/Home/MakeLatePayment/{username}")]
        public async Task<IActionResult> MakeLatePayment([FromBody] InvoiceViewModel invoice, string username)
        {
            var user = _unitOfWork._userRepository.GetAll().FirstOrDefault(q=> q.Username.ToLower().Equals(username.ToLower()));
            var items = new List<Item>();
            var products = new List<Product>();


            var curInvoice = _unitOfWork._invoiceRepository.GetById(invoice.InvoiceId);

            if (user != null && curInvoice != null)
            {
                curInvoice.GrossCost = invoice.GrossCost;
                curInvoice.DateUpdated = DateTime.Now;
                curInvoice.UserId = user.UserId;
            }
            else {
                return await Task.FromResult(BadRequest(new { Message = "Username not found Or Current Invoice not found" }));
            }
            var latePaymentProduct = new Product { Amount = curInvoice.GrossCost, ProductName = curInvoice.InvoiceName, InvoiceId= curInvoice.InvoiceId, ProductDescription = "Late Payments: " + curInvoice.InvoiceName + "----InvoiceId-" + curInvoice.InvoiceId };
            //Call Paypal Facilities:
            var paypalUrl = await PaymentsManager.MakePayments(user.Username, new List<Product> { latePaymentProduct });
            var commoditiesBought = new StringBuilder();

            _emailService.SendEmail(new EmailDao
            {
                EmailTo = user.Email,
                EmailSubject = "Late Payment For Commodity By Invoice Id: " + latePaymentProduct.ProductName + " is being processed.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.InvoiceMessage).Replace("[[FirstName]]", user.FirstName).
                Replace("[[TransactionCommoditesList]]", latePaymentProduct.ProductName + System.Environment.NewLine + "Gross Total: " + curInvoice.GrossCost)
            });
            return await Task.FromResult(Ok(new { payPalRedirectUrl = paypalUrl }));
        }

        public async Task<JsonResult> CheckAndValidatePaypalPayments(FormCollection formsCollection)
        {
            decimal amountPaid = Decimal.Parse(formsCollection["amount"]);
            int clientId = Int32.Parse(formsCollection["clientId"]);
            int invoiceId = Int32.Parse(formsCollection["invoice"]);
            var userInvoice = _unitOfWork._invoiceRepository.GetById(invoiceId); ;

            try
            {
                if (userInvoice != null && userInvoice.User.Username.ToLower().Equals(formsCollection["buyer_email"].First().ToLower()) && amountPaid == userInvoice.GrossCost)
                {
                    userInvoice.HasFullyPaid = true;

                    _unitOfWork.SaveChanges();
                    _emailService.SendEmail(new EmailDao
                    {
                        EmailTo = userInvoice.User.Username,
                        EmailSubject = "Confirmation Of Invoice Payment.",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.SuccessBuyCommodityMessage).Replace("[[FirstName]]", userInvoice.User.FirstName).
    Replace("[[TransactionCommoditesList]]", userInvoice.InvoiceName + ", Net Price:" + userInvoice.NetCost + ", Gross Total Payable: " + userInvoice.GrossCost)
                    });

                    _emailService.SendEmail(new EmailDao
                    {
                        EmailTo = userInvoice.User.Username,
                        EmailSubject = "Please Schedule Transportation of your bought Commodities.",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.ArrangeTransportScheduleMessage).Replace("[[FirstName]]", userInvoice.User.FirstName).
Replace("[[CommodiyName]]", userInvoice.InvoiceName)
                    });
                    return await Task.FromResult(Json(new { Result = "Success" }));
                }
            }
            catch (Exception e)
            {
                _emailService.SendEmail(new EmailDao
                {
                    EmailTo = userInvoice.User.Username,
                    EmailSubject = "Transaction for: " + userInvoice.User.FirstName + ", failed Processing By Paypal.",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.TransactionFailureMessage).Replace("[[FirstName]]", userInvoice.User.FirstName).
Replace("[[TransactionCommoditesList]]", userInvoice.InvoiceName + ", Net Price:" + userInvoice.NetCost + ", Gross Total Payable: " + userInvoice.GrossCost)
                });
                //email exception to admin email
                return Json(new { Result = "Failed" });
            }
            _emailService.SendEmail(new EmailDao
            {
                EmailTo = userInvoice.User.Username,
                EmailSubject = "Transaction for: " + userInvoice.User.FirstName + ", failed Processing By Paypal.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.TransactionFailureMessage).Replace("[[FirstName]]", userInvoice.User.FirstName).
                Replace("[[TransactionCommoditesList]]", userInvoice.InvoiceName + ", Net Price:" + userInvoice.NetCost + ", Gross Total Payable: " + userInvoice.GrossCost)
            });
            return Json(new { Result = "Failed" });
        }
        [HttpPost]
        public IActionResult GetClientEmailAndMobilePhoneNumber([FromBody] AfricanFarmersCommodities.Models.UserDetails userDetail)
        {
            User user = _serviceEndPoint.GetUserByEmailAddress(userDetail.emailAddress);

            if (user != null)
            {
                //Validate: mobile number
                if (user.MobileNumber.Equals(userDetail.mobileNumber))
                {
                    return Json(new { message = "Verified", statusCode = 200 });
                }
            }
            return Json(new { message = "Failed Validation. User not Found!", statusCode = 400 });
        }
        [HttpGet]
        public FileContentResult GetUserGeneratedQrCode(string username)
        {
            User user = _serviceEndPoint.GetUserByEmailAddress(username);

            //Generate QR Code:

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{user.MobileNumber}_{user.Email}",
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return File(BitmapToBytes(qrCodeImage), "image/png");
        }
        private Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private readonly static object _locker = new object();
    }

}
