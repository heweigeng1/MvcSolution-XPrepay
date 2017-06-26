namespace Xprepay.Data.Enums
{
    /**
     * 命名规范 EnumDelflag 为通用
     * EnumCommodityStatus 为Commodity表Status字段
     * **/
    public enum EnumDelflag : int
    {
        删除 = -1,
        正常 = 0,
    }
    public enum EnumMsgState : int
    {
        系统错误=-1,
        成功=0,
        失败=1,
        数据异常=2,
    }
    public enum EnumUserType : int
    {
        普通用户=0,
        后台管理员=1,
    }
    public enum EnumStatus : int
    {
        下架=0,
        上架=1
    }
    public enum EnumOrderStatus : int
    {
        已取消=-1,
        已下单=0,
        已统计=1,
    }
    public enum EnumErrorsType : int
    {
        商品异常=1,
        系统错误=2,
    }
}
