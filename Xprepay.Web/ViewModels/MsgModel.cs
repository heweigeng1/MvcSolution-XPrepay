using FluentValidation.Results;
using System.Collections.Generic;
using Xprepay.Data.Enums;

namespace Xprepay.Web.ViewModels
{
    public class MsgModel
    {
        public MsgModel() { }
        public MsgModel(ValidationResult result)
        {
            if (!result.IsValid)
            {
                this.Msg = "数据格式不正确!";
                this.State = (int)EnumMsgState.数据异常;
                this.Errors = result.Errors;
            }
        }
        public MsgModel(bool b)
        {
            if (b)
            {
                Msg = "操作成功" ;
                State = (int)EnumMsgState.成功;
            }
            else
            {
                Msg = "操作失败";
                State = (int)EnumMsgState.失败;
            }
        }
        public string Msg { get; set; } 
        public int State { get; set; } 
        public string Url { get; set; }
        public IList<ValidationFailure> Errors { get; }
    }
    public class MsgModel<T>:MsgModel
    {
        public T Data { get; set; }
    }
}
