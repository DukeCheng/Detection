// Copyright (c) 2016 Sarin Na Wangkanai, All Rights Reserved.
// The GNU GPLv3. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;

namespace Wangkanai.Browser.Depreciated
{
    internal class UAProfBrowser : DeviceBrowser
    {
        public override bool IsValid(HttpRequest request)
        {
            // user agent prof detection
            if (request.Headers.ContainsKey("x-wap-profile") || request.Headers.ContainsKey("Profile"))
            {
                DeviceInfoDepreciated = DeviceBuilderDepreciated.Mobile();
                return true;
            }
            
            return false;
        }
    }
}