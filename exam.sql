-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.19-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for evergreen
CREATE DATABASE IF NOT EXISTS `evergreen` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `evergreen`;

-- Dumping structure for table evergreen.fgmats
CREATE TABLE IF NOT EXISTS `fgmats` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product` text NOT NULL,
  `description` text NOT NULL,
  `qty` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `uom` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table evergreen.fgmats: ~3 rows (approximately)
/*!40000 ALTER TABLE `fgmats` DISABLE KEYS */;
INSERT INTO `fgmats` (`id`, `product`, `description`, `qty`, `uom`) VALUES
	(1, 'Tire', 'Tread', 1.0000, 'pcs'),
	(2, 'Tire', 'Beadwires', 2.0000, 'pcs'),
	(3, 'Tire', 'Plys', 3.0000, 'pcs');
/*!40000 ALTER TABLE `fgmats` ENABLE KEYS */;

-- Dumping structure for table evergreen.fgone
CREATE TABLE IF NOT EXISTS `fgone` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` text NOT NULL,
  `fgtwomatsid` int(11) NOT NULL,
  `fgtwomatsqty` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `fgtwouom` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_fgthree_fgtwo` (`fgtwomatsid`),
  CONSTRAINT `FK_fgthree_fgtwo` FOREIGN KEY (`fgtwomatsid`) REFERENCES `fgtwo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table evergreen.fgone: ~5 rows (approximately)
/*!40000 ALTER TABLE `fgone` DISABLE KEYS */;
INSERT INTO `fgone` (`id`, `description`, `fgtwomatsid`, `fgtwomatsqty`, `fgtwouom`) VALUES
	(1, 'Tire', 1, 1.0000, 'kgs'),
	(2, 'Tire', 2, 0.5000, 'kgs'),
	(3, 'Tire', 3, 0.2500, 'kgs'),
	(4, 'Tire', 4, 0.6000, 'kgs'),
	(5, 'Tire', 4, 0.4000, 'kgs');
/*!40000 ALTER TABLE `fgone` ENABLE KEYS */;

-- Dumping structure for table evergreen.fgthree
CREATE TABLE IF NOT EXISTS `fgthree` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fgid` int(11) NOT NULL,
  `description` text NOT NULL,
  `qty` int(11) DEFAULT NULL,
  `rawmatsid` int(11) NOT NULL,
  `rawmatsqty` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `rawmatsuom` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_fgone_rawmats` (`rawmatsid`),
  CONSTRAINT `FK_fgone_rawmats` FOREIGN KEY (`rawmatsid`) REFERENCES `rawmats` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Dumping data for table evergreen.fgthree: ~6 rows (approximately)
/*!40000 ALTER TABLE `fgthree` DISABLE KEYS */;
INSERT INTO `fgthree` (`id`, `fgid`, `description`, `qty`, `rawmatsid`, `rawmatsqty`, `rawmatsuom`) VALUES
	(1, 1, 'Final Rubber', 1, 2, 0.8000, 'kgs'),
	(2, 1, 'Final Rubber', 1, 3, 0.1000, 'kgs'),
	(3, 1, 'Final Rubber', 1, 4, 0.0200, 'grams'),
	(4, 1, 'Final Rubber', 1, 5, 0.0400, 'grams'),
	(5, 1, 'Final Rubber', 1, 6, 0.0600, 'grams'),
	(6, 0, 'None', 0, 8, 0.0000, 'grams');
/*!40000 ALTER TABLE `fgthree` ENABLE KEYS */;

-- Dumping structure for table evergreen.fgtwo
CREATE TABLE IF NOT EXISTS `fgtwo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` text NOT NULL,
  `fgthreematsid` int(11) NOT NULL,
  `fgthreeqty` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `rawmatsid` int(11) NOT NULL,
  `rawmatsqty` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `rawmatsuom` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_fgtwo_fgone` (`fgthreematsid`),
  KEY `FK_fgtwo_rawmats` (`rawmatsid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Dumping data for table evergreen.fgtwo: ~4 rows (approximately)
