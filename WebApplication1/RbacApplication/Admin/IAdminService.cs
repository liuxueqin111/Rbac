using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using RbacApplication.Admin;
using RbacApplication.Admin.Dto;

namespace RbacApplication.Admin
{
    public interface IAdminService:IBaseService<Rbac.Entity.Admin, AdminDto>
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        RestultDto Register(AdminDto dto);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TokenDto Login(LoginDto dto);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Pindex"></param>
        /// <param name="Psize"></param>
        /// <returns></returns>
        Tuple<List<Rbac.Entity.Admin>, int> Page(int Pindex = 1, int Psize = 2);
    }
}

