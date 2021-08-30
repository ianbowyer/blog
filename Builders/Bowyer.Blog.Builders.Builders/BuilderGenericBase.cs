using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Bowyer.Blog.Builders.Builders
{
    public abstract class BuilderGenericBase<TModel, TBuilder>
        where TModel : class
        where TBuilder : BuilderGenericBase<TModel, TBuilder>
    {
        protected readonly TModel BuilderEntity;

        protected BuilderGenericBase(TModel defaultModel)
        {
            BuilderEntity = (TModel)Activator.CreateInstance(typeof(TModel));
            BuilderEntity = defaultModel;
        }

        public TBuilder With<TProperty>(Expression<Func<TModel, TProperty>> property, TProperty value)
        {
            var memberExpression = (MemberExpression)property.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;

            propertyInfo.SetValue(BuilderEntity, value);

            return (TBuilder)this;
        }

        public TBuilder Add<TProperty, TCollection>(Expression<Func<TModel, TCollection>> collection, TProperty item)
        {
            var memberExpression = (MemberExpression)collection.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;

            var list = propertyInfo.GetValue(BuilderEntity) as List<TProperty>;

            if (list == null)
            {
                list = new List<TProperty>();
            }

            list.Add(item);

            propertyInfo.SetValue(BuilderEntity, list);
            return (TBuilder)this;
        }

        public TBuilder Remove<TProperty, TCollection>(Expression<Func<TModel, TCollection>> collection, TProperty item)
        {
            var memberExpression = (MemberExpression)collection.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;

            var list = propertyInfo.GetValue(BuilderEntity) as List<TProperty>;

            if (list == null)
            {
                throw new NullReferenceException($"The collection '{memberExpression}' is null");
            }

            list.Remove(item);
            return (TBuilder)this;
        }

        public TBuilder Clear<TCollection>(Expression<Func<TModel, TCollection>> collection)

        {
            var memberExpression = (MemberExpression)collection.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;

            var list = propertyInfo.GetValue(BuilderEntity) as IList;

            if (list == null)
            {
                throw new NullReferenceException($"The collection '{memberExpression}' is null");
            }

            list.Clear();
            return (TBuilder)this;
        }

        public TModel Build()
        {
            return BuilderEntity;
        }
    }
}