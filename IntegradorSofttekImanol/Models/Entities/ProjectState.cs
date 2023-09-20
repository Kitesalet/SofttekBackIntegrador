namespace IntegradorSofttekImanol.Models.Entities
{
    /// <summary>
    /// Enumerates the states of a proyect.
    /// </summary>
    public enum ProjectState
    {
        /// <summary>
        /// The proyect state is pending.
        /// </summary>
        Pendiente = 1,

        /// <summary>
        /// The proyect state is confirmed.
        /// </summary>
        Confirmado = 2,

        /// <summary>
        /// The proyect state is completed.
        /// </summary>
        Terminado = 3
    }
}