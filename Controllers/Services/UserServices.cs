using System.Collections.Generic;

public class UserServices
{
    public string ErrorMessage {get; private set;}
    private WebsiteServices _websiteServices;
    public User  currentUser {get; private set;}
    public IList<User> UserList {get; private set;}

    public dynamic filter {get; set;}    

    public IList<User> SelectedUsers {get; private set; }

    public UserServices(string inputFilter)
    {
        if (string.IsNullOrEmpty(inputFilter))
        {
            filter = "aaa";
        }else
        {
            filter = inputFilter;
        }
    }

    public bool Assign(string userId, string WebsiteID)
    {
        return true;
    }
    public bool GetListUser()
    {
        //UserList = repository.GetAll(filer)
        return true; 
    }

    public bool UserSelected(string listIds)
    {
        var ids = listIds.Split(',');
        // SelectedUsers = repo.GetById(ids)
        return true; 
    }


    public void test()
    {
        currentUser = new User("100");

        if (currentUser.Get())
        {
            // user.UserEntity.
        }
    }
    
    public bool GetUserDto()
    {
        if (currentUser.GetBasic())
        {
            var a = currentUser.UserDto;
        }

        if (currentUser.Get())
        {
            var b= currentUser.UserDto;
        }
       return true; 
    }

   public bool Deactive(string userId)
   {
       currentUser = new User(userId);

       if (! currentUser.Deactive())
       {
           
           ErrorMessage = "Could not de active" + currentUser.ErrorMessage;
           return false; 
       }
       return true;

   }
}

public class UserMSSQL 
{

}
public class UserNoSQL
{

}

public class UserDto
{
    public string Id;
    public string Name;

    public string Address;

    public UserDto(UserMSSQL basic, UserNoSQL full)
    {

    }
}
public class User
{
    private UserMSSQL _basicInfo;
    private UserNoSQL _fullInfo; 
    
    public UserDto UserDto
    {
        get { return new UserDto(_basicInfo, _fullInfo);  }
    }
    private string _errorMessage; 
    public string ErrorMessage
    {
        get {return _errorMessage; }
        private set {
            _errorMessage = value; 


            //Nlog.Debug(_errorMessage)
        }
    }

    public string ErrorCode {get; private set;}
    public string Id {get; set;}
    public UserEntity UserEntity {get; private set;}

    public string SecondValue(){
        return "Id " + Id + "Name "; 
    }
        
    public User(string id)
    {
        Id = id;
        // UserEntity = repository.Get(id);
    }

    public bool Get()
    {
        // UserEntity = repository.Get(id);
        // _basicInfo = MSSQLrepository.Get(id);
        // _fullInfo = NoSQLrepo.Get(id); 
        // if (UserEntity = null)
        return false; 
    }

    public bool GetBasic()
    {
        // _basicInfo = MSSQLrepository.Get(id);
        return false; 
    }

    
    public bool Update()
    {
        return true;
    }

    public bool Deactive()
    {
        if (false)
        {
            ErrorMessage = "User not exist";
            return false;
        }
        return true;
    }
}

public class UserEntity
{

}