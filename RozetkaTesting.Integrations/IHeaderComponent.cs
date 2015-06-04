namespace RozetkaTesting.Integrations
{
    public interface IHeaderComponent
    {
        /// <summary>
        /// Opens cart as pop-up window.
        /// </summary>
        void OpenCart();

        /// <summary>
        /// Clear and type search phrase into search field.
        /// </summary>
        /// <param name="searchPhrase"></param>
        void InputSearchPhrase(string searchPhrase);

        /// <summary>
        /// Submits searching.
        /// </summary>
        void Search();
    }
}
