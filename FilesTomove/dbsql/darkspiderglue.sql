-- phpMyAdmin SQL Dump
-- version 3.3.9.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 18, 2013 at 09:26 PM
-- Server version: 5.6.14
-- PHP Version: 5.4.14

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `darkspiderglue`
--

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_applications`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_applications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `my_aspnet_applications`
--

INSERT INTO `my_aspnet_applications` (`id`, `name`, `description`) VALUES
(1, '/', 'MySQL Session State Store Provider');

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_membership`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_membership` (
  `userId` int(11) NOT NULL DEFAULT '0',
  `Email` varchar(128) DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` char(32) DEFAULT NULL,
  `PasswordFormat` tinyint(4) DEFAULT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='2';

--
-- Dumping data for table `my_aspnet_membership`
--

INSERT INTO `my_aspnet_membership` (`userId`, `Email`, `Comment`, `Password`, `PasswordKey`, `PasswordFormat`, `PasswordQuestion`, `PasswordAnswer`, `IsApproved`, `LastActivityDate`, `LastLoginDate`, `LastPasswordChangedDate`, `CreationDate`, `IsLockedOut`, `LastLockedOutDate`, `FailedPasswordAttemptCount`, `FailedPasswordAttemptWindowStart`, `FailedPasswordAnswerAttemptCount`, `FailedPasswordAnswerAttemptWindowStart`) VALUES
(1, 'aaaa@gg.gr', '', 'jK9SMzDwFoxftQX5opHAC81KJ63ngZAjuV5crwe/TI8=', '5gGVYUCmdYU9lpriM3BaKQ==', 1, NULL, NULL, 1, '2013-11-17 16:39:05', '2013-11-17 16:39:05', '2013-11-16 23:01:18', '2013-11-16 23:01:18', 0, '2013-11-16 23:01:18', 0, '2013-11-16 23:01:18', 0, '2013-11-16 23:01:18');

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_profiles`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_profiles` (
  `userId` int(11) NOT NULL,
  `valueindex` longtext,
  `stringdata` longtext,
  `binarydata` longblob,
  `lastUpdatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `my_aspnet_profiles`
--


-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_roles`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC AUTO_INCREMENT=3 ;

--
-- Dumping data for table `my_aspnet_roles`
--

INSERT INTO `my_aspnet_roles` (`id`, `applicationId`, `name`) VALUES
(1, 1, 'Administrator'),
(2, 1, 'User');

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_schemaversion`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_schemaversion` (
  `version` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `my_aspnet_schemaversion`
--

INSERT INTO `my_aspnet_schemaversion` (`version`) VALUES
(8);

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_sessioncleanup`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_sessioncleanup` (
  `LastRun` datetime NOT NULL,
  `IntervalMinutes` int(11) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  PRIMARY KEY (`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `my_aspnet_sessioncleanup`
--

INSERT INTO `my_aspnet_sessioncleanup` (`LastRun`, `IntervalMinutes`, `ApplicationId`) VALUES
('2013-11-17 17:13:02', 10, 1);

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_sessions`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_sessions` (
  `SessionId` varchar(191) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  `Expires` datetime NOT NULL,
  `LockDate` datetime NOT NULL,
  `LockId` int(11) NOT NULL,
  `Timeout` int(11) NOT NULL,
  `Locked` tinyint(1) NOT NULL,
  `SessionItems` longblob,
  `Flags` int(11) NOT NULL,
  PRIMARY KEY (`SessionId`,`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `my_aspnet_sessions`
--

INSERT INTO `my_aspnet_sessions` (`SessionId`, `ApplicationId`, `Created`, `Expires`, `LockDate`, `LockId`, `Timeout`, `Locked`, `SessionItems`, `Flags`) VALUES
('41qjoz3dzilidl53ixvkm2kh', 1, '2013-11-17 17:08:35', '2013-11-17 17:29:55', '2013-11-17 17:09:55', 4, 20, 0, NULL, 0),
('gamxqrk3xg5qfvpmqco5jk43', 1, '2013-11-17 17:12:59', '2013-11-17 17:34:10', '2013-11-17 17:14:10', 5, 20, 0, NULL, 0),
('j32eh4ysxn3ei2ovl5vxfn2t', 1, '2013-11-17 17:14:44', '2013-11-17 17:35:36', '2013-11-17 17:15:36', 3, 20, 0, NULL, 0),
('jbcew00guvdmb1yjrsvfji5k', 1, '2013-11-17 17:17:52', '2013-11-17 17:38:47', '2013-11-17 17:18:47', 4, 20, 0, NULL, 0),
('u0ljjufyhg3iersdgg1xr302', 1, '2013-11-17 17:02:28', '2013-11-17 17:23:20', '2013-11-17 17:03:20', 4, 20, 0, NULL, 0),
('wfvjnwmrmodmfkmj2voonnhy', 1, '2013-11-17 16:55:44', '2013-11-17 17:17:07', '2013-11-17 16:57:07', 5, 20, 0, NULL, 0),
('xp3oixxqd5yqr5pumfyklafu', 1, '2013-11-17 16:54:10', '2013-11-17 17:15:11', '2013-11-17 16:55:11', 4, 20, 0, NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_users`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `isAnonymous` tinyint(1) NOT NULL DEFAULT '1',
  `lastActivityDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `my_aspnet_users`
--

INSERT INTO `my_aspnet_users` (`id`, `applicationId`, `name`, `isAnonymous`, `lastActivityDate`) VALUES
(1, 1, 'administrator', 0, '2013-11-17 16:39:05');

-- --------------------------------------------------------

--
-- Table structure for table `my_aspnet_usersinroles`
--

CREATE TABLE IF NOT EXISTS `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL DEFAULT '0',
  `roleId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `my_aspnet_usersinroles`
--

INSERT INTO `my_aspnet_usersinroles` (`userId`, `roleId`) VALUES
(1, 1);
