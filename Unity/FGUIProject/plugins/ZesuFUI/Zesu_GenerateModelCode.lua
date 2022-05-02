--FYI: https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/XLua_Tutorial_EN.md
local handler = nil
local settings = nil
local namespaceName = nil
local exportCodePath = nil
local hotfixCodePath = nil
local codePkgName = nil
local getMemberByName = nil

local writer = nil
local customComponentFlagsArray = nil
local crossPackageFlagsArray = nil
local classCnt = 0
local classes = nil
local classInfo = nil
local members = nil
local enumName = nil

local childCustomComs = {}

local function genHotfixCode()
    local path = hotfixCodePath .. classInfo.className .. 'System.cs'
    local file, err = io.open(path)
    if not file then
        fprint("使用 Zeus 插件生成 ComponentSystem 代码" .. path)
        local hotfixWriter = CodeWriter.new()
        hotfixWriter:writeln('using Cfg;')
        hotfixWriter:writeln('namespace ET')
        hotfixWriter:startBlock()

        --静态方法部分
        hotfixWriter:writeln('public static class %sSystem', classInfo.className)
        hotfixWriter:startBlock()
            hotfixWriter:writeln('public static void Awake(this %s self)', classInfo.className)
            hotfixWriter:startBlock()
            hotfixWriter:endBlock()
        hotfixWriter:endBlock()

        hotfixWriter:writeln()

        --Event部分
        hotfixWriter:writeln('[FGUIEvent(FGUIType.%s)]', enumName)
        hotfixWriter:writeln('[FriendClass(typeof(%s))]', classInfo.className)
        for key, value in pairs(childCustomComs) do      
            hotfixWriter:writeln('[FriendClass(typeof(%s))]', value)
        end
        hotfixWriter:writeln('public class %sEvent: FGUIEvent<%s>', classInfo.className, classInfo.className)
        hotfixWriter:startBlock()
            hotfixWriter:writeln('public override void OnCreate(%s component){}', classInfo.className)
            hotfixWriter:writeln('public override void OnShow(%s component){}', classInfo.className)
            hotfixWriter:writeln('public override void OnRefresh(%s component){}', classInfo.className)
            hotfixWriter:writeln('public override void OnHide(%s component){}', classInfo.className)
            hotfixWriter:writeln('public override void OnDestroy(%s component){}', classInfo.className)
        hotfixWriter:endBlock()
        hotfixWriter:endBlock()
        hotfixWriter:save(path)
    else
        fprint("已存在该代码" .. path)
        io.close(file)
    end
end

local function generateMember(j)
    local memberInfo = members[j]
    childCustomComs = {}
    customComponentFlagsArray[j] = false
    crossPackageFlagsArray[j] = false

    -- 判断是不是我们自定义类型组件
    local typeName = memberInfo.type
    for k = 0, classCnt - 1 
    do
        if typeName == classes[k].className 
        then
            customComponentFlagsArray[j] = true
            break
        end
    end

    -- 判断是不是跨包类型组件
    if memberInfo.res ~= nil then
        typeName = memberInfo.res.name
        crossPackageFlagsArray[j] = true
    end

    if not customComponentFlagsArray[j] and not crossPackageFlagsArray[j] then
        writer:writeln('[FGUIObject]')
    else
        writer:writeln('[FGUICustomCom]')
        table.insert(childCustomComs, typeName)
    end
    writer:writeln('public %s %s;', typeName, memberInfo.varName)
end

local function generateMembers()
    writer:writeln('[FGUISelfObjectAttribute]')
    writer:writeln('public %s self;', classInfo.superClassName)
    writer:writeln()

    customComponentFlagsArray = {}
    crossPackageFlagsArray = {}

    members = classInfo.members
    local memberCnt = members.Count
    for j = 0, memberCnt - 1 do
        generateMember(j)
    end
end

local function generateClass()
    writer:reset()
    writer:writeln('using FairyGUI;')
    writer:writeln('namespace %s', namespaceName)
    writer:startBlock()
        local isCusCom = string.match(classInfo.className, "_Component")
        if isCusCom then
            enumName = string.gsub(classInfo.className, "_Component", "")
            enumName = string.gsub(enumName, "FUI_", "")
            writer:writeln('[FGUIComponent(Cfg.FGUIType.%s)]', enumName)
        end
        writer:writeln('public sealed class %s : Entity, IFGUIComponent', classInfo.className)
        writer:startBlock()
            writer:writeln('public const string UIPackageName = "%s";', codePkgName)
            writer:writeln('public const string UIResName = "%s";', classInfo.resName)
            writer:writeln('public const string URL = "ui://%s%s";', handler.pkg.id, classInfo.resId)
            writer:writeln()
            writer:writeln('public string GetAddressablePath() { return $"{UIPackageName}_fui"; }')
            writer:writeln()
            writer:writeln('public string GetPackageName() { return UIPackageName; }')
            writer:writeln()
            writer:writeln('public string GetComponentName() { return UIResName; }')
            writer:writeln()
            --生成全部的成员
            generateMembers()
        writer:endBlock()
    writer:endBlock()

    local savePath = exportCodePath .. classInfo.className .. '.cs'
    fprint(savePath)
    writer:save(savePath)

    if isCusCom then
        genHotfixCode()--初次生成ComponentSystem代码
    end
end

local function genModelCode(h)
    handler = h
    settings = handler.project:GetSettings("Publish").codeGeneration

    codePkgName = handler:ToFilename(handler.pkg.name) --convert chinese to pinyin, remove special chars etc.
    namespaceName = settings.packageName

    hotfixCodePath = handler.exportCodePath .. '/HotfixView/' .. codePkgName .. '/FUI/System/'
    exportCodePath = handler.exportCodePath .. '/ModelView/' .. codePkgName .. '/FUI/Generate/'

    classes = handler:CollectClasses(settings.ignoreNoname, settings.ignoreNoname, nil)

    handler:SetupCodeFolder(exportCodePath, "cs") --check if target folder exists, and delete old files

    getMemberByName = settings.getMemberByName

    classCnt = classes.Count
    writer = CodeWriter.new()

    for i = 0, classCnt - 1 do
        classInfo = classes[i]
        generateClass()
    end
end

return genModelCode