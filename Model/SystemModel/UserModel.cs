using System;
using System.Collections.Generic;

namespace Model.SystemModel
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TrueName { get; set; }
        public bool? IsEnabled { get; set; } = true;
        public bool? IsDel { get; set; } = false;
        public List<string> UserRole { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
