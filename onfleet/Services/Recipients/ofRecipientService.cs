﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace onfleet
{
    public class ofRecipientService : ofService
    {
        public ofRecipientService(string apiKey = null) : base(apiKey) { }

        public virtual ofRecipient Create(ofRecipientsCreateOptions createOptions, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            string serilizedObj = JsonConvert.SerializeObject(createOptions).ToString();
            var PostData = new StringContent(serilizedObj, Encoding.UTF8, "application/json");
            var recipient = Requestor.Post<ofRecipient>(Urls.Recipients, requestOptions, PostData);
            return recipient;
        }

        public virtual ofRecipient Get(string recipientId, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var recipient = Requestor.Get<ofRecipient>(string.Format("{0}/{1}", Urls.Recipients, recipientId), requestOptions);
            return recipient;
        }

        public virtual ofRecipient FindByPhone(string recipientPhone, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var recipient = Requestor.Get<ofRecipient>(string.Format("{0}/phone/{1}", Urls.Recipients, HttpUtility.UrlEncode(recipientPhone)), requestOptions);
            return recipient;
        }

        public virtual ofRecipient FindByName(string recipientName, ofRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var recipient = Requestor.Get<ofRecipient>(string.Format("{0}/name/{1}", Urls.Recipients, HttpUtility.UrlEncode(recipientName)), requestOptions);
            return recipient;
        }
    }
}
