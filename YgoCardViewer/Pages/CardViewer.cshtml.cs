using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

public class CardViewerModel : PageModel 
{
    public Card Card {get;set;}
    public ICardsProvider _cardsProvider;

    public CardViewerModel(ICardsProvider cardsProvider)
    {
        _cardsProvider = cardsProvider;
    }

    public async Task<IActionResult> OnGetAsync(int id) 
    {
        try
        {
            var card = await _cardsProvider.GetCardAsync(id);
            if (card != null) {
                Card = card;
                return Page();
            }
            return RedirectToPage("Index");
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
       
    }
}