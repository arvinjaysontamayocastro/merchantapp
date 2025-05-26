using System;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria => criteria;
}

// Changed to Primary Constructor format
// public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
// {
//     private readonly Expression<Func<T, bool>> criteria;

//     public BaseSpecification
//     {
//         this.criteria = criteria;
//     }

//     public Expression<Func<T, bool>> Criteria => criteria;
// }
