using CookieCookBook.Recipes;

namespace CookieCookBook.App
{
    public class CookiesRecipesApp
    {
        private readonly IRecipesUserInteraction _recipesUserInteraction;
        private readonly IRecipesRepository _recipesRepository;

        public CookiesRecipesApp(IRecipesUserInteraction recipesConsoleUserInteraction, IRecipesRepository recipesRepository)
        {
            _recipesUserInteraction = recipesConsoleUserInteraction;
            _recipesRepository = recipesRepository;
        }

        public void Run(string filePath)
        {
            var allRecipes = _recipesRepository.Read(filePath);
            _recipesUserInteraction.PrintExistingRecipes(allRecipes);
            _recipesUserInteraction.PromptToCreateRecipe();

            var ingredients = _recipesUserInteraction.ReadIngredientsFromUsers();

            if (ingredients.Count() > 0)
            {
                Recipe recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipesRepository.Write(filePath, allRecipes);

                _recipesUserInteraction.ShowMessage("Recipe added:");
                _recipesUserInteraction.ShowMessage(recipe.ToString());
            }
            else
            {
                _recipesUserInteraction.ShowMessage("No ingredients has been selected. Recipe will not be saved");
            }
            _recipesUserInteraction.Exit();
        }
    }
}
