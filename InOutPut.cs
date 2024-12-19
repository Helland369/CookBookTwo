namespace cookbookTwo;

public class InOutPut
{
    private Recipe selectedRecipe;

    private List<Recipe> _recipes = new List<Recipe>
    {
        new Recipe("Dinner", "Delicious Dinner", "Meet balls",
            new List<string> { "Ground beef", "Eggs", "Milk", "Potato flour" }),
        new Recipe("Desert", "Delicious Chocolate Cake", "Chocolate cake",
            new List<string> { "Wheat flour", "Eggs", "Milk", "Chocolate" }),
    };

    public InOutPut()
    {
        MainMenu();
    }

    private void PrintRecipieList()
    {
        foreach (Recipe recipe in _recipes)
        {
            Console.WriteLine(recipe.Category + "\n" + recipe.Description + "\n" + recipe.NameOfRecipe);
            if (recipe.Ingredients.Count > 0)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }

                Console.WriteLine("------------------------");
            }
        }
    }

    private void FilterBasedOnCategory()
    {
        Console.WriteLine("Write the category you want to filter");

        string input = Console.ReadLine();

        var filteredRecipies =
            _recipes.Where(c => String.Equals(c.Category, input, StringComparison.CurrentCultureIgnoreCase)).ToList();
        // out loop in a separate function?
        foreach (Recipe recipe in filteredRecipies)
        {
            Console.WriteLine(recipe.Category + "\n" + recipe.Description + "\n" + recipe.NameOfRecipe);
        }
    }

    private void FilterBasedOnIngredients()
    {
        Console.WriteLine("Write the ingredients you want to search for");

        string input = Console.ReadLine();

        foreach (Recipe recipe in _recipes)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (String.Equals(ingredient, input, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(recipe.NameOfRecipe + "\n" + ingredient);
                }
            }
        }
    }

    private void PrintListWithIndex()
    {
        for (int i = 0; i < _recipes.Count; i++)
        {
            Console.WriteLine($"Index: [{i + 1}]\n" +
                              $"Category: {_recipes[i].Category}" +
                              $"{_recipes[i].NameOfRecipe}");
        }
    }

    private int SelectedRecipe()
    {
        PrintListWithIndex();

        Console.WriteLine("Select a recipe by index");

        int input = Convert.ToInt32(Console.ReadLine());

        return input;
    }

    private void ReadSelectedRecipe(int input)
    {
        if (input >= 0 && input <= _recipes.Count)
        {
            selectedRecipe = _recipes[input - 1];
            Console.WriteLine($"Category: {selectedRecipe.Category}\n" +
                              $"Description: {selectedRecipe.Description}\n" +
                              $"Name: {selectedRecipe.NameOfRecipe}");
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                Console.WriteLine($"Ingredient: {ingredient}");
            }
        }
    }

    private void EditTextScreen()
    {
        PrintListWithIndex();

        int input = Convert.ToInt32(Console.ReadLine());

        selectedRecipe = _recipes[input - 1];

        ReadSelectedRecipe(input);
        
        Console.WriteLine("Select the item you want to edit");

        string inputText = Console.ReadLine();

        EditRecipe(selectedRecipe,inputText);
    }
    
    private void EditRecipe(Recipe selectedRecipe,string inputText)
    {
        if (String.Equals(inputText, "Name", StringComparison.CurrentCultureIgnoreCase))
        {
            selectedRecipe.NameOfRecipe = inputText;
        }
        else if (String.Equals(inputText, "Category", StringComparison.CurrentCultureIgnoreCase))
        {
            selectedRecipe.Category = inputText;
        }
        else if (String.Equals(inputText, "Description", StringComparison.CurrentCultureIgnoreCase))
        {
            selectedRecipe.Description = inputText;
        }
    }

    private void MainMenu()
    {
        //PrintRecipieList();
        //FilterBasedOnCategory();
        //FilterBasedOnIngredients();
        //ReadSelectedRecipe(SelectedRecipe());
        EditTextScreen();
    }
}