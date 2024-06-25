using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConsoleWebAPI.Binders
{
    public class CustomBinder : IModelBinder
    {
        public  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            //string bodyAsText = new StreamReader(bindingContext.HttpContext.Request.Body).ReadToEnd();

            IQueryCollection data = bindingContext.HttpContext.Request.Query;
            bool result = data.TryGetValue("countries", out var country);

            if (result) { 
                string[] array = country.ToString().Split('|', StringSplitOptions.RemoveEmptyEntries);
                bindingContext.Result= ModelBindingResult.Success(array);
            }

            return Task.CompletedTask;
        }
    }
}
