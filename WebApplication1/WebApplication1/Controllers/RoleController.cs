using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RbacApplication;
using RbacApplication.Role;
using RbacRepository.FenYe;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService role;

        public RoleController(IRoleService role)
        {
            this.role = role;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(RoleDto dto)
        {
            return Ok(role.Add(dto));
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Show()
        {
            return new JsonResult(role.GetAll());
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFen([FromQuery] TiaoJian t)
        {
            return new JsonResult(role.GetFen(t));
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GeiId(int id)
        {
            return new JsonResult(role.GetById(id));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Del(int id)
        {
            return Ok(role.Delete(id));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Upd(RoleDto r)
        {
            return Ok(role.Update(r));
        }
    }
}
