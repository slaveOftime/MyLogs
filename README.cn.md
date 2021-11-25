# MyLogs 

[English 👈](./README.md)

你可以用它来记录日志，学习笔记，简单的待办事项软件等。

![](./Assets/mylogs-on-window11.png)

![](./Assets/mylogs-change-color.gif)

![](./Assets/mylogs-basic-demo.cn.gif)

主要的想法是把每一个日志按天保存起来，并用最简单的文本格式，后缀为.md，以便于将来使用 VSCode 等可以编辑和阅读markdown文件的软件打开，当然用写字板也可以。

这样你就不用担心有一天这个软件停更了，甚至操作系统不兼容，而导致你不能正常的访问你过去宝贵的笔记。

数据格式如下：

```txt
# [我的日志]
- 标签：演示，演示2
- 计划：17:18:27
- 创建：11/24/2021 16:23:19 +08:00
- 修改：11/24/2021 17:18:31 +08:00
## 详情
演示内容
```


## 如何使用

### Windows

1. 从发布页面下载相应的 zip 包
2. 解压，并放于任何位置，双击运行 MyLogs.WPF.exe
3. 如果你的电脑没有预装 .net 6 desktop runtime 的话，程序会提醒你安装。另外如果你的电脑没有下载过 Microsoft Edge WebView2，程序会帮你自动下载。所以第一次启动可能会需要一点时间
4. 好运 😊

## 在不同设备分享

现在并不直接支持集成云盘账号，但是你可以在程序的配置里改变本地文件存储的位置来达到这个目的。比如，如果你用的是 onedrive，你可以配置文件夹到 C:\Users\\(your_name)\OneDrive\MyLogs


## 项目详情

1. MyLogs: 是基于 [Fun.Blazor](https://github.com/slaveOftime/Fun.Blazor) 的F#项目，包含主要的功能和界面逻辑
2. MyLogs.MAUI: 是微软跨平台项目，旨在将来支持 Mac, IOS, Android
3. MyLogs.WPF: 仅适配Windows桌面。因为目前 WinUI3 的一些限制，所以使用WPF还是比较好的方案，以后可能去除.
4. MyLogs.WPF.Package: 用于将 MyLogs.WPF 分发到 Windows 应用商店
