using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NbSites.Web.Demo.Configs
{
    [Route("Api/Demo/FooOptions/[action]")]
    public class FooOptionsApiController : ControllerBase
    {
        /// <summary>
        /// 检测状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string CheckStatus()
        {
            return this.GetType().FullName + " => " + DateTime.Now;
        }

        /// <summary>
        /// 查看配置数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FooOptions GetOptions([FromServices] IOptionsSnapshot<FooOptions> optionsSnapshot)
        {
            return optionsSnapshot.Value;
        }

        /// <summary>
        /// 查看配置数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FooOptions GetOptions2([FromServices] IOptions<FooOptions> options)
        {
            //not change immediately!
            return options.Value;
        }

        /// <summary>
        /// 查看配置数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FooOptions GetOptions3([FromServices] IConfiguration config)
        {
            //bind by hand when use in app code
            var theOptions = new FooOptions();
            config.GetSection(FooOptions.SectionName).Bind(theOptions);
            return theOptions;
        }

        /// <summary>
        /// 查看配置数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FooOptions GetOptions4([FromServices] FooOptions options)
        {
            return options;
        }
        
        /// <summary>
        /// 设置是否启用
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        [HttpGet("SetEnabled")]
        public string SetEnabled(bool enabled)
        {
            return "todo";
        }
    }
}
