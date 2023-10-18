using UseCasesQuery.RepositoriesQ.UserRepositoryQ;

namespace UseCasesQuery.Factory
{
    public interface IUserUserCaseQueryFactory
    {
        IUserRegisterUseCaseQuery Create();
    }

}
