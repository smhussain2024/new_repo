using ConsoleWebAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConsoleWebAPI.Binders
{
    public class CustomeBinderCountryDetails : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName= bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;

            if(!int.TryParse(result, out var countryId))
            {
                return Task.CompletedTask;
            }

            var country = new CountryModel()
            {
                Id = countryId,
                Name = "Pakistan",
                Area = 5000,
                Population = 24000000
            };

            bindingContext.Result = ModelBindingResult.Success(country);

            return Task.CompletedTask;
        }
    }
}
