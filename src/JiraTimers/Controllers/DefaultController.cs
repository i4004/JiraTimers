using Simplify.Web;
using Simplify.Web.Attributes;
using Simplify.Web.Responses;

namespace JiraTimers.Controllers
{
	[Get("/")]
	public class DefaultController : Controller
	{
		public override ControllerResponse Invoke()
		{
			return new Ajax("Hello world!");
		}
	}
}