using System.Collections.Generic;

namespace dotnetcore_aurelia_demo.Models.AccountViewModels
{
    public class RolesInUserModel
    {
        public string Id { get; set; }
        public List<string> EnrolledRoles { get; set; }
        public List<string> RemovedRoles { get; set; }
    }
}