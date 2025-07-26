public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        double totalCost = _price * _quantity;
        return totalCost;
    }

    public string GetPackingLabelText()
    {
        return $"Name: {_name}, ProductID: {_productId}";
    }

}