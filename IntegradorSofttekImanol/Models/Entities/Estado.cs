namespace IntegradorSofttekImanol.Models.Entities
{
    /// <summary>
    /// Enumerates the states of a Proyecto.
    /// </summary>
    public enum Estado
    {
        /// <summary>
        /// The Proyecto state is pending.
        /// </summary>
        Pendiente = 1,

        /// <summary>
        /// The Proyecto state is confirmed.
        /// </summary>
        Confirmado = 2,

        /// <summary>
        /// The Proyecto state is completed.
        /// </summary>
        Terminado = 3
    }
}