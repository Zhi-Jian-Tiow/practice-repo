﻿namespace CookieCookBook.Recipes.Ingredients;

public class Chocolate : Ingredient
{
    public override string PreparationInstructions => $"Melt in a water bath. {base.PreparationInstructions}.";
    public override int Id => 4;
    public override string Name => "Chocolate";
}
