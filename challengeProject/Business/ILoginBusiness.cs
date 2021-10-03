using challengeProject.Data.VO;

namespace challengeProject.Business
{
    public interface ILoginBusiness
    {
        TokenVO Create(UserVO user);
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
