using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fset.Utility
{
    public class PaymentState
    {
        public static string State(string Stateresult)
        {
            string result = "";
            switch (Stateresult)
            {
                
                case "Canceled By User":
                    result = "عملیات ناموفق";
                    break;
                case "Canceled By Issuer":
                    result = "عملیات ناموفق";
                    break;

                case "Invalid Merchant":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";
                    break;

                case "Do Not Honour":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Honour With Identification":
                    result = "عملیات موفق";
                    break;
                case "Invalid Transaction":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Invalid Card Number":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "No Such Issuer":
                    result = "کارت نامعتبر است";
                    break;
                case "Approved Update Track3":
                    result = "عملیات موفق";

                    break;
                case "Reenter Transaction":
                    result = "عملیات ناموفق";

                    break;
                case "UnAcceptable Transaction Fee":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Format Error":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Bank Not Supported By Switch":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Expired Card Pick Up":
                    result = "کارت نامعتبر است-تاریخ انقضای کارت سپری شده است";

                    break;
                case "Suspected Fraud Pick Up":
                    result = "عملیات ناموفق";

                    break;
                case "Allowable PIN Tries Exceeded Pick Up":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "No Credit Acount":
                    result = "کارت نامعتبر است";

                    break;
                case "Requested Function":
                    result = "عملیات ناموفق";

                    break;
                case "Lost Card":
                    result = "کارت نامعتبر است";
                    break;
                case "No Universal Account":
                    result = "کارت نامعتبر است";
                    break;
                case "Stolen Card":
                    result = "عملیات ناموفق";

                    break;

                case "No Investment Acount":
                    result = "کارت نامعتبر است";

                    break;
                case "No Sufficient Funds":
                    result = "عدم موجودی کافی";
                    break;
                case "No Cheque Account":
                    result = "کارت نامعتبر است";

                    break;
                case "No Saving Account":
                    result = "کارت نامعتبر است";

                    break;
                
                case "Expired Account":
                    result = "کارت نامعتبر است-تاریخ انقضای کارت سپری شده است";

                    break;
                case "Incorrect PIN":
                    result = "رمز نامعتبر است";
                    break;
                case "No Card Record":
                    result = "کارت نامعتبر است";

                    break;
                case "Transaction Not Permitted To CardHolder":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Transaction Not Permitted To Terminal":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Exceeds Withdrawal Amount Limit":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Restricted Card Decline":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Security Violation":
                    result = "عملیات ناموفق";
                    break;
                case "Exceeds Withdrawal Frequency Limit":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Response Received Too Late":
                    result = "-";
                    break;
                case "PIN Reties Exceeds-Slm":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Invalid Amount":
                    result = "عملیات ناموفق";

                    break;
                case "Issuer Down Slm":
                    result = "عملیات ناموفق";

                    break;
                case "Cut Off Is Inprogress":
                    result = "عملیات ناموفق-سامانه مقصد تراکنش در حال انجام عملیات پایان روز می باشد";

                    break;
                case "Transaction Cannot Be Completed":
                    result = "عملیات ناموفق";

                    break;
                case "TME Error":
                    result = "عملیات ناموفق";

                    break;


                default:
                    result = string.Empty;
                    break;

            }
            return result;
        }

        public static string AdminState(string Stateresult)
        {
            string result = "";
            switch (Stateresult)
            {

                case "Canceled By User":
                    result = "عملیات ناموفق";
                    break;
                case "Canceled By Issuer":
                    result = "عملیات ناموفق";
                    break;

                case "Invalid Merchant":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";
                    break;

                case "Do Not Honour":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Honour With Identification":
                    result = "عملیات موفق";
                    break;
                case "Invalid Transaction":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Invalid Card Number":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "No Such Issuer":
                    result = "کارت نامعتبر است";
                    break;
                case "Approved Update Track3":
                    result = "عملیات موفق";

                    break;
                case "Reenter Transaction":
                    result = "عملیات ناموفق";

                    break;
                case "UnAcceptable Transaction Fee":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Format Error":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Bank Not Supported By Switch":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Expired Card Pick Up":
                    result = "کارت نامعتبر است-تاریخ انقضای کارت سپری شده است";

                    break;
                case "Suspected Fraud Pick Up":
                    result = "عملیات ناموفق";

                    break;
                case "Allowable PIN Tries Exceeded Pick Up":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "No Credit Acount":
                    result = "کارت نامعتبر است";

                    break;
                case "Requested Function":
                    result = "عملیات ناموفق";

                    break;
                case "Lost Card":
                    result = "کارت نامعتبر است";
                    break;
                case "No Universal Account":
                    result = "کارت نامعتبر است";
                    break;
                case "Stolen Card":
                    result = "عملیات ناموفق";

                    break;

                case "No Investment Acount":
                    result = "کارت نامعتبر است";

                    break;
                case "No Sufficient Funds":
                    result = "عدم موجودی کافی";
                    break;
                case "No Cheque Account":
                    result = "کارت نامعتبر است";

                    break;
                case "No Saving Account":
                    result = "کارت نامعتبر است";

                    break;

                case "Expired Account":
                    result = "کارت نامعتبر است-تاریخ انقضای کارت سپری شده است";

                    break;
                case "Incorrect PIN":
                    result = "رمز نامعتبر است";
                    break;
                case "No Card Record":
                    result = "کارت نامعتبر است";

                    break;
                case "Transaction Not Permitted To CardHolder":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Transaction Not Permitted To Terminal":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Exceeds Withdrawal Amount Limit":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Restricted Card Decline":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Security Violation":
                    result = "عملیات ناموفق";
                    break;
                case "Exceeds Withdrawal Frequency Limit":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Response Received Too Late":
                    result = "-";
                    break;
                case "PIN Reties Exceeds-Slm":
                    result = "تراکنش نامعتبر است _ در صورت کسر وجه از حساب شما،مبلغ مذکور طی 72 ساعت به حساب عودت خواهد شد،درغیراینصورت جهت پی گیری لطفا با شماره تلفن 021-84080 تماس حاصل فرمایید";

                    break;
                case "Invalid Amount":
                    result = "عملیات ناموفق";

                    break;
                case "Issuer Down Slm":
                    result = "عملیات ناموفق";

                    break;
                case "Cut Off Is Inprogress":
                    result = "عملیات ناموفق-سامانه مقصد تراکنش در حال انجام عملیات پایان روز می باشد";

                    break;
                case "Transaction Cannot Be Completed":
                    result = "عملیات ناموفق";

                    break;
                case "TME Error":
                    result = "عملیات ناموفق";

                    break;


                default:
                    result = string.Empty;
                    break;

            }
            return result;
        }


    }
}