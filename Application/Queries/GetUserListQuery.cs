using Domain;
using MediatR;

namespace Application.Queries
{
    public class GetUserListQuery:IRequest<List<User>>
    {

    }
}
