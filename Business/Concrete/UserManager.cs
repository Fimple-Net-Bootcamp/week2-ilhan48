﻿using Business.Abstract;
using Business.BusinessAspect;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

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

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public IDataResult<User> GetByMail(string email)
    {
        return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
    }
}