// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright � ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections;

namespace Z.Expressions
{
    /// <summary>An eval delegate used to cache delegate items.</summary>
    public class EvalDelegate
    {
        /// <summary>The key used to cache the EvalDelegate.</summary>
        public string CacheKey;

        /// <summary>The delegate to cache.</summary>
        public Func<IDictionary, object> Delegate;

        /// <summary>The inner delegate.</summary>
        public object InnerDelegate;

        /// <summary>The last access Date/Time of the delegate.</summary>
        public DateTime LastAccess;

        /// <summary>Constructor.</summary>
        /// <param name="cacheKey">The key used to cache the EvalDelegate.</param>
        /// <param name="delegateAction">The delegate to cache.</param>
        public EvalDelegate(string cacheKey, Func<IDictionary, object> delegateAction)
        {
            CacheKey = cacheKey;
            Delegate = delegateAction;
            LastAccess = DateTime.Now;
        }
    }
}