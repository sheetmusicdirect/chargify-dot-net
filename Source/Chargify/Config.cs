﻿
#region License, Terms and Conditions
//
// Config.cs
//
// Authors: Kori Francis <twitter.com/djbyter>, David Ball
// Copyright (C) 2010 Clinical Support Systems, Inc. All rights reserved.
// 
//  THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW:
//
//  Permission is hereby granted, free of charge, to any person obtaining a
//  copy of this software and associated documentation files (the "Software"),
//  to deal in the Software without restriction, including without limitation
//  the rights to use, copy, modify, merge, publish, distribute, sublicense,
//  and/or sell copies of the Software, and to permit persons to whom the
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.
//
#endregion

namespace Chargify
{
    #region Imports

    using System.Configuration;
    using Chargify.Configuration;
    #endregion

    /// <summary>
    /// TODO
    /// </summary>
    public class Config
    {
        /// <summary>
        /// The API consumer's username
        /// </summary>
        public static string ApiKey
        {
            get
            {
                var config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
                ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
                return accountInfo.ApiKey;
            }
        }

        /// <summary>
        /// The API consumer's password
        /// </summary>
        public static string ApiPassword
        {
            get
            {
                var config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
                ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
                return accountInfo.ApiPassword;
            }
        }

        /// <summary>
        /// The site's shared key (used for hosted pages)
        /// </summary>
        public static string SharedKey
        {
            get
            {
                var config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
                ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
                return accountInfo.SharedKey;
            }
        }

        /// <summary>
        /// Should we use json?
        /// </summary>
        public static bool UseJson
        {
            get
            {
                var config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
                ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
                return accountInfo.UseJSON;
            }
        }

        /// <summary>
        /// The base API URL
        /// </summary>
        public static string ApiBaseUrl { get; set; }

        static Config()
        {
            var config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
            ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
            ApiBaseUrl = string.Format("https://{0}.chargify.com", accountInfo.Subdomain);
        }
    }
}
