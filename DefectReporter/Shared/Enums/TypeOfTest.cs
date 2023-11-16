namespace DefectReporter.Shared.Enums
{
    /// <summary>
    /// The type of test enum.
    /// </summary>
    public enum TypeOfTest
    {
        /// <summary>
        /// The unit test.
        /// </summary>
        Unit = 0,

        /// <summary>
        /// The integration test.
        /// </summary>
        Integration,

        /// <summary>
        /// The functional test.
        /// </summary>
        Functional,

        /// <summary>
        /// The mandatory test.
        /// </summary>
        Complex,
        
        /// <summary>
        /// The acceptance test.
        /// </summary>
        Acceptance,

        /// <summary>
        /// The performance test.
        /// </summary>
        Performance,

        /// <summary>
        /// The security test.
        /// </summary>
        Security,

        /// <summary>
        /// The smoke test.
        /// </summary>
        Smoke
    }
}
