// Description: Evaluate C# code and expression in T-SQL stored procedure, function and trigger.
// Website & Documentation: https://github.com/zzzprojects/Eval-SQL.NET
// Forum & Issues: https://github.com/zzzprojects/Eval-SQL.NET/issues
// License: https://github.com/zzzprojects/Eval-SQL.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright � ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;

// ReSharper disable InconsistentNaming

namespace Z.Expressions.SqlServer.Eval
{
    public partial struct SQLNET
    {
        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET Val(string key, object value)
        {
            value = SqlTypeHelper.ConvertToType(value);
            Type type;

            // CHECK for key containing type: int? x
            if (key.Contains(" "))
            {
                var split = key.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length == 1)
                {
                    type = value.GetType();
                    key = key.Trim();
                }
                else if (split.Length == 2)
                {
                    type = TypeHelper.GetTypeFromName(split[0]);
                    key = split[1];
                }
                else
                {
                    throw new Exception(string.Format(ExceptionMessage.Invalid_ValueKey, key));
                }
            }
            else
            {
                type = value.GetType();
            }

            object oldType;
            if (Item.ParameterTypes.TryGetValue(key, out oldType))
            {
                if (!Equals(oldType, type))
                {
                    Item.ParameterTypes[key] = type;
                    Item.Delegate = null;
                }

                Item.ParameterValues[key] = value;
            }
            else
            {
                Item.ParameterTypes.Add(key, type);
                Item.ParameterValues.Add(key, value);
            }

            return this;
        }

        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET val(string key, object value)
        {
            return Val(key, value);
        }

        /// <summary>Add or update a value associated with the specified key.</summary>
        /// <param name="key">The key of the value to add or update.</param>
        /// <param name="value">The value to add or update associated with the specified key.</param>
        /// <returns>A fluent SQLNET object.</returns>
        public SQLNET VAL(string key, object value)
        {
            return Val(key, value);
        }
    }
}