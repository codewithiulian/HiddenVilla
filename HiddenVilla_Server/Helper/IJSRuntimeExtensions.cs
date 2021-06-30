using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Server.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
