-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 07-Out-2024 às 23:57
-- Versão do servidor: 5.7.11
-- PHP Version: 7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gerenciamentotarefas`
--
CREATE DATABASE IF NOT EXISTS `gerenciamentotarefas` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `gerenciamentotarefas`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tarefas`
--

DROP TABLE IF EXISTS `tarefas`;
CREATE TABLE IF NOT EXISTS `tarefas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeTarefa` varchar(90) NOT NULL,
  `descricao` varchar(370) NOT NULL,
  `dataTarefa` varchar(50) NOT NULL,
  `prioridade` varchar(50) NOT NULL,
  `concluido` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tarefas`
--

INSERT INTO `tarefas` (`id`, `nomeTarefa`, `descricao`, `dataTarefa`, `prioridade`, `concluido`) VALUES
(1, '2 Teste', 'Bla bla bla', '07-10-2024', 'Baixa', 'N'),
(2, 'Desafio Rabinson', 'O prefessor Rabinson me desafiou a achar a matrix do DataGridView.', '03-10-2024', 'Alta', 'N'),
(3, 'Terminar Arte', 'Caio quer que eu termine a arte do personagem para colocar no Instagram.', '03-10-2024', 'Media', 'N');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
