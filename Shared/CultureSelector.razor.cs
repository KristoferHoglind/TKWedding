using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace TKWeddingASPBlazor.Shared
{
    public partial class CultureSelector
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public string CurrentCulture { get; set; }

        public CultureSelector()
        {
            CurrentCulture = CultureInfo.CurrentUICulture.Name;
        }

        public void ChangeLanguage()
        {
            var currentUICulture = CultureInfo.CurrentUICulture;
            if(currentUICulture.Name == "sv")
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", "pl");
                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
                CurrentCulture = "pl";
            } else
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", "sv");
                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
                CurrentCulture = "sv";
            }

        }
    }
}
