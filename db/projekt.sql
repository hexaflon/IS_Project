-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 29 Cze 2023, 21:42
-- Wersja serwera: 10.4.25-MariaDB
-- Wersja PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;



/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `projekt`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kraj`
--

CREATE TABLE `kraj` (
  `id` int(11) NOT NULL,
  `nazwa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `kraj`
--

INSERT INTO `kraj` (`id`, `nazwa`) VALUES
(1, 'Polska');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `liczba_bezrobotnych`
--

CREATE TABLE `liczba_bezrobotnych` (
  `id` int(11) NOT NULL,
  `zmienna_id` int(11) NOT NULL,
  `kraj_id` int(11) NOT NULL,
  `rok` int(11) NOT NULL,
  `miesiac` int(11) NOT NULL,
  `wartosc` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `liczba_bezrobotnych`
--

INSERT INTO `liczba_bezrobotnych` (`id`, `zmienna_id`, `kraj_id`, `rok`, `miesiac`, `wartosc`) VALUES
(1, 1, 1, 2011, 1, 1966),
(2, 1, 1, 2011, 2, 1982),
(4, 1, 1, 2011, 4, 1984),
(5, 1, 1, 2011, 5, 1972),
(6, 1, 1, 2011, 6, 1960),
(7, 1, 1, 2011, 7, 1954),
(8, 1, 1, 2011, 8, 1952),
(9, 1, 1, 2011, 9, 1955),
(10, 1, 1, 2011, 10, 1960),
(11, 1, 1, 2011, 11, 1964),
(12, 1, 1, 2011, 12, 1972),
(13, 1, 1, 2012, 1, 1986),
(14, 1, 1, 2012, 2, 2001),
(15, 1, 1, 2012, 3, 2008),
(16, 1, 1, 2012, 4, 2014),
(17, 1, 1, 2012, 5, 2024),
(18, 1, 1, 2012, 6, 2036),
(19, 1, 1, 2012, 7, 2044),
(20, 1, 1, 2012, 8, 2056),
(21, 1, 1, 2012, 9, 2070),
(22, 1, 1, 2012, 10, 2085),
(23, 1, 1, 2012, 11, 2104),
(24, 1, 1, 2012, 12, 2129),
(25, 1, 1, 2013, 1, 2160),
(26, 1, 1, 2013, 2, 2178),
(27, 1, 1, 2013, 3, 2190),
(28, 1, 1, 2013, 4, 2198),
(29, 1, 1, 2013, 5, 2188),
(30, 1, 1, 2013, 6, 2179),
(31, 1, 1, 2013, 7, 2175),
(32, 1, 1, 2013, 8, 2170),
(33, 1, 1, 2013, 9, 2166),
(34, 1, 1, 2013, 10, 2162),
(35, 1, 1, 2013, 11, 2159),
(36, 1, 1, 2013, 12, 2149),
(37, 1, 1, 2014, 1, 2134),
(38, 1, 1, 2014, 2, 2106),
(39, 1, 1, 2014, 3, 2067),
(40, 1, 1, 2014, 4, 2029),
(41, 1, 1, 2014, 5, 1999),
(42, 1, 1, 2014, 6, 1977),
(43, 1, 1, 2014, 7, 1956),
(44, 1, 1, 2014, 8, 1930),
(45, 1, 1, 2014, 9, 1899),
(46, 1, 1, 2014, 10, 1865),
(47, 1, 1, 2014, 11, 1840),
(48, 1, 1, 2014, 12, 1818),
(49, 1, 1, 2015, 1, 1801),
(50, 1, 1, 2015, 2, 1781),
(51, 1, 1, 2015, 3, 1757),
(52, 1, 1, 2015, 4, 1737),
(53, 1, 1, 2015, 5, 1712),
(54, 1, 1, 2015, 6, 1682),
(55, 1, 1, 2015, 7, 1654),
(56, 1, 1, 2015, 8, 1631),
(57, 1, 1, 2015, 9, 1608),
(58, 1, 1, 2015, 10, 1588),
(59, 1, 1, 2015, 11, 1569),
(60, 1, 1, 2015, 12, 1555),
(61, 1, 1, 2016, 1, 1542),
(62, 1, 1, 2016, 2, 1529),
(63, 1, 1, 2016, 3, 1509),
(64, 1, 1, 2016, 4, 1486),
(65, 1, 1, 2016, 5, 1466),
(66, 1, 1, 2016, 6, 1445),
(67, 1, 1, 2016, 7, 1422),
(68, 1, 1, 2016, 8, 1403),
(69, 1, 1, 2016, 9, 1385),
(70, 1, 1, 2016, 10, 1368),
(71, 1, 1, 2016, 11, 1349),
(72, 1, 1, 2016, 12, 1328),
(73, 1, 1, 2017, 1, 1303),
(74, 1, 1, 2017, 2, 1275),
(75, 1, 1, 2017, 3, 1246),
(76, 1, 1, 2017, 4, 1224),
(77, 1, 1, 2017, 5, 1211),
(78, 1, 1, 2017, 6, 1199),
(79, 1, 1, 2017, 7, 1191),
(80, 1, 1, 2017, 8, 1183),
(81, 1, 1, 2017, 9, 1168),
(82, 1, 1, 2017, 10, 1122),
(83, 1, 1, 2017, 11, 1099),
(84, 1, 1, 2017, 12, 1076),
(85, 1, 1, 2018, 1, 1051),
(86, 1, 1, 2018, 2, 1033),
(87, 1, 1, 2018, 3, 1024),
(88, 1, 1, 2018, 4, 1017),
(89, 1, 1, 2018, 5, 1012),
(90, 1, 1, 2018, 6, 1009),
(91, 1, 1, 2018, 7, 1005),
(92, 1, 1, 2018, 8, 998),
(93, 1, 1, 2018, 9, 991),
(94, 1, 1, 2018, 10, 984),
(95, 1, 1, 2018, 11, 978),
(96, 1, 1, 2018, 12, 966),
(97, 1, 1, 2019, 1, 950),
(98, 1, 1, 2019, 2, 936),
(99, 1, 1, 2019, 3, 925),
(100, 1, 1, 2019, 4, 916),
(101, 1, 1, 2019, 5, 913),
(102, 1, 1, 2019, 6, 911),
(103, 1, 1, 2019, 7, 906),
(104, 1, 1, 2019, 8, 899),
(105, 1, 1, 2019, 9, 890),
(106, 1, 1, 2019, 10, 883),
(107, 1, 1, 2019, 11, 876),
(108, 1, 1, 2019, 12, 867),
(109, 1, 1, 2020, 1, 856),
(110, 1, 1, 2020, 2, 850),
(111, 1, 1, 2020, 3, 856),
(112, 1, 1, 2020, 4, 944),
(113, 1, 1, 2020, 5, 1016),
(114, 1, 1, 2020, 6, 1056),
(115, 1, 1, 2020, 7, 1060),
(116, 1, 1, 2020, 8, 1058),
(117, 1, 1, 2020, 9, 1058),
(118, 1, 1, 2020, 10, 1057),
(119, 1, 1, 2020, 11, 1052),
(120, 1, 1, 2020, 12, 1048),
(121, 1, 1, 2021, 1, 1032),
(122, 1, 1, 2021, 2, 1035),
(123, 1, 1, 2021, 3, 1031),
(124, 1, 1, 2021, 4, 1032),
(125, 1, 1, 2021, 5, 1029),
(126, 1, 1, 2021, 6, 1020),
(127, 1, 1, 2021, 7, 1004),
(128, 1, 1, 2021, 8, 987),
(129, 1, 1, 2021, 9, 967),
(130, 1, 1, 2021, 10, 947),
(131, 1, 1, 2021, 11, 924),
(132, 1, 1, 2021, 12, 898),
(133, 1, 1, 2022, 1, 874),
(134, 1, 1, 2022, 2, 861),
(135, 1, 1, 2022, 3, 857),
(136, 1, 1, 2022, 4, 857),
(137, 1, 1, 2022, 5, 852),
(138, 1, 1, 2022, 6, 844),
(139, 1, 1, 2022, 7, 838),
(140, 1, 1, 2022, 8, 833),
(141, 1, 1, 2022, 9, 832),
(142, 1, 1, 2022, 10, 830),
(143, 1, 1, 2022, 11, 824),
(144, 1, 1, 2022, 12, 815),
(145, 1, 1, 2023, 1, 807),
(146, 1, 1, 2023, 2, 804),
(147, 1, 1, 2023, 3, 802);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `liczba_mieszkancow`
--

CREATE TABLE `liczba_mieszkancow` (
  `Id` int(11) NOT NULL,
  `Rok` int(11) NOT NULL,
  `Ilosc_kobiet` int(11) NOT NULL,
  `Ilosc_mezczyzn` int(11) NOT NULL,
  `Wszyscy` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `liczba_mieszkancow`
--

INSERT INTO `liczba_mieszkancow` (`Id`, `Rok`, `Ilosc_kobiet`, `Ilosc_mezczyzn`, `Wszyscy`) VALUES
(68895, 2011, 34435, 29933, 64368),
(68896, 2012, 33948, 29451, 63399),
(68897, 2013, 33564, 29191, 62755),
(68898, 2014, 33318, 28901, 62219),
(68899, 2015, 32918, 28581, 61499),
(68900, 2016, 32496, 28245, 60741),
(68901, 2017, 32116, 27950, 60066),
(68902, 2018, 31769, 27524, 59293),
(68903, 2019, 31385, 27075, 58460),
(68904, 2020, 30881, 26628, 57509),
(68905, 2021, 30236, 26077, 56313),
(68906, 2022, 29678, 25571, 55249),
(68907, 2023, 29593, 25455, 55048);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `role`
--

CREATE TABLE `role` (
  `Id` int(11) NOT NULL,
  `Role_` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `role`
--

INSERT INTO `role` (`Id`, `Role_`) VALUES
(1, 'admin'),
(2, 'number'),
(3, 'user');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `typ_danej`
--

CREATE TABLE `typ_danej` (
  `id` int(11) NOT NULL,
  `nazwa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `typ_danej`
--

INSERT INTO `typ_danej` (`id`, `nazwa`) VALUES
(1, 'Bezrobotni zarejestrowani');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `userroles`
--

CREATE TABLE `userroles` (
  `users_id` int(11) DEFAULT NULL,
  `role_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `userroles`
--

INSERT INTO `userroles` (`users_id`, `role_id`) VALUES
(1, 1),
(2, 2),
(2, 3),
(4, 1),
(4, 2),
(3, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` text DEFAULT NULL,
  `Password` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`) VALUES
(1, 'Andrzej', 'Andrzej'),
(2, 'Piotrek', 'Piotrek'),
(3, 'Ania', 'Ania'),
(4, 'test', 'testing');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `kraj`
--
ALTER TABLE `kraj`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `liczba_bezrobotnych`
--
ALTER TABLE `liczba_bezrobotnych`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_kraj_id` (`kraj_id`),
  ADD KEY `fk_zmienna_id` (`zmienna_id`);

--
-- Indeksy dla tabeli `liczba_mieszkancow`
--
ALTER TABLE `liczba_mieszkancow`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Id`);

--
-- Indeksy dla tabeli `typ_danej`
--
ALTER TABLE `typ_danej`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `userroles`
--
ALTER TABLE `userroles`
  ADD KEY `users_id` (`users_id`),
  ADD KEY `role_id` (`role_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `kraj`
--
ALTER TABLE `kraj`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `liczba_bezrobotnych`
--
ALTER TABLE `liczba_bezrobotnych`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=148;

--
-- AUTO_INCREMENT dla tabeli `liczba_mieszkancow`
--
ALTER TABLE `liczba_mieszkancow`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68908;

--
-- AUTO_INCREMENT dla tabeli `role`
--
ALTER TABLE `role`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `typ_danej`
--
ALTER TABLE `typ_danej`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `liczba_bezrobotnych`
--
ALTER TABLE `liczba_bezrobotnych`
  ADD CONSTRAINT `fk_kraj_id` FOREIGN KEY (`kraj_id`) REFERENCES `kraj` (`id`),
  ADD CONSTRAINT `fk_zmienna_id` FOREIGN KEY (`zmienna_id`) REFERENCES `typ_danej` (`id`);

--
-- Ograniczenia dla tabeli `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`users_id`) REFERENCES `users` (`Id`),
  ADD CONSTRAINT `userroles_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `role` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
