--FYI: https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/XLua_Tutorial_EN.md

-- local genModelCode = require(PluginPath..'/NKG_GenerateModelCode')
local genHotfixCode = require(PluginPath..'/Zesu_GenerateHotfixCode')

function onPublish(handler)
    if handler.genCode then
        handler.genCode = false--这里关掉软件自身的生成代码工作
        genHotfixCode(handler)
        fprint("使用 Zeus插件生成 ET 代码完成")
    else
        fprint("本次导出不生成代码")
    end
end