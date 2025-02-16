// Creazione di un oggetto WebApplicationBuilder che gestisce la configurazione dell'applicazione.
// 'args' rappresenta gli argomenti della riga di comando passati all'applicazione al momento dell'avvio.
var builder = WebApplication.CreateBuilder(args);

// Registrazione dei servizi nel contenitore delle dipendenze dell'applicazione.
// In questo caso, viene registrato il servizio MVC (Model-View-Controller) con supporto per le viste.
// Questo servizio consente di gestire richieste HTTP utilizzando i controller e di restituire risposte basate su file di visualizzazione (CSHTML).
builder.Services.AddControllersWithViews();

// Creazione dell'oggetto WebApplication basato sulla configurazione definita nel builder.
// Questo oggetto rappresenta l'applicazione ASP.NET Core e permette di configurare il middleware e la gestione delle richieste HTTP.
var app = builder.Build();

// Configurazione della pipeline di gestione delle richieste HTTP.
// La pipeline è una serie di middleware che processano le richieste prima che raggiungano il controller e dopo che il controller ha generato una risposta.

// Controlla se l'applicazione non è in modalità di sviluppo.
if (!app.Environment.IsDevelopment())
{
    // Se l'app è in modalità di produzione o staging, utilizza un gestore di errori personalizzato.
    // Reindirizza le richieste alla pagina "/Home/Error" quando si verifica un'eccezione non gestita.
    app.UseExceptionHandler("/Home/Error");

    // Abilita HTTP Strict Transport Security (HSTS) per migliorare la sicurezza.
    // HSTS forza i browser a utilizzare solo HTTPS per tutte le richieste future per un determinato periodo di tempo.
    // Il valore predefinito è 30 giorni, ma può essere modificato per ambienti di produzione.
    app.UseHsts();
}

// Abilita il reindirizzamento automatico delle richieste HTTP a HTTPS.
// Questo garantisce che tutte le comunicazioni con il server avvengano in modo sicuro.
app.UseHttpsRedirection();

// Configura il middleware di routing, che permette all'app di instradare le richieste HTTP ai controller appropriati.
// Senza questa configurazione, l'applicazione non saprebbe a quale controller inviare le richieste ricevute.
app.UseRouting();

// Abilita il middleware di autorizzazione, che garantisce che solo utenti autenticati possano accedere a determinate risorse.
// Anche se non è ancora stata configurata l'autenticazione, questa linea è necessaria per eventuali futuri controlli di accesso.
app.UseAuthorization();

// Mappa le risorse statiche, come file CSS, JavaScript e immagini, per permetterne l'accesso da parte dei client.
// Questo middleware assicura che i file statici presenti nella cartella "wwwroot" o in altre directory configurate siano serviti correttamente.
app.MapStaticAssets();

// Configura il sistema di routing dell'applicazione, specificando una route predefinita per i controller.
// Il pattern "{controller=Home}/{action=Index}/{id?}" significa:
// - Se nessun controller è specificato nell'URL, viene utilizzato "Home" come controller predefinito.
// - Se nessuna azione è specificata, viene usata "Index" come azione predefinita.
// - Il parametro "id" è opzionale e può essere usato per identificare una risorsa specifica (es. un post, un utente, ecc.).
app.MapControllerRoute(
        name: "default", // Nome della route, utile se si vogliono definire più percorsi
        pattern: "{controller=Home}/{action=Index}/{id?}") // Definizione della struttura dell'URL
    .WithStaticAssets(); // Garantisce che le risorse statiche siano disponibili anche con questa route

// Avvia l'applicazione e inizia ad ascoltare le richieste HTTP in entrata.
// L'app rimarrà in esecuzione finché non viene chiusa manualmente o si verifica un errore critico.
app.Run();
