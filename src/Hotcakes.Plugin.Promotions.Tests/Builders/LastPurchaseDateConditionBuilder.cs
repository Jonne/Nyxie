﻿using System;
using System.Collections.Generic;

using Sitecore.Commerce.Plugin.Rules;

namespace Hotcakes.Plugin.Promotions.Tests.Builders
{
    public class LastPurchaseDateConditionBuilder : IQualificationBuilder
    {
        private DateTimeOffset date;
        private Operator @operator;

        public ConditionModel Build()
        {
            string comparer;
            switch (@operator)
            {
                case Builders.Operator.NotEqual:
                    comparer = "Sitecore.Framework.Rules.DateTimeNotEqualityOperator";
                    break;
                case Builders.Operator.GreaterThan:
                    comparer = "Sitecore.Framework.Rules.DateTimeGreaterThanOperator";
                    break;
                case Builders.Operator.GreaterThanOrEqual:
                    comparer = "Sitecore.Framework.Rules.DateTimeGreaterThanEqualToOperator";
                    break;
                case Builders.Operator.LessThanOrEqual:
                    comparer = "Sitecore.Framework.Rules.DateTimeLessThanEqualToOperator";
                    break;
                case Builders.Operator.LessThan:
                    comparer = "Sitecore.Framework.Rules.DateTimeLessThanOperator";
                    break;
                default:
                    comparer = "Sitecore.Framework.Rules.DateTimeEqualityOperator";
                    break;
            }

            return new ConditionModel
            {
                Name = "Hc_LastPurchaseDateCondition",
                LibraryId = "Hc_LastPurchaseDateCondition",
                Properties = new List<PropertyModel>
                {
                    new PropertyModel
                    {
                        Name = "Hc_Operator",
                        Value = comparer,
                        IsOperator = true
                    },
                    new PropertyModel
                    {
                        Name = "Hc_Date",
                        Value = date.ToString()
                    }
                }
            };
        }

        public LastPurchaseDateConditionBuilder Operator(Operator @operator)
        {
            this.@operator = @operator;
            return this;
        }

        public LastPurchaseDateConditionBuilder Date(DateTimeOffset date)
        {
            this.date = date;
            return this;
        }
    }
}
