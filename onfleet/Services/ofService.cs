﻿using System;

namespace onfleet
{
    public class ofService
    {
          public string ApiKey { get; set; }

        protected ofService(string apiKey)
        {
            ApiKey = apiKey;
        }

        protected ofRequestOptions SetupRequestOptions(ofRequestOptions requestOptions)
        {
            if(requestOptions == null) requestOptions = new ofRequestOptions();

            if (!String.IsNullOrEmpty(ApiKey))
                requestOptions.ApiKey = ApiKey;

            return requestOptions;
        }
    }
}
