namespace IntegradorSofttekImanol.Models.Dictionaries
{

    /// <summary>
    /// A static class for translating an index to user roles.
    /// </summary>
    public static class UserRoleDic
    {

        /// <summary>
        /// Translates a numeric index representing a user role to the corresponding state string.
        /// </summary>
        /// <param name="index">An int.</param>
        /// <returns>A string containing the name of the user role.</returns>
        public static string TranslateUserRole(int index)
        {

            Dictionary<int,string> indexRole = new Dictionary<int, string>() 
            {
                {1,"Consultor" },
                {2,"Administrador" }
            };

            return indexRole[index];

        }

    }
}
