namespace Bowyer.Blog.Builders.Builders
{
    /// <summary>
    /// The Abstract class for a Builder Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BuilderBase<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the builder entity.
        /// </summary>
        protected T BuilderEntity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderBase{T}"/> class.
        /// </summary>
        protected BuilderBase()
        {
            BuilderEntity = new T();
        }

        /// <summary>
        /// Builds an instance from the builder.
        /// </summary>
        /// <returns>An instance of <see cref="T"/></returns>
        public T Build()
        {
            return BuilderEntity;
        }
    }
}