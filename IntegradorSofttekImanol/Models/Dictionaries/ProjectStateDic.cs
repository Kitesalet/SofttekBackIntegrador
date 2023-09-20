namespace IntegradorSofttekImanol.Models.Dictionaries
{

    /// <summary>
    /// A static class for translating an index to project states.
    /// </summary>
    public static class ProjectStateDic
    {

        /// <summary>
        /// Translates a numeric index representing a project state to the corresponding state string.
        /// </summary>
        /// <param name="index">An int.</param>
        /// <returns>A string containing the name of the project.</returns>
        public static string TranslateProjectState(int index)
        {

            Dictionary<int,string> indexState = new Dictionary<int, string>() 
            {
                {1, "Pendiente" },
                {2, "Confirmado" },
                {3, "Terminado" }
            };

            return indexState[index];
        }

    }
}
