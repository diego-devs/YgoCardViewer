using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace YgoCardViewer.Pages;

public class IndexModel : PageModel
{
    public List<Card> Cards {get;set;}

    [BindProperty(SupportsGet = true)]
    public string Search {get;set;}

    private readonly ILogger<IndexModel> _logger;

    public readonly ICardsProvider _cardsProvider;

    public IndexModel(ILogger<IndexModel> logger, ICardsProvider cardsProvider)
    {
        _logger = logger;
        _cardsProvider = cardsProvider;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!string.IsNullOrEmpty(Search)) 
        {
            var response = await _cardsProvider.GetCardsAsync(Search);
            if (response != null) {
                Cards = new List<Card>(response);
            }
        }
        return Page();
    }
}
