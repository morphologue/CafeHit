using System;
using System.Collections.Generic;
using System.Linq;
using CafeHit.Shared.Models;

namespace CafeHit.Shared.Extensions
{
    public static class MainViewModelExtensions
    {
        private static readonly Sweetener?[] Sweeteners = {
            null,
            Sweetener.Sugar,
            Sweetener.Sugar,
            Sweetener.Sugar,
            Sweetener.Honey,
            Sweetener.Equal
        };

        private static readonly decimal[] SweetenerQuantities = {
            0M,
            0.5M,
            1M,
            2M,
            1M,
            2M
        };

        public static OrderModel ToModel(this MainViewModel vm) => new OrderModel
        {
            Variant = (Variant)vm.Variant,
            Size = (Size)vm.Size,
            Milk = vm.Milk == 0 ? null : (Milk?)(vm.Milk - 1),
            Dash = vm.Dash == 0 ? null : (Dash?)(vm.Dash - 1),
            Sweetener = Sweeteners[vm.Sweetener],
            SweetenerQuantity = SweetenerQuantities[vm.Sweetener],
            ProportionFull = Deflag(new[] {1M, 0.75M, 0.5M},
                vm.IsProportionFullOne, vm.IsProportionFullThreeQuarters, vm.IsProportionFullHalf),
            Customisations = new[]
            {
                Deflag(new Customisation?[] {null, Customisation.Strong, Customisation.Weak},
                    vm.IsStrengthNormal, vm.IsStrengthStrong, vm.IsStrengthWeak),
                Deflag(new Customisation?[] {null, Customisation.ExtraHot, Customisation.Warm},
                    vm.IsTemperatureNormal, vm.IsTemperatureExtraHot, vm.IsTemperatureWarm),
                vm.IsCustomisationCaramel ? Customisation.Caramel : (Customisation?) null,
                vm.IsCustomisationHazelnut ? Customisation.Hazelnut : (Customisation?) null,
                vm.IsCustomisationExtraChoc ? Customisation.ExtraChocolate : (Customisation?) null
            }.Where(c => c.HasValue).Cast<Customisation>().ToArray()
        };

        private static T Deflag<T>(IEnumerable<T> rubric, params bool[] flags)
        {
            int flagIndex = 0;
            foreach (T value in rubric)
            {
                if (flags[flagIndex++])
                {
                    return value;
                }
            }
            throw new ApplicationException("No set flag corresponded with a rubric element");
        }
    }
}
