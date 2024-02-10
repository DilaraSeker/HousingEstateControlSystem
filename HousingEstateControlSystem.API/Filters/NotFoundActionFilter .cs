using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HousingEstateControlSystem.Repositories.Interfaces;

namespace HousingEstateControlSystem.API.Filters
{
    public class NotFoundActionFilter : Attribute, IActionFilter
    {
        private readonly IDuesRepository _duesRepository;

        public NotFoundActionFilter(IDuesRepository duesRepository)
        {
            _duesRepository = duesRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var idAsObject = context.ActionArguments.FirstOrDefault(x => x.Key == "id");

            if (idAsObject.Key == null || idAsObject.Value == null)
                return;

            if (!int.TryParse(idAsObject.Value.ToString(), out var id))
                return;

            // Dues kaydını kontrol et
            var dues = _duesRepository.GetDuesById(id);

            if (dues == null)
            {
                context.Result = new NotFoundObjectResult($"Dues not found with id {id}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Eylem tamamlandıktan sonra yapılacak işlemler
        }
    }
}
