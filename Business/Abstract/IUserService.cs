using Core.Entities.Concrete;
using Core.Utilities.Paging;
using Core.Utilities.Results;
using Entities.DTOs;
using Entities.DTOs.UserDtos;

namespace Business.Abstract;

public interface IUserService
{
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
    IDataResult<PagedList<User>> GetAll(bool status, string sortOrder, int page = 1, int size = 10);
    IDataResult<User> GetById(Guid userId);
    IDataResult<List<OperationClaim>> GetClaims(User user);
    IDataResult<User> GetByMail(string email);
    IResult EditProfile(UserForUpdateDto user);

}
