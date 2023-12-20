using AgricolaLoja.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricolaLoja.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            return View(usuario);
        }
    }
}
