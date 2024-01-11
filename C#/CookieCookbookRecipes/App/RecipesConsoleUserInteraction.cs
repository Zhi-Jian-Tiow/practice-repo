using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes;

namespace CookieCookBook.App
{
    public class RecipesConsoleUserInteraction : IRecipesUserInteraction
    {
        private readonly IIngredientsRegister _ingredientRegister;

        public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
        {
            _ingredientRegister = ingredientsRegister;
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are: " + Environment.NewLine);

                int counter = 1;
                foreach (Recipe recipe in allRecipes)
                {                    
                    Console.WriteLine($"*****{counter}*****");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    counter++;
                }
            }
        }

        public void PromptToCreateRecipe()
        {
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            foreach (Ingredient ingredient in _ingredientRegister.All)
            {
                Console.WriteLine(ingredient);
            }
        }

        public IEnumerable<Ingredient> ReadIngredientsFromUsers()
        {
            bool isSelectingIngredient = true;
            List<Ingredient> ingredients = new List<Ingredient>();
            while (isSelectingIngredient)
            {
                Console.WriteLine("Add an ingredient by it's Id, or type anything else if finished.");
                string userChoice = Console.ReadLine();
                bool userChoiceIsValid = int.TryParse(userChoice, out int selectedIngredientId);
                if (userChoiceIsValid)
                {
                    Ingredient selectedIngredient = _ingredientRegister.GetById(selectedIngredientId);
                    if (selectedIngredient is not null)
                    {
                        ingredients.Add(selectedIngredient);
                    }
                }
                else
                {
                    isSelectingIngredient = false;
                }
            }
            return ingredients;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
