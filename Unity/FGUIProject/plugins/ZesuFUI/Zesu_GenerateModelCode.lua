--FYI: https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/XLua_Tutorial_EN.md

fprint('Use fprint to output to console')

function onPublish(handler)
    if not handler.genCode then 
        handler.genCode = false
        genHotfixCode(handler)
		fprint("使用NKG插件生成ET Hotfix代码完成")
    else
        handler.genCode = false
        genModelCode(handler)
		fprint("使用NKG插件生成ET Model层代码完成")
    end
    fprint("使用NKG插件生成ET Hotfix代码完成")
end