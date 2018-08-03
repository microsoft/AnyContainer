// © Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.AnyContainer
{
    /// <summary>
    /// Determines how IoC container-created objects are re-used.
    /// </summary>
    public enum Lifetime
    {
        /// <summary>
        /// Created objects are never re-used.
        /// </summary>
        Transient,

        /// <summary>
        /// One object is created and used for all resolves.
        /// </summary>
        Singleton,

        /// <summary>
        /// One object is created and used for each web request.
        /// </summary>
        WebRequest,
    }
}
