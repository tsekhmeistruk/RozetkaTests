namespace RozetkaTesting.Integrations
{
    public interface IResultPageComponent
    {
        /// <summary>
        /// Gets the title of the result page.
        /// </summary>
        /// <returns>Text of the title on the result page.</returns>
        string GetTitleOfResultPage();

        /// <summary>
        /// Adds product from result page to the cart by index and return its price.
        /// </summary>
        /// <param name="indexOfItem">Index of the item.</param>
        /// <returns>Price value of the product which was been added.</returns>
        int AddProductToCartAndReturnPrice(int indexOfItem);

        /// <summary>
        /// Adds random product from result page to the cart and return its price.
        /// </summary>
        /// <returns>Price value of the product which was been added.</returns>
        int AddProductToCartAndReturnPrice();
    }
}
