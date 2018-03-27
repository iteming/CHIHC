/*
Navicat SQL Server Data Transfer

Source Server         : SQL Server
Source Server Version : 105000
Source Host           : .:1433
Source Database       : CHIHCC_SHOOT
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 105000
File Encoding         : 65001

Date: 2018-03-27 23:28:40
*/


-- ----------------------------
-- Table structure for Bis_Coupon
-- ----------------------------
DROP TABLE [dbo].[Bis_Coupon]
GO
CREATE TABLE [dbo].[Bis_Coupon] (
[ID] nvarchar(40) NOT NULL ,
[RecordID] nvarchar(40) NULL ,
[UserID] nvarchar(40) NULL ,
[Coupon] nvarchar(100) NULL ,
[Status] int NULL ,
[ExpireDate] date NULL ,
[InsuranceName] varchar(40) NULL ,
[InsuranceIdCard] varchar(40) NULL ,
[InsurancePhone] varchar(40) NULL ,
[InsuranceSex] int NULL ,
[InsuranceAddress] varchar(40) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账户使用券'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账户使用券'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'使用券ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'使用券ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'UserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'UserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'UserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'Coupon')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'使用券'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'Coupon'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'使用券'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'Coupon'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'使用券状态（1.未使用，2.已使用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'使用券状态（1.未使用，2.已使用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'ExpireDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'使用券过期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'使用券过期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'InsuranceName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'参保人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'参保人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'InsuranceIdCard')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'参保人身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceIdCard'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'参保人身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceIdCard'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'InsurancePhone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'参保人手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsurancePhone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'参保人手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsurancePhone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Coupon', 
'COLUMN', N'InsuranceSex')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'参保人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceSex'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'参保人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Coupon'
, @level2type = 'COLUMN', @level2name = N'InsuranceSex'
GO

-- ----------------------------
-- Records of Bis_Coupon
-- ----------------------------

-- ----------------------------
-- Table structure for Bis_Gift
-- ----------------------------
DROP TABLE [dbo].[Bis_Gift]
GO
CREATE TABLE [dbo].[Bis_Gift] (
[GiftID] nvarchar(40) NOT NULL ,
[GiftName] nvarchar(50) NULL ,
[Price] decimal(18,4) NULL ,
[Description] nvarchar(200) NULL ,
[ExpireDate] date NULL ,
[ImgPath] nvarchar(255) NULL ,
[Type1Count] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'GiftID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'GiftID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'GiftID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'GiftName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'GiftName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'GiftName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'Price')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Price'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Price'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'ExpireDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包到期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包到期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'ImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包图片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包图片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Gift', 
'COLUMN', N'Type1Count')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N' 可选枪支数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Type1Count'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N' 可选枪支数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Gift'
, @level2type = 'COLUMN', @level2name = N'Type1Count'
GO

