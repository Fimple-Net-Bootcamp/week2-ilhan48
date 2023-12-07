using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract;

public interface IUserService
{
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
    IDataResult<List<User>> GetAll(bool status, string sortOrder);
    IDataResult<User> GetById(Guid userId);
    IDataResult<List<OperationClaim>> GetClaims(User user);
    IDataResult<User> GetByMail(string email);
    IResult EditProfile(UserForUpdateDto user);

}
