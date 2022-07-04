using AutoMapper;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RbacApplication.Admin.Dto;
using RbacRepository;
using RbacRepository.Admin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;

namespace RbacApplication.Admin
{
    public class AdminService : BaseService<Rbac.Entity.Admin, AdminDto>, IAdminService
    {
        private readonly IAdminDto baseService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AdminService(IAdminDto baseService, IMapper mapper, IConfiguration configuration) : base(baseService, mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public TokenDto Login(LoginDto dto)
        {
            var admin = baseService.GetEntity(m => m.UserName == dto.UserName.Trim());
            if (admin == null)
            {
                return new TokenDto { Code = 1, Msg = "没有此用户" };
            }
            if (admin.Password.ToLower() != Md5(dto.Password.Trim().ToLower()))
            {
                return new TokenDto { Code = 2, Msg = "密码错误" };
            }

            //生成Token令牌
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, dto.UserName)
            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));

            //算法，签名证书
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);


            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims, //自定义声明信息
                notBefore: DateTime.UtcNow,  //创建时间
                expires: expires,   //过期时间
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new TokenDto { Code = 0, Msg = "登录成功", Token = jwt };
        }

        public RestultDto Register(AdminDto dto)
        {
            if (baseService.GetEntity(m => m.UserName == dto.UserName.Trim().ToUpper()) != null)
            {
                return new RestultDto { Code = 1, Msg = "已存在此用户" };
            }

            //密码、注册时间、末次登录时间
            dto.UserName = dto.UserName.Trim().ToUpper();
            dto.Password = Md5(dto.Password.Trim());
            dto.CreateTime = DateTime.Now;
            dto.LastLoginTime = null;

           baseService.Create(mapper.Map<Rbac.Entity.Admin>(dto));

            return new RestultDto { Code = 0, Msg = "注册成功" };
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="Pindex"></param>
        /// <param name="Psize"></param>
        /// <returns></returns>
        public Tuple<List<Rbac.Entity.Admin>, int> Page(int Pindex = 1, int Psize = 2)
        {
            var list = mapper.Map<List<Rbac.Entity.Admin>>(baseService.GetAll().OrderBy(s => s.AdminId).Skip((Pindex - 1) * Psize).Take(Psize).ToList());
            var count = baseService.GetAll().Count();
            return new Tuple<List<Rbac.Entity.Admin>, int>(list, count);
        }

    }
}
