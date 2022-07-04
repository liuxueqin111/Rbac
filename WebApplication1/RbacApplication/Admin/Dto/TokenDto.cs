using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Admin.Dto
{
    /// <summary>
    /// 继承
    /// </summary>
    public class TokenDto:RestultDto
    {
        /// <summary>
        /// JWT token
        /// </summary>
        public string Token { get; set; }
    }
}
