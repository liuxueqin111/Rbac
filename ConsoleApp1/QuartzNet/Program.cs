using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
namespace QuartzNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1,创建调度器
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            //2.创建job

            //3.创建jobdetail
            var jobdetail = JobBuilder.Create<MyJob>().WithIdentity("myjob").Build();

            //4.创建触发器
            var trigger = TriggerBuilder.Create().WithSimpleSchedule(build =>
              {
                  build.WithInterval(TimeSpan.FromSeconds(3)).WithRepeatCount(10);
              }).Build();

            //5.通过调度器调度作业执行
           await scheduler.ScheduleJob(jobdetail, trigger);
           await scheduler.Start();

            Console.ReadLine();
        }
    }
    /// <summary>
    /// 2.创建job
    /// </summary>
    public class MyJob:IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
