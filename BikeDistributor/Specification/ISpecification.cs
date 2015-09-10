namespace BikeDistributor.Specification
{
    /// <summary>
    /// Interface for specifications
    /// </summary>
    public interface ISpecification
    {
        /// <summary>
        /// Returs true if the specification matches the critirea, otherwise returns false
        /// </summary>
        /// <returns></returns>
        bool IsSatisfied();
    }
}
