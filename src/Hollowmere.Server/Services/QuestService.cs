using Hollowmere.Data.Models;
using Hollowmere.Data.Repositories;
using Hollowmere.Server.DTOs

using Microsoft.EntityFrameworkCore;

namespace Hollowmere.Server.Services;

public class QuestService(CreaturesRepository repository)
{
    public DbResponse<IEnumerable<QuestDTO>
}