using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Data.SqlClient;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDAL)
    {
        _userDal = userDAL;
    }

    public IDataResult<User> GetById(Guid userId)
    {
        return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
    }

    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
    }
    [SecuredOperation("Admin")]
    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult();

    }

    public IResult EditProfile(UserForUpdateDto user)
    {
        byte[] passwordHash;
        byte[] passwordSalt;

        HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

        var userInfo = new User()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        _userDal.Update(userInfo);
        return new SuccessResult();
    }

    [SecuredOperation("user.delete, Admin")]
    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult();
    }

    public IDataResult<List<User>> GetAll(bool status, string sortOrder)
    {
        var users = _userDal.GetAll();


        users = users.Where(item => item.Status == status).ToList();

        if (users.Count == 0)
        {
            return new ErrorDataResult<List<User>>(Messages.NoMatchingContent);
        }

        if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
        {
            users = users.OrderBy(item => item.FirstName).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            users = users.OrderByDescending(item => item.FirstName).ToList();
        }
        else
        {
            users = users.OrderBy(item => item.FirstName).ToList();
        }

        return new SuccessDataResult<List<User>>(users);
    }


    public IDataResult<User> GetByMail(string email)
    {
        return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
    }
}