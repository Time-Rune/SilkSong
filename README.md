# Sliksong —— 项目企划



## 任务总览

- 类型：2D RPG 使用金币升级

- **地图：大幅减少流程，减少难度 （整体重新设计）**

	**据点 —— 可以购买装备，升级，学习技能，认识NPC，NO支线，仅主线**

	**流程简介：新手指导 -> 新手村 -> 刷刷刷 -> Boss房**

- 功能：添加退出键，更改键位

- 操作：优化上劈下劈手感 （更容易按出来）

- **能力：简化，可以加入远程攻击，远程更安全，但是伤害更低**

- **加入升级：生命 / 攻击力 / 魂量 ｜ 升级后可以学习新技能**

- 美术：外包 or 使用现有素材 （参考宣传片）

- 音效：基本不用改 / 背景bgm可以改

- 剧情：加入文本，加入新的NPC，加入对话系统（对话框 or 头顶），写一个故事

	播片：前面加一点，boss战加一点，结局加一点

- 游戏：~~加入开场动画~~ / 结束动画



## 日程安排

Week1:  

- 读懂GitHub项目流程
- 继续学习课程
- 制作最早的Demo（地图+build）

- # 更新日志
## 7.10
### 待办 
* 改键(待商量)
* 待更新
### 正在处理
* 待更新(成员名)
### 已办
* 待更新

## 游戏的名字

- ? silk
- silk ?

## 另一个地方

- 打完小boss , 掉落一个 二段跳
- 回血 是 初始技能
- 普通攻击 可以 击落子弹
- 斜下冲刺是无敌的.

## 核心机制

- 打怪 掉落 经验条 & 金币
- 升级 给 点数
- build 强身健体 消耗 点数 ---> 在凳子上
  - 血量 HP
  - 蓝条 Silk
  - 攻击力 Attack
- skill tree 技能树 消耗 金币 ---> 在村庄 的 teacher处
- 击败最终Boss => 获得胜利

## 技能树

- 分支1 : 冲刺
  - ​                \\=> 冲刺无敌帧  => 冲刺伤害
  - ​                \\=> 二段冲刺
  - ​                \\=> 冲刺距离
- 分支2 : 攻击
  - ​                \\=> 攻击距离
  - ​                \\=> 攻击速度
  - ​                \\=> 剑气
- 分支3 : 特殊技能
  - ​                \\=> 向前扔针
  - ​                \\=> 范围AOE
  - ​                \\=> 向下 钻 (四声)
  - ## Skill tree

- branch1 : dash
  - ​                \\=> dash with no damage from enemy => dash to damage enemy
  - ​                \\=> twice dash
  - ​                \\=> dash distance
- branch2 : attack
  - ​                \\=> attack distance
  - ​                \\=> attack frequency
  - ​                \\=> attack with far damage
- 分支3 : 特殊技能
  - ​                \\=> Throw needle to attack enemies in a line
  - ​                \\=> a large AOE damage
  - ​                \\=> attack enemies below for times




