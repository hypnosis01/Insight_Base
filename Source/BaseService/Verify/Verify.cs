﻿using System;
using System.Linq;
using System.ServiceModel;
using Insight.WS.Base.Common;
using Insight.WS.Base.Common.Entity;
using static Insight.WS.Base.Common.Util;

namespace Insight.WS.Base.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class BaseService : Iverify
    {

        #region Verify

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult Verification()
        {
            return General.Verify();
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult Authorization(string action)
        {
            return General.Authorize(action);
        }

        #endregion

        #region SMSCode

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="type">验证类型</param>
        /// <param name="time">过期时间（分钟）</param>
        /// <returns>JsonResult</returns>
        public JsonResult NewCode(string mobile, int type, int time)
        {
            var result = General.Verify(mobile + Secret);
            if (!result.Successful) return result;

            var record = SmsCodes.OrderByDescending(r => r.CreateTime).FirstOrDefault(r => r.Mobile == mobile && r.Type == type);
            if (record != null && (DateTime.Now - record.CreateTime).TotalSeconds < 60) return result.TimeTooShort();

            var code = Util.Random.Next(100000, 999999).ToString();
            record = new VerifyRecord
            {
                Type = type,
                Mobile = mobile,
                Code = code,
                FailureTime = DateTime.Now.AddMinutes(time),
                CreateTime = DateTime.Now
            };
            SmsCodes.Add(record);
            return result.Success(code);
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="remove">是否验证成功后删除记录</param>
        /// <returns>JsonResult</returns>
        public JsonResult VerifyCode(string mobile, string code, int type, bool remove)
        {
            var result = General.Verify(mobile + Secret);
            if (!result.Successful) return result;

            SmsCodes.RemoveAll(c => c.FailureTime < DateTime.Now);
            var record = SmsCodes.FirstOrDefault(c => c.Mobile == mobile && c.Code == code && c.Type == type);
            if (record == null) return result.SMSCodeError();

            if (!remove) return result;

            SmsCodes.RemoveAll(c => c.Mobile == mobile && c.Type == type);
            return result;
        }

        #endregion

        #region Session

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetSessions()
        {
            var result = General.Authorize("331BF752-CDB7-44DE-9631-DF2605BB527E");
            if (!result.Successful) return result;

            var list = Sessions.Where(s => s.UserType > 0 && s.OnlineStatus).ToList();
            return result.Success(Serialize(list));
        }

        #endregion

    }
}
