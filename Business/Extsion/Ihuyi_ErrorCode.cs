using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extsion
{
    public class Ihuyi_ErrorCode
    {
        public static string GetErrorMessage(int code)
        {
            switch (code) {
                case 0:return "位置错误";
                case 1:return "提交成功";
                case 1000: return "无此操作类型(action为空或不存在)";
                case 1001: return "API ID为空";
                case 1002: return "API ID错误";
                case 1003: return "手机号码为空";
                case 1004: return "手机号码为空";
                case 1005: return "套餐不能为空";
                case 1006: return "时间戳不能为空";
                case 1007: return "不存在的套餐";
                case 1008: return "签名不能为空";
                case 1009: return "签名错误";
                case 1010: return "签名过期";
                case 1011: return "账号被冻结";
                case 1012: return "余额不足";
                case 1013: return "访问ip与备案ip不相同";
                case 1014: return "订单ID不能为空";
                case 1015: return "订单ID已存在";
                case 2001: return "不支持的手机号码";
                case 2002: return "手机号码已加入黑名单";
                case 2003: return "不支持的地区";
                case 3001: return "扣费失败";
                case 4001: return "系统内部故障";
            }
         
            return "未知错误";
        }
    }
}
