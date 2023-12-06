using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        throw new NotImplementedException();
    }

    public void EditProfile(UserForUpdateDto user)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public User GetByMail(string mail)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}
