namespace RozetkaTesting.Integrations
{
    public interface IPriceFilterComponent
    {
        /// <summary>
        /// Sets the range of price values.
        /// </summary>
        /// <param name="minValue">Min value in the range.</param>
        /// <param name="maxValue">Max value in the range.</param>
        void SetPriceFilter(out int minValue, out int maxValue);

        /// <summary>
        /// Presses button 'OK' for submitting range of price.
        /// </summary>
        void SubmitPriceFilter();

        /// <summary>
        /// Checks the price of products are in the range.
        /// </summary>
        /// <param name="minPriceValue">Min value of the range.</param>
        /// <param name="maxPriceValue">Max value of the range.</param>
        /// <returns>True if the price exists in the range.</returns>
        bool IsPriceInRange(int minPriceValue, int maxPriceValue);
    }
}
