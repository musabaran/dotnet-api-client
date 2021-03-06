﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Exceptions;
using Etkinlik.io.ApiClient.Models;
using Newtonsoft.Json;

namespace Etkinlik.io.ApiClient.Services
{
    public class TurService
    {
        public ApiClient client { get; set; }
        public TurService(ApiClient client)
        {
            this.client = client;
        }

        public List<Tur> GetList()
        {
            Task<HttpResponseMessage> response = client.Call("/turler");

            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Tur>>(response.Result.Content.ReadAsStringAsync().Result);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }
            throw new UnknownException(response.Result);
        }
    }

}
