using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes;

namespace CookieCookBook.App
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUsers();
    }
}
