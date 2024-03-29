using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Services.Localization;

namespace Nop.Services.Orders
{
    /// <summary>
    /// Represents a shopping cart
    /// </summary>
    public static class ShoppingCartExtensions
    {
        /// <summary>
        /// Indicates whether the shopping cart requires shipping
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <returns>True if the shopping cart requires shipping; otherwise, false.</returns>
        public static bool RequiresShipping(this IList<ShoppingCartItem> shoppingCart)
        {
            foreach (var shoppingCartItem in shoppingCart)
                if (shoppingCartItem.IsShipEnabled)
                    return true;
            return false;
        }

        /// <summary>
        /// Gets a number of product in the cart
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <returns>Result</returns>
        public static int GetTotalProducts(this IList<ShoppingCartItem> shoppingCart)
        {
            int result = 0;
            foreach (ShoppingCartItem sci in shoppingCart)
            {
                result += sci.Quantity;
            }
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether shopping cart is recurring
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <returns>Result</returns>
        public static bool IsRecurring(this IList<ShoppingCartItem> shoppingCart)
        {
            foreach (ShoppingCartItem sci in shoppingCart)
            {
                var product = sci.Product;
                if (product != null && product.IsRecurring)
                        return true;
            }
            return false;
        }

        /// <summary>
        /// Get a recurring cycle information
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <param name="localizationService">Localization service</param>
        /// <param name="cycleLength">Cycle length</param>
        /// <param name="cyclePeriod">Cycle period</param>
        /// <param name="totalCycles">Total cycles</param>
        /// <returns>Error (if exists); otherwise, empty string</returns>
        public static string GetRecurringCycleInfo(this IList<ShoppingCartItem> shoppingCart,
            ILocalizationService localizationService,
            out int cycleLength, out RecurringProductCyclePeriod cyclePeriod, out int totalCycles)
        {
            string error = "";

            cycleLength = 0;
            cyclePeriod = 0;
            totalCycles = 0;

            int? _cycleLength = null;
            RecurringProductCyclePeriod? _cyclePeriod = null;
            int? _totalCycles = null;

            foreach (var sci in shoppingCart)
            {
                var product= sci.Product;
                if (product == null)
                {
                    throw new NopException(string.Format("Product (Id={0}) cannot be loaded", sci.ProductId));
                }

                string conflictError = localizationService.GetResource("ShoppingCart.ConflictingShipmentSchedules");
                if (product.IsRecurring)
                {
                    //cycle length
                    if (_cycleLength.HasValue && _cycleLength.Value != product.RecurringCycleLength)
                    {
                        error = conflictError;
                        return error;
                    }
                    else
                    {
                        _cycleLength = product.RecurringCycleLength;
                    }

                    //cycle period
                    if (_cyclePeriod.HasValue && _cyclePeriod.Value != product.RecurringCyclePeriod)
                    {
                        error = conflictError;
                        return error;
                    }
                    else
                    {
                        _cyclePeriod = product.RecurringCyclePeriod;
                    }

                    //total cycles
                    if (_totalCycles.HasValue && _totalCycles.Value != product.RecurringTotalCycles)
                    {
                        error = conflictError;
                        return error;
                    }
                    else
                    {
                        _totalCycles = product.RecurringTotalCycles;
                    }
                }
            }

            if (_cycleLength.HasValue && _cyclePeriod.HasValue && _totalCycles.HasValue)
            {
                cycleLength = _cycleLength.Value;
                cyclePeriod = _cyclePeriod.Value;
                totalCycles = _totalCycles.Value;
            }

            return error;
        }

        /// <summary>
        /// Get customer of shopping cart
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <returns>Customer of shopping cart</returns>
        public static Customer GetCustomer(this IList<ShoppingCartItem> shoppingCart)
        {
            if (shoppingCart.Count == 0)
                return null;

            return shoppingCart[0].Customer;
        }

        public static IEnumerable<ShoppingCartItem> LimitPerStore(this IEnumerable<ShoppingCartItem> cart, int storeId)
        {
            //simply replace the following code with "return cart"
            //if you want to share shopping carts between stores

            //UNDONE the same "limit per store" logic should be done in
            //HasAllProductsDiscountRequirementRule.cs and HasOneProductDiscountRequirementRule.cs files
            return cart.Where(x => x.StoreId == storeId);
        }
    }
}