-- ----------------------------
-- Records of Bis_Gift
-- ----------------------------
INSERT INTO [dbo].[Bis_Gift] ([GiftID], [GiftName], [Price], [Description], [ExpireDate], [ImgPath], [Type1Count]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'300元体验包', N'.0100', N'包括10发子弹，2把指定枪械，枪支管理费，子弹费，保险费', null, N'/Images/Product/gift_03.png', N'2')
GO
GO
INSERT INTO [dbo].[Bis_Gift] ([GiftID], [GiftName], [Price], [Description], [ExpireDate], [ImgPath], [Type1Count]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'600元礼享包', N'.0200', N'包括20发子弹，2把指定枪械可挑选组合，枪支管理费，子弹费，保险费', null, N'/Images/Product/gift_06.png', N'2')
GO
GO
INSERT INTO [dbo].[Bis_Gift] ([GiftID], [GiftName], [Price], [Description], [ExpireDate], [ImgPath], [Type1Count]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e8e8', N'900元畅玩包', N'.0300', N'包括30发子弹，2把枪械可自由挑选组合，外加一把狙击步枪，共3把枪，枪支管理费，子弹费，保险费', null, N'/Images/Product/gift_09.png', N'3')
GO
GO
INSERT INTO [dbo].[Bis_Gift] ([GiftID], [GiftName], [Price], [Description], [ExpireDate], [ImgPath], [Type1Count]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e8e9', N'自由组合包', N'.0000', N'自由选择', N'2017-10-01', N'/Images/Product/gift_03.png', null)
GO
GO

-- ----------------------------
-- Table structure for Bis_GiftGood
-- ----------------------------
DROP TABLE [dbo].[Bis_GiftGood]
GO
CREATE TABLE [dbo].[Bis_GiftGood] (
[ID] nvarchar(40) NOT NULL ,
[GiftID] nvarchar(40) NULL ,
[GoodID] nvarchar(40) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_GiftGood', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'礼包商品关联'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_GiftGood'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'礼包商品关联'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_GiftGood'
GO

-- ----------------------------
-- Records of Bis_GiftGood
-- ----------------------------
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e812', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e812')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e813', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e821')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e814', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e831')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e815', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e832')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e816', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e833')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e817', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e841')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e818', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e811')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e819', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e812')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e820', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e813')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e821', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e822')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e822', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e831')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e823', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e832')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e824', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e833')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e825', N'07edfe47-593f-4bb4-99f6-402d94e0e8e7', N'07edfe47-593f-4bb4-99f6-402d94e0e841')
GO
GO
INSERT INTO [dbo].[Bis_GiftGood] ([ID], [GiftID], [GoodID]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e8e6', N'07edfe47-593f-4bb4-99f6-402d94e0e811')
GO
GO

-- ----------------------------
-- Table structure for Bis_Goods
-- ----------------------------
DROP TABLE [dbo].[Bis_Goods]
GO
CREATE TABLE [dbo].[Bis_Goods] (
[GoodID] nvarchar(40) NOT NULL ,
[GoodName] nvarchar(50) NULL ,
[Type] int NULL ,
[Price] decimal(18,4) NULL ,
[Description] nvarchar(200) NULL ,
[ExpireDate] date NULL ,
[ImgPath] nvarchar(255) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'GoodID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'GoodID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'GoodID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'GoodName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'GoodName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'GoodName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'类型（1.枪械，2.子弹，3.距离，4.保险）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'类型（1.枪械，2.子弹，3.距离，4.保险）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'Price')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Price'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Price'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'ExpireDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品到期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品到期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'ExpireDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Goods', 
'COLUMN', N'ImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品图片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品图片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Goods'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
GO

-- ----------------------------
-- Records of Bis_Goods
-- ----------------------------
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e811', N'枪械1', N'1', N'100.0000', N'手枪', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e812', N'枪械2', N'1', N'150.0000', N'机枪', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e813', N'枪械3', N'1', N'180.0000', N'冲锋枪', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e814', N'枪械4', N'1', N'300.0000', N'狙击枪', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e821', N'子弹10发', N'2', N'100.0000', N'10发', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e822', N'子弹20发', N'2', N'200.0000', N'20发', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e823', N'子弹30发', N'2', N'300.0000', N'30发', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e831', N'距离15米', N'3', N'.0000', N'15米', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e832', N'距离30米', N'3', N'.0000', N'30米', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e833', N'距离50米', N'3', N'.0000', N'50米', null, null)
GO
GO
INSERT INTO [dbo].[Bis_Goods] ([GoodID], [GoodName], [Type], [Price], [Description], [ExpireDate], [ImgPath]) VALUES (N'07edfe47-593f-4bb4-99f6-402d94e0e841', N'保险', N'4', N'50.0000', N'保险', null, null)
GO
GO

