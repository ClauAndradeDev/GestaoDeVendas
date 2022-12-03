using Microsoft.JSInterop;

namespace GestaoDeVendas.Web.Util
{
    public static class IJSRuntimeExtensions
    {
        //escrever no localstorage
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        //obter um item do localStorage
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js,
            string key) => js.InvokeAsync<string>("localStorage.getItem", key);

        //remover um item do localStorage
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);
    }
}
