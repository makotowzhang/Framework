using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Model.SystemModel
{
    public class MenuModel
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public Guid? ParentId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
