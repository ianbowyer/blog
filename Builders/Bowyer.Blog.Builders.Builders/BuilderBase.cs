using System;
using System.Collections.Generic;
using System.Text;

namespace Bowyer.Blog.Builders.Builders
{
    public abstract class BuilderBase<T>
        where T : class, new()
    {
        protected T BuilderEntity { get; }

        protected BuilderBase()
        {
            BuilderEntity = new T();
        }

        public T Build()
        {
            return BuilderEntity;
        }
    }
}