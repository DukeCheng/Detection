﻿// Copyright (c) 2018 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using Wangkanai.Detection;

namespace Wangkanai.Detection.Collections
{
    public class Opera : Browser
    {
        private readonly string _agent;

        public Opera(string agent)
        {
            _agent = agent.ToLower();
            var opera12 = BrowserType.Opera.ToString().ToLower();

            if(_agent.Contains(opera12))
            {
                var first = _agent.IndexOf("version");
                var version = _agent.Substring(first + "version".Length + 1);
                Version = version.ToVersion();
                Type = BrowserType.Opera;
            }

            var opera15 = "opr";
            if (_agent.Contains(opera15))
            {
                var first = _agent.IndexOf(opera15);
                var version = _agent.Substring(first + opera15.Length + 1);
                Version = version.ToVersion();
                Type = BrowserType.Opera;
            }
        }
    }
}
