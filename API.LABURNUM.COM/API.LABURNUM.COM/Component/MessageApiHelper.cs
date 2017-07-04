using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class MessageApiHelper
    {
        string userName = Component.Constants.SMSAPI.SMSUSERNAME;
        string password = Component.Constants.SMSAPI.SMSPASSWORD;
        string url = Component.Constants.SMSAPI.SMSAPIURL;
        string senderId = Component.Constants.SMSAPI.SENDERID;



        //For Scheduling SMS Date & Time Required
        //http://www.smsjust.com/sms/user/urlsms.php?username=XXXX&pass=XXXX&senderid=XXXX&message=XXXX&dest_mobileno=XXXX&dt=2012-12-12&tm=18:00:00&response=Y
        //UniCode SMS Convert into Any Language.
        //http://www.smsjust.com/sms/user/urlsms.php?username=XXXX&pass=XXXX&senderid=XXXX&dest_mobileno=XXXXXXXXXX&msgtype=UNI&message=XXXX&response=Y
        //Web Push Messaging.
        //http://www.smsjust.com/sms/user/urlsms.php?username=XXXXXX&pass=XXXXXX&senderid=XXXXXX&dest_mobileno=XXXXXXXXXX&message=XXXXXX&WAPURL=http://www.XXXXXX.com&msgType=WAP&response=Y


        public string GetSMSBalance()
        {
            try
            {
                //Check SMS Balance
                //http://www.smsjust.com/sms/user/balance_check.php?username=XXXX&pass=XXXX
                string responsemessage = url + "balance_check.php?username=" + userName + "&pass=" + password;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(responsemessage);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(responsemessage, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    responsemessage = response.Content.ReadAsStringAsync().Result;
                    string[] a = responsemessage.Split(' ');
                    string[] b = a[3].Split(':');
                    return b[1];
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                return "Not Get";
            }
        }

        public string ChangePassword(string oldpassword, string newpassword)
        {
            try
            {
                //Change Password.
                //http://www.smsjust.com/sms/user/change_password.php?username=XXXX&oldpassword=XXXX&newpassword=XXXX
                string responsemessage = url + "change_password.php?username=" + userName + "&oldpassword=" + oldpassword + "&newpassword=" + newpassword;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(responsemessage);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(responsemessage, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    responsemessage = response.Content.ReadAsStringAsync().Result;
                    return responsemessage;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                return API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.SOMETHING_GOES_WRONG;
            }
        }

        public string SendSingleSMS(string mobileno, string message)
        {
            //Send Single SMS
            //http://www.smsjust.com/sms/user/urlsms.php?username=XXXX&pass=XXXX&senderid=XXXX&dest_mobileno=XXXX&message=XXXX&response=Y
            string responsemessage = url + "urlsms.php?username=" + userName + "&pass=" + password + "&senderid=" + senderId + "&dest_mobileno=" + mobileno + "&message=" + message + "&response=Y";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(responsemessage);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsync(responsemessage, null).Result;
            if (response.IsSuccessStatusCode)
            {
                responsemessage = response.Content.ReadAsStringAsync().Result;
                return responsemessage;
            }
            else { return null; }
        }
    }
}