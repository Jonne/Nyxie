﻿using Promethium.Plugin.Promotions.Extensions;
using Sitecore.Commerce.Plugin.Carts;
using Sitecore.Framework.Rules;
using System.Linq;

namespace Promethium.Plugin.Promotions.Conditions
{
    /// <summary>
    /// A SiteCore Commerce condition for the qualification
    /// "Cart contains [compares] [specific value] products in the [specific category]"
    /// </summary>
    [EntityIdentifier("Pm_" + nameof(CartProductAmountInCategoryCondition))]
    public class CartProductAmountInCategoryCondition : ICartsCondition
    {
        public IBinaryOperator<decimal, decimal> Pm_Compares { get; set; }

        public IRuleValue<decimal> Pm_SpecificValue { get; set; }

        public IRuleValue<string> Pm_SpecificCategory { get; set; }

        public IRuleValue<bool> Pm_IncludeSubCategories { get; set; }

        public bool Evaluate(IRuleExecutionContext context)
        {
            //Get configuration
            var specificCategory = Pm_SpecificCategory.Yield(context);
            var specificValue = Pm_SpecificValue.Yield(context);
            var includeSubCategories = Pm_IncludeSubCategories.Yield(context);
            if (string.IsNullOrEmpty(specificCategory) || specificValue == 0 || Pm_Compares == null)
            {
                return false;
            }

            //Get Data
            if (!context.GetCardLines(specificCategory, includeSubCategories, out var categoryLines))
            {
                return false;
            }

            //Validate data against configuration
            var productAmount = categoryLines.Sum(x => x.Quantity);
            return Pm_Compares.Evaluate(productAmount, specificValue);
        }
    }
}