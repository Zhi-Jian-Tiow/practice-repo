using CookieCookBook.DataAccess;
using CookieCookBook.Recipes.Ingredients;

namespace CookieCookBook.Recipes
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IStringsRepository _stringsRepository;
        private readonly IIngredientsRegister _ingredientRegister;
        private const string Separator = ",";
        public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
        {
            _stringsRepository = stringsRepository;
            _ingredientRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _stringsRepository.Read(filePath);
            List<Recipe> recipes = new List<Recipe>();

            foreach (string recipeFromFile in recipesFromFile)
            {
                Recipe recipe = RecipeFromString(recipeFromFile);
                recipes.Add(recipe);
            }
            return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            string[] textualIds = recipeFromFile.Split(Separator);
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (string textualId in textualIds)
            {
                int id = int.Parse(textualId);
                Ingredient ingredient = _ingredientRegister.GetById(id);
                ingredients.Add(ingredient);
            }
            return new Recipe(ingredients);
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            List<string> recipeAsStrings = new List<string>();
            foreach (Recipe recipe in allRecipes)
            {
                List<int> allIds = new List<int>();
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recipeAsStrings.Add(string.Join(Separator, allIds));
            }
            _stringsRepository.Write(filePath, recipeAsStrings);
        }
    }
}
