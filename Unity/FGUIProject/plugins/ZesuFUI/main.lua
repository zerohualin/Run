--FYI: https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/XLua_Tutorial_EN.md

-- local genModelCode = require(PluginPath..'/NKG_GenerateModelCode')
local genModelCode = require(PluginPath..'/Zesu_GenerateModelCode')

function onPublish(handler)
    if handler.genCode then
        handler.genCode = false--这里关掉软件自身的生成代码工作
        genModelCode(handler)--生成所有Model代码
    else
        fprint("本次导出不生成代码")
    end
end