/*!40000 ALTER TABLE `fgtwo` DISABLE KEYS */;
INSERT INTO `fgtwo` (`id`, `description`, `fgthreematsid`, `fgthreeqty`, `rawmatsid`, `rawmatsqty`, `rawmatsuom`) VALUES
	(1, 'Tread', 1, 2.0000, 8, 0.0000, 'kgs'),
	(2, 'Beadwires', 0, 0.0000, 7, 0.2500, 'kgs'),
	(3, 'Beadwires', 1, 0.1250, 8, 0.0000, 'kgs'),
	(4, 'Plys', 0, 0.0000, 1, 0.2000, 'kgs'),
	(5, 'Plys', 1, 0.1330, 8, 0.0000, 'kgs');
/*!40000 ALTER TABLE `fgtwo` ENABLE KEYS */;

-- Dumping structure for table evergreen.rawmats
CREATE TABLE IF NOT EXISTS `rawmats` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `materialdesc` text NOT NULL,
  `materialqty` decimal(11,2) NOT NULL DEFAULT '0.00',
  `materialuom` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Dumping data for table evergreen.rawmats: ~8 rows (approximately)
/*!40000 ALTER TABLE `rawmats` DISABLE KEYS */;
INSERT INTO `rawmats` (`id`, `materialdesc`, `materialqty`, `materialuom`) VALUES
	(1, 'Nylon', 100.00, 'kgs'),
	(2, 'Natural Rubber', 100.00, 'kgs'),
	(3, 'Synthetic Rubber', 100.00, 'kgs'),
	(4, 'Chemical #1', 100.00, 'grams'),
	(5, 'Chemical #2', 100.00, 'grams'),
	(6, 'Chemical #3', 100.00, 'grams'),
	(7, 'Wire', 100.00, 'kgs'),
	(8, 'NONE', 0.00, 'kgs');
/*!40000 ALTER TABLE `rawmats` ENABLE KEYS */;

-- Dumping structure for procedure evergreen.sr_GET_COMPUTERAWMATS
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sr_GET_COMPUTERAWMATS`(
	IN `pfbqty` DECIMAL(11,4)


)
BEGIN
SELECT 
rm.materialdesc as description,
(CASE
	WHEN th.rawmatsuom = 'grams' THEN
	((th.rawmatsqty * 1000) * pfbqty)
	ELSE
	(th.rawmatsqty * pfbqty)
END) AS qty,

th.rawmatsuom as uom
FROM fgthree th
INNER JOIN rawmats rm
ON th.rawmatsid = rm.id
WHERE rm.materialdesc != 'NONE';

END//
DELIMITER ;

-- Dumping structure for procedure evergreen.sr_GET_MATS2
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sr_GET_MATS2`(
	IN `pqty` DECIMAL(11,4)
)
BEGIN
SELECT Description, (qty * pqty) as qty, uom FROM fgmats;
END//
DELIMITER ;

-- Dumping structure for procedure evergreen.sr_GET_MATS3
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sr_GET_MATS3`(
	IN `pqty` DECIMAL(11,4)


)
BEGIN

SELECT Material as description, FORMAT(ROUND(SUM(A.qty),2),4) AS Qty, hasraw, uom  FROM
(
SELECT --   *,
-- tw.description 'MAT1',
-- fm.qty AS mat1qty,
(CASE
	WHEN tw.fgthreematsid > 0 THEN
		th.description
	ELSE
		rm.materialdesc
END) AS Material ,
(
CASE
	WHEN tw.fgthreematsid > 0 THEN
		tw.fgthreeqty * (fm.qty * pqty)
	ELSE
		tw.rawmatsqty * (fm.qty * pqty)
END) AS qty,
fm.uom,
(
CASE
	WHEN tw.fgthreematsid > 0 THEN
		1
	ELSE
		0
END
) as hasraw
FROM fgtwo tw
LEFT JOIN fgthree th ON tw.fgthreematsid = th.id
LEFT JOIN rawmats rm ON tw.rawmatsid = rm.id
INNER JOIN fgmats fm ON tw.description = fm.description
) AS A GROUP BY a.Material;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
