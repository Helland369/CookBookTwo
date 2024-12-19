namespace cookbookTwo;

public class Recipe
{   
    private string _category, _description, _nameOfRecipe;
    
    private List<string> _ingredients;

    public Recipe(string category, string description, string nameOfRecipe, List<string> ingredients)
    {
        _category = category;
        _description = description;
        _nameOfRecipe = nameOfRecipe;
        _ingredients = new List<string>(ingredients);
    }
    
    public string Category { get { return _category; } set { _category = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public string NameOfRecipe { get { return _nameOfRecipe; } set { _nameOfRecipe = value; } }
    public List<string> Ingredients { get { return _ingredients; } set { _ingredients = value; } }
}