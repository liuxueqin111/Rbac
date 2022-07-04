using AutoMapper;
using RbacRepository;
using RbacRepository.FenYe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class BaseService<T,TDto>:IBaseService<T,TDto>
        where T : class,new()
        where TDto : class,new()
    {
        private readonly IBaseDTO<T, int> baseService;
        private readonly IMapper mapper;

        public BaseService(IBaseDTO<T, int> baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int Add(TDto dto)
        {
            return baseService.Add(mapper.Map<T>(dto));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return baseService.Del(id);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public  virtual List<TDto> GetAll()
        {
            return mapper.Map<List<TDto>>(baseService.GetAll());
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public virtual shuju GetFen(TiaoJian j)
        {
            return mapper.Map<shuju>(baseService.GetFen(j));
        }
        /// <summary>
        /// 获取单个id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TDto GetById(int id)
        {
            return mapper.Map<TDto>(baseService.Get(id));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int Update(TDto dto)
        {
            return baseService.Upd(mapper.Map<T>(dto));
        }
    }
}
