// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Gent.Services.Identity.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gent.Services.Identity.MainModule.Account
{
    public class LoginViewModel : LoginInputModel
    {
        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;

        public static implicit operator LoginViewModel(ViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}