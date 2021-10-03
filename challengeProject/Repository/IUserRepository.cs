using challengeProject.Data.VO;
using challengeProject.Model;

namespace challengeProject.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
        void CreateCredentials(UserVO user);
    }
}
