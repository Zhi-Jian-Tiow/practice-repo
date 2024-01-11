using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.App;
using CookieCookBook.DataAccess;
using CookieCookBook.FileAccess;

const FileFormat Format = FileFormat.Json;
IStringsRepository stringRepository = Format == FileFormat.Json ? new StringsJsonRepository() : new StringsTextualRepository();
IngredientsRegister ingredientRegister = new IngredientsRegister();
const string FileName = "recipes";
FileMetadata fileMetadata = new FileMetadata(FileName, Format);

CookiesRecipesApp cookiesRecipesApp = new CookiesRecipesApp(new RecipesConsoleUserInteraction(ingredientRegister), new RecipesRepository(stringRepository, ingredientRegister));
cookiesRecipesApp.Run(fileMetadata.Name);