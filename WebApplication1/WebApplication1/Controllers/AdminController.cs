using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RbacApplication.Admin;
using RbacApplication.Admin.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AdminDto dto)
        {
            return Ok(adminService.Add(dto));
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Show()
        {
            return new JsonResult(adminService.GetAll());
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GeiId(int id)
        {
            return new JsonResult(adminService.GetById(id));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Del(int id)
        {
            return Ok(adminService.Delete(id));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Upd(AdminDto r)
        {
            return Ok(adminService.Update(r));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RbacApplication.Admin.AdminDto dto)
        {
            return Ok(adminService.Register(dto));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(adminService.Login(dto));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Pindex"></param>
        /// <param name="Psize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Page(int Pindex = 1, int Psize = 2)
        {
            return Ok(adminService.Page(Pindex, Psize));
        }
    }
}
