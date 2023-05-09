# NetifeSlientScript
NetifeSlientScript，`Netife`静默前端，后台自动执行插件、脚本；同时作为插件、脚本自运行依赖库。  
# Usage  
本软件为 `Netife Installer` 默认的 “脚本执行依赖库”，其作用对所有连接进行全部过滤，并重定向到 `Netife Dispatcher`，进行脚本和插件的修改处理，前端则不完成任何的处理工作。  
`NetifeSlientScript`可能会作为第三方插件、脚本的依赖库使用，如果你需要为插件和脚本指定最小化的运行流程，你可以仅对`NetifeSlientScript`进行打包。
# Config  
`NetifeSlientScript`无需人为配置，如果需要指定最小化插件和脚本包装，可以人为修改`config\core.json`分发。  
在`core.json`中，你可以指定以下的人为修改：  
- 在`autoInstallList`节点中，请添加你需要的插件或脚本的名称，并显式指定依赖关系。  
```json
    "autoInstallList":{
        "DESCRIPTION_EN":"THIS LIST IS ADDED BY THRID_PARTY INSTALLER FOR INSTALL EXTRA PLUGINS OR SCRIPT PROVIDING RELATIVE INFO",
        "DESCRIPTION_CN":"本列表为 第三方安装器 自动添加，用于安装额外软件时提供依赖说明",
        "lists":[
            {
                "demoPlugin":"1.0.0",
                "relativeCheck":"force"
            }
        ]
    }
```
其中，`relativeCheck`可为`soft`（若某依赖关系无法满足，仅提示用户但仍然完成工作）、`force`（强制为脚本进行依赖检查，如果依赖检查出错则抛出异常工作）和`common`（视插件依赖情况由软件自动决定依赖检查的结果）。  
- 在`relative`中，你可以显式指明工作环境：  
```json
"relative":{
        "dispatcher":{
            "version":"1.0.0",
            "type":"release"
        },
        "slientScript":{
            "version":"1.0.0",
            "type":"release",
            "relative":[
                {
                    "dispatcher":"^1.0.0|~2.0.0"
                }
            ]
        },
        "jsRemote":{
            "version":"1.0.0",
            "type":"dev"
        },
        "probe":{
            "version":"1.0.0",
            "type":"release"
        }
    }
```