-- ----------------------------
-- Table structure for Bis_Record
-- ----------------------------
DROP TABLE [dbo].[Bis_Record]
GO
CREATE TABLE [dbo].[Bis_Record] (
[RecordID] nvarchar(40) NOT NULL ,
[AccountID] nvarchar(40) NULL ,
[UserID] nvarchar(40) NULL ,
[Type] int NULL ,
[Amount] decimal(18,4) NOT NULL ,
[Description] nvarchar(200) NULL ,
[CreateTime] datetime NULL DEFAULT (getdate()) ,
[UpdateTime] datetime NULL ,
[Status] int NULL ,
[OrderNo] nvarchar(255) NULL ,
[OtherOrderNum] nvarchar(255) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账户充值消费记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账户充值消费记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'RecordID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单记录ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'RecordID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单记录ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'RecordID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'AccountID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'AccountID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'AccountID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'UserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'UserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'UserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单类型（1.充值，2.消费）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单类型（1.充值，2.消费）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'Amount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'交易金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Amount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'交易金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Amount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单备注（购买哪类物品，购买物品单号/内容）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单备注（购买哪类物品，购买物品单号/内容）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单最后一次更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单最后一次更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单状态（1.未支付，2.已支付，3.退款中，4.已退款）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单状态（1.未支付，2.已支付，3.退款中，4.已退款）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'OrderNo')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'订单编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'OrderNo'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'订单编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'OrderNo'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_Record', 
'COLUMN', N'OtherOrderNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方订单编号(ex：微信单号，支付宝单号等等）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'OtherOrderNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方订单编号(ex：微信单号，支付宝单号等等）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_Record'
, @level2type = 'COLUMN', @level2name = N'OtherOrderNum'
GO

-- ----------------------------
-- Records of Bis_Record
-- ----------------------------

-- ----------------------------
-- Table structure for Bis_RecordDetail
-- ----------------------------
DROP TABLE [dbo].[Bis_RecordDetail]
GO
CREATE TABLE [dbo].[Bis_RecordDetail] (
[ID] nvarchar(40) NOT NULL ,
[RecordID] nvarchar(40) NULL ,
[GoodID] nvarchar(40) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_RecordDetail', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'消费记录明细'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'消费记录明细'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_RecordDetail', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'消费明细ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'消费明细ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_RecordDetail', 
'COLUMN', N'RecordID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'消费记录ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'RecordID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'消费记录ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'RecordID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_RecordDetail', 
'COLUMN', N'GoodID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'GoodID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_RecordDetail'
, @level2type = 'COLUMN', @level2name = N'GoodID'
GO

-- ----------------------------
-- Records of Bis_RecordDetail
-- ----------------------------

-- ----------------------------
-- Table structure for Bis_UserRank
-- ----------------------------
DROP TABLE [dbo].[Bis_UserRank]
GO
CREATE TABLE [dbo].[Bis_UserRank] (
[ID] nvarchar(40) NOT NULL ,
[UserID] nvarchar(40) NULL ,
[Score] decimal(18,4) NULL ,
[CreateTime] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_UserRank', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'成绩排行管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'成绩排行管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_UserRank', 
'COLUMN', N'UserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'UserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'UserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_UserRank', 
'COLUMN', N'Score')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户分数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'Score'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户分数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'Score'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Bis_UserRank', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'射击时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'射击时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Bis_UserRank'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO

-- ----------------------------
-- Records of Bis_UserRank
-- ----------------------------
INSERT INTO [dbo].[Bis_UserRank] ([ID], [UserID], [Score], [CreateTime]) VALUES (N'04ea996d-9a74-48cc-aa2d-324d5c628da8', N'91923dcf-d894-4fed-97c8-e0aac0681490', N'90.0000', N'2017-10-27 17:57:40.180')
GO
GO
INSERT INTO [dbo].[Bis_UserRank] ([ID], [UserID], [Score], [CreateTime]) VALUES (N'4319cc55-676d-4563-9868-81777bb611d2', N'91923dcf-d894-4fed-97c8-e0aac0681490', N'99.8000', N'2017-10-31 13:58:33.897')
GO
GO
INSERT INTO [dbo].[Bis_UserRank] ([ID], [UserID], [Score], [CreateTime]) VALUES (N'498653fc-04ac-4b19-8ae3-5ae55135e5c3', N'6243892d-b98d-40e0-845a-6076fc6b1934', N'99.0000', N'2017-10-27 18:09:04.240')
GO
GO
INSERT INTO [dbo].[Bis_UserRank] ([ID], [UserID], [Score], [CreateTime]) VALUES (N'498653fc-04ac-4b19-8ae3-5ae55135e5c4', N'6e22837f-a6eb-441b-a06a-46b028d9d371', N'70.0000', N'2017-10-25 18:09:04.240')
GO
GO
INSERT INTO [dbo].[Bis_UserRank] ([ID], [UserID], [Score], [CreateTime]) VALUES (N'498653fc-04ac-4b19-8ae3-5ae55135e5c5', N'45581e66-d858-4f89-a724-4740fc030fc3', N'88.0000', N'2017-10-25 18:09:04.240')
GO
GO

-- ----------------------------
-- Table structure for Sys_Code
-- ----------------------------
DROP TABLE [dbo].[Sys_Code]
GO
CREATE TABLE [dbo].[Sys_Code] (
[ID] nvarchar(40) NOT NULL ,
[TelePhone] nvarchar(40) NULL ,
[Code] nvarchar(40) NULL ,
[CreateTime] datetime NULL ,
[Remark] nvarchar(200) NULL ,
[Invalid] bit NULL ,
[CodeType] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'验证码ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'验证码ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'TelePhone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'接收验证码的手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'TelePhone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'接收验证码的手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'TelePhone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'Code')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'验证码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Code'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'验证码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Code'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间（有效5分钟）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间（有效5分钟）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'Remark')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Remark'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Remark'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'Invalid')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否失效：0 有效，1 失效'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Invalid'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否失效：0 有效，1 失效'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'Invalid'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_Code', 
'COLUMN', N'CodeType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'验证码类型：1 录入成绩，2 退款申请'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'CodeType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'验证码类型：1 录入成绩，2 退款申请'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_Code'
, @level2type = 'COLUMN', @level2name = N'CodeType'
GO

-- ----------------------------
-- Records of Sys_Code
-- ----------------------------

-- ----------------------------
-- Table structure for Sys_User
-- ----------------------------
DROP TABLE [dbo].[Sys_User]
GO
CREATE TABLE [dbo].[Sys_User] (
[UserID] nvarchar(40) NOT NULL ,
[UserName] nvarchar(40) NULL ,
[IdCard] nvarchar(40) NULL ,
[TelePhone] nvarchar(40) NULL ,
[Password] nvarchar(40) NULL ,
[WeiXin_Openid] nvarchar(40) NULL ,
[QQ_Openid] nvarchar(40) NULL ,
[CreateTime] datetime NULL DEFAULT (getdate()) ,
[IsSuper] bit NULL DEFAULT ((0)) ,
[HeaderUrl] varchar(255) NULL ,
[Sex] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'UserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'UserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'UserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'IdCard')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'IdCard'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'IdCard'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'TelePhone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'TelePhone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'TelePhone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'Password')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'Password'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'Password'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'WeiXin_Openid')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'微信帐号的openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'WeiXin_Openid'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'微信帐号的openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'WeiXin_Openid'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'QQ_Openid')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'QQ帐号的openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'QQ_Openid'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'QQ帐号的openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'QQ_Openid'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'IsSuper')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否超级管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'IsSuper'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否超级管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'IsSuper'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'HeaderUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'头像'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'HeaderUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'头像'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'HeaderUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_User', 
'COLUMN', N'Sex')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'性别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'Sex'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'性别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_User'
, @level2type = 'COLUMN', @level2name = N'Sex'
GO

