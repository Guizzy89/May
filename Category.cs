public class Category
{
    private readonly int _categoryId;
    private readonly string _name;

    public int CategoryId => _categoryId;
    public string Name => _name;

    public Category(int categoryId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ќазвание категории не может быть пустым.", nameof(name));

        _categoryId = categoryId;
        _name = name;
    }
}