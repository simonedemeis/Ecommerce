using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    // Il controller Home gestisce le richieste relative alle pagine principali dell'applicazione (ad esempio, la homepage e la pagina di privacy).
    // Viene utilizzato anche per gestire gli errori globali tramite il metodo `Error`.

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Il logger viene utilizzato per registrare i messaggi di log dell'applicazione.
        // In questo caso, il logger è specifico per la classe HomeController, per tenere traccia degli eventi legati a questo controller.

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // Il costruttore del controller riceve un'istanza del logger tramite dependency injection.
            // Questo permette di registrare eventi come errori o informazioni di esecuzione relativi a questo controller.
        }

        // Azione che restituisce la vista principale (Index)
        public IActionResult Index()
        {
            // Restituisce la vista "Index", che è la homepage del sito.
            return View();
        }

        // Azione che restituisce la vista "Privacy"
        public IActionResult Privacy()
        {
            // Restituisce la vista "Privacy", che contiene la pagina delle informazioni sulla privacy.
            return View();
        }

        // Azione per la gestione degli errori generici
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // L'attributo [ResponseCache] disabilita la cache per la vista di errore.
        // La durata della cache è impostata su 0, quindi la risposta non viene memorizzata.
        // "NoStore" indica che la risposta non deve essere conservata nella cache.
        // Questo è utile per evitare che le informazioni relative agli errori vengano memorizzate in modo errato o per lungo tempo.
        
        public IActionResult Error()
        {
            // Crea un'istanza di ErrorViewModel, passando l'ID della richiesta corrente (utile per il debug).
            // Se l'ID della richiesta è disponibile tramite `Activity.Current?.Id`, viene usato, altrimenti si utilizza l'ID di traccia dalla richiesta HTTP.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
