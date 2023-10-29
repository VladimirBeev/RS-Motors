using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RSMotors.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
