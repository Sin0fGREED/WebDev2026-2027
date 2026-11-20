using Hollowmere.Server.DTOs;
using Hollowmere.Server.Services;

using Microsoft.AspNetCore.Mvc;

namespace Hollowmere.Server.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestController(QuestServices)