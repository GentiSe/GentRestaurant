// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Gent.Services.Identity.MainModule.Consent;

namespace Gent.Services.Identity.MainModule.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}