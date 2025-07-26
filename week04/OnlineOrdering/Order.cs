public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        return totalCost;
    }
    public double GetTotalPrice()
    {
        double totalCost = GetTotalCost();
        int shippingCost = GetShippingCost();
        return totalCost + shippingCost;
    }

    public int GetShippingCost()
    {
        return _customer.IsInUsa() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        List<string> packingLabel = [];
        foreach (Product product in _products)
        {
            packingLabel.Add(product.GetPackingLabelText());
        }
        string packingLabelText = string.Join("\n",packingLabel);
        return packingLabelText;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = _customer.GetShippingLabel();
        return shippingLabel;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}