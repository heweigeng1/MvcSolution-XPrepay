# 介绍

本项目是mvcsolution框架的分支.

**原项目地址:[https://github.com/leotsai/mvcsolution/](https://github.com/leotsai/mvcsolution/)**

现在项目增加了一个分支 antd-pro ,主要是后台使用了单页面框架.react 的antd-pro 后台管理UI框架.

## 跟原项目的区别

- autompper--映射组件
- FluentValidation--校验组件
- layui--后台模版
- light7--mobile模版
- webapi
- mobile--移动网站
- T4模板

## 开发环境

* IDE:    **VS2015,VS2017**
* NET Version: **4.5**
* MVC Version: **5.2**
* ORM: **Entity Framework 6.1**
* Json Serialization: **Newtonsoft 8.0.1**
* Unit Tests: **NUnit 2.5.10**

## 默认登录帐号

请查看**Xprepay.Data**下的初始化类**Init**;

## 初学者学习指南

- MVC基础
- EF基础
- code frist
- linq 与 lambda表达式
- 了解IOC
- 阅读Mvcsolution项目的资料

## 提示

* 不能右键添加控制器
* 不能在控制器右键跳转到视图
* Management是给后台单页面程序提供接口的.如果是用主线的开发方式,无视这个项目即可.
* 在分支antd-pro 里实现了jwt授权验证.如果你需要jwt可以把那个实现复制过来即可.

## 将来

* 将日志系统改为log4net(主线和分支都实现了)
* 后台修改为ng 或者vue,react框架的UI(在antd-pro 分支已经使用react的antd-pro)
* 权限 是否改为微软的Identity组件,还在思考
* 升级为.net core版本
* 微信开发的一些类库
* 支付的demo

## 最后

如果您也有兴趣参与或使用这个项目,请加QQ群:539301714

## 最新情况

2018/6/6 
添加swagger 插件(生成接口文档的工具)
微信移动支付的统一下单接口,与微信回调接口.

目前正在准备改版,将使用react 的前端框架[Ant Design Pro阿里系](https://pro.ant.design/),(已经实现)

日志系统改为log4net.(已经实现)

文档分支