-- ----------------------------
-- Records of Sys_User
-- ----------------------------
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'3edade34-a558-4786-a334-78484b611976', N'Maybe丶True', null, null, null, N'opHry0pTHEF1jlOAUu19p_BZK_Vk', null, N'2017-10-28 10:07:41.523', null, N'http://wx.qlogo.cn/mmhead/FK7bODrvXY9OVewvobqBe554AnaGm5qSib1UFVhiaMLok/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'45581e66-d858-4f89-a724-4740fc030fc3', N'五月麻麻', N'130481198811293173', N'18755555555', N'', N'opHry0hcGAVOPEEWJzcq9z4ZACRM', N'', N'2017-10-25 16:25:13.000', null, N'http://wx.qlogo.cn/mmhead/qUUWt96FwTf5gIr3sYZsLicbBrmOCmARTnRQJsQJZL3U/0', N'2')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'4bac4c1e-57b9-470f-be11-37cb612d19db', N'南琦www.my2space.com', null, null, null, N'opHry0jRvgWvPe_ylqSaFxq8ATcw', null, N'2017-10-27 22:32:28.413', null, N'http://wx.qlogo.cn/mmhead/Q3auHgzwzM5ibO96MmBZ5j4CNmpvCDEd98dd8ibVqGqfocffsibmSib3uQ/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'4d16847a-2a99-44ae-ac41-71b3f4ecaaf0', N'ζ__小╮侽亽。', null, null, null, N'opHry0iQGHXoDUXl30iSA0PBB4aw', null, N'2017-10-27 21:26:49.110', null, N'http://wx.qlogo.cn/mmhead/Q3auHgzwzM6oXSKO7bc1VJSUNAWLZpN9IdkicDz6xI57C2J2XbUMqxg/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'6243892d-b98d-40e0-845a-6076fc6b1934', N'海格力斯皮袋 º', null, null, null, N'opHry0r22bl3c8uYOA-tbwVc8yOc', N'', N'2017-10-25 16:23:41.000', null, N'http://wx.qlogo.cn/mmhead/LIUI5tJGiauBbVt4TBkzJeYrGrSNjiaCV6qthBqQIt6DlEBCJEqFEPJA/0', N'2')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'6e22837f-a6eb-441b-a06a-46b028d9d371', N'许多鱼', N'612129198109095227', N'13399282294', N'', N'opHry0tJbEUSRLvlPPMR3brGpp-k', N'', N'2017-10-26 17:41:04.000', null, N'http://wx.qlogo.cn/mmhead/DYAIOgq83epUnAGZ8SWS9TAiaLrHPMOcSumcfDrAcdhkRtDpTbvOaDg/0', N'2')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'91923dcf-d894-4fed-97c8-e0aac0681490', N'猫小镇', N'130481198811293173', N'13609245992', N'', N'opHry0gMQZ9pR5r95VSd_Ul7PyvE', N'', N'2017-10-25 11:20:56.000', null, N'http://wx.qlogo.cn/mmhead/Q3auHgzwzM4WBAgff7vgGKS2QIPJoHRK8NxhCbZYz9iaZwM1mKlicT3A/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'afd274fc-eb96-491d-b157-dcf3779ac9a9', N'左奇', null, null, null, N'opHry0kkiZLb1WiD8Oypfv_3Pg50', null, N'2017-10-28 10:23:04.617', null, N'http://wx.qlogo.cn/mmhead/iaRlzG8zy7BuKgmbPm6Rk9V2OOUmCvtVg47H3qZaA0dXEj3A9rkS9HA/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'e2dca6bc-6912-495c-b666-a25d7bf0b1df', N'泰戈卜', null, null, null, N'opHry0u1zEUik0EXEQKmbSUvpUsg', null, N'2017-10-27 21:24:19.340', null, N'http://wx.qlogo.cn/mmhead/PiajxSqBRaEI595B8icwXW77jZz4je1qSzPZn6fglnbVCvvJDaO0kDYg/0', N'1')
GO
GO
INSERT INTO [dbo].[Sys_User] ([UserID], [UserName], [IdCard], [TelePhone], [Password], [WeiXin_Openid], [QQ_Openid], [CreateTime], [IsSuper], [HeaderUrl], [Sex]) VALUES (N'f496712e-5e1e-4dda-8f4e-eb986ba8e862', N'末日喧嚣', null, null, null, N'opHry0kYQ5e-hpSIULUHSbbMYPss', null, N'2017-10-28 17:13:32.210', null, N'http://wx.qlogo.cn/mmhead/6t0VDe9bl5eSvbJxHlEvPereh5nxY8xxsicO6JRw68JwBjmVISowjtg/0', N'2')
GO
GO

-- ----------------------------
-- Table structure for Sys_UserAccount
-- ----------------------------
DROP TABLE [dbo].[Sys_UserAccount]
GO
CREATE TABLE [dbo].[Sys_UserAccount] (
[AccountID] nvarchar(40) NOT NULL ,
[UserID] nvarchar(40) NULL ,
[Balance] decimal(18,4) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_UserAccount', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户账户管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户账户管理'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_UserAccount', 
'COLUMN', N'AccountID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'AccountID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'AccountID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_UserAccount', 
'COLUMN', N'UserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'UserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'UserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Sys_UserAccount', 
'COLUMN', N'Balance')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账户余额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'Balance'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账户余额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Sys_UserAccount'
, @level2type = 'COLUMN', @level2name = N'Balance'
GO

-- ----------------------------
-- Records of Sys_UserAccount
-- ----------------------------
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'01c7219f-274a-407e-bf98-eb0354391871', N'a5dd8c07-aef2-4b8e-abad-bff42edbe644', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'0b8e4500-daf7-4447-8a2a-ddfc8dec49cd', N'91923dcf-d894-4fed-97c8-e0aac0681490', N'.0100')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'10cab578-fc79-40b3-ac35-6322896219bd', N'6e22837f-a6eb-441b-a06a-46b028d9d371', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'41f0dac4-38d8-402c-90bc-530f78516798', N'88f09058-8a47-4cb9-91dd-5935206ce31f', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'5bfc952a-19f5-48f7-8438-48cec838affa', N'45581e66-d858-4f89-a724-4740fc030fc3', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'9995d05b-47c7-40b3-92b1-f95f0c7ede7e', N'f496712e-5e1e-4dda-8f4e-eb986ba8e862', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'9a8f16ea-2120-4302-9d7e-3da22e7b584b', N'e2dca6bc-6912-495c-b666-a25d7bf0b1df', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'a7caf77b-0563-4065-9f5f-3d3a354caf3f', N'0dceb75d-82d5-4d6c-aa84-2fb2636d5f2d', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'afa840b3-aeca-4844-a5ee-720b755c581d', N'afd274fc-eb96-491d-b157-dcf3779ac9a9', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'c7fc81df-3d19-405d-8578-7b48a50355eb', N'4bac4c1e-57b9-470f-be11-37cb612d19db', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'ddc56daa-a09c-4b87-be7d-a5ae16766588', N'4d16847a-2a99-44ae-ac41-71b3f4ecaaf0', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'e0cd397c-5573-4e88-817d-347f271c3f65', N'd22ab61c-d35d-478f-bc54-26dbb694013b', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'e96ef55c-2ffd-43b9-b2f7-5c8016e4df1f', N'41e3c0fe-bcd6-4227-86d1-088c6169eefa', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'ebca88df-7194-4b0e-8d75-8cfb6fed98ab', N'3edade34-a558-4786-a334-78484b611976', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'ec43585d-b81a-4c93-b6a9-b4b2a475d2ba', N'b2a2c35c-43c9-4b5b-9693-0f3263ee00aa', N'.0000')
GO
GO
INSERT INTO [dbo].[Sys_UserAccount] ([AccountID], [UserID], [Balance]) VALUES (N'ed8bc02b-b964-499f-b575-0bcad6869d43', N'6243892d-b98d-40e0-845a-6076fc6b1934', N'.0000')
GO
GO

