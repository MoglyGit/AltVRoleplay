/*
Navicat MySQL Data Transfer

Source Server         : V-Server
Source Server Version : 50742
Source Host           : 93.90.205.242:3306
Source Database       : GtaV

Target Server Type    : MYSQL
Target Server Version : 50742
File Encoding         : 65001

Date: 2024-04-16 22:25:09
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `accounts`
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `socialclubid` bigint(11) unsigned NOT NULL,
  `money` int(11) DEFAULT '0',
  `adminlevel` tinyint(4) DEFAULT '0',
  `password` varchar(1000) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL,
  `x` float DEFAULT '-1660',
  `y` float DEFAULT '-952',
  `z` float DEFAULT '7',
  `r` float DEFAULT '0',
  `sex` tinyint(1) DEFAULT '3',
  `dimension` int(11) DEFAULT '0',
  `head` varchar(500) DEFAULT '0',
  `face` varchar(255) DEFAULT '0',
  `haircolor` tinyint(4) DEFAULT '0',
  `hairtint` tinyint(4) DEFAULT '0',
  `eyecolor` int(11) DEFAULT '0',
  `overlay` varchar(255) DEFAULT '0',
  `fname` varchar(16) DEFAULT 'test',
  `lname` varchar(16) DEFAULT 'test',
  `age` varchar(50) DEFAULT '0',
  `height` int(11) DEFAULT '0',
  `armour` int(11) DEFAULT '0',
  `health` int(11) DEFAULT '200',
  `mask` int(11) DEFAULT '-1',
  `top` int(11) DEFAULT '-1',
  `under` int(11) DEFAULT '-1',
  `legs` int(11) DEFAULT '-1',
  `shoes` int(11) DEFAULT '-1',
  `acces` int(11) DEFAULT '-1',
  `hair` int(11) DEFAULT '0',
  `torso` int(11) DEFAULT '15',
  `hats` int(11) DEFAULT '0',
  `glasses` int(11) DEFAULT '0',
  `ears` int(11) DEFAULT '0',
  `watches` int(11) DEFAULT '0',
  `bracelets` int(11) DEFAULT '0',
  `drivingtheory` int(11) DEFAULT '0',
  `drivingtheorywait` int(11) DEFAULT '0',
  `drivinglicens` int(11) DEFAULT '0',
  `drivingpickup` int(11) DEFAULT '0',
  `bank` int(11) DEFAULT '0',
  `banktype` int(11) DEFAULT '0',
  `kredit` int(11) DEFAULT '0',
  `kreditpayback` int(11) DEFAULT '0',
  `payday` int(11) DEFAULT '0',
  `paydaymoney` int(11) DEFAULT '0',
  `kraftlevel` int(11) DEFAULT '0',
  `kraftskill` int(11) DEFAULT '0',
  `bergbau` int(11) DEFAULT '0',
  `bergbaucd` int(11) DEFAULT '0',
  `faction` int(11) DEFAULT '0',
  `rank` int(11) DEFAULT '0',
  `duty` int(11) DEFAULT '0',
  `pizzajob` int(11) DEFAULT '0',
  `mowerjob` int(11) DEFAULT '0',
  `graveljob` int(11) DEFAULT '0',
  `lumberjob` int(11) DEFAULT '0',
  `thirst` int(11) DEFAULT NULL,
  `hunger` int(11) DEFAULT NULL,
  `harn` int(11) DEFAULT NULL,
  `happy` int(11) DEFAULT NULL,
  PRIMARY KEY (`socialclubid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES ('1', '1089', '3', 'password', '-1998.42', '4628.08', '-0.444312', '2.96843', '0', '0', '44|10|0|23|25|0|0.2|0.5|0|', '0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|', '15', '34', '9', '255|0|0|0|0|14|1|1|13|0|18|1|1|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|255|0|0|0|0|', 'Naruto', 'Uzumaki', '16.1.1974', '189', '0', '115', '-1', '1668', '0', '1666', '1667', '-1', '32', '5', '0', '0', '0', '1701', '0', '2', '0', '0', '0', '27619', '1', '2', '600', '355', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '149', '0');

-- ----------------------------
-- Table structure for `appartment`
-- ----------------------------
DROP TABLE IF EXISTS `appartment`;
CREATE TABLE `appartment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `posx` float DEFAULT NULL,
  `posy` float DEFAULT NULL,
  `posz` float DEFAULT NULL,
  `interrior` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `rent` int(11) DEFAULT NULL,
  `owner` varchar(255) DEFAULT NULL,
  `owned` int(11) DEFAULT NULL,
  `open` int(11) DEFAULT NULL,
  `mintime` int(11) DEFAULT '3',
  `trash` float DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of appartment
-- ----------------------------
INSERT INTO `appartment` VALUES ('14', '-83.6044', '-1623.06', '31.4703', '0', 'Apartment 1\nStrawberry Ave', '20', 'Hanna Mandry', '395995939', '0', '0', '203.387');
INSERT INTO `appartment` VALUES ('15', '-89.5517', '-1630.04', '31.504', '0', 'Apartment 2\nStrawberry Ave', '20', '', '0', '1', '3', '200.9');
INSERT INTO `appartment` VALUES ('16', '-97.0681', '-1639', '32.0938', '0', 'Apartment 3\nStrawberry Ave', '20', '', '0', '1', '3', '0');
INSERT INTO `appartment` VALUES ('18', '-105.323', '-1632.21', '32.9026', '0', 'Apartment 4\nStrawberry Ave', '20', '', '0', '1', '3', '0');
INSERT INTO `appartment` VALUES ('19', '-109.477', '-1628.81', '32.9026', '0', 'Apartment 5\nStrawberry Ave', '20', '', '0', '1', '3', '0');
INSERT INTO `appartment` VALUES ('20', '-97.4505', '-1612.77', '32.296', '0', 'Apartment 6\nCarson Ave', '20', '', '0', '1', '3', '2');
INSERT INTO `appartment` VALUES ('23', '-93.4945', '-1607.21', '32.296', '0', '1\nCarson Ave', '20', 'Hanna Mandry', '395995939', '0', '0', '200.197');
INSERT INTO `appartment` VALUES ('24', '-87.9692', '-1601.58', '32.296', '0', '1\nCarson Ave', '20', 'Hanna Mandry', '395995939', '0', '0', '201.111');
INSERT INTO `appartment` VALUES ('25', '-80.2022', '-1608', '31.4703', '0', 'Appartment 9\nCarson Ave', '20', 'Hanna Mandry', '395995939', '0', '0', '201.95');
INSERT INTO `appartment` VALUES ('26', '136.075', '-1030.6', '29.3473', '0', 'Test\nVespucci Blvd', '10', 'Marc Black', '374628655', '1', '2', '201.777');
INSERT INTO `appartment` VALUES ('27', '52.6813', '-179.657', '54.959', '0', 'test\nAlta St', '10', 'Naruto Uzumaki', '395995939', '1', '0', '200.151');
INSERT INTO `appartment` VALUES ('28', '1736.11', '6406.42', '34.9751', '0', 'Test\nSenora Fwy', '20', 'Naruto Uzumaki', '395995939', '1', '0', '200.559');

-- ----------------------------
-- Table structure for `backpack`
-- ----------------------------
DROP TABLE IF EXISTS `backpack`;
CREATE TABLE `backpack` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item0` int(11) DEFAULT '0',
  `item1` int(11) DEFAULT '0',
  `item2` int(11) DEFAULT '0',
  `item3` int(11) DEFAULT '0',
  `item4` int(11) DEFAULT '0',
  `item5` int(11) DEFAULT '0',
  `item6` int(11) DEFAULT '0',
  `item7` int(11) DEFAULT '0',
  `item8` int(11) DEFAULT '0',
  `item9` int(11) DEFAULT '0',
  `item10` int(11) DEFAULT '0',
  `item11` int(11) DEFAULT '0',
  `item12` int(11) DEFAULT '0',
  `item13` int(11) DEFAULT '0',
  `item14` int(11) DEFAULT '0',
  `item15` int(11) DEFAULT '0',
  `item16` int(11) DEFAULT '0',
  `item17` int(11) DEFAULT '0',
  `item18` int(11) DEFAULT '0',
  `item19` int(11) DEFAULT '0',
  `item20` int(11) DEFAULT '0',
  `item21` int(11) DEFAULT '0',
  `item22` int(11) DEFAULT '0',
  `item23` int(11) DEFAULT '0',
  `size` int(11) DEFAULT NULL,
  `amount` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of backpack
-- ----------------------------
INSERT INTO `backpack` VALUES ('34', '0', '-1', '-1', '-1', '-1', '-1', '-1', '-1', '-1', '-1', '-1', '-1', '577', '597', '572', '-1', '0', '0', '-1', '-1', '0', '0', '0', '0', '1', '0');
INSERT INTO `backpack` VALUES ('35', '639', '654', '0', '0', '645', '0', '-1', '0', '646', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '-1', '-1', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('36', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('37', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '667', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('38', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '0');
INSERT INTO `backpack` VALUES ('39', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '666', '0', '0', '0', '0', '1', '0');
INSERT INTO `backpack` VALUES ('40', '1317', '1397', '1400', '1399', '1365', '1318', '0', '0', '1016', '1322', '0', '-1', '0', '0', '0', '-1', '-1', '0', '0', '-1', '0', '-1', '0', '-1', '2', '0');
INSERT INTO `backpack` VALUES ('41', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('42', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('43', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('44', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('45', '1436', '645', '1589', '1525', '1590', '1594', '1526', '0', '0', '0', '0', '-1', '-1', '-1', '-1', '1539', '-1', '-1', '1586', '-1', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('46', '0', '0', '0', '1516', '0', '0', '0', '1521', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '0');
INSERT INTO `backpack` VALUES ('47', '0', '1518', '1517', '1431', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '0');
INSERT INTO `backpack` VALUES ('48', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '-1', '1554', '0', '0', '0', '1540', '0', '0', '1631', '1', '0');
INSERT INTO `backpack` VALUES ('49', '0', '0', '0', '1626', '0', '0', '0', '1627', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2', '0');
INSERT INTO `backpack` VALUES ('50', '-1', '1708', '1670', '1716', '1669', '1698', '1713', '1717', '1722', '1720', '1723', '1724', '-1', '0', '0', '1730', '0', '0', '0', '0', '1729', '0', '0', '-1', '2', '0');
INSERT INTO `backpack` VALUES ('51', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '1', '0');

-- ----------------------------
-- Table structure for `banktransfers`
-- ----------------------------
DROP TABLE IF EXISTS `banktransfers`;
CREATE TABLE `banktransfers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `socialclubid` int(11) DEFAULT '0',
  `money` int(11) DEFAULT '0',
  `reason` varchar(255) DEFAULT 'Staatliche unterstützung',
  `date` varchar(255) DEFAULT '19.09.2000',
  `name` varchar(255) DEFAULT 'Unbekannt',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=568 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of banktransfers
-- ----------------------------
INSERT INTO `banktransfers` VALUES ('543', '395995939', '-600', 'Kredit rückzahlung', '14.04.2024(16:47:55)', 'Fleeca Bank');
INSERT INTO `banktransfers` VALUES ('544', '395995939', '-20', 'Miete: Apartment 1\nStrawberry Ave', '14.04.2024(16:47:57)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('545', '395995939', '-20', 'Miete: 1\nCarson Ave', '14.04.2024(16:47:58)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('546', '395995939', '-20', 'Miete: 1\nCarson Ave', '14.04.2024(16:47:59)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('547', '395995939', '-20', 'Miete: Appartment 9\nCarson Ave', '14.04.2024(16:48:00)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('548', '395995939', '-10', 'Miete: test\nAlta St', '14.04.2024(16:48:01)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('549', '395995939', '-20', 'Miete: Test\nSenora Fwy', '14.04.2024(16:48:02)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('550', '395995939', '500', 'Gehalt', '14.04.2024(16:48:03)', 'Firma: M1 Mechanic');
INSERT INTO `banktransfers` VALUES ('551', '395995939', '-600', 'Kredit rückzahlung', '15.04.2024(00:45:10)', 'Fleeca Bank');
INSERT INTO `banktransfers` VALUES ('552', '395995939', '-20', 'Miete: Apartment 1\nStrawberry Ave', '15.04.2024(00:45:11)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('553', '395995939', '-20', 'Miete: 1\nCarson Ave', '15.04.2024(00:45:13)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('554', '395995939', '-20', 'Miete: 1\nCarson Ave', '15.04.2024(00:45:14)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('555', '395995939', '-20', 'Miete: Appartment 9\nCarson Ave', '15.04.2024(00:45:15)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('556', '395995939', '-10', 'Miete: test\nAlta St', '15.04.2024(00:45:16)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('557', '395995939', '-20', 'Miete: Test\nSenora Fwy', '15.04.2024(00:45:17)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('558', '395995939', '500', 'Gehalt', '15.04.2024(00:45:18)', 'Firma: ');
INSERT INTO `banktransfers` VALUES ('559', '395995939', '-600', 'Kredit rückzahlung', '16.04.2024(19:02:58)', 'Fleeca Bank');
INSERT INTO `banktransfers` VALUES ('560', '395995939', '-20', 'Miete: Apartment 1\nStrawberry Ave', '16.04.2024(19:02:59)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('561', '395995939', '-20', 'Miete: 1\nCarson Ave', '16.04.2024(19:03:00)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('562', '395995939', '-20', 'Miete: 1\nCarson Ave', '16.04.2024(19:03:01)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('563', '395995939', '-20', 'Miete: Appartment 9\nCarson Ave', '16.04.2024(19:03:02)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('564', '395995939', '-10', 'Miete: test\nAlta St', '16.04.2024(19:03:03)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('565', '395995939', '-20', 'Miete: Test\nSenora Fwy', '16.04.2024(19:03:04)', 'Hausverwaltung');
INSERT INTO `banktransfers` VALUES ('566', '395995939', '500', 'Gehalt', '16.04.2024(19:03:05)', 'Firma: ');
INSERT INTO `banktransfers` VALUES ('567', '348091326', '295', 'Gehalt', '16.04.2024(19:06:07)', 'Arbeitgeber');

-- ----------------------------
-- Table structure for `banktransfers_firmen`
-- ----------------------------
DROP TABLE IF EXISTS `banktransfers_firmen`;
CREATE TABLE `banktransfers_firmen` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firmenid` int(11) DEFAULT NULL,
  `money` int(11) DEFAULT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of banktransfers_firmen
-- ----------------------------
INSERT INTO `banktransfers_firmen` VALUES ('1', '11', '150', 'Neue Lackierung', '2024-03-07 00:07:22', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('2', '11', '-8000', 'Fahrzeug: infernus gekauft', '2024-03-07 00:17:59', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('3', '11', '-2000', 'Fahrzeug: asbo gekauft', '2024-03-07 00:18:48', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('4', '11', '-3500', 'Fahrzeug: dilettante gekauft', '2024-03-07 00:19:15', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('5', '11', '-3000', 'elegy gekauft', '2024-03-07 00:37:29', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('6', '11', '4000', 'Fahrzeug gekafut', '2024-03-07 00:39:10', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('7', '11', '-200', 'Test', '2024-03-07 15:58:22', 'Firma: ');
INSERT INTO `banktransfers_firmen` VALUES ('8', '11', '-30', 'Lackierung', '2024-03-07 16:04:10', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('9', '11', '41', 'Test', '2024-03-07 16:04:32', 'Firma: ');
INSERT INTO `banktransfers_firmen` VALUES ('10', '11', '-41', 'Test', '2024-03-07 16:04:32', 'Firma: ');
INSERT INTO `banktransfers_firmen` VALUES ('11', '11', '-200', 'Gehalt', '2024-03-08 01:26:26', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('12', '11', '-500', 'Gehalt', '2024-03-08 22:03:49', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('13', '11', '-500', 'Gehalt', '2024-03-20 21:45:34', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('14', '8', '-500', 'Gehalt', '2024-04-03 20:28:22', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('15', '4', '-500', 'Gehalt', '2024-04-10 22:20:15', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('16', '4', '-500', 'Gehalt', '2024-04-11 18:27:39', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('17', '4', '-500', 'Gehalt', '2024-04-12 15:56:58', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('18', '4', '-500', 'Gehalt', '2024-04-13 20:30:25', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('19', '4', '-500', 'Gehalt', '2024-04-14 03:25:54', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('20', '8', '-500', 'Gehalt', '2024-04-14 16:48:05', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('21', '4', '-500', 'Gehalt', '2024-04-15 00:45:19', 'Naruto Uzumaki');
INSERT INTO `banktransfers_firmen` VALUES ('22', '4', '-500', 'Gehalt', '2024-04-16 19:03:06', 'Naruto Uzumaki');

-- ----------------------------
-- Table structure for `businesskeys`
-- ----------------------------
DROP TABLE IF EXISTS `businesskeys`;
CREATE TABLE `businesskeys` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(500) NOT NULL DEFAULT 'Ladenschlüssel',
  `businessdbid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of businesskeys
-- ----------------------------

-- ----------------------------
-- Table structure for `clothes`
-- ----------------------------
DROP TABLE IF EXISTS `clothes`;
CREATE TABLE `clothes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `drawable` int(11) DEFAULT NULL,
  `texture` int(11) DEFAULT NULL,
  `sex` int(11) DEFAULT NULL,
  `componente` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=140 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clothes
-- ----------------------------
INSERT INTO `clothes` VALUES ('119', '66', '0', '1', '4');
INSERT INTO `clothes` VALUES ('120', '49', '0', '1', '6');
INSERT INTO `clothes` VALUES ('121', '247', '0', '1', '11');
INSERT INTO `clothes` VALUES ('122', '2', '0', '1', '4');
INSERT INTO `clothes` VALUES ('123', '49', '0', '1', '6');
INSERT INTO `clothes` VALUES ('124', '0', '0', '1', '11');
INSERT INTO `clothes` VALUES ('125', '18', '0', '1', '7');
INSERT INTO `clothes` VALUES ('126', '1', '0', '1', '7');
INSERT INTO `clothes` VALUES ('127', '0', '0', '0', '4');
INSERT INTO `clothes` VALUES ('128', '1', '0', '0', '6');
INSERT INTO `clothes` VALUES ('129', '0', '0', '0', '4');
INSERT INTO `clothes` VALUES ('130', '1', '0', '0', '6');
INSERT INTO `clothes` VALUES ('131', '103', '0', '0', '4');
INSERT INTO `clothes` VALUES ('132', '7', '0', '0', '6');
INSERT INTO `clothes` VALUES ('133', '1', '0', '0', '8');
INSERT INTO `clothes` VALUES ('134', '346', '0', '0', '11');
INSERT INTO `clothes` VALUES ('135', '5', '0', '0', '4');
INSERT INTO `clothes` VALUES ('136', '7', '0', '0', '6');
INSERT INTO `clothes` VALUES ('137', '5', '0', '0', '11');
INSERT INTO `clothes` VALUES ('138', '1', '1', '1', '1');
INSERT INTO `clothes` VALUES ('139', '1', '0', '0', '1');

-- ----------------------------
-- Table structure for `crimes`
-- ----------------------------
DROP TABLE IF EXISTS `crimes`;
CREATE TABLE `crimes` (
  `crimeid` int(11) NOT NULL AUTO_INCREMENT,
  `verbrechen` varchar(255) DEFAULT NULL,
  `gesucht` int(11) DEFAULT NULL,
  `knasttime` int(11) DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  `cost` int(11) DEFAULT NULL,
  `date` varchar(255) DEFAULT NULL,
  `socialclubid` int(11) DEFAULT NULL,
  `pname` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`crimeid`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of crimes
-- ----------------------------
INSERT INTO `crimes` VALUES ('51', '', '0', '0', '3', '0', '03.01.2000(10:54:19)', '395995939', 'Staatsgefängnis');
INSERT INTO `crimes` VALUES ('52', '', '0', '0', '3', '0', '03.01.2000(12:08:24)', '395995939', 'Staatsgefängnis');
INSERT INTO `crimes` VALUES ('53', '24/7 Überfallen', '0', '0', '3', '0', '16.01.2000(18:46:12)', '395995939', 'Staatsgefängnis');
INSERT INTO `crimes` VALUES ('54', 'Tankstellen Rechnung nicht bezahlt', '1', '10', '2', '23', '15.04.2024(00:16:54)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('55', 'Tankstellen Rechnung nicht bezahlt', '1', '10', '2', '0', '15.04.2024(00:16:57)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('56', 'Tankstellen Rechnung nicht bezahlt', '2', '300', '2', '1', '15.04.2024(00:25:18)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('57', 'Test', '1', '3600', '2', '5000', '15.04.2024(00:25:54)', '395995939', 'Naruto Uzumaki');
INSERT INTO `crimes` VALUES ('58', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '1', '15.04.2024(00:32:31)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('59', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '2', '15.04.2024(00:32:42)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('60', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '5', '15.04.2024(01:00:34)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('61', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '1', '15.04.2024(01:06:18)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('62', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '1', '15.04.2024(20:24:54)', '395995939', 'Tankstelle: Tankstelle');
INSERT INTO `crimes` VALUES ('63', 'Tankstellen Rechnung nicht bezahlt', '1', '180', '2', '30', '16.04.2024(19:05:41)', '395995939', 'Tankstelle: Tankstelle');

-- ----------------------------
-- Table structure for `drivinglicenses`
-- ----------------------------
DROP TABLE IF EXISTS `drivinglicenses`;
CREATE TABLE `drivinglicenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `socialclubid` int(11) DEFAULT NULL,
  `owner` varchar(255) DEFAULT NULL,
  `car` int(11) DEFAULT '0',
  `bike` int(11) DEFAULT '0',
  `searched` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of drivinglicenses
-- ----------------------------

-- ----------------------------
-- Table structure for `faction_duty_history`
-- ----------------------------
DROP TABLE IF EXISTS `faction_duty_history`;
CREATE TABLE `faction_duty_history` (
  `factionid` int(11) NOT NULL,
  `accountid` int(11) NOT NULL,
  `datum` varchar(255) NOT NULL,
  `state` int(11) NOT NULL,
  PRIMARY KEY (`factionid`,`datum`,`accountid`,`state`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of faction_duty_history
-- ----------------------------
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:10:37)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:10:40)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:11:04)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:11:51)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:20:36)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (18:21:10)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:24:16)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:24:57)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:24:58)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:25:12)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:26:14)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '06.01.2000 (19:36:52)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '07.01.2000 (13:29:48)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '07.01.2000 (13:29:53)', '1');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '15.01.2000 (19:33:18)', '0');
INSERT INTO `faction_duty_history` VALUES ('1', '395995939', '15.01.2000 (19:33:21)', '1');

-- ----------------------------
-- Table structure for `firmen`
-- ----------------------------
DROP TABLE IF EXISTS `firmen`;
CREATE TABLE `firmen` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pos_x` float DEFAULT NULL,
  `pos_y` float DEFAULT NULL,
  `pos_z` float DEFAULT NULL,
  `info` varchar(255) DEFAULT '',
  `owner_id` int(11) DEFAULT '0',
  `owner_name` varchar(255) DEFAULT '',
  `products` int(11) DEFAULT '0',
  `type` int(11) DEFAULT '0',
  `price` int(11) DEFAULT '0',
  `konto` int(11) DEFAULT '0',
  `kontonr` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of firmen
-- ----------------------------
INSERT INTO `firmen` VALUES ('1', '1187.8', '2645.35', '38.3619', '', '0', '', '0', '2', '0', '0', '421345');
INSERT INTO `firmen` VALUES ('2', '-1142.76', '-1993.35', '13.1545', '', '0', '', '0', '1', '0', '0', '531241');
INSERT INTO `firmen` VALUES ('3', '722.98', '-1069.48', '23.0623', '', '0', '', '0', '1', '0', '0', '778212');
INSERT INTO `firmen` VALUES ('4', '-354.448', '-128.176', '39.4235', '', '395995939', 'Naruto Uzumaki', '0', '1', '0', '0', '987123');
INSERT INTO `firmen` VALUES ('5', '119.288', '6626.6', '31.9421', '', '0', '', '0', '2', '0', '0', '776123');
INSERT INTO `firmen` VALUES ('6', '2004.03', '3790.54', '32.178', '', '0', '', '0', '2', '0', '0', '444212');
INSERT INTO `firmen` VALUES ('7', '2515.62', '4203.48', '39.9963', '', '0', '', '0', '2', '0', '0', '412451');
INSERT INTO `firmen` VALUES ('8', '540.567', '-196.589', '54.4872', 'M1 Mechanic', '395995939', 'Naruto Uzumaki', '840', '2', '0', '0', '221354');
INSERT INTO `firmen` VALUES ('10', '483.547', '-1312.35', '29.1956', '', '0', '', '0', '2', '0', '0', '333213');
INSERT INTO `firmen` VALUES ('11', '-38.3341', '-1109.08', '26.4323', 'Autohaus Sports', '395995939', 'Naruto Uzumaki', '0', '6', '0', '66270', '998131');
INSERT INTO `firmen` VALUES ('12', '-239.037', '-1398.01', '31.2682', '', '0', '', '0', '6', '0', '0', '874512');

-- ----------------------------
-- Table structure for `firmen_cardealer_all`
-- ----------------------------
DROP TABLE IF EXISTS `firmen_cardealer_all`;
CREATE TABLE `firmen_cardealer_all` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `vehname` varchar(255) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `firmenid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of firmen_cardealer_all
-- ----------------------------
INSERT INTO `firmen_cardealer_all` VALUES ('1', 'Naruto Uzumaki', 'stanier', '1000', '11');
INSERT INTO `firmen_cardealer_all` VALUES ('2', 'Naruto Uzumaki', 'elegy', '3000', '11');
INSERT INTO `firmen_cardealer_all` VALUES ('3', 'Naruto Uzumaki', 'infernus', '8000', '11');

-- ----------------------------
-- Table structure for `firmen_cardealer_contract`
-- ----------------------------
DROP TABLE IF EXISTS `firmen_cardealer_contract`;
CREATE TABLE `firmen_cardealer_contract` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firmenid` int(11) DEFAULT NULL,
  `model` int(11) unsigned DEFAULT NULL,
  `p_r` int(11) DEFAULT NULL,
  `p_g` int(11) DEFAULT NULL,
  `p_b` int(11) DEFAULT NULL,
  `s_r` int(11) DEFAULT NULL,
  `s_g` int(11) DEFAULT NULL,
  `s_b` int(11) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `delivery` datetime DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of firmen_cardealer_contract
-- ----------------------------
INSERT INTO `firmen_cardealer_contract` VALUES ('18', '11', '1118611807', '250', '146', '0', '240', '5', '5', '2000', '2024-03-06 22:59:52', 'Naruto Uzumaki');
INSERT INTO `firmen_cardealer_contract` VALUES ('19', '11', '418536135', '3', '0', '153', '255', '255', '255', '8000', '2024-03-07 00:18:59', 'Naruto Uzumaki');
INSERT INTO `firmen_cardealer_contract` VALUES ('20', '11', '1118611807', '240', '0', '0', '255', '255', '255', '2000', '2024-03-07 00:19:48', 'Naruto Uzumaki');
INSERT INTO `firmen_cardealer_contract` VALUES ('21', '11', '3164157193', '92', '72', '0', '255', '255', '255', '3500', '2024-03-07 00:20:15', 'Naruto Uzumaki');
INSERT INTO `firmen_cardealer_contract` VALUES ('22', '11', '196747873', '219', '0', '150', '230', '0', '157', '3000', '2024-03-07 00:38:29', 'Naruto Uzumaki');

-- ----------------------------
-- Table structure for `firmen_worker`
-- ----------------------------
DROP TABLE IF EXISTS `firmen_worker`;
CREATE TABLE `firmen_worker` (
  `socialclubid` bigint(20) NOT NULL,
  `firmenid` int(11) DEFAULT NULL,
  `rang` int(11) DEFAULT NULL,
  `gehalt` int(11) DEFAULT NULL,
  PRIMARY KEY (`socialclubid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of firmen_worker
-- ----------------------------
INSERT INTO `firmen_worker` VALUES ('348091326', '4', '3', '100');
INSERT INTO `firmen_worker` VALUES ('395995939', '4', '3', '500');

-- ----------------------------
-- Table structure for `friends`
-- ----------------------------
DROP TABLE IF EXISTS `friends`;
CREATE TABLE `friends` (
  `player` bigint(11) unsigned NOT NULL,
  `friend` bigint(11) unsigned NOT NULL,
  PRIMARY KEY (`player`,`friend`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of friends
-- ----------------------------
INSERT INTO `friends` VALUES ('348091326', '395995939');
INSERT INTO `friends` VALUES ('374628655', '395995939');
INSERT INTO `friends` VALUES ('395995939', '348091326');
INSERT INTO `friends` VALUES ('395995939', '374628655');
INSERT INTO `friends` VALUES ('395995939', '395995939');

-- ----------------------------
-- Table structure for `gasstation`
-- ----------------------------
DROP TABLE IF EXISTS `gasstation`;
CREATE TABLE `gasstation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `x` float DEFAULT NULL,
  `y` float DEFAULT NULL,
  `z` float DEFAULT NULL,
  `konto` int(11) DEFAULT NULL,
  `products` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `owner` varchar(255) DEFAULT NULL,
  `owned` bigint(20) DEFAULT NULL,
  `ped_x` float DEFAULT NULL,
  `ped_y` float DEFAULT NULL,
  `ped_z` float DEFAULT NULL,
  `ped_r` float DEFAULT NULL,
  `sellprice` int(11) DEFAULT NULL,
  `f0` int(11) DEFAULT '1',
  `f1` int(11) DEFAULT '1',
  `f2` int(11) DEFAULT '1',
  `f3` int(11) DEFAULT '1',
  `open` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of gasstation
-- ----------------------------
INSERT INTO `gasstation` VALUES ('1', '1160.86', '-313.095', '69.197', '129', '913', 'Tankstelle', '', '0', '1164.87', '-323.565', '69.197', '90', '0', '1', '25', '20', '12', '1');
INSERT INTO `gasstation` VALUES ('2', '-41.7626', '-1748.95', '29.4147', '0', '1000', 'Tankstelle', '', '0', '-47.3538', '-1758.76', '29.4147', '50', '0', '1', '1', '1', '1', '1');
INSERT INTO `gasstation` VALUES ('3', '-708.119', '-903.534', '19.2036', '7', '988', 'Tankstelle', '', '0', '-706.062', '-914.519', '19.2036', '90', '0', '1', '1', '1', '1', '1');
INSERT INTO `gasstation` VALUES ('4', '-1828.39', '800.347', '138.146', '0', '1000', 'Tankstelle', '', '0', '-1819.52', '793.635', '138.079', '130', '0', '1', '1', '1', '1', '1');
INSERT INTO `gasstation` VALUES ('5', '1707.32', '4918.52', '42.052', '0', '1000', 'Tankstelle', '', '0', '1697.31', '4923.35', '42.052', '-30', '0', '1', '1', '1', '1', '1');

-- ----------------------------
-- Table structure for `grounditems`
-- ----------------------------
DROP TABLE IF EXISTS `grounditems`;
CREATE TABLE `grounditems` (
  `id` int(11) NOT NULL,
  `x` float DEFAULT NULL,
  `y` float DEFAULT NULL,
  `z` float DEFAULT NULL,
  `dimension` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of grounditems
-- ----------------------------
INSERT INTO `grounditems` VALUES ('573', '1224.71', '2720.22', '37.9912', '0');
INSERT INTO `grounditems` VALUES ('576', '1259.97', '2673.31', '37.6879', '0');
INSERT INTO `grounditems` VALUES ('582', '1224.91', '2720.04', '38.0081', '0');
INSERT INTO `grounditems` VALUES ('587', '1261.05', '2674.39', '37.6205', '0');
INSERT INTO `grounditems` VALUES ('588', '1221.36', '2708.82', '37.9912', '0');
INSERT INTO `grounditems` VALUES ('589', '1259.97', '2673.31', '37.6879', '0');
INSERT INTO `grounditems` VALUES ('595', '1261.05', '2674.39', '37.6205', '0');
INSERT INTO `grounditems` VALUES ('598', '1261.05', '2674.39', '37.6205', '0');
INSERT INTO `grounditems` VALUES ('599', '1261.05', '2674.39', '37.6205', '0');
INSERT INTO `grounditems` VALUES ('600', '1261.05', '2674.39', '37.6205', '0');

-- ----------------------------
-- Table structure for `inventory`
-- ----------------------------
DROP TABLE IF EXISTS `inventory`;
CREATE TABLE `inventory` (
  `socialclubid` int(11) NOT NULL,
  `itemid` int(11) NOT NULL DEFAULT '0',
  `slot` int(11) NOT NULL,
  PRIMARY KEY (`socialclubid`,`slot`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of inventory
-- ----------------------------
INSERT INTO `inventory` VALUES ('348091326', '1740', '10');
INSERT INTO `inventory` VALUES ('348091326', '1510', '11');
INSERT INTO `inventory` VALUES ('374628655', '1628', '2');
INSERT INTO `inventory` VALUES ('374628655', '1625', '3');
INSERT INTO `inventory` VALUES ('374628655', '1630', '5');
INSERT INTO `inventory` VALUES ('374628655', '1635', '6');
INSERT INTO `inventory` VALUES ('374628655', '1633', '9');
INSERT INTO `inventory` VALUES ('374628655', '1632', '10');
INSERT INTO `inventory` VALUES ('374628655', '1637', '20');
INSERT INTO `inventory` VALUES ('395995939', '1726', '0');
INSERT INTO `inventory` VALUES ('395995939', '1731', '1');
INSERT INTO `inventory` VALUES ('395995939', '1732', '2');
INSERT INTO `inventory` VALUES ('395995939', '1714', '3');
INSERT INTO `inventory` VALUES ('395995939', '1697', '4');
INSERT INTO `inventory` VALUES ('395995939', '1738', '5');
INSERT INTO `inventory` VALUES ('395995939', '1739', '6');
INSERT INTO `inventory` VALUES ('395995939', '1737', '7');
INSERT INTO `inventory` VALUES ('395995939', '1719', '8');
INSERT INTO `inventory` VALUES ('395995939', '1721', '10');
INSERT INTO `inventory` VALUES ('395995939', '1692', '20');

-- ----------------------------
-- Table structure for `items`
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `businesskey` int(11) NOT NULL,
  `vehkey` int(11) NOT NULL,
  `weapons` varchar(100) NOT NULL,
  `housekeys` int(11) NOT NULL,
  `backpack` int(11) NOT NULL,
  `clothes` int(11) NOT NULL,
  `amount` int(11) DEFAULT '0',
  `description` varchar(500) NOT NULL DEFAULT 'Ein normales item',
  `prop` int(11) NOT NULL DEFAULT '0',
  `munitype` int(11) NOT NULL DEFAULT '-1',
  `objhash` int(11) DEFAULT '0',
  `perso` int(11) NOT NULL DEFAULT '0',
  `drivinglicense` int(11) DEFAULT '0',
  `serveritem` int(11) DEFAULT '0',
  `mass` float DEFAULT '0.1',
  `maxamount` int(11) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1741 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of items
-- ----------------------------
INSERT INTO `items` VALUES ('569', '0', '0', '-1', '0', '0', '122', '1', 'Modell: 2 | Frau', '0', '-1', '-1157632529', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('570', '0', '0', '-1', '0', '0', '123', '1', 'Modell: 49 | Frau', '0', '-1', '1682675077', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('571', '0', '0', '-1', '0', '0', '124', '1', 'Modell: 0 | Frau', '0', '-1', '-1256588656', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('572', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('573', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('574', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 1 | Frau', '37', '-1', '419222340', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('575', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 1 | Frau', '38', '-1', '1169295068', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('576', '0', '0', '-1', '0', '34', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('577', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('580', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 145 | Frau', '39', '-1', '-1870936557', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('581', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 22 | Frau', '40', '-1', '-1703594174', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('582', '0', '0', '-1', '0', '0', '125', '1', 'Modell: 18 | Frau', '0', '-1', '0', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('583', '0', '0', '-1', '0', '0', '126', '1', 'Modell: 1 | Frau', '0', '-1', '0', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('584', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 1 | Frau', '41', '-1', '-14292445', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('585', '0', '0', '-1', '0', '35', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('586', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Hanna Mandry', '0', '-1', '292851939', '15', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('587', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('588', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('589', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('595', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '8');
INSERT INTO `items` VALUES ('596', '0', '0', '-1', '0', '36', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('597', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('598', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('599', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('600', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('601', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '30');
INSERT INTO `items` VALUES ('602', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '30');
INSERT INTO `items` VALUES ('603', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '8');
INSERT INTO `items` VALUES ('606', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('607', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '8');
INSERT INTO `items` VALUES ('608', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '30');
INSERT INTO `items` VALUES ('609', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('610', '0', '0', '-1', '0', '0', '0', '9', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('611', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('614', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('616', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '8');
INSERT INTO `items` VALUES ('617', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('618', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '30');
INSERT INTO `items` VALUES ('619', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('620', '0', '0', '-1', '0', '0', '0', '11', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('621', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('622', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '1', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('623', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('625', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('626', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('627', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('628', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('631', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('633', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('634', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('635', '0', '0', '-1', '0', '0', '0', '15', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('636', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('637', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('638', '0', '0', '-1', '0', '0', '0', '15', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('639', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('642', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('643', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('644', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('645', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('646', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('647', '0', '0', '-1', '0', '0', '0', '9', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('648', '0', '0', '-1', '0', '0', '0', '6', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('649', '0', '0', '-1', '0', '0', '0', '11', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('650', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('651', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('654', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('656', '0', '0', '-1', '0', '0', '0', '9', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('657', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('658', '0', '0', '-1', '0', '0', '0', '9', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('659', '0', '0', '-1', '0', '0', '0', '2', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('660', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('661', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('662', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('663', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('664', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('665', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('666', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('667', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('668', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('669', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('670', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('671', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('672', '0', '0', '-1', '0', '37', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('673', '0', '0', '-1', '0', '38', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('674', '0', '0', '-1', '0', '39', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('675', '0', '0', '-1', '0', '40', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('676', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('677', '0', '0', '-1', '0', '41', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('678', '0', '0', '-1', '0', '42', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('679', '0', '0', '-1', '0', '43', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('683', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('687', '0', '0', '-1', '0', '44', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('690', '0', '0', '-1', '0', '0', '0', '28', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('694', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('697', '0', '0', '-1', '0', '0', '0', '11', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('701', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('712', '0', '0', '-1', '0', '0', '0', '1', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('730', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('731', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('737', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('738', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('739', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('740', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('752', '0', '0', '-1', '0', '0', '0', '3', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('758', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('761', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('764', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('765', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('769', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('783', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('784', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('787', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('788', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('789', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('790', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('792', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('794', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('795', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('799', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('800', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('801', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('806', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('807', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('808', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('810', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('811', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('812', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('813', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('816', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('817', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('819', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('820', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('828', '0', '0', '-1', '0', '0', '0', '22', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('830', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('831', '0', '0', '-1', '0', '0', '0', '17', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('832', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('846', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('852', '0', '0', '-1', '0', '0', '0', '23', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('853', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('856', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('857', '0', '0', '-1', '0', '0', '0', '10', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('858', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('859', '0', '0', '-1', '0', '0', '0', '0', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('869', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('873', '0', '0', '-1', '0', '0', '0', '28', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('880', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('881', '0', '0', '-1', '0', '0', '0', '1', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('882', '0', '0', '-1', '0', '0', '0', '3', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('885', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('889', '0', '0', '-1', '0', '0', '0', '18', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('890', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('891', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('892', '0', '0', '-1', '0', '0', '0', '18', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('893', '0', '0', '-1', '0', '0', '0', '14', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('894', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('904', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('905', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.016', '30');
INSERT INTO `items` VALUES ('913', '0', '70', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('914', '0', '71', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('915', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('916', '0', '0', 'weapon_microsmg', '0', '0', '0', '1', 'Micro MG', '0', '-1', '-1056713654', '0', '0', '5', '1.2', '1');
INSERT INTO `items` VALUES ('917', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('918', '0', '0', 'weapon_microsmg', '0', '0', '0', '1', 'Micro MG', '0', '-1', '-1056713654', '0', '0', '5', '1.2', '1');
INSERT INTO `items` VALUES ('919', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('920', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('921', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('922', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('923', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '3', '-284652484', '0', '0', '6', '0.04', '30');
INSERT INTO `items` VALUES ('924', '0', '0', '-1', '0', '0', '0', '10', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('925', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('927', '0', '0', 'weapon_microsmg', '0', '0', '0', '1', 'Micro MG', '0', '-1', '-1056713654', '0', '0', '5', '1.2', '1');
INSERT INTO `items` VALUES ('928', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('929', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('930', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('931', '0', '0', '-1', '0', '0', '0', '5', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('932', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('935', '0', '0', 'weapon_microsmg', '0', '0', '0', '1', 'Micro MG', '0', '-1', '-1056713654', '0', '0', '5', '1.2', '1');
INSERT INTO `items` VALUES ('944', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('945', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('946', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('947', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('948', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('949', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('950', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('951', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('952', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('953', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('954', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('955', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('956', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('957', '0', '0', '-1', '0', '0', '0', '3', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('961', '0', '0', '-1', '0', '0', '0', '42', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('964', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('965', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('966', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('967', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('968', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('969', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('970', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('971', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('972', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('973', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('976', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('977', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('978', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('979', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('980', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('981', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('982', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('983', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('984', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('985', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('986', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('987', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('988', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('989', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('990', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('991', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('992', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('993', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('994', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('995', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('996', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('997', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('998', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('999', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1000', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1001', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1002', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1003', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1004', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1005', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1006', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1007', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1008', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1009', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1010', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1011', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1012', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1013', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1014', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1015', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1016', '0', '72', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1017', '0', '0', '-1', '0', '0', '0', '40', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1021', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1022', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1023', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1024', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1025', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1026', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1027', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1028', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1029', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1031', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1032', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1033', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1034', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1035', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1036', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1037', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1038', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1039', '0', '0', '-1', '0', '0', '0', '10', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1044', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1045', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1046', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1047', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1048', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1049', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1050', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1051', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1052', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1053', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1054', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1055', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1056', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1057', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1058', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1059', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1060', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1061', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1062', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1063', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1064', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1065', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1066', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1067', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1068', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1069', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1072', '0', '0', '-1', '0', '0', '0', '3', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1073', '0', '0', '-1', '0', '0', '0', '3', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1074', '0', '0', '-1', '0', '0', '0', '3', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1075', '0', '0', '-1', '0', '0', '0', '3', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1076', '0', '0', '-1', '0', '0', '0', '3', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1206', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1207', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1208', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1209', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1210', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1211', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1212', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1213', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1214', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1215', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1216', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1217', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1219', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1220', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1221', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1222', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1223', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1224', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1227', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1228', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1229', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1230', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1231', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1232', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1233', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1234', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1235', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1236', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1237', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1238', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1239', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1240', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1241', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1242', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1243', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1244', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1245', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1246', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1247', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1248', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1249', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1250', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1259', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1260', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1261', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1262', '0', '0', '-1', '0', '0', '0', '5', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1264', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1265', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1268', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1269', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1270', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1271', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1272', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1273', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1274', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1275', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1278', '0', '0', '-1', '0', '0', '0', '6', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1279', '0', '0', '-1', '0', '0', '0', '6', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1315', '0', '72', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1316', '0', '72', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1317', '0', '72', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1318', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Hanna Mandry', '0', '-1', '292851939', '16', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1322', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Hanna Mandry', '0', '-1', '292851939', '17', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1354', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('1356', '0', '0', '-1', '0', '0', '127', '1', 'Modell: 0 | Mann', '0', '-1', '-1157632529', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1357', '0', '0', '-1', '0', '0', '128', '1', 'Modell: 1 | Mann', '0', '-1', '1682675077', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1362', '0', '0', '-1', '0', '0', '0', '3', 'Verarbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1363', '0', '0', '-1', '0', '0', '0', '3', 'Verarbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '12', '0.1', '100');
INSERT INTO `items` VALUES ('1365', '0', '73', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1366', '0', '73', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1367', '0', '73', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (73)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1368', '0', '0', 'weapon_pistol', '0', '0', '0', '1', 'Pistole', '0', '-1', '1467525553', '0', '0', '5', '0.6', '1');
INSERT INTO `items` VALUES ('1383', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1384', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1385', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1386', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1387', '0', '0', '-1', '0', '0', '0', '12', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1388', '0', '0', '-1', '0', '0', '0', '4', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1397', '0', '0', '-1', '0', '0', '0', '17', 'Unbearbeitetes Eisen', '0', '-1', '-1134789989', '0', '0', '13', '0.4', '100');
INSERT INTO `items` VALUES ('1399', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1400', '0', '0', '-1', '0', '0', '0', '16', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('1403', '0', '0', '-1', '0', '0', '0', '12', 'Unbearbeitetes Eisen', '0', '-1', '-1134789989', '0', '0', '13', '0.4', '100');
INSERT INTO `items` VALUES ('1407', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1412', '0', '0', '-1', '0', '0', '0', '5', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1413', '0', '0', '-1', '0', '0', '0', '5', 'Made', '0', '-1', '-1134789989', '0', '0', '17', '0.01', '5');
INSERT INTO `items` VALUES ('1414', '0', '0', '-1', '0', '0', '0', '1', 'Kugel Fisch', '0', '-1', '-1134789989', '0', '0', '19', '0.41538', '1');
INSERT INTO `items` VALUES ('1415', '0', '0', '-1', '0', '0', '0', '1', 'Tropischen Fisch', '0', '-1', '-1134789989', '0', '0', '21', '0.369537', '1');
INSERT INTO `items` VALUES ('1416', '0', '0', '-1', '0', '0', '0', '1', 'Kraken', '0', '-1', '-1134789989', '0', '0', '20', '0.52007', '1');
INSERT INTO `items` VALUES ('1417', '0', '0', '-1', '0', '0', '0', '1', 'Baby Delfin', '0', '-1', '-1134789989', '0', '0', '23', '7.14999', '1');
INSERT INTO `items` VALUES ('1418', '0', '0', '-1', '0', '0', '0', '1', 'Baby Hai', '0', '-1', '-1134789989', '0', '0', '22', '9.70021', '1');
INSERT INTO `items` VALUES ('1419', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.180782', '1');
INSERT INTO `items` VALUES ('1420', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.115489', '1');
INSERT INTO `items` VALUES ('1421', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.275393', '1');
INSERT INTO `items` VALUES ('1422', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.215327', '1');
INSERT INTO `items` VALUES ('1423', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.287046', '1');
INSERT INTO `items` VALUES ('1424', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.255741', '1');
INSERT INTO `items` VALUES ('1425', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.327887', '1');
INSERT INTO `items` VALUES ('1426', '0', '0', '-1', '0', '0', '0', '1', 'Baby Delfin', '0', '-1', '-1134789989', '0', '0', '23', '8.26687', '1');
INSERT INTO `items` VALUES ('1427', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.108539', '1');
INSERT INTO `items` VALUES ('1428', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.280409', '1');
INSERT INTO `items` VALUES ('1429', '0', '0', '-1', '0', '0', '129', '1', 'Modell: 0 | Mann', '0', '-1', '-1157632529', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1430', '0', '0', '-1', '0', '0', '130', '1', 'Modell: 1 | Mann', '0', '-1', '1682675077', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1431', '0', '78', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (78)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1432', '0', '-1', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (-1)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1433', '0', '79', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (79)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1434', '0', '80', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (80)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1435', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1436', '0', '0', 'weapon_microsmg', '0', '0', '0', '1', 'Micro MG', '0', '-1', '-1056713654', '0', '0', '5', '1.2', '1');
INSERT INTO `items` VALUES ('1439', '0', '0', '-1', '0', '45', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1491', '0', '0', '-1', '0', '0', '0', '4', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1493', '0', '0', '-1', '0', '0', '0', '2', 'Munition', '0', '3', '-177292685', '0', '0', '6', '0.04', '16');
INSERT INTO `items` VALUES ('1495', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1496', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1497', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1498', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1499', '0', '0', '-1', '0', '0', '0', '21', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1500', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1502', '0', '0', '-1', '0', '0', '0', '1', 'Unbearbeitetes Holz', '0', '-1', '-1996501787', '0', '0', '11', '0.2', '100');
INSERT INTO `items` VALUES ('1503', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1504', '0', '0', '-1', '14', '0', '0', '1', 'Wohnungsschlüssel Apartment 1\nStrawberry Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1505', '0', '0', '-1', '21', '0', '0', '1', 'Wohnungsschlüssel d\nCarson Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1506', '0', '0', '-1', '22', '0', '0', '1', 'Wohnungsschlüssel 1\nCarson Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1507', '0', '0', '-1', '23', '0', '0', '1', 'Wohnungsschlüssel 1\nCarson Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1508', '0', '0', '-1', '24', '0', '0', '1', 'Wohnungsschlüssel 1\nCarson Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1509', '0', '0', '-1', '25', '0', '0', '1', 'Wohnungsschlüssel Appartment 9\nCarson Ave', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1510', '0', '82', '-1', '0', '0', '0', '1', 'asd', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1511', '0', '83', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (83)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1512', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1513', '0', '0', '-1', '0', '0', '0', '5', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1514', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.146885', '1');
INSERT INTO `items` VALUES ('1515', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Hanna Mandry', '0', '-1', '292851939', '18', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1516', '0', '85', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (85)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1517', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('1518', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('1519', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1521', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1525', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1526', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1527', '0', '0', '-1', '0', '0', '0', '100', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1528', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1529', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1530', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1531', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1532', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1533', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1534', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1535', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1536', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1537', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1538', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1539', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1540', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1541', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1542', '0', '0', '-1', '0', '46', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1543', '0', '0', '-1', '0', '47', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1544', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1546', '0', '0', '-1', '0', '0', '0', '5', 'Made', '0', '-1', '-1134789989', '0', '0', '17', '0.01', '5');
INSERT INTO `items` VALUES ('1547', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1549', '0', '0', '-1', '0', '0', '0', '1', 'Zigarretten', '0', '-1', '1120955680', '0', '0', '37', '0.09', '1');
INSERT INTO `items` VALUES ('1550', '0', '0', '-1', '0', '0', '0', '1', 'Spitzhacke', '0', '-1', '260873931', '0', '0', '24', '1.5', '1');
INSERT INTO `items` VALUES ('1552', '0', '0', '-1', '0', '0', '0', '1', 'Apfel', '0', '-1', '-2071489092', '0', '0', '29', '0.08', '20');
INSERT INTO `items` VALUES ('1556', '0', '0', '-1', '0', '0', '0', '1', 'Lockpick', '0', '-1', '-1134789989', '0', '0', '25', '0.1', '15');
INSERT INTO `items` VALUES ('1557', '0', '0', '-1', '0', '0', '0', '1', 'Benzinkanister Leer', '0', '-1', '-963445391', '0', '0', '28', '0.1', '1');
INSERT INTO `items` VALUES ('1558', '0', '0', '-1', '0', '0', '0', '5', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1560', '0', '0', '-1', '0', '0', '0', '1', 'Bier', '0', '-1', '1451528099', '0', '0', '34', '0.25', '5');
INSERT INTO `items` VALUES ('1563', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('1564', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1570', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1574', '0', '0', '-1', '0', '0', '0', '7', 'Munition', '0', '0', '-1899196150', '0', '0', '6', '0.03', '12');
INSERT INTO `items` VALUES ('1581', '0', '0', '-1', '0', '0', '0', '3', 'Werkzeugkasten', '0', '-1', '1871266393', '0', '0', '27', '0.8', '3');
INSERT INTO `items` VALUES ('1585', '0', '86', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (86)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1586', '0', '0', 'weapon_heavyrifle', '0', '0', '0', '1', 'Assault Rifle', '0', '-1', '273925117', '0', '0', '5', '2.9', '1');
INSERT INTO `items` VALUES ('1588', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1589', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1590', '0', '0', '-1', '0', '0', '0', '15', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1593', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1594', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1595', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1600', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.278185', '1');
INSERT INTO `items` VALUES ('1601', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.421385', '1');
INSERT INTO `items` VALUES ('1602', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.625593', '1');
INSERT INTO `items` VALUES ('1603', '0', '0', '-1', '0', '0', '0', '1', 'Kraken', '0', '-1', '-1134789989', '0', '0', '20', '0.457887', '1');
INSERT INTO `items` VALUES ('1604', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.212796', '1');
INSERT INTO `items` VALUES ('1607', '0', '0', '-1', '0', '0', '0', '1', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1617', '0', '0', '-1', '0', '48', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1618', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1619', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1620', '0', '0', '-1', '0', '0', '0', '30', 'Munition', '0', '2', '1044133150', '0', '0', '6', '0.06', '30');
INSERT INTO `items` VALUES ('1621', '0', '0', '-1', '0', '0', '131', '1', 'Modell: 103 | Mann', '0', '-1', '-1157632529', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1622', '0', '0', '-1', '0', '0', '132', '1', 'Modell: 7 | Mann', '0', '-1', '1682675077', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1623', '0', '0', '-1', '0', '0', '133', '1', 'Modell: 1 | Mann', '0', '-1', '578126062', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1624', '0', '0', '-1', '0', '0', '134', '1', 'Modell: 346 | Mann', '0', '-1', '-1256588656', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1625', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1626', '0', '0', '-1', '0', '0', '0', '1', 'Energy', '0', '-1', '1489222168', '0', '0', '33', '0.25', '5');
INSERT INTO `items` VALUES ('1627', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1630', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1632', '0', '0', '-1', '26', '0', '0', '1', 'Wohnungsschlüssel Test\nVespucci Blvd', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1633', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Marc Black', '0', '-1', '292851939', '19', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1634', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Hanna Mandry', '0', '-1', '292851939', '20', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1635', '0', '88', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (88)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1636', '0', '88', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (88)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1637', '0', '0', '-1', '0', '49', '0', '1', 'Rucksack größe 2', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1660', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1666', '0', '0', '-1', '0', '0', '135', '1', 'Modell: 5 | Mann', '0', '-1', '-1157632529', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1667', '0', '0', '-1', '0', '0', '136', '1', 'Modell: 7 | Mann', '0', '-1', '1682675077', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1668', '0', '0', '-1', '0', '0', '137', '1', 'Modell: 5 | Mann', '0', '-1', '-1256588656', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1669', '0', '0', '-1', '27', '0', '0', '1', 'Wohnungsschlüssel test\nAlta St', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1670', '0', '0', '-1', '0', '0', '0', '1', 'GPS gerät', '0', '-1', '-1585232418', '0', '0', '1', '0.4', '1');
INSERT INTO `items` VALUES ('1674', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1675', '0', '0', '-1', '0', '0', '0', '5', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1677', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.858556', '1');
INSERT INTO `items` VALUES ('1678', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.279575', '1');
INSERT INTO `items` VALUES ('1679', '0', '90', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (90)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1680', '0', '91', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (91)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1681', '0', '92', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (92)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1682', '0', '93', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (93)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1683', '0', '94', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (94)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1684', '0', '95', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (95)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1685', '0', '96', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (96)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1686', '0', '97', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (97)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1687', '0', '98', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (98)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1688', '0', '99', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (99)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1689', '0', '100', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (100)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1690', '0', '101', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (101)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1691', '0', '102', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (102)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1692', '0', '0', '-1', '0', '50', '0', '1', 'XXXDA', '0', '-1', '2096599423', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1693', '0', '103', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (103)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1694', '0', '104', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (104)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1695', '0', '105', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (105)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1696', '0', '106', '-1', '0', '0', '0', '1', 'Roter Elegy LS-09', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1697', '0', '0', '-1', '0', '0', '0', '1', 'Angel', '0', '-1', '-1910604593', '0', '0', '15', '0.3', '1');
INSERT INTO `items` VALUES ('1698', '0', '0', '-1', '0', '0', '0', '4', 'Wurm', '0', '-1', '-1134789989', '0', '0', '16', '0.01', '5');
INSERT INTO `items` VALUES ('1700', '0', '0', '-1', '0', '51', '0', '1', 'Rucksack größe 1', '0', '-1', '1203231469', '0', '0', '8', '0', '1');
INSERT INTO `items` VALUES ('1701', '0', '0', '-1', '0', '0', '0', '1', 'Modell: 1 | Mann', '42', '-1', '1169295068', '0', '0', '10', '0.15', '1');
INSERT INTO `items` VALUES ('1704', '0', '107', '-1', '0', '0', '0', '1', 'Barista New', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1705', '0', '108', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (108)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1706', '0', '0', '-1', '0', '0', '138', '1', 'Modell: 1 | Frau', '0', '-1', '-915071241', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1707', '0', '0', '-1', '0', '0', '139', '1', 'Modell: 1 | Mann', '0', '-1', '-915071241', '0', '0', '9', '0.25', '1');
INSERT INTO `items` VALUES ('1708', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Naruto Uzumaki', '0', '-1', '292851939', '24', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1709', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.223082', '1');
INSERT INTO `items` VALUES ('1710', '0', '0', '-1', '0', '0', '0', '1', 'Fisch', '0', '-1', '-1134789989', '0', '0', '18', '0.137158', '1');
INSERT INTO `items` VALUES ('1711', '0', '109', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (109)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1712', '0', '110', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (110)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1713', '0', '0', 'weapon_pumpshotgun', '0', '0', '0', '1', 'Pump Shotgun', '0', '-1', '689760839', '0', '0', '5', '1.8', '1');
INSERT INTO `items` VALUES ('1714', '0', '0', '-1', '0', '0', '0', '8', 'Munition', '0', '1', '-1793660294', '0', '0', '6', '0.05', '8');
INSERT INTO `items` VALUES ('1716', '0', '0', '-1', '0', '0', '0', '1', 'Neuer Schlüssel', '0', '-1', '494219267', '0', '0', '30', '0.1', '5');
INSERT INTO `items` VALUES ('1719', '0', '0', '-1', '0', '0', '0', '5', 'Made', '0', '-1', '-1134789989', '0', '0', '17', '0.01', '5');
INSERT INTO `items` VALUES ('1721', '0', '0', '-1', '28', '0', '0', '1', 'Wohnungsschlüssel Test\nSenora Fwy', '0', '-1', '494219267', '0', '0', '7', '0.2', '1');
INSERT INTO `items` VALUES ('1724', '0', '0', '-1', '0', '0', '0', '1', 'Wohnungsschlüssel', '0', '-1', '494219267', '0', '0', '7', '0.1', '5');
INSERT INTO `items` VALUES ('1725', '0', '0', '-1', '0', '0', '0', '1', 'Neuer Schlüssel', '0', '-1', '977923025', '0', '0', '38', '0.2', '1');
INSERT INTO `items` VALUES ('1726', '0', '0', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1727', '0', '0', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1729', '0', '0', '-1', '0', '0', '0', '1', 'Benzinkanister Leer', '0', '-1', '-963445391', '0', '0', '28', '0.1', '1');
INSERT INTO `items` VALUES ('1730', '0', '0', '-1', '0', '0', '0', '1', 'Benzinkanister Leer', '0', '-1', '-963445391', '0', '0', '28', '0.1', '1');
INSERT INTO `items` VALUES ('1731', '0', '0', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1732', '0', '111', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (111)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1737', '0', '0', '-1', '0', '0', '0', '1', 'Werkzeugkasten', '0', '-1', '1871266393', '0', '0', '27', '0.8', '3');
INSERT INTO `items` VALUES ('1738', '0', '0', '-1', '0', '0', '0', '1', 'Ausweis Naruto Uzumaki', '0', '-1', '292851939', '25', '0', '4', '0.3', '1');
INSERT INTO `items` VALUES ('1739', '0', '112', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (112)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');
INSERT INTO `items` VALUES ('1740', '0', '111', '-1', '0', '0', '0', '1', 'Fahrzeugschlüssel (111)', '0', '-1', '977923025', '0', '0', '2', '0.2', '1');

-- ----------------------------
-- Table structure for `ped_ankauf`
-- ----------------------------
DROP TABLE IF EXISTS `ped_ankauf`;
CREATE TABLE `ped_ankauf` (
  `id` int(11) NOT NULL,
  `course` int(11) DEFAULT NULL,
  `storage` int(11) DEFAULT NULL,
  `x` float DEFAULT NULL,
  `y` float DEFAULT NULL,
  `z` float DEFAULT NULL,
  `r` float DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ped_ankauf
-- ----------------------------
INSERT INTO `ped_ankauf` VALUES ('0', '24', '100', '-114.844', '-967.121', '27.2748', '0', '1');
INSERT INTO `ped_ankauf` VALUES ('1', '25', '100', '838.84', '2176.3', '52.2799', '-90', '1');
INSERT INTO `ped_ankauf` VALUES ('2', '54', '176', '1724.29', '3696.25', '34.4022', '0', '2');
INSERT INTO `ped_ankauf` VALUES ('3', '51', '155', '-195.653', '6265.09', '31.4872', '0', '2');

-- ----------------------------
-- Table structure for `perso`
-- ----------------------------
DROP TABLE IF EXISTS `perso`;
CREATE TABLE `perso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vname` varchar(255) NOT NULL DEFAULT 'Max',
  `nname` varchar(255) NOT NULL DEFAULT 'Mustermann',
  `age` varchar(50) NOT NULL DEFAULT '01.01.2000',
  `adress` varchar(255) NOT NULL DEFAULT 'Flughafen',
  `height` int(11) NOT NULL DEFAULT '0',
  `eyecolor` int(11) NOT NULL DEFAULT '1',
  `searched` int(11) NOT NULL DEFAULT '0',
  `socialclubid` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of perso
-- ----------------------------
INSERT INTO `perso` VALUES ('15', 'Hanna', 'Mandry', '3.1.1979', 'Adress', '180', '6', '1', '395995939');
INSERT INTO `perso` VALUES ('16', 'Hanna', 'Mandry', '3.1.1979', 'Adress', '180', '6', '1', '395995939');
INSERT INTO `perso` VALUES ('17', 'Hanna', 'Mandry', '3.1.1979', 'Adress', '180', '6', '1', '395995939');
INSERT INTO `perso` VALUES ('18', 'Hanna', 'Mandry', '3.1.1979', 'Adress', '180', '6', '1', '395995939');
INSERT INTO `perso` VALUES ('19', 'Marc', 'Black', '16.1.1972', 'Adress', '178', '1', '0', '374628655');
INSERT INTO `perso` VALUES ('20', 'Hanna', 'Mandry', '3.1.1979', 'Adress', '180', '6', '1', '395995939');
INSERT INTO `perso` VALUES ('21', 'Naruto', 'Uzumaki', '16.1.1974', 'Adress', '189', '9', '1', '395995939');
INSERT INTO `perso` VALUES ('22', 'Naruto', 'Uzumaki', '16.1.1974', 'Adress', '189', '9', '1', '395995939');
INSERT INTO `perso` VALUES ('23', 'Naruto', 'Uzumaki', '16.1.1974', 'Adress', '189', '9', '1', '395995939');
INSERT INTO `perso` VALUES ('24', 'Naruto', 'Uzumaki', '16.1.1974', 'Adress', '189', '9', '1', '395995939');
INSERT INTO `perso` VALUES ('25', 'Naruto', 'Uzumaki', '16.1.1974', 'Adress', '189', '9', '0', '395995939');

-- ----------------------------
-- Table structure for `props`
-- ----------------------------
DROP TABLE IF EXISTS `props`;
CREATE TABLE `props` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `componente` int(11) DEFAULT '0',
  `drawable` int(11) DEFAULT NULL,
  `texture` int(11) DEFAULT NULL,
  `sex` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of props
-- ----------------------------
INSERT INTO `props` VALUES ('35', '7', '2', '0', '1');
INSERT INTO `props` VALUES ('36', '7', '2', '1', '1');
INSERT INTO `props` VALUES ('37', '7', '1', '0', '1');
INSERT INTO `props` VALUES ('38', '6', '1', '0', '1');
INSERT INTO `props` VALUES ('39', '0', '145', '0', '1');
INSERT INTO `props` VALUES ('40', '1', '22', '0', '1');
INSERT INTO `props` VALUES ('41', '2', '1', '0', '1');
INSERT INTO `props` VALUES ('42', '6', '1', '0', '0');

-- ----------------------------
-- Table structure for `server`
-- ----------------------------
DROP TABLE IF EXISTS `server`;
CREATE TABLE `server` (
  `Hour` int(11) DEFAULT NULL,
  `Minute` int(11) DEFAULT NULL,
  `Second` int(11) DEFAULT NULL,
  `Day` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of server
-- ----------------------------
INSERT INTO `server` VALUES ('19', '8', '52', '16', '4', '2024', '0');

-- ----------------------------
-- Table structure for `store_24`
-- ----------------------------
DROP TABLE IF EXISTS `store_24`;
CREATE TABLE `store_24` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `x` float DEFAULT NULL,
  `y` float DEFAULT NULL,
  `z` float DEFAULT NULL,
  `konto` int(11) DEFAULT NULL,
  `open` int(11) DEFAULT NULL,
  `products` int(11) DEFAULT NULL,
  `eat` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `owner` varchar(255) DEFAULT NULL,
  `owned` int(11) DEFAULT NULL,
  `ped_x` float DEFAULT NULL,
  `ped_y` float DEFAULT NULL,
  `ped_z` float DEFAULT NULL,
  `ped_r` float DEFAULT NULL,
  `sellprice` int(11) DEFAULT NULL,
  `p1` int(11) DEFAULT '0',
  `p1_price` int(11) DEFAULT '0',
  `p2` int(11) DEFAULT '0',
  `p2_price` int(11) DEFAULT '0',
  `p3` int(11) DEFAULT '0',
  `p3_price` int(11) DEFAULT '0',
  `p4` int(11) DEFAULT '0',
  `p4_price` int(11) DEFAULT '0',
  `p5` int(11) DEFAULT '0',
  `p5_price` int(11) DEFAULT '0',
  `p6` int(11) DEFAULT '0',
  `p6_price` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of store_24
-- ----------------------------
INSERT INTO `store_24` VALUES ('1', '1741.4', '6419.55', '35.0425', '300', '1', '581', '500', 'Lala Shop', 'Hanna Mandry', '395995939', '1727.62', '6414.83', '35.0256', '-120', '0', '25', '0', '27', '0', '29', '0', '38', '0', '33', '0', '35', '0');
INSERT INTO `store_24` VALUES ('2', '1961.09', '3753.92', '32.2454', '0', '1', '1000', '500', '24/7', '', '0', '1960.31', '3739.61', '32.3297', '-60', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('3', '542.149', '2663.64', '42.3553', '0', '1', '1000', '500', '24/7', '', '0', '549.073', '2671.71', '42.1531', '90', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('4', '-3248.39', '1007.45', '12.8176', '0', '1', '1000', '500', '24/7', '', '0', '-3242.32', '999.917', '12.8176', '-10', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('5', '31.3714', '-1340.77', '29.4821', '30', '1', '882', '500', '24/7', 'Marc Black', '374628655', '24.4088', '-1347.49', '29.4821', '-100', '0', '15', '5', '28', '5', '29', '5', '1', '5', '33', '5', '0', '0');
INSERT INTO `store_24` VALUES ('6', '380.862', '331.095', '103.554', '0', '1', '1000', '500', '24/7', '', '0', '372.58', '326.73', '103.554', '-100', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('7', '-3047.56', '589.002', '7.89746', '0', '1', '1000', '500', '24/7', '', '0', '-3038.74', '584.532', '7.89746', '10', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('8', '2551.04', '387.969', '108.609', '0', '1', '1000', '500', '24/7', '', '0', '2557.19', '380.796', '108.609', '-20', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `store_24` VALUES ('9', '2675.71', '3288.61', '55.2285', '0', '1', '1000', '500', '24/7', '', '0', '2677.74', '3279.51', '55.2285', '-40', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for `vehicle_handschuh`
-- ----------------------------
DROP TABLE IF EXISTS `vehicle_handschuh`;
CREATE TABLE `vehicle_handschuh` (
  `itemid` int(11) NOT NULL,
  `slot` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  PRIMARY KEY (`itemid`,`slot`,`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicle_handschuh
-- ----------------------------
INSERT INTO `vehicle_handschuh` VALUES ('1706', '2', '110');
INSERT INTO `vehicle_handschuh` VALUES ('1707', '3', '110');
INSERT INTO `vehicle_handschuh` VALUES ('1709', '0', '110');
INSERT INTO `vehicle_handschuh` VALUES ('1710', '1', '110');

-- ----------------------------
-- Table structure for `vehicle_inv`
-- ----------------------------
DROP TABLE IF EXISTS `vehicle_inv`;
CREATE TABLE `vehicle_inv` (
  `id` int(11) NOT NULL,
  `itemid` int(11) NOT NULL,
  `slot` int(11) NOT NULL,
  PRIMARY KEY (`itemid`,`id`,`slot`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicle_inv
-- ----------------------------
INSERT INTO `vehicle_inv` VALUES ('72', '574', '1');
INSERT INTO `vehicle_inv` VALUES ('72', '584', '8');
INSERT INTO `vehicle_inv` VALUES ('81', '1502', '5');
INSERT INTO `vehicle_inv` VALUES ('81', '1507', '2');
INSERT INTO `vehicle_inv` VALUES ('81', '1508', '3');
INSERT INTO `vehicle_inv` VALUES ('81', '1509', '1');
INSERT INTO `vehicle_inv` VALUES ('81', '1511', '0');
INSERT INTO `vehicle_inv` VALUES ('85', '1512', '0');
INSERT INTO `vehicle_inv` VALUES ('83', '1513', '0');
INSERT INTO `vehicle_inv` VALUES ('81', '1515', '4');
INSERT INTO `vehicle_inv` VALUES ('81', '1543', '7');
INSERT INTO `vehicle_inv` VALUES ('72', '1544', '13');

-- ----------------------------
-- Table structure for `vehicleMods`
-- ----------------------------
DROP TABLE IF EXISTS `vehicleMods`;
CREATE TABLE `vehicleMods` (
  `id` tinyint(11) NOT NULL,
  `type` tinyint(11) NOT NULL,
  `value` tinyint(11) NOT NULL,
  PRIMARY KEY (`id`,`type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicleMods
-- ----------------------------
INSERT INTO `vehicleMods` VALUES ('111', '0', '14');
INSERT INTO `vehicleMods` VALUES ('111', '1', '6');
INSERT INTO `vehicleMods` VALUES ('111', '2', '2');
INSERT INTO `vehicleMods` VALUES ('111', '3', '5');
INSERT INTO `vehicleMods` VALUES ('111', '4', '8');
INSERT INTO `vehicleMods` VALUES ('111', '5', '3');
INSERT INTO `vehicleMods` VALUES ('111', '7', '6');
INSERT INTO `vehicleMods` VALUES ('111', '8', '5');
INSERT INTO `vehicleMods` VALUES ('111', '11', '4');
INSERT INTO `vehicleMods` VALUES ('111', '12', '3');
INSERT INTO `vehicleMods` VALUES ('111', '13', '2');
INSERT INTO `vehicleMods` VALUES ('111', '14', '10');
INSERT INTO `vehicleMods` VALUES ('111', '18', '1');
INSERT INTO `vehicleMods` VALUES ('111', '22', '1');
INSERT INTO `vehicleMods` VALUES ('111', '44', '2');
INSERT INTO `vehicleMods` VALUES ('111', '48', '4');
INSERT INTO `vehicleMods` VALUES ('112', '0', '10');
INSERT INTO `vehicleMods` VALUES ('112', '1', '5');
INSERT INTO `vehicleMods` VALUES ('112', '2', '1');
INSERT INTO `vehicleMods` VALUES ('112', '3', '3');
INSERT INTO `vehicleMods` VALUES ('112', '4', '6');
INSERT INTO `vehicleMods` VALUES ('112', '5', '5');
INSERT INTO `vehicleMods` VALUES ('112', '6', '3');
INSERT INTO `vehicleMods` VALUES ('112', '7', '12');
INSERT INTO `vehicleMods` VALUES ('112', '8', '4');
INSERT INTO `vehicleMods` VALUES ('112', '10', '4');
INSERT INTO `vehicleMods` VALUES ('112', '11', '4');
INSERT INTO `vehicleMods` VALUES ('112', '12', '3');
INSERT INTO `vehicleMods` VALUES ('112', '13', '3');
INSERT INTO `vehicleMods` VALUES ('112', '14', '38');
INSERT INTO `vehicleMods` VALUES ('112', '18', '1');
INSERT INTO `vehicleMods` VALUES ('112', '22', '1');
INSERT INTO `vehicleMods` VALUES ('112', '25', '1');
INSERT INTO `vehicleMods` VALUES ('112', '27', '1');
INSERT INTO `vehicleMods` VALUES ('112', '30', '5');
INSERT INTO `vehicleMods` VALUES ('112', '31', '7');
INSERT INTO `vehicleMods` VALUES ('112', '32', '12');
INSERT INTO `vehicleMods` VALUES ('112', '33', '12');
INSERT INTO `vehicleMods` VALUES ('112', '43', '11');
INSERT INTO `vehicleMods` VALUES ('112', '44', '1');
INSERT INTO `vehicleMods` VALUES ('112', '45', '5');
INSERT INTO `vehicleMods` VALUES ('112', '46', '1');
INSERT INTO `vehicleMods` VALUES ('112', '48', '3');

-- ----------------------------
-- Table structure for `vehicleNeon`
-- ----------------------------
DROP TABLE IF EXISTS `vehicleNeon`;
CREATE TABLE `vehicleNeon` (
  `id` int(11) NOT NULL,
  `R` int(11) DEFAULT NULL,
  `G` int(11) DEFAULT NULL,
  `B` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicleNeon
-- ----------------------------
INSERT INTO `vehicleNeon` VALUES ('111', '0', '8', '255');
INSERT INTO `vehicleNeon` VALUES ('112', '117', '0', '0');

-- ----------------------------
-- Table structure for `vehicles`
-- ----------------------------
DROP TABLE IF EXISTS `vehicles`;
CREATE TABLE `vehicles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vehicleName` varchar(255) DEFAULT NULL,
  `x` float(11,0) NOT NULL,
  `y` float(11,0) NOT NULL,
  `z` float(11,0) NOT NULL,
  `r_roll` float NOT NULL DEFAULT '0',
  `r_pitch` float NOT NULL DEFAULT '0',
  `r_yaw` float NOT NULL,
  `vehlock` int(11) DEFAULT NULL,
  `color_r` int(11) DEFAULT NULL,
  `color_g` int(11) DEFAULT NULL,
  `color_b` int(11) DEFAULT NULL,
  `color_r2` int(11) DEFAULT NULL,
  `color_g2` int(11) DEFAULT NULL,
  `color_b2` int(11) DEFAULT NULL,
  `rangestand` int(11) DEFAULT '0',
  `fill` float DEFAULT '0',
  `price` int(11) DEFAULT '0',
  `plate` varchar(255) DEFAULT 'New',
  `ownername` varchar(255) DEFAULT 'Niemand',
  `ownersocialclub` int(11) DEFAULT '0',
  `engineon` int(11) DEFAULT '0',
  `lockstate` tinyint(4) DEFAULT '0',
  `maxspeed` tinyint(4) DEFAULT '110',
  `factionid` int(11) DEFAULT '0',
  `bodyhealth` int(11) DEFAULT '1000',
  `enginehealth` int(11) DEFAULT '1000',
  `motordamage` tinyint(1) DEFAULT '0',
  `death` tinyint(1) DEFAULT '0',
  `anchoractive` tinyint(4) DEFAULT '0',
  `tuev` datetime DEFAULT NULL,
  `noscharges` int(11) DEFAULT '0',
  `chip` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicles
-- ----------------------------
INSERT INTO `vehicles` VALUES ('70', 'youga', '-198', '6229', '31', '0.000275381', '0.000937349', '0.999301', '2', '185', '133', '1', '120', '195', '71', '0', '0', '6000', 'New', 'Hanna Mandry', '395995939', '0', '2', '27', '0', '696', '982', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('71', 'faggio', '-93', '-1292', '29', '-0.254699', '-0.0590601', '-1.3428', '1', '188', '247', '164', '8', '199', '206', '142', '0', '300', 'New', 'Hanna Mandry', '395995939', '0', '1', '15', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('72', 'bobcatxl', '-582', '5255', '70', '-0.00201787', '0.000837249', '2.99846', '1', '0', '0', '0', '0', '0', '0', '153', '0', '0', 'New', 'Niemand', '0', '0', '1', '-1', '0', '0', '-4000', '1', '1', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('73', 'trash', '-346', '-1564', '25', '-0.00280834', '-0.0103741', '-2.09953', '1', '0', '255', '0', '0', '0', '0', '1033', '0', '0', 'LS73', 'Niemand', '0', '0', '1', '-1', '1', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('74', 'trash', '60', '6468', '31', '0.00269829', '-0.0011447', '-2.37323', '1', '0', '100', '0', '0', '0', '0', '26', '28.4718', '0', 'LS74', 'Niemand', '0', '0', '1', '-1', '1', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('75', 'trash', '48', '6457', '31', '0.0158487', '0.0175305', '-2.00261', '2', '0', '100', '0', '241', '1', '0', '12', '0', '0', 'LS75', 'Niemand', '0', '0', '2', '-1', '1', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('76', 'trash', '42', '6450', '31', '0.0132422', '0.0011186', '-1.99926', '2', '0', '100', '0', '241', '1', '0', '16', '0', '0', 'LS76', 'Niemand', '0', '0', '2', '-1', '1', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('77', 'trash', '35', '6444', '31', '0.00759788', '0.007346', '-1.99929', '1', '0', '100', '0', '241', '1', '0', '15', '0', '0', 'LS77', 'Niemand', '0', '0', '1', '-1', '1', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('78', 'marquis', '-4160', '1302', '1', '-0.0160161', '0.0261515', '1.59988', '1', '255', '255', '255', '0', '0', '0', '3093', '37.6524', '0', 'LS78', 'Niemand', '0', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('79', 'jetmax', '-843', '-1502', '0', '0.013148', '-0.0196373', '1.71246', '1', '192', '192', '199', '244', '188', '203', '916', '0', '60000', 'New', 'Hanna Mandry', '395995939', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('80', 'suntrap', '869', '4001', '30', '0.0425374', '-0.122515', '-1.62772', '1', '24', '62', '217', '246', '154', '200', '2074', '0', '30000', 'New', 'Hanna Mandry', '395995939', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('81', 'elegy', '529', '-175', '54', '0.0275999', '0.0604636', '0.685124', '1', '255', '0', '0', '0', '0', '0', '384', '0', '0', 'LS81', 'Niemand', '0', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-04-03 18:49:37', '0', '0');
INSERT INTO `vehicles` VALUES ('82', 'marquis', '-819', '-1473', '0', '-0.0167813', '0.00947358', '2.62109', '1', '12', '31', '13', '75', '211', '58', '323', '0', '80000', 'New', 'Leon Bergsen', '348091326', '0', '1', '-1', '0', '1000', '1000', '0', '0', '1', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('83', 'speeder', '-735', '-1477', '5', '0.00318043', '-0.00370808', '-2.00747', '1', '10', '72', '228', '135', '19', '38', '216', '0', '50000', 'New', 'Hanna Mandry', '395995939', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('84', 'bobcatxl', '-815', '-1519', '-10', '0.000209185', '-0.00762808', '0.236138', '1', '0', '255', '0', '0', '0', '0', '504', '51.8135', '0', 'LS84', 'Niemand', '0', '0', '1', '-1', '0', '981', '995', '0', '1', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('85', 'bobcatxl', '-783', '-1460', '5', '0.000268722', '0.00093928', '1.0135', '1', '0', '0', '255', '0', '0', '0', '295', '0', '0', 'LS85', 'Niemand', '0', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('86', 'police', '-943', '-193', '37', '0.0463806', '0.0531911', '1.41256', '1', '255', '255', '255', '0', '0', '0', '4530', '50.389', '0', 'LS86', 'Niemand', '0', '0', '1', '-1', '0', '0', '-4000', '1', '1', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('87', 'elegy', '-1014', '6313', '1', '-0.147862', '0.509964', '0.545785', '2', '0', '0', '255', '0', '0', '0', '142', '59.8641', '0', 'LS87', 'Niemand', '0', '0', '2', '-1', '0', '1000', '1000', '0', '1', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('88', 'elegy', '-556', '5258', '71', '-0.193105', '-0.0716771', '2.17522', '1', '255', '0', '0', '0', '0', '0', '474', '0', '0', 'LS88', 'Niemand', '0', '0', '1', '-1', '0', '998', '999', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('89', 'flatbed', '-152', '-2030', '23', '0.00415905', '-0.00799029', '-0.173612', '1', '0', '0', '255', '0', '0', '0', '342', '0', '0', 'LS89', 'Niemand', '0', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('105', 'flatbed', '-57', '-1107', '27', '0.00062468', '0.000751155', '0.183337', '1', '0', '255', '255', '153', '32', '89', '3083', '52.7952', '0', 'LS105', 'Niemand', '0', '0', '1', '-1', '0', '998', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('106', 'adder', '-366', '-128', '38', '0.00158897', '0.00149932', '-2.27231', '1', '254', '22', '22', '17', '13', '242', '2595', '18.3647', '4500', 'New', 'Naruto Uzumaki', '395995939', '0', '1', '-1', '0', '618', '890', '1', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('107', 'baller3', '-1167', '-2014', '13', '0.000362616', '-0.000907176', '-0.810268', '2', '6', '204', '254', '0', '0', '0', '6674', '0', '2500', 'New', 'Naruto Uzumaki', '395995939', '0', '2', '-1', '0', '993', '989', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('108', 'stanier', '735', '-2577', '18', '0.029702', '0.00216469', '0.00618639', '1', '204', '150', '0', '252', '252', '252', '0', '60', '1000', 'New', 'Naruto Uzumaki', '395995939', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('109', 'elegy', '975', '-2985', '5', '-0.00000855356', '0.000976927', '1.58831', '1', '255', '255', '255', '255', '255', '255', '0', '0', '3000', 'New', 'Naruto Uzumaki', '395995939', '0', '1', '-1', '0', '1000', '1000', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('110', 'infernus', '347', '-2508', '5', '0.0384154', '-0.0445721', '0.0181358', '1', '70', '242', '7', '244', '1', '1', '4287', '42.0212', '8000', 'New', 'Naruto Uzumaki', '395995939', '0', '1', '-1', '0', '666', '872', '0', '0', '0', '2024-03-06 22:59:52', '0', '0');
INSERT INTO `vehicles` VALUES ('111', 'elegy', '-1940', '4591', '56', '-0.00271178', '-0.00111237', '-0.792264', '1', '255', '255', '255', '255', '255', '255', '107249', '37.8449', '0', 'LS111', 'Niemand', '0', '1', '1', '-1', '0', '869', '988', '0', '0', '0', '1995-03-10 10:12:30', '1', '20');
INSERT INTO `vehicles` VALUES ('112', 'elegy', '-1993', '4644', '-1', '-0.0809835', '-0.0147304', '0.886282', '1', '255', '0', '0', '194', '0', '0', '30241', '25.0983', '0', 'LS112', 'Niemand', '0', '0', '1', '-1', '0', '909', '891', '1', '1', '0', '1995-03-10 10:12:30', '0', '50');

-- ----------------------------
-- Table structure for `vehicleWheels`
-- ----------------------------
DROP TABLE IF EXISTS `vehicleWheels`;
CREATE TABLE `vehicleWheels` (
  `id` int(11) NOT NULL,
  `type` int(11) DEFAULT NULL,
  `color` int(11) DEFAULT NULL,
  `value` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicleWheels
-- ----------------------------
INSERT INTO `vehicleWheels` VALUES ('111', '7', '93', '37');
INSERT INTO `vehicleWheels` VALUES ('112', '0', '115', '8');

-- ----------------------------
-- Table structure for `vehicleWheelsHealth`
-- ----------------------------
DROP TABLE IF EXISTS `vehicleWheelsHealth`;
CREATE TABLE `vehicleWheelsHealth` (
  `id` int(11) NOT NULL,
  `wheel` int(11) NOT NULL,
  PRIMARY KEY (`id`,`wheel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of vehicleWheelsHealth
-- ----------------------------

-- ----------------------------
-- Table structure for `wardrobe`
-- ----------------------------
DROP TABLE IF EXISTS `wardrobe`;
CREATE TABLE `wardrobe` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL,
  `size` int(11) NOT NULL,
  `dimension` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of wardrobe
-- ----------------------------
INSERT INTO `wardrobe` VALUES ('1', '0', '0', '72', '10', '0');
INSERT INTO `wardrobe` VALUES ('2', '151.767', '-1001.54', '-99.0146', '10', '0');
INSERT INTO `wardrobe` VALUES ('3', '151.767', '-1001.54', '-99.0146', '10', '22');
INSERT INTO `wardrobe` VALUES ('4', '151.767', '-1001.54', '-99.0146', '10', '23');
INSERT INTO `wardrobe` VALUES ('5', '151.767', '-1001.54', '-99.0146', '10', '24');
INSERT INTO `wardrobe` VALUES ('6', '151.767', '-1001.54', '-99.0146', '10', '25');
INSERT INTO `wardrobe` VALUES ('7', '151.767', '-1001.54', '-99.0146', '10', '27');
INSERT INTO `wardrobe` VALUES ('8', '151.767', '-1001.54', '-99.0146', '10', '28');

-- ----------------------------
-- Table structure for `Wardrobe_Inv`
-- ----------------------------
DROP TABLE IF EXISTS `Wardrobe_Inv`;
CREATE TABLE `Wardrobe_Inv` (
  `Id` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `Slot` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`ItemId`,`Slot`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of Wardrobe_Inv
-- ----------------------------
INSERT INTO `Wardrobe_Inv` VALUES ('1', '1468', '0');
INSERT INTO `Wardrobe_Inv` VALUES ('1', '1474', '2');
INSERT INTO `Wardrobe_Inv` VALUES ('1', '1491', '7');
INSERT INTO `Wardrobe_Inv` VALUES ('1', '1493', '2');
INSERT INTO `Wardrobe_Inv` VALUES ('1', '1500', '0');
INSERT INTO `Wardrobe_Inv` VALUES ('4', '1504', '0');
INSERT INTO `Wardrobe_Inv` VALUES ('4', '1505', '1');
INSERT INTO `Wardrobe_Inv` VALUES ('4', '1506', '2');
INSERT INTO `Wardrobe_Inv` VALUES ('6', '1356', '0');
