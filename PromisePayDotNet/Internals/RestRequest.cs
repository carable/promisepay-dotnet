﻿using System;
using System.Net;
using System.Net.Http;

namespace PromisePayDotNet.Internals
{
    public class RestRequest
    {
        internal string url;

        public RestRequest(string url, HttpMethod method)
        {
            this.url = url;
            this.Method = method;
        }

        public HttpMethod Method { get; }

        internal void AddUrlSegment(string name, string value)
        {
            this.url = this.url.Replace($"{{{name}}}", WebUtility.UrlEncode(value));
        }

        internal void AddParameter(string name, object value)
        {
            if (ReferenceEquals(null, value)) return;
            if (this.url.Contains("?"))
            {
                this.url = $"{this.url}&{WebUtility.UrlEncode(name)}={WebUtility.UrlEncode(value.ToString())}";
            }
            else
            {
                this.url = $"{this.url}?{WebUtility.UrlEncode(name)}={WebUtility.UrlEncode(value.ToString())}";
            }
        }
    }
}
