namespace ET.Server
{
    public enum AccountType
    {
        General = 0,
        BlackList = 1//处于黑名单，禁止连接
    }
    
    [ChildOf()]
    public class AccountDB : Entity, IAwake, IDestroy
    {
        public string Account;//账户名
        public string Password;//账户密码
        public long CreateTime;//创建时间
        public int AccountType;//账号类型
    }
}