-- ----------------------------
-- Indexes structure for table Bis_Coupon
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_Coupon
-- ----------------------------
ALTER TABLE [dbo].[Bis_Coupon] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Bis_Gift
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_Gift
-- ----------------------------
ALTER TABLE [dbo].[Bis_Gift] ADD PRIMARY KEY ([GiftID])
GO

-- ----------------------------
-- Indexes structure for table Bis_GiftGood
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_GiftGood
-- ----------------------------
ALTER TABLE [dbo].[Bis_GiftGood] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Bis_Goods
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_Goods
-- ----------------------------
ALTER TABLE [dbo].[Bis_Goods] ADD PRIMARY KEY ([GoodID])
GO

-- ----------------------------
-- Indexes structure for table Bis_Record
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_Record
-- ----------------------------
ALTER TABLE [dbo].[Bis_Record] ADD PRIMARY KEY ([RecordID])
GO

-- ----------------------------
-- Indexes structure for table Bis_RecordDetail
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_RecordDetail
-- ----------------------------
ALTER TABLE [dbo].[Bis_RecordDetail] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Bis_UserRank
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bis_UserRank
-- ----------------------------
ALTER TABLE [dbo].[Bis_UserRank] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Sys_Code
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_Code
-- ----------------------------
ALTER TABLE [dbo].[Sys_Code] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Sys_User
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_User
-- ----------------------------
ALTER TABLE [dbo].[Sys_User] ADD PRIMARY KEY ([UserID])
GO

-- ----------------------------
-- Indexes structure for table Sys_UserAccount
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Sys_UserAccount
-- ----------------------------
ALTER TABLE [dbo].[Sys_UserAccount] ADD PRIMARY KEY ([AccountID])
GO
