-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Dec 30, 2018 at 04:54 AM
-- Server version: 5.7.21
-- PHP Version: 7.1.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ql_ban_hang`
--

-- --------------------------------------------------------

--
-- Table structure for table `loai_san_pham`
--

DROP TABLE IF EXISTS `loai_san_pham`;
CREATE TABLE IF NOT EXISTS `loai_san_pham` (
  `ma_loai` int(11) NOT NULL AUTO_INCREMENT,
  `ten_loai` text COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`ma_loai`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `loai_san_pham`
--

INSERT INTO `loai_san_pham` (`ma_loai`, `ten_loai`) VALUES
(2, 'loại 2'),
(3, 'Loại 3');

-- --------------------------------------------------------

--
-- Table structure for table `nhan_vien`
--

DROP TABLE IF EXISTS `nhan_vien`;
CREATE TABLE IF NOT EXISTS `nhan_vien` (
  `id_nhan_vien` int(11) NOT NULL AUTO_INCREMENT,
  `ho_ten` text COLLATE utf8_unicode_ci NOT NULL,
  `dia_chi` text COLLATE utf8_unicode_ci NOT NULL,
  `nam_sinh` int(11) NOT NULL,
  `gioi_tinh` int(11) NOT NULL,
  `quyen` int(11) NOT NULL,
  `dien_thoai` text COLLATE utf8_unicode_ci NOT NULL,
  `email` text COLLATE utf8_unicode_ci NOT NULL,
  `password` text COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id_nhan_vien`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `nhan_vien`
--

INSERT INTO `nhan_vien` (`id_nhan_vien`, `ho_ten`, `dia_chi`, `nam_sinh`, `gioi_tinh`, `quyen`, `dien_thoai`, `email`, `password`) VALUES
(1, 'tiếnn', 'adas', 1998, 1, 0, '0123456789', 'buckblack44@gmail.com', '1');

-- --------------------------------------------------------

--
-- Table structure for table `san_pham`
--

DROP TABLE IF EXISTS `san_pham`;
CREATE TABLE IF NOT EXISTS `san_pham` (
  `id_san_pham` int(11) NOT NULL AUTO_INCREMENT,
  `ten_san_pham` text COLLATE utf8_unicode_ci NOT NULL,
  `gia_ban` double NOT NULL,
  `so_luong` int(11) NOT NULL,
  `noi_dung` text COLLATE utf8_unicode_ci NOT NULL,
  `bao_hanh` int(11) NOT NULL,
  `hinh` text COLLATE utf8_unicode_ci NOT NULL,
  `id_loai` int(11) NOT NULL,
  PRIMARY KEY (`id_san_pham`),
  KEY `id_loai` (`id_loai`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `san_pham`
--

INSERT INTO `san_pham` (`id_san_pham`, `ten_san_pham`, `gia_ban`, `so_luong`, `noi_dung`, `bao_hanh`, `hinh`, `id_loai`) VALUES
(5, 'asd', 56, 0, '56', 5, 'avatar.png', 2);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `san_pham`
--
ALTER TABLE `san_pham`
  ADD CONSTRAINT `san_pham_ibfk_1` FOREIGN KEY (`id_loai`) REFERENCES `loai_san_pham` (`ma_loai`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
