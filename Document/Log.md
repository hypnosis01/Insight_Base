# LogInfo数据结构

|数据类型|属性名称|描述|
| ------------ | ------------ | ------------ |
|string|Interface|日志接口Url *|
|TokenHelper|Token|AccessToken *|
|string|EventSource|系统日志事件源，写到系统日志时必填|
|EventLogEntryType|EventType|系统日志事件类型，默认Error|
|string|Code|事件代码，根据事件表编制 *|
|string|Source|事件源，见事件源表|
|string|Action|事件名称，见事件名称表|
|string|Message|事件消息，如日志规则已配置消息内容，可空|
|string|Key|查询关键词|
|Guid?|CreatorUserId|创建者用户ID|
\* 写到日志服务器时必填

# 事件代码结构

|日志等级代码|事件源代码|事件名称代码|
| ------------ | ------------ | ------------ |
|2(1位)|001(3位)|01(2位)|

# 日志等级

|代码|名称|描述|
| ------------ | ------------ | ------------ |
|0|Emergency|不能配置规则|
|1|Alert|不能配置规则|
|2|Critical||
|3|Error||
|4|Warning||
|5|Notice||
|6|Informational||
|7|Debug|不能配置规则|

# 事件源

|代码|事件源|描述|
| ------------ | ------------ | ------------ |
|001|系统平台||
|006|日志服务||

# 事件

|代码|事件名称|描述|
| ------------ | ------------ | ------------ |
|2|001|系统平台|
|01|SqlQuery||
|02|SqlNonQuery||
|03|SqlScalar||
|04|SqlExecute||
|05|SqlExecute||
|3|006|日志服务|
|01|新增规则|插入数据失败|
|02|删除规则|删除数据失败|
|03|编辑规则|更新数据失败|
|5|001|系统平台|
|01|接口验证||
|6|006|日志服务|
|01|新增规则||
|02|删除规则||
|03|编辑规则||
|7|001|系统平台|
|01|接口调用